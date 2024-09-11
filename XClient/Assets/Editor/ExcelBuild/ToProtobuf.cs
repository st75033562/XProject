using Google.Protobuf;
using Google.Protobuf.Collections;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEditor;
using UnityEngine;
using static Google.Protobuf.WellKnownTypes.Field;

public class ToProtobuf : Editor {
    #region 配置
    public const string AssemblyName = "Common";
    private static string saveFilePath = Application.dataPath + "/S/";
    private const string SheetFilter = "@";
    private const string NewExcelTag = "N";
    #endregion

    class SheetDatas {
        public string SheetName;//工作簿名字
        public List<string[]> SheetRowDatas;
    }

    private static bool ScriptCompileIng = false;
    [MenuItem("Tools/ExcelBuild/ToProtobuf/生成C#")]
    public static void BuildCSharp() {
        var (excelPath, protoPath) = ExcelFolderPath();  //获取excel文件夹路径
        var excels = GetAllExcels(excelPath); //获取所有xlsx表

        foreach (var excel in excels) {
            var sheetDatas = ParseExcel(excel); //解析表
            for (int i = 0; i < sheetDatas.Count; i++) {
                var sheetData = sheetDatas[i];
                SaveProto(protoPath, sheetData.SheetName, sheetData.SheetRowDatas[1], sheetData.SheetRowDatas[2]); //保存proto协议文件
                ExecuteProto(protoPath, sheetData.SheetName);  //根据proto打c#
            }
        }
        AssetDatabase.Refresh();
        ScriptCompileIng = true;
        UnityEditor.Compilation.CompilationPipeline.RequestScriptCompilation();  //代码编译 但这是异步过程

        Action<object> action = null;
        action = (obj) => {
            ScriptCompileIng = false;
            UnityEditor.Compilation.CompilationPipeline.compilationFinished -= action;
        };
        UnityEditor.Compilation.CompilationPipeline.compilationFinished += action;
    }

    [MenuItem("Tools/ExcelBuild/ToProtobuf/生成数据文件")]
    public static void BuildProtoFile() {
        if (ScriptCompileIng) {
            Debug.LogError("代码未编译完，稍后再试！！！");
            return;
        }
        var (excelPath, protoPath) = ExcelFolderPath();  //获取excel文件夹路径
        var excels = GetAllExcels(excelPath); //获取所有xlsx表

        foreach (var excel in excels) {
            var sheetDatas = ParseExcel(excel); //解析表
            for (int i = 0; i < sheetDatas.Count; i++) {
                var sheetData = sheetDatas[i];
                SaveDataFile(sheetData.SheetName, sheetData.SheetRowDatas);
            }
            
        }
        AssetDatabase.Refresh();
        UnityEngine.Debug.Log("完成");
    }

    private static (string, string) ExcelFolderPath() {
        var projectPath = Directory.GetParent(Application.dataPath).FullName;
        projectPath = Directory.GetParent(projectPath).FullName;

        var excelPath = projectPath + "/Tools/Excels";
        var protoPath = projectPath + "/Tools/Proto";
        return (excelPath, protoPath);
    }

    private static string[] GetAllExcels(string path) {
        var oldExcel = Directory.GetFiles(path, "*.xls");
        if (oldExcel.Length > 0) {
            UnityEngine.Debug.LogError("暂不支持xls格式");
        }
        var totalExcels = Directory.GetFiles(path, "*.xlsx");
        return totalExcels.ToList().FindAll(x => { return Path.GetFileName(x).StartsWith(NewExcelTag); }).ToArray();
    }

    private static List<SheetDatas> ParseExcel(string path) {
        List<SheetDatas> sheetDatas = new List<SheetDatas>();

        using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read)) {
            using (ExcelPackage excel = new ExcelPackage(fileStream)) {
                for (int i = 0; i < excel.Workbook.Worksheets.Count; i++) {
                    ExcelWorksheet sheet = excel.Workbook.Worksheets[i + 1];
                    if (sheet.Name.StartsWith(SheetFilter)) {
                        continue;
                    }
                    List<string[]> lines = new List<string[]>();
                    var maxColumn = sheet.Dimension.End.Column; //一共多少列
                    for (int r = 1; r <= sheet.Dimension.End.Row; r++) {  //遍历行
                        string[] valueArray = new string[maxColumn];
                        for (int c = 1; c <= maxColumn; c++) {
                            valueArray[c - 1] = sheet.Cells[r, c].Text;
                        }
                        lines.Add(valueArray);
                    }

                    foreach (var str in lines[1]) {
                        if (string.IsNullOrEmpty(str)) {
                            UnityEngine.Debug.LogError("获取总列数中，对应的第二行有空内容");
                        }
                    }
                    sheetDatas.Add(new SheetDatas { SheetName = sheet.Name, SheetRowDatas = lines });
                }
            }
        }
        return sheetDatas;
    }

    private static void SaveProto(string savePath, string fileName, string[] names, string[] types) {
        BaseProtobuf pro = GetToProtobuf(types[0]);
        pro.SaveProto(savePath, fileName, names, types);
    }

    private static void ExecuteProto(string protoPath, string fileName) {
        var savePath = Application.dataPath + "/Scripts/Config/Define/";
        List<string> cmds = new List<string>();
        cmds.Add($"cd /d {protoPath}");
        cmds.Add($"protoc {fileName} --csharp_out={savePath}");
        new CMD(cmds);
    }

    private static void SaveDataFile(string fileName, List<string[]> datas) {
        var pro = GetToProtobuf(datas[2][0]);
        pro.SaveDataFile(saveFilePath, fileName, datas);
    }

    static BaseProtobuf GetToProtobuf(string str) {
        BaseProtobuf pro = null;
        if (str.StartsWith("Dic_")) {
            pro = new ToDicProtobuf(str == "Dic_int32");
        } else {
            pro = new ToListProtobuf();
        }
        return pro;
    }
}
