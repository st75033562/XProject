// See https://aka.ms/new-console-template for more information
using DotNetty.Transport.Bootstrapping;
using DotNetty.Transport.Channels;
using DotNetty.Transport.Channels.Sockets;
using DotNetty.Codecs;
using DotNetty.Handlers.Logging;
using DotNetty.Common;
using XServer.ChannelHandler;

Console.WriteLine("Hello, World!");

IEventLoopGroup bossGroup;//主要工作组
IEventLoopGroup workerGroup;//子工作组，推荐设置为内核数*2的线程数

bossGroup = new MultithreadEventLoopGroup(1);//主线程只会实例化一个 负责接收客户端连接
workerGroup = new MultithreadEventLoopGroup(16);//子线程组可以按照自己的需求在构造函数里指定数量 处理已经建立连接的I/O操作

ServerBootstrap bootstrap = new ServerBootstrap();
bootstrap.Group(bossGroup, workerGroup);  //主从模型多线程

bootstrap.Channel<TcpServerSocketChannel>();//非阻塞式tcp通道

bootstrap
.Option(ChannelOption.SoBacklog, 100)  //当处理Accept的速率小于连接建立的速率时，全连接队列中堆积的连接数大于SO_BACKLOG设置的值是，便会抛出异常
.Option(ChannelOption.SoReuseport, true)//设置端口复用
.ChildOption(ChannelOption.SoKeepalive, true)
//.Handler(new LoggingHandler("SRV-LSTN"))//初始化日志拦截器
.ChildHandler(new ActionChannelInitializer<IChannel>(channel =>//处理连接(Accepter)之后逻辑
{
    /*
    * 这里主要是配置channel中需要被设置哪些参数，以及channel具体的实现方法内容。
    * channel可以理解为，socket通讯当中客户端和服务端的连接会话，会话内容的处理在channel中实现。
    */

    IChannelPipeline pipeline = channel.Pipeline;
    //if (tlsCertificate != null) {
    //    pipeline.AddLast("tls", TlsHandler.Server(tlsCertificate));//添加ssl加密
    //}

    pipeline.AddLast(new LoggingHandler("SRV-CONN"));  //增加log
    pipeline.AddLast("framing-enc", new LengthFieldPrepender(4)); //表示用 4 字节来表示消息长度
    pipeline.AddLast("framing-dec", new LengthFieldBasedFrameDecoder(1024 * 1024 * 3, 0, 4, 0, 4)); //最大帧长度 长度字段的偏移量 长度字段的长度 从长度字段到实际数据的额外偏移量 从数据中剥离的字节数（即长度字段本身）

    //    pipeline.AddLast(new LoggingHandler("SRV-CONN"));
    //  pipeline.AddLast("framing-enc", new LengthFieldPrepender(2));//Dotnetty自带的编码器，将要发送的内容进行编码然后发送
    //   pipeline.AddLast("framing-dec", new LengthFieldBasedFrameDecoder(ushort.MaxValue, 0, 2, 0, 2));//Dotnetty自带的解码器，将接受到的内容进行解码然后根据内容对应到业务逻辑当中

    pipeline.AddLast("echo", new EchoServerHandler());//server的channel的处理类实现
}));

IChannel boundChannel = await bootstrap.BindAsync(6066);//指定服务端的端口号，ip地址donetty可以自动获取到本机的地址。也可以在这里手动指定。

Console.ReadLine();
