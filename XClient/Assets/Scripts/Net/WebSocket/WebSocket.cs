using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class WebSocket {
    public enum NetState {
        None,
        Connecting,
        Connected,
        ConnectFail,
        Close
    }

    private Task connectTask;
    private Task sendTask;
    private Task<WebSocketReceiveResult> recTask;
    private ClientWebSocket webSocket = new ClientWebSocket();

    private bool isSending;
    private Queue<byte[]> requests = new Queue<byte[]>();

    private byte[] recArray = new byte[1024 * 1024];
    private IProtoc<PCMD> protoc;

    public NetState NetStateVar { get; private set; }

    public WebSocket(IProtoc<PCMD> protoc) {
        this.protoc = protoc;
    }

    public void Connect(string ip, int port)
    {
        string url = $"ws://{ip}:{port}";
        bool createUri = Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out Uri uri);

        if (createUri) {
            connectTask = webSocket.ConnectAsync(uri, CancellationToken.None);
            NetStateVar = NetState.Connecting;
        } else {
            NetStateVar = NetState.ConnectFail;
        }
    }

    public void Update() {
        if (NetStateVar == NetState.Connecting) {
            if (connectTask.IsCompleted) {
                if (webSocket.State == WebSocketState.Open) {
                    NetStateVar = NetState.Connected;
                    Receive();
                } else {
                    NetStateVar = NetState.ConnectFail;
                }
            }
        } else if (NetStateVar == NetState.Connected) {
            if (isSending) {
                if (sendTask.IsCompleted) {  //������һ�����
                    if (requests.Count > 0) {
                        byte[] data = requests.Dequeue();
                        DoSend(data);
                    } else {
                        isSending = false;
                    }
                }
            }
            if (recTask != null) {
                if (recTask.IsCompleted) {
                    if (webSocket.State == WebSocketState.CloseReceived || recTask.Result.MessageType == WebSocketMessageType.Close) {
                        CloseClientWebSocket();
                    } else {
                        Debug.Log("������Ϣ");
                        protoc.DealWith(recArray, 0, recTask.Result.Count);
                        Receive();
                    }
                }
            }
        }

    }

    public void Send(byte[] data) {
        if (isSending) {
            requests.Enqueue(data);
        } else {
            isSending = true;
            DoSend(data);
        }
    }

    private void DoSend(byte[] content) {
        try {
            sendTask = webSocket.SendAsync(content, WebSocketMessageType.Binary, true, CancellationToken.None);  //����
        } catch (WebSocketException ex) {
            Debug.LogError("�������������Ϣ����" + ex.Message);
            CloseClientWebSocket();
        }
    }

    private void Receive() {
        try {
            if (webSocket.State == WebSocketState.Open || webSocket.State == WebSocketState.CloseSent) {
                recTask = webSocket.ReceiveAsync(recArray, CancellationToken.None);
            }
        } catch (WebSocketException ex) {
            Debug.LogError("���շ�������Ϣ����" + ex.Message);
            CloseClientWebSocket();
        }
    }


    public void CloseClientWebSocket() {
        try {
            var task = webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            task.Wait();
            NetStateVar = NetState.Close;
        } catch (WebSocketException ex) {
            Debug.LogError("�ر�websocket�쳣��" + ex.Message);
        }
    }

}
