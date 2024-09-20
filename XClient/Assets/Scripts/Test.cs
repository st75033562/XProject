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
        Debug.Log("=====11111===" + gameObject.name);

        NetMgr.Instance.NetStateEvent += Connect;
        NetMgr.Instance.Connet("172.18.2.73" , 6066);

       
    }

    private void Connect(TCP.NetState state) {
        if (state == TCP.NetState.Connected) {
            LoginC2S login = new LoginC2S();
            login.ID = 1;
            login.Name = "Test";

            Debug.Log("========222=====" + gameObject.name);
            NetMgr.Instance.Send(NetMsgType.C2Slogin, login.ToByteString());

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

            NetMgr.Instance.Send(NetMsgType.C2Slogin, login.ToByteString());
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        NetMgr.Instance.Close();
    }
}
