using System.Buffers;
using System.Net;
using XServer.Net;

var server = new XTcpServer(IPAddress.Any, 6669);
server.Start();
//new NettyMgr();

Console.WriteLine("启动完成！");

Console.ReadLine();
