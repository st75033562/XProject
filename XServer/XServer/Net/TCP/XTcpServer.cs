using NetCoreServer;
using System.Net.Sockets;
using System.Net;


namespace XServer.Net.TCP
{
    internal class XTcpServer : TcpServer
    {
        public XTcpServer(IPAddress address, int port) : base(address, port) { }

        protected override XTcpSession CreateSession() { return new XTcpSession(this); }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat TCP server caught an error with code {error}");
        }
    }
}
