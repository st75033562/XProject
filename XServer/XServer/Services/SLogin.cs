using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XServer.Services {
    internal class SLogin : Singleton<SLogin>, IServer {

        public ByteString ProcessClientData(ByteString byteValue) {
            LoginC2S login = LoginC2S.Parser.ParseFrom(byteValue);
            Console.WriteLine("channel code: " + login.Name);

            LoginS2C loginS2C = new LoginS2C();
            loginS2C.Error = 3;
            return ServiceMsgPack.PackMessage(NetMsgType.S2Clogin, loginS2C.ToByteString()); 
        }
    }
}
