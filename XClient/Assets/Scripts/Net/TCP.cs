using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class TCP
{
    private Socket socket;
    private Action<bool> connectAct;

    private const int HeaderLength = 4;
    private const int NormalLength = 1048576; //1024 * 1024

    private object gate = new object();
    private bool isSending;


    private byte[] headBuf = new byte[HeaderLength];
    private byte[] normalBuf = new byte[NormalLength];
    private Queue<byte[]> requests = new Queue<byte[]>();
    private IProtoc protoc;
    public void Init(IProtoc protoc) { 
        this.protoc = protoc;
    }

    #region 连接
    public void Connnet(string url, int port, Action<bool> act) {
        connectAct = act;
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPAddress servAD = null;
        try {
            if (url.Contains(".com") || url.Contains(".net") || url.Contains(".cn")) {
                Dns.BeginGetHostAddresses(url, result => {
                    var IPs = Dns.EndGetHostAddresses(result);
                    servAD = IPs[0]; //一个域名可以对应多个ip这里选第一个
                }, null);
            } else {
                servAD = IPAddress.Parse(url); //"192.168.1.1"
            }
        } catch (Exception e) {
            Debug.LogError("can not parse url:" + e.ToString());
        }
        var iPEndPoint = new IPEndPoint(servAD, port);
        try {
            socket.BeginConnect(iPEndPoint, ConnectCallback, null);
        } catch (Exception e) {
            Debug.LogError("can not Connect:" + e.ToString());
        }
    }

    private void ConnectCallback(IAsyncResult ar) {
        try {
            socket.EndConnect(ar); //or socket from [(Socket)ar.AsyncState]
            connectAct?.Invoke(true);
            Receive(true, 0, HeaderLength, headBuf);
        } catch (Exception e) {
            connectAct?.Invoke(false);
            Debug.LogError("Connect Callback fail :" + e.ToString());
        }
    }
    #endregion


    public void Send(byte[] data) {
        lock (gate) {
            if (!isSending) {
                isSending = true;
                DoSend(data, 0);
            } else {
                requests.Enqueue(data);
            }
        }
    }

    private void DoSend(byte[] buf, int offset) {
        try {
            socket.BeginSend(buf, offset, buf.Length - offset, SocketFlags.None, asyncResult => {
                int sentBytes = 0;
                try {
                    sentBytes = socket.EndSend(asyncResult);
                } catch (Exception ex) {
                    Debug.LogError("socket send end error" + ex.ToString());
                    Close();
                    return;
                }
                if (sentBytes < buf.Length - offset) {
                    DoSend(buf, offset + sentBytes);
                } else {
                    byte[] pendingBuf = null;
                    lock (gate) {
                        if (requests.Count > 0) {
                            pendingBuf = requests.Dequeue();
                        } else {
                            isSending = false;
                        }
                    }
                    if (pendingBuf != null) {
                        DoSend(pendingBuf, 0);
                    }
                }

            }, null);
        } catch (Exception ex) {
            Debug.LogError("socket send error" + ex.ToString());
            Close();
        }
    }

    private void Receive(bool isHead, int offset, int size, byte[] buf) {
        
        try {
            socket.BeginReceive(buf, offset, size, SocketFlags.None, asyncResult => {
                int length;
                try {
                    length = socket.EndReceive(asyncResult); //return real read length 
                } catch (Exception ex) {
                    Debug.LogError("socket recive end fail：" + ex.ToString());
                    Close();
                    return;
                }
                if (length == 0) {
                    Close();
                    return;
                }
                if (length < size) {
                    Receive(isHead, offset + length, size - length, buf);
                    return;
                }

                if (isHead) {
                    //得到的网络字节序长度转换成主机字节序的长度，服务端返回的长度包含头的长度，所以减去头的大小
                    size = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buf, 0));
                    if (size <= NormalLength) {
                        buf = normalBuf;
                    } else {
                        buf = new byte[size];
                    }
                    Receive(!isHead, 0, size, buf);
                } else {
                    protoc.DealWith(buf, 0, size);
                    //AddResponse(buf);
                    Receive(!isHead, 0, HeaderLength, headBuf);
                }
                
            }, null);
        } catch (Exception ex) {
            Debug.LogError("socket recive fail：" + ex.ToString());
            Close();
        }
    }

    public void Close() {
        try {
            socket.Shutdown(SocketShutdown.Both);
        } catch (Exception ex) {
            Debug.LogError("socket Shutdown fail" + ex.ToString());
        }
        try {
            socket.Close();
        } catch (Exception ex) {
            Debug.LogError("socket Close fail" + ex.ToString());
        }
        socket = null;
    }
}
