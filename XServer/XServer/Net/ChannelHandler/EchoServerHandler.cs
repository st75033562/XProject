using DotNetty.Buffers;
using DotNetty.Common.Utilities;
using DotNetty.Transport.Channels;
using Google.Protobuf;
using System.Buffers;
using System.Net;
using XServer.Services;

namespace XServer.Net.ChannelHandler
{
    public class EchoServerHandler : ChannelHandlerAdapter
    {
        private static readonly ArrayPool<byte> arrayPool = ArrayPool<byte>.Create(maxArrayLength: 1024 * 1024 * 16, maxArraysPerBucket: 50);


        //public override void ChannelActive(IChannelHandlerContext context) {
        //    // 设置属性
        //    context.GetAttribute(MyAttributeKey).Set("MyAttributeValue");
        //    base.ChannelActive(context);
        //}

        public override void ChannelRead(IChannelHandlerContext context, object message)
        {
            if (message is IByteBuffer buffer) {
                int length = buffer.ReadableBytes;
                byte[] data = arrayPool.Rent(length);
                try {
                    buffer.ReadBytes(data, 0, length);

                    PCMD pCMD = PCMD.Parser.ParseFrom(data, 0, length);
                    var (reponseType, resposeData) = ServiceMgr.Instance.DistractService(pCMD);

                    if (reponseType == ServiceMgr.ResponseType.Response) {
                        int networkInt = IPAddress.HostToNetworkOrder(resposeData.Length); // 转换为网络字节序
                        byte[] hostOrderArray = BitConverter.GetBytes(networkInt); // 转换为字节数组

                        byte[] finalDatas = hostOrderArray.Concat(resposeData).ToArray();

                        context.WriteAndFlushAsync(Unpooled.CopiedBuffer(resposeData.ToArray()));

                    } else if (reponseType == ServiceMgr.ResponseType.Error) {
                        context.CloseAsync();
                    }

                } finally {
                    arrayPool.Return(data, clearArray: true); // 可选：清除数组内容
                }
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
