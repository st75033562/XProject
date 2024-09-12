## 配表
- 配表会转成protobuf使用
- 根据配表生成c#类(Unity菜单Tools->ExcelBuild->ToProtobuf->生成C#) 脚本生成的目录在Assets/Scripts/Config/Define/下
- 生成对应的类以后把数据转成protobuf格式保存文件(Unity菜单Tools->ExcelBuild->ToProtobuf->生成数据文件) 文件生成路径在Assets/Res/Data/下
- 编译脚本在 Assets/Editor/ExcelBuild/下，程序集、生成路径等配置在ToProtobuf.cs类中

#### 配表规范
- 路径： 项目名/Tools/Excels
- 表名规范：首字母大写N开头,只有大写N开头的表会编译 如： N道具表
- 表中工作簿命名必须是大写T开头，如TRecharge。@开头的工作簿名除外(@开头表示不打的表，可作为备注使用)
- 行规范：
  - 第一行注释行
  - 第二行变量名，<font color=red>首字母必须大写,且不能有下划线</font>
  - 第三行变量类型

类型  | 类型  | 注释
---- | ----- | ------  
int32  | 数字 |   
string  | 字符串 |     
Dic_int32  | 字典 key是int32) |  仅第三行第一列有效   
Dic_string | 字典 key是字符串 | 仅第三行第一列有效	
		

