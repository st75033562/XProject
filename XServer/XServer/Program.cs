using XServer.Net;
using System.Net;

new ServerMgr(ServerMgr.NetType.TCP,IPAddress.Any, 6668);


//new NettyMgr();

Console.WriteLine("启动完成！");

Console.ReadLine();
