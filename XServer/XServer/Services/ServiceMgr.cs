using Google.Protobuf;

namespace XServer.Services {
    internal class ServiceMgr {
        public enum ResponseType { 
            None, 
            Response, 
            Error
        }

        private ServiceMgr() {}
        private static readonly ServiceMgr instance = new ServiceMgr();
        public static ServiceMgr Instance => instance;


        public (ResponseType, ByteString) DistractService(PCMD pCMD) {
            try {
                IServer server = null;
                switch (pCMD.MsgType) {
                    case NetMsgType.C2Slogin:
                        server = new SLogin();
                        break;
                }
                if (server != null) {
                    var result = server.ProcessClientData(pCMD.Msg);
                    if (result == ByteString.Empty) {
                        return (ResponseType.None, ByteString.Empty);
                    } else {
                        return (ResponseType.Response, result);
                    }
                } else {
                    return (ResponseType.None, ByteString.Empty);

                }
            }catch (System.Exception e) {
                Console.WriteLine(e.Message);
                return (ResponseType.Error, ByteString.Empty);
            }
        }


        
    }
}
