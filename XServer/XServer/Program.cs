using XServer.Net;
using System.Net;
using XServer.Utils;
using log4net.Config;
using log4net;
using System.Reflection;


//1、log
var log4netRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(log4netRepository, new FileInfo("log4net.config"));

// 2、配置
var config = Config.Instance;
config.Init();




//启动服务
new ServerMgr(ServerMgr.NetType.TCP, IPAddress.Any, config.GetInt("Port"));
Console.WriteLine("启动完成！");

Console.ReadLine();
