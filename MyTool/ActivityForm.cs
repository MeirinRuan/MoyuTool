using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LuaInterface;
using System.Text.RegularExpressions;
using System.IO;

namespace MyTool
{
    public partial class ActivityForm : Form
    {
        bool Flag = false;
        MyRegularExpression mre = new MyRegularExpression();
        public ActivityForm()
        {
            InitializeComponent();
        }

        private void CombList_tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ReadFile_button_Click(object sender, EventArgs e)
        {
            //成功
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //判断是否是50046_data
                string FileNameExtension = Path.GetExtension(openFileDialog1.FileName);
                string FileName = Path.GetFileName(openFileDialog1.FileName);
                if (FileNameExtension == ".lua" && FileName == "50046_data.lua")
                {
                    string FileText = File.ReadAllText(openFileDialog1.FileName, Encoding.Default);
                    string TabConfig = mre.GetLuaTableTabConfig(FileText);
                    Dictionary<int, Dictionary<int, string>> dic_list = new Dictionary<int, Dictionary<int, string>>();


                    //循环存每个子表
                    while (TabConfig.Length > 0)
                    {
                        var strinfo = mre.GetSecondLuaTable(TabConfig);
                        int nNpcId = mre.GetNpcIdByItem(strinfo.Item1);

                        //读取npcid进行分类
                        if (!dic_list.ContainsKey(nNpcId))
                        {
                            dic_list[nNpcId] = new Dictionary<int, string>();
                        }
                        dic_list[nNpcId].Add(dic_list[nNpcId].Count + 1, strinfo.Item1);

                        //更新文本
                        TabConfig = TabConfig.Substring(strinfo.Item2, TabConfig.Length - strinfo.Item2);
                        
                    }

                    //放入combobox中
                    BindingSource bs = new BindingSource
                    {
                        DataSource = dic_list
                    };
                    TypeList_comboBox.DataSource = bs;
                    TypeList_comboBox.ValueMember = "Value";
                    TypeList_comboBox.DisplayMember = "Key";

                    //combo刷新标记
                    Flag = true;
                }
                else
                {
                    MessageBox.Show("请打开50046_data.lua。");
                }
            }
        }

        private void TypeList_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //更新界面中的显示
            if (Flag)
            {
                ActivityList_tableLayoutPanel.Controls.Clear();
                //创建按钮
                KeyValuePair<int, Dictionary<int, string>> kvp = ((KeyValuePair<int, Dictionary<int, string>>)TypeList_comboBox.SelectedItem);
                Dictionary<int, string> dic = kvp.Value;
                int nCount = dic.Count;
                for (int i = 0; i < nCount; i++)
                {
                    Button btn = new Button();
                    string luaTable = dic[i + 1];
                    if (luaTable != null)
                    {
                        //判断button代表的类型，设置button文字
                        btn.Text = mre.GetLuaTableType(luaTable);
                    }
                    btn.Click += TypeList_Btn_Click;
                    ActivityList_tableLayoutPanel.Controls.Add(btn);
                }
            }

        }

        private void TypeList_Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            
            //读取火爆活动面板tTaskList
            //MessageBox.Show(btn.Name);
            //throw new NotImplementedException();
        }

        private void ActivityForm_Load(object sender, EventArgs e)
        {
        }
    }
}
