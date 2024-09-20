using Google.Protobuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using UnityEngine;

public class NetMgr : Singleton<NetMgr>
{
    private IProtoc<PCMD> protoc;
    private TCP tcp;
    private NetMsgMgr netMsgMgr;
    private TCP.NetState preNetState;

    public event Action<TCP.NetState> NetStateEvent;

    public void Start()
    {
        protoc = new ProtoBufProtoc<PCMD>();
        tcp = new TCP(protoc);
        netMsgMgr = NetMsgMgr.Instance;
    }

    public void Connet(string url, int port) {
        tcp.Connnet(url, port);
    }

    public void Send(NetMsgType netMsgType, ByteString byteStrs) { 
        PCMD pCMD = new PCMD();
        pCMD.MsgType = netMsgType;
        pCMD.Msg = byteStrs;
        var datas = pCMD.ToByteArray();

        int networkInt = IPAddress.HostToNetworkOrder(datas.Length); // 转换为网络字节序
        byte[] byteArray = BitConverter.GetBytes(networkInt); // 转换为字节数组

        byte[] finalDatas = byteArray.Concat(datas).ToArray();

        tcp.Send(finalDatas);
    }

    public void Update()
    {
        var pcmd = protoc.DequeueData();
        if (pcmd != null) {
            netMsgMgr.AddMsg(pcmd.MsgType, pcmd.Msg);
        }
        NetState();
    }

    void NetState() {
        var netState = tcp.NetStateVar;
        if (preNetState != netState) {
            preNetState = netState;
            NetStateEvent?.Invoke(netState);
        }
    }

    public void Close() {
        if (tcp != null) {
            tcp.Close();
        }
    }
}
