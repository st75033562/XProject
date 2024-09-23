using Google.Protobuf;
using System.Collections.Generic;
using System.Diagnostics;

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
                UnityEngine.Debug.Log("loginMsg:" + loginMsg.loginS2c.Error);
                return loginMsg;
            default:
                XLog.LogError("协议解析不存在!:" + netMsgType);
                return null;
        }
    }
    #endregion
}
