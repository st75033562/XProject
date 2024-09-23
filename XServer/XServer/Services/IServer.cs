using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XServer.Services {
    internal interface IServer {
        ByteString ProcessClientData(ByteString byteValue);

        
    }
}
