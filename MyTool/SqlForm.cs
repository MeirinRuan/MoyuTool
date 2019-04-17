using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyTool
{
    public partial class SqlForm : Form
    {
        //目标数据库
        public string TargetDatabase = "";

        //sql文本
        string AllTexts = "";

        //sql文件名
        string FileName = "";

        //sql文件表数据
        List <SqlFileInfoStruct> TableInfo = new List<SqlFileInfoStruct>();

        //连接数据库的初始化信息
        public string[] SqlInitInfo = new string[4]
        {
            "192.168.19.38",
            "root",
            "aaa",
            "sjmy27",
        };

        MySqlOpration myso = new MySqlOpration();

        public SqlForm()
        {

            //初始化界面
            InitializeComponent();

            //连接数据库
            if (!myso.MySqlConncet(SqlInitInfo))
            {
                MessageBox.Show("连接数据库失败。");
                return;
            }
            DataSet ds = new DataSet();
            //string sText = "show databases";
            //读取数据库列表
            ds = myso.MySqlCommand_GetDataSet(SqlInitInfo, "show databases");

            SqlDatabase_ListBox.DataSource = ds.Tables[0];
            SqlDatabase_ListBox.DisplayMember = ds.Tables[0].Columns[0].ToString();

            //设置默认选择项
            SetListBoxSelectItem(SqlInitInfo[3]);
        }



        private void FileText_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            //回车读取
            //if (e.KeyCode == Keys.Enter)
            //{
                
            //}
        }

        private void FileText_textBox_DragDrop(object sender, DragEventArgs e)
        {
            //获得路径
            string sPath = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string FileNameExtension = Path.GetExtension(sPath);
            FileName = Path.GetFileNameWithoutExtension(sPath);

            if (FileNameExtension == ".sql")
            {
                //由一个textBox显示路径
                FileText_textBox.Text = sPath;

                //读取sql文件
                AllTexts = File.ReadAllText(sPath, Encoding.Default);

                TableInfo = myso.GetTableInfo(AllTexts);

                FileText_textBox.Text += "\r\n\r\n-------------请按导出按钮--------------";
            }
            else
            {
                MessageBox.Show("请拖入sql文件。");
            }
        }

        private void SqlDatabase_ListBox_DoubleClick(object sender, EventArgs e)
        {
            //获取目标库名称
            TargetDatabase = SqlDatabase_ListBox.GetItemText(SqlDatabase_ListBox.SelectedItem);
            SqlInitInfo[3] = TargetDatabase;
            //切换数据库连接
            if (!myso.MySqlConncet(SqlInitInfo))
            {
                MessageBox.Show("连接数据库失败。");
                return;
            }

            FileText_textBox.Text += "\r\n\r\n------------已切换数据库:" + TargetDatabase + "------------------";
            //string str = myso.MySqlCommand_GetNameIndex(SqlInitInfo, "cq_user", 0);
            //MessageBox.Show(str);
        }

        private void SqlDatabase_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FileText_textBox_DragEnter(object sender, DragEventArgs e)
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

        //设置默认选择项
        public void SetListBoxSelectItem(string TargetTable)
        {
            for (int i = 0; i < SqlDatabase_ListBox.Items.Count; i++)
            {
                if (SqlDatabase_ListBox.GetItemText(SqlDatabase_ListBox.Items[i]) == TargetTable)
                {
                    SqlDatabase_ListBox.SetSelected(i, true);
                    return;
                }
            }
        }

        private void button_output_Click(object sender, EventArgs e)
        {
            if (AllTexts == "")
            {
                MessageBox.Show("请先拖入sql文件。");
                return;
            }

            string InsertText = "";

            for (int i = 0; i < TableInfo.Count; i++)
            {
                //文件中的sql
                string SqlTableName = TableInfo[i].TableName;
                List<string> SqlField = TableInfo[i].Field;
                Dictionary<int, List<string>> SqlValue = TableInfo[i].Value;

                //目标表
                string TargetSqlTableName = SqlTableName;
                List<string> TargetSqlField = myso.MySqlCommand_GetAllField(SqlInitInfo, string.Format("select *from {0}", SqlTableName));
                Dictionary<int, List<string>> TargetValue = new Dictionary<int, List<string>>();
                for (int l = 0; l < SqlValue.Count; l++)
                {
                    List<string> values = new List<string>(TargetSqlField.Count);
                    TargetValue.Add(l, values);
                }

                //检测sql文件中的字段值长度是否和表字段长度一致
                foreach (var list in SqlValue)
                {
                    if (list.Value.Count != SqlField.Count)
                    {
                        MessageBox.Show("请先检查"+ SqlTableName + "字段是否匹配！字段数：" + SqlField.Count+"字段值：" + list.Value.Count);
                        return;
                    }
                }

                try
                {
                    //比对字段
                    for (int j = 0; j < TargetSqlField.Count; j++)
                    {
                        for (int k = 0; k < SqlField.Count;)
                        {
                            if (TargetSqlField[j] == SqlField[k])
                            {
                                //插入相同字段的值
                                for (int m = 0; m < TargetValue.Count; m++)
                                {
                                    TargetValue[m].Insert(j, SqlValue[m][k]);
                                    //Console.WriteLine(TargetValue[m][j]);
                                }

                                break;
                            }
                            k++;
                            if (k == SqlField.Count)
                            {
                                for (int m = 0; m < TargetValue.Count; m++)
                                {
                                    TargetValue[m].Insert(j, "");
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }

                //不同字段插入目标表的默认值
                //List<string> TargetSqlFieldType = myso.MySqlCommand_GetAllField(SqlInitInfo,
                //    string.Format("select DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where table_name = '{0}'", SqlTableName));
                DataSet ds = new DataSet();
                ds = myso.MySqlCommand_GetDataSet(SqlInitInfo, "desc " + TargetSqlTableName);


                for (int n = 0; n < TargetValue.Count; n++)
                {
                    for (int m = 0; m < TargetValue[n].Count; m++)
                    {
                        if (string.IsNullOrEmpty(TargetValue[n][m]))
                        {
                            int index = TargetValue[n].IndexOf(TargetValue[n][m]);
                            if (ds.Tables[0].Rows[index][1].ToString().Contains("char"))
                            {
                                TargetValue[n][index] = "\'\'";
                            }
                            else if (ds.Tables[0].Rows[index][1].ToString().Contains("int"))
                            {
                                TargetValue[n][index] = "0";
                            }
                        }
                    }

                }

                //表字段字符串
                string targetfields = string.Join(",", TargetSqlField);


                //表字段值字符串
                string targetvalues = "";
                for (int index = 0; index < TargetValue.Count; index++)
                {
                    if (index == TargetValue.Last().Key)
                    {
                        targetvalues += "(" + string.Join(",", TargetValue[index]) + ");\r\n\r\n";
                    }
                    else
                    {
                        targetvalues += "(" + string.Join(",", TargetValue[index]) + "),\r\n";
                    }
                    //Console.WriteLine(string.Join(",", list.Value));
                }

                //输出表
                //Console.WriteLine(string.Format("INSERT INTO " + TargetSqlTableName +
                //    "({0}) VALUES\r\n" +
                //    "{1}",
                //    targetfields,
                //    targetvalues
                //    ));
                InsertText += string.Format("INSERT INTO " + TargetSqlTableName +
                    "({0}) VALUES\r\n" +
                    "{1}",
                    targetfields,
                    targetvalues
                    );

            }
            //写入文件
            OutPutSqlFile(InsertText);
            FileText_textBox.Text += "\r\n\r\n-------------已导出至桌面--------------";
        }

        //导出文件
        public void OutPutSqlFile(string NewStr)
        {
            string Deskdir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string NewFileName = FileName;
            string NewFileText = AllTexts;
            if (TargetDatabase.Contains("xsj"))
            {
                NewFileName = Regex.Replace(NewFileName, "手机魔域", "魔域手游");
                NewFileText = Regex.Replace(NewFileText, @"\[手机魔域\]", "[魔域手游]");
            }
            else
            {
                NewFileName = Regex.Replace(NewFileName, "魔域手游", "手机魔域");
                NewFileText = Regex.Replace(NewFileText, @"\[魔域手游\]", "[手机魔域]");
            }

            //表内容替换
            Regex regex = new Regex(@"insert into[\s\S]+?;", RegexOptions.IgnoreCase);
            MatchCollection mc_newfile = regex.Matches(NewFileText);
            MatchCollection mc_newstr = regex.Matches(NewStr);

            if (mc_newfile.Count == mc_newstr.Count)
            {
                for (int i = 0; i < mc_newstr.Count; i++)
                {
                    NewFileText = NewFileText.Replace(mc_newfile[i].Value, mc_newstr[i].Value);
                }
            }
            else
            {
                NewFileText = Regex.Replace(NewFileText, @"insert into[\s\S]+?;", "", RegexOptions.IgnoreCase);
            }

            NewStr = NewFileText;
            
            File.WriteAllText(@Deskdir + "\\" + NewFileName + ".sql", NewStr, Encoding.Default);
            System.Diagnostics.Process.Start(Deskdir);
        }


    }
}
