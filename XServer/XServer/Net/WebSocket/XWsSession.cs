using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static XServer.Services.ServiceMgr;
using XServer.Services;
using System.Net;

namespace XServer.Net.WebSocket {
    internal class XWsSession : WsSession {
        public XWsSession(WsServer server) : base(server) { }

        public override void OnWsConnected(HttpRequest request) {
            Console.WriteLine($"Chat WebSocket session with Id {Id} connected!");

            // Send invite message
          //  string message = "Hello from WebSocket chat! Please send a message or '!' to disconnect the client!";
          //  SendTextAsync(message);
        }

        public override void OnWsDisconnected() {
            Console.WriteLine($"Chat WebSocket session with Id {Id} disconnected!");
        }

        public override void OnWsReceived(byte[] buffer, long offset, long size) {
            PCMD pCMD = PCMD.Parser.ParseFrom(buffer, (int)offset, (int)size);
            var(reponseType, resposeData) = ServiceMgr.Instance.DistractService(pCMD);

            if (reponseType == ServiceMgr.ResponseType.Response) {
                SendTextAsync(resposeData.ToArray());
                // Server.MulticastText(finalDatas);  //向所有连接发送

            } else if (reponseType == ServiceMgr.ResponseType.Error) {
                Dispose();
            }
        }

        protected override void OnError(SocketError error) {
            Console.WriteLine($"Chat WebSocket session caught an error with code {error}");
        }
    }
}
