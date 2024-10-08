using UnityEngine;

public class Main : MonoBehaviour
{
    private TcpMgr netMgr = TcpMgr.Instance;
    private WebSocketMgr wsSocket = WebSocketMgr.Instance;
    private NetMsgMgr netMsgMgr = NetMsgMgr.Instance;
    void Start()
    {
        GameDefine.Instance.Init(this);
        netMgr.Start();
        wsSocket.Start();
    }

    void Update()
    {
        netMgr.Update();
        wsSocket.Update();
    }

    private void OnDestroy() {
        netMsgMgr.Destroy();
    }
}
