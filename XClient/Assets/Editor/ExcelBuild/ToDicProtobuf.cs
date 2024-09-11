using Google.Protobuf.Collections;
using Google.Protobuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.IO;

public class ToDicProtobuf : BaseProtobuf {
    private bool keyIsInt;
    public ToDicProtobuf(bool keyIsInt) {
        this.keyIsInt = keyIsInt;
    }
    protected override bool SkipCol(int index) {
        return index == 0; //字典中第一列作为key，跳过写入数据对象中
    }

    protected override string CollectProStr(string className) {
        if(keyIsInt)
            return $"    map<int32, {className}>     datas =   1;";
        else
            return $"    map<string, {className}>     datas =   1;";
    }

    public override void SaveDataFile(string saveFilePath, string fileName, List<string[]> datas) {
        Assembly assembly = Assembly.Load("Common");  //脚本所在程序集

        Type Tclass = assembly.GetType($"{fileName}");
        object TObj = Activator.CreateInstance(Tclass);
        FieldInfo datas_ = Tclass.GetField("datas_", BindingFlags.NonPublic | BindingFlags.Instance);
        var tDataProperty = TObj.GetType().GetProperty("Datas");
        //propertyInfo.PropertyType.GenericTypeArguments得到具体的泛型值
        var newDic = Activator.CreateInstance(typeof(MapField<,>).MakeGenericType(tDataProperty.PropertyType.GenericTypeArguments));
        var addMethod = newDic.GetType().GetMethod("Add", tDataProperty.PropertyType.GenericTypeArguments);
        datas_.SetValue(TObj, newDic);

        Type TDataType = assembly.GetType($"{fileName}Data");
        var titleData = datas[1];
        var typeData = datas[2];
        for (int i = 3; i < datas.Count; i++) { //真实数据行开始遍历
            var data = datas[i];
            object TDataObj = Activator.CreateInstance(TDataType);
            for (int j = 1; j < titleData.Length; j++) { //获取name行 
                PropertyInfo property = TDataType.GetProperty($"{titleData[j]}");
                if (typeData[j] == "int32") {
                    property.SetValue(TDataObj, int.Parse(data[j]));
                } else {
                    property.SetValue(TDataObj, data[j]);
                }
            }

            if(keyIsInt)
                addMethod.Invoke(newDic,new object[] { int.Parse(data[0]), TDataObj });
            else
                addMethod.Invoke(newDic, new object[] { data[0], TDataObj });
        }

        SaveDataFile(saveFilePath, fileName, MessageExtensions.ToByteArray(TObj as IMessage));
    }
}
