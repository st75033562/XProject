using System;
using XServer.Net.TCP;
using System.Net;
using XServer.Net.WebSocket;

namespace XServer.Net {
    internal class ServerMgr {
        public enum NetType { 
            TCP,
            WEBSOCKET
        }

        public ServerMgr(NetType netType, IPAddress ipAddress, int port) {
            switch (netType) { 
                case NetType.TCP:
                    var server = new XTcpServer(ipAddress, port);
                    server.Start();
                    break;
                case NetType.WEBSOCKET:
                    var wsWerver = new XWsServer(ipAddress, port);
                    wsWerver.Start();
                    break;
            
            }
        
        }
    }
}
