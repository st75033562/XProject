using DotNetty.Buffers;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using Google.Protobuf;
using System.Net;

namespace XServer.Net.ChannelHandler
{
    public class EchoServerHandler : ChannelHandlerAdapter
    {

        //public override void ChannelActive(IChannelHandlerContext context) {
        //    // 设置属性
        //    context.GetAttribute(MyAttributeKey).Set("MyAttributeValue");
        //    base.ChannelActive(context);
        //}

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            var buffer = message as IByteBuffer;
            if (buffer != null)
            {


                byte[] data = new byte[buffer.ReadableBytes];
                buffer.ReadBytes(data);

                PCMD pCMD = PCMD.Parser.ParseFrom(data);
                LoginC2S login = LoginC2S.Parser.ParseFrom(pCMD.Msg);
                Console.WriteLine("channel code: " + login.Name);

            }
            //LoginS2C login1 = new LoginS2C();
            //login1.Error = 123;
            //PCMD pCMD1 = new PCMD();
            //pCMD1.MsgType = NetMsgType.S2Clogin;
            //pCMD1.Msg = login1.ToByteString();
            //var datas = pCMD1.ToByteString();

            //int networkInt = IPAddress.HostToNetworkOrder(datas.Length); // 转换为网络字节序
            //byte[] byteArray = BitConverter.GetBytes(networkInt); // 转换为字节数组

            //byte[] finalDatas = byteArray.Concat(datas).ToArray();

            //Console.WriteLine("IsWritable" + context.Channel.IsWritable);
            //context.Channel.WriteAndFlushAsync(Unpooled.CopiedBuffer(finalDatas));

            //context.Channel.Flush();
        }

        public override void ChannelReadComplete(IChannelHandlerContext context) => context.Flush();

        public override void ExceptionCaught(IChannelHandlerContext context, Exception exception)
        {
            Console.WriteLine("Exception: " + exception);
            context.CloseAsync();
        }
    }
}
