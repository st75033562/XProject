using Google.Protobuf.Collections;
using Google.Protobuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;

public class BaseProtobuf {
    //Ìø¹ýµÄÁÐ
    protected virtual bool SkipCol(int index) {
        return false;
    }

    protected virtual string CollectProStr(string className) {
        return $"    repeated    {className}  datas =   1;";
    }

    public void SaveProto(string savePath, string fileName, string[] names, string[] types) {
        var className = fileName + "Data";

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("syntax = \"proto3\";");
        sb.AppendLine($"message {className}");
        sb.AppendLine("{");
        int index = 0;
        for (int i = 0; i < names.Length; i++) {
            if (SkipCol(i)) {
                continue;
            }
            index++;
            sb.AppendLine($"    {types[i]}  {names[i]}  =   {index};");
        }
        sb.AppendLine("}");

        sb.AppendLine($"message {fileName}");
        sb.AppendLine("{");

        sb.AppendLine(CollectProStr(className));
        sb.AppendLine("}");

        File.WriteAllText(savePath + "/" + fileName, sb.ToString());
    }

    public virtual void SaveDataFile(string saveFilePath, string fileName, List<string[]> datas) {}

    protected void SaveDataFile(string saveFilePath, string fileName, byte[] datas) {
        string savePath = saveFilePath + fileName + ".pro";
        File.WriteAllBytes(savePath, datas);
    }
}
