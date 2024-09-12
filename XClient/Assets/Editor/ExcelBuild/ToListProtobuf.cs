using Google.Protobuf.Collections;
using Google.Protobuf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ToListProtobuf : BaseProtobuf {
    public override void SaveDataFile(string saveFilePath, string fileName, List<string[]> datas) {
        Assembly assembly = Assembly.Load(ToProtobuf.AssemblyName);  //�ű����ڳ���

        Type Tclass = assembly.GetType($"{fileName}");
        object TObj = Activator.CreateInstance(Tclass);
        FieldInfo datas_ = Tclass.GetField("datas_", BindingFlags.NonPublic | BindingFlags.Instance);
        var tDataProperty = TObj.GetType().GetProperty("Datas");
        //propertyInfo.PropertyType.GenericTypeArguments�õ�����ķ���ֵ
        var newList = Activator.CreateInstance(typeof(RepeatedField<>).MakeGenericType(tDataProperty.PropertyType.GenericTypeArguments));
        var addMethod = newList.GetType().GetMethod("Add", tDataProperty.PropertyType.GenericTypeArguments);
        datas_.SetValue(TObj, newList);

        Type TDataType = assembly.GetType($"{fileName}Data");
        var titleData = datas[1];
        var typeData = datas[2];
        for (int i = 3; i < datas.Count; i++) { //��ʵ�����п�ʼ����
            var data = datas[i];
            object TDataObj = Activator.CreateInstance(TDataType);
            for (int j = 0; j < titleData.Length; j++) { //��ȡname�� 
                PropertyInfo property = TDataType.GetProperty($"{titleData[j]}");
                if (typeData[j] == "int32") {
                    property.SetValue(TDataObj, int.Parse(data[j]));
                } else {
                    property.SetValue(TDataObj, data[j]);
                }
            }
            addMethod.Invoke(newList, new object[] { TDataObj });
        }
        SaveDataFile(saveFilePath, fileName, MessageExtensions.ToByteArray(TObj as IMessage));
    }
}
