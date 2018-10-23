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

namespace MyTool
{
    public partial class ActivityForm : Form
    {
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
                string FileNameExtension = System.IO.Path.GetExtension(openFileDialog1.FileName);
                string FileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
                if (FileNameExtension == ".lua" && FileName == "50046_data.lua")
                {
                    MyLuaOpration mlo = new MyLuaOpration();
                    //打开lua文件
                    mlo.OpenLuaFile(openFileDialog1.FileName);
                    //读取table
                    LuaTable table = mlo.ReadFirstLuaTable("tTabConfig");

                    int nLength = table.Keys.Count;
                    Dictionary<int, Dictionary<int, LuaTable>> dic_list = new Dictionary<int, Dictionary<int, LuaTable>>();

                    for (int i = 1;i <= nLength; i++)
                    {
                        //读取npcid进行分类
                        LuaTable SecondTable = mlo.ReadSecondLuaTableBySort(table, i);
                        LuaTable ConditonTable = mlo.ReadSecondLuaTableByString(SecondTable, "Condition");
                        int nNpcId = Convert.ToInt32(ConditonTable["nNpcId"]);

                        if (ConditonTable["nNpcId"].ToString() != "")
                        {
                            if (!dic_list.ContainsKey(nNpcId))
                            {
                                dic_list[nNpcId] = new Dictionary<int, LuaTable>();
                            }
                            dic_list[nNpcId].Add(dic_list[nNpcId].Count + 1, SecondTable);
                        }
                    }

                    //放入combobox中
                    BindingSource bs = new BindingSource
                    {
                        DataSource = dic_list
                    };
                    TypeList_comboBox.DataSource = bs;
                    TypeList_comboBox.ValueMember = "Value";
                    TypeList_comboBox.DisplayMember = "Key";

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
            Button btn = new Button();
            ActivityList_tableLayoutPanel.Controls.Add(btn);


        }
    }
}
