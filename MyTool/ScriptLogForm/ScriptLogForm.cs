using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LuaInterface;

namespace MyTool
{
    public partial class ScriptLogForm : Form
    {
        List<string> FileName = new List<string>();


        public ScriptLogForm()
        {
            InitializeComponent();
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            var regex = new Regex(@"nLogId");

            var directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());

            MyLuaOpration mlo = new MyLuaOpration();

            Lua lua = new Lua();

            //注册c#函数供lua调用
            lua.RegisterFunction("MyLua_GetBaseLuaPath", mlo, typeof(MyLuaOpration).GetMethod("MyLua_GetBaseLuaPath"));
            lua.RegisterFunction("MyLua_OutPutLog", mlo, typeof(MyLuaOpration).GetMethod("MyLua_OutPutLog"));
            lua.RegisterFunction("MyLua_ToLuaData", mlo, typeof(MyLuaOpration).GetMethod("MyLua_ToLuaData"));


            //执行Main.lua
            lua.DoFile(MyLuaOpration.MyLua_GetBaseLuaPath() + "\\Main.lua");
            lua.DoFile(MyLuaOpration.MyLua_GetBaseLuaPath() + "\\CommonFunc.lua");
            lua.DoFile(MyLuaOpration.MyLua_GetBaseLuaPath() + "\\CheckLog.lua");


            
            //加载选中的lua
            //lua.DoFile(FileName[0]);


            //选中项
            //foreach (var item in checkedListBox1.CheckedItems)
            //{

            //}
        }

        private void CheckedListBox1_DragDrop(object sender, DragEventArgs e)
        {
            //获得路径
            var sPath = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            var FileNameExtension = Path.GetExtension(sPath);
            //string FileName = Path.GetFileNameWithoutExtension(sPath);

            if (FileNameExtension == ".lua")
            {
                //单个lua文件
                checkedListBox1.Items.Add(sPath, true);
                FileName.Add(sPath);

                //读取sql文件
                var AllTexts = File.ReadAllText(sPath, Encoding.Default);

            }
            else if (Directory.Exists(sPath))
            {
                //文件夹的话就清空下
                FileName.Clear();

                var filenames = Directory.GetFiles(sPath);

                foreach (var str in filenames)
                {
                    checkedListBox1.Items.Add(str, true);
                    FileName.Add(str);
                    //Console.WriteLine(str);
                }
            }
            else
            {
                MessageBox.Show("请拖入lua文件或文件夹。");
            }
        }

        private void CheckedListBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
