using UnityEngine;

public class Main : MonoBehaviour
{
    private NetMgr netMgr = NetMgr.Instance;
    private NetMsgMgr netMsgMgr = NetMsgMgr.Instance;
    void Start()
    {
        netMgr.Start();
    }

    void Update()
    {
        netMgr.Update();
    }

    private void OnDestroy() {
        netMsgMgr.Destroy();
    }
}
