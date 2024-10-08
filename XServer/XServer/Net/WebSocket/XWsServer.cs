using NetCoreServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace XServer.Net.WebSocket {
    internal class XWsServer : WsServer {
        public XWsServer(IPAddress address, int port) : base(address, port) { }

        protected override TcpSession CreateSession() { return new XWsSession(this); }

        protected override void OnError(SocketError error) {
            Console.WriteLine($"Chat WebSocket server caught an error with code {error}");
        }
    }
}
