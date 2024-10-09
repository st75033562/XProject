using XServer.Net;
using System.Net;
using XServer.Utils;

// 1、配置
var config = Config.Instance;
config.Init();

//启动服务
new ServerMgr(ServerMgr.NetType.TCP, IPAddress.Any, config.GetInt("Port"));

Console.WriteLine("启动完成！");

Console.ReadLine();
