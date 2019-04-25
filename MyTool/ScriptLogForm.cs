using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyTool
{
    public partial class ScriptLogForm : Form
    {
        List<string> FileName = new List<string>();
        

        public ScriptLogForm()
        {
            InitializeComponent();
        }

        private void ListBox1_DragDrop(object sender, DragEventArgs e)
        {
            //获得路径
            string sPath = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string FileNameExtension = Path.GetExtension(sPath);
            //string FileName = Path.GetFileNameWithoutExtension(sPath);

            if (FileNameExtension == ".lua")
            {
                //由一个textBox显示路径
                listBox1.Items.Add(sPath);
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
                    FileName.Add(str);
                    //Console.WriteLine(str);
                }
            }
            else
            {
                MessageBox.Show("请拖入lua文件或文件夹。");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(@"nLogId");
        }

        private void ListBox1_DragEnter(object sender, DragEventArgs e)
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
