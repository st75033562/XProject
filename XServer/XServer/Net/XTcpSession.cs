using NetCoreServer;
using System;
using System.Buffers;
using System.Net;
using System.Net.Sockets;
using static System.Runtime.InteropServices.JavaScript.JSType;
using XServer.Services;

namespace XServer.Net {
    internal class XTcpSession : TcpSession {
        private const int HEAD_SIZE = 4;
        private bool isHead = true;
        private byte[] headBuf = new byte[HEAD_SIZE];
        private byte[] cacheBuf = new byte[1]; //
        private int msgLength = 0;

        private List<byte> tempBuffer = new List<byte>();

        public XTcpSession(TcpServer server) : base(server) { }

        protected override void OnConnected() {
            Console.WriteLine($"Chat TCP session with Id {Id} connected!");

            // Send invite message
          //  string message = "Hello from TCP chat! Please send a message or '!' to disconnect the client!";
          //  SendAsync(message);
        }

        protected override void OnDisconnected() {
            base.OnDisconnected();
            Console.WriteLine($"Chat TCP session with Id {Id} disconnected!");
        }

        protected override void OnReceived(byte[] buffer, long offset, long size) {
            tempBuffer.AddRange(buffer.Skip((int)offset).Take((int)size));
            while (true) {
                if (isHead) {
                    if (tempBuffer.Count >= HEAD_SIZE) {
                        var headBuf = ToHeadBuf(tempBuffer);
                        msgLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(headBuf));
                        tempBuffer.RemoveRange(0, HEAD_SIZE);
                        isHead = false;
                        if (tempBuffer.Count < msgLength) {
                            break;
                        }
                    }
                } else {
                    if (tempBuffer.Count >= msgLength) {
                        var headBuf = ToHeadBuf(tempBuffer);
                        // 读取消息内容
                        byte[] message = ToMsgBuf(tempBuffer, msgLength);
                        ProcessMessage(message, msgLength);
                        tempBuffer.RemoveRange(0, msgLength);
                        isHead = true;
                        if (tempBuffer.Count < HEAD_SIZE) {
                            break;
                        }
                    }
                }
            }
        }

        protected override void OnError(SocketError error) {
            Console.WriteLine($"Chat TCP session caught an error with code {error}");
        }

        byte[] ToHeadBuf(List<byte> list) {
            for(int i=0; i<HEAD_SIZE; i++){
                headBuf[i] = list[i];
            }
            return headBuf;
        }

        byte[] ToMsgBuf(List<byte> list, int msgLength) {
            if (msgLength <= cacheBuf.Length) {
                for (int i=0; i< msgLength; i++) {
                    cacheBuf[i] = list[i];
                }
                return cacheBuf;
            }
            return list.ToArray();
        }

        void ProcessMessage(byte[] message, int size) {
            PCMD pCMD = PCMD.Parser.ParseFrom(message, 0 , size);
            var (reponseType, resposeData) = ServiceMgr.Instance.DistractService(pCMD);

            if (reponseType == ServiceMgr.ResponseType.Response) {
                int networkInt = IPAddress.HostToNetworkOrder(resposeData.Length); // 转换为网络字节序
                byte[] hostOrderArray = BitConverter.GetBytes(networkInt); // 转换为字节数组

                byte[] finalDatas = hostOrderArray.Concat(resposeData).ToArray();

                SendAsync(finalDatas);

               // Server.Multicast(finalDatas);  //向所有连接发送

            } else if (reponseType == ServiceMgr.ResponseType.Error) {
                Dispose();
            }
        }

    }
}
