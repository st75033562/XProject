using Google.Protobuf;
using System.Collections.Generic;

public class NetMsgMgr : Singleton<NetMsgMgr>{
    private Dictionary<NetMsgType, IMsg> allMsgs = new Dictionary<NetMsgType, IMsg>();

    public void AddMsg(NetMsgType netMsgType, ByteString byteStrs) {
        var msg = ParseMsg(netMsgType, byteStrs);
        allMsgs[netMsgType] = msg;
    }

    public void Destroy() {
        allMsgs.Clear();
    }

    #region 协议反序列化
    IMsg ParseMsg(NetMsgType netMsgType, ByteString byteStrs) {
        switch (netMsgType) {
            case NetMsgType.S2Clogin:
                LoginMsg loginMsg = new LoginMsg();
                loginMsg.loginS2c = LoginS2C.Parser.ParseFrom(byteStrs);
                return loginMsg;
            default:
                XLog.LogError("协议解析不存在!:" + netMsgType);
                return null;
        }
    }
    #endregion
}
