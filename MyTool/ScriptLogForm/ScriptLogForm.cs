using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NLua;

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
            Regex regex = new Regex(@"nLogId");

            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());


            Lua lua = new Lua();

            //加载NLua
            //lua.RegisterFunction("testfunc", null, typeof(MyLuaOpration).GetMethod("test"));
            lua.RegisterFunction("MyNLua_GetCurrentPath", null, typeof(MyLuaOpration).GetMethod("MyNLua_GetCurrentPath"));
            lua.RegisterFunction("MyNLua_OutPutLog", null, typeof(MyLuaOpration).GetMethod("MyNLua_OutPutLog"));
            //lua.DoString("MyNLua_OutPutLog()");
            

            //Console.ReadLine();

            lua.DoFile(directoryInfo.FullName + "\\Nlua\\Main.lua");

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
            string sPath = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string FileNameExtension = Path.GetExtension(sPath);
            //string FileName = Path.GetFileNameWithoutExtension(sPath);

            if (FileNameExtension == ".lua")
            {
                //单个lua文件
                checkedListBox1.Items.Add(sPath, true);
                FileName.Add(sPath);

                //读取sql文件
                string AllTexts = File.ReadAllText(sPath, Encoding.Default);

            }
            else if (Directory.Exists(sPath))
            {
                //文件夹的话就清空下
                FileName.Clear();
                string[] filenames = Directory.GetFiles(sPath);
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
