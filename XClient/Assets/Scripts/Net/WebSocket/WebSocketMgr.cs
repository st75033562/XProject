using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net.WebSockets;
using Google.Protobuf;
using System.Linq;
using System.Net;

public class WebSocketMgr : Singleton<WebSocketMgr>
{
    private IProtoc<PCMD> protoc;
    private WebSocket webSocket;

    public event Action<WebSocket.NetState> NetStateEvent;
    private WebSocket.NetState preNetState;
    public WebSocket.NetState NetStateVar { get; private set; }
    public void Start()
    {
        protoc = new ProtoBufProtoc<PCMD>();
        webSocket = new WebSocket(protoc);
    }

    public void Connect(string ip, int port)
    {
        webSocket.Connect(ip, port);
    }

    public void Send(NetMsgType netMsgType, ByteString byteStrs) {
        PCMD pCMD = new PCMD();
        pCMD.MsgType = netMsgType;
        pCMD.Msg = byteStrs;
        var datas = pCMD.ToByteArray();

        webSocket.Send(datas);
    }

    public void Update() {
        webSocket.Update();
        var netState = webSocket.NetStateVar;
        if (preNetState != netState) {
            preNetState = netState;
            NetStateEvent?.Invoke(netState);
        }
    }
}
