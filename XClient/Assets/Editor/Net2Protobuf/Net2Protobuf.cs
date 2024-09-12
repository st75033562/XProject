using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class Net2Protobuf : Editor {

    #region 配置
    private static string ProtoCPath {  //protoc.exe 路径
        get {
            return ToProtobuf.ProtoCPath;
        }
    }

    private static string Proto2ProtocRP { //excel转proto文件相对proroc.exe相对路径
        get {
            return "Net/";
        }
    }

    private static string NetProtoMesPath {  //protobuf message 转成对应c#类路径
        get {
            return Application.dataPath + "/Scripts/Net/Protoc/Message/";
        }
    }
    #endregion


    [MenuItem("Tools/Net2Protobuf")]
    public static void BuildNet2Protobuf() {
        List<string> cmds = new List<string>();
        cmds.Add($"cd /d {ProtoCPath}");

        DirectoryInfo root = new DirectoryInfo(ProtoCPath + Proto2ProtocRP);
        foreach (FileInfo f in root.GetFiles())
        {
            cmds.Add($"protoc {Proto2ProtocRP + f.Name} --csharp_out={NetProtoMesPath}");
        }
        new CMD(cmds);
    }
}
