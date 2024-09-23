using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XServer.Services {
    internal class ServiceMsgPack {
        public static ByteString PackMessage(NetMsgType netMsgType, ByteString byteValue) {
            PCMD pCMD = new PCMD();
            pCMD.MsgType = netMsgType;
            pCMD.Msg = byteValue;
            return pCMD.ToByteString();
        }
    }
}
