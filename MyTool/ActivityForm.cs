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
        Dictionary<int, Dictionary<int, string>> dic_list = new Dictionary<int, Dictionary<int, string>>();
        Dictionary<int, Dictionary<int, Tuple<string, int>>> dic_activity = new Dictionary<int, Dictionary<int, Tuple<string, int>>>();
        MyFilesOpration mfo = new MyFilesOpration();

        //gamepath
        string GamePath = "";

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
                
                string FileNameExtension = Path.GetExtension(openFileDialog1.FileName);
                string FileName = Path.GetFileName(openFileDialog1.FileName);

                GamePath = mfo.GetGamePath(openFileDialog1.FileName);

                //判断是否是50046_data
                if (FileNameExtension == ".lua" && FileName == "50046_data.lua")
                {
                    string FileText = File.ReadAllText(openFileDialog1.FileName, Encoding.Default);
                    string TabConfig = mre.GetLuaTableTabConfig(FileText);


                    //循环存每个子表
                    while (TabConfig.Length > 0)
                    {
                        var strinfo = mre.GetSecondLuaTable(TabConfig);
                        int nNpcId = mre.GetTabConfigNpcIdByItem(strinfo.Item1);

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
                    TypeList_comboBox.ValueMember = "Key";
                    TypeList_comboBox.DisplayMember = "Key";

                    string TaskList = mre.GetLuaTableTaskList(FileText);

                    //循环存火爆的子表
                    while (TaskList.Length > 0)
                    {
                        var strinfo = mre.GetActivityLuaTable(TaskList);
                        string newstr = strinfo.Item1;
                        int end = strinfo.Item2;
                        int TaskId = strinfo.Item3;
                        int nNpcId = strinfo.Item4;
                        Tuple<string, int> tuple = new Tuple<string, int>(newstr, TaskId);

                        //读取npcid进行分类
                        if (!dic_activity.ContainsKey(nNpcId))
                        {
                            dic_activity[nNpcId] = new Dictionary<int, Tuple<string, int>>();
                        }
                        dic_activity[nNpcId].Add(dic_activity[nNpcId].Count + 1, tuple);

                        //更新文本
                        TaskList = TaskList.Substring(end - 1, TaskList.Length - end);
                    }

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
                ActivityList_flowLayoutPanel.Controls.Clear();
                ActivityItem_flowLayoutPanel.Controls.Clear();

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
                        //设置button背景
                        string ImagePath = mfo.GetImagePathByControl(GamePath, mfo.GetControlText(GamePath), mre.GetTabConfigTitleByItem(luaTable), 1);

                        if (ImagePath != "")
                        {
                            //设置button边框样式
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.FlatAppearance.BorderSize = 0;
                            btn.BackgroundImage = Image.FromFile(ImagePath);
                            btn.Height = btn.BackgroundImage.Height;
                            btn.Width = btn.BackgroundImage.Width;
                            btn.BackgroundImageLayout = ImageLayout.Stretch;
                        }
                        else
                        {
                            //读取不到图片
                            //判断button代表的类型，设置button文字
                            btn.Text = mre.GetLuaTableType(luaTable);
                        }
                        btn.Tag = mre.GetLuaTableType(luaTable);
                    }
                    btn.Click += TypeList_Btn_Click;
                    ActivityList_flowLayoutPanel.Controls.Add(btn);
                }
            }
        }

        //combo中button的点击事件
        private void TypeList_Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            ActivityItem_flowLayoutPanel.Controls.Clear();

            if ((string)btn.Tag == "火爆")
            {
                //读取火爆活动面板tTaskList
                int NpcId = Convert.ToInt32(TypeList_comboBox.SelectedValue);
                int nCount = dic_activity[NpcId].Count;
                for (int i = 0; i < nCount; i++)
                {
                    //Button btn_activity = new Button();
                    ActivityItemForm activityItem = new ActivityItemForm();
                    activityItem.TopLevel = false;

                    string luatable = dic_activity[NpcId][i + 1].Item1;
                    string ImagePath = mfo.GetImagePathByControl(GamePath, mfo.GetControlText(GamePath), mre.GetTaskListIcoByItem(luatable), 0);

                    //子界面存数据
                    activityItem.Tag = luatable;

                    //设置图标
                    if (ImagePath != "")
                    {
                        //设置button边框样式
                        activityItem.Controls["btn_activity"].BackgroundImage = Image.FromFile(ImagePath);
                        activityItem.Controls["btn_activity"].Height = btn.BackgroundImage.Height;
                        activityItem.Controls["btn_activity"].Width = btn.BackgroundImage.Width;
                    }
                    //读取不到图片
                    else
                    {
                        //判断button代表的类型，设置button文字
                        activityItem.Controls["btn_activity"].Text = (dic_activity[NpcId][i + 1].Item2).ToString();
                    }

                    //标题文字
                    activityItem.Controls["Title_label"].Text = mre.GetTaskListTitleByItem(luatable);

                    //推荐图标
                    if (mre.GetTaskListRecommendByItem(luatable))
                    {
                        activityItem.Controls["Recommend_label"].Visible = true;
                    }

                    //人数文字
                    if (mre.GetTaskListTeamNumStrByItem(luatable) != "")
                    {
                        activityItem.Controls["TeamNumStr_label"].Text = mre.GetTaskListTeamNumStrByItem(luatable);
                    }

                    //展示物品组



                    ActivityItem_flowLayoutPanel.Controls.Add(activityItem);
                    activityItem.Show();

                }
            }
        }



        private void ActivityForm_Load(object sender, EventArgs e)
        {
        }

        private void Main_flowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
