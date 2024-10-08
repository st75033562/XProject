using Google.Protobuf;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //  TcpMgr.Instance.NetStateEvent += Connect;
        //   TcpMgr.Instance.Connet("172.18.2.73" , 6669);

        WebSocketMgr.Instance.NetStateEvent += Connect;
        WebSocketMgr.Instance.Connect("172.18.2.73", 6668);
       
    }

    private void Connect(WebSocket.NetState state) {
        if (state == WebSocket.NetState.Connected) {
            LoginC2S login = new LoginC2S();
            login.ID = 1;
            login.Name = "Test";

            WebSocketMgr.Instance.Send(NetMsgType.C2Slogin, login.ToByteString());

           // StartCoroutine(FF());
        }
    }

    int index = 0;
    IEnumerator FF() {
        while (true) {
           // Debug.Log("============="+ (index++ * 12));
            yield return new WaitForSeconds(0.2f);
            LoginC2S login = new LoginC2S();
            login.ID = 1;
            login.Name = "Test"+ index++;

            TcpMgr.Instance.Send(NetMsgType.C2Slogin, login.ToByteString());
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        TcpMgr.Instance.Close();
    }
}
