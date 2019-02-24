using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTool
{
    public partial class SqlForm : Form
    {
        //目标数据库
        public string TargetDatabase = "";

        //sql文件表数据
        List<SqlFileInfoStruct> TableInfo = new List<SqlFileInfoStruct>();

        //连接数据库的初始化信息
        public string[] SqlInitInfo = new string[4]
        {
            "127.0.0.1",
            "root",
            "aaa",
            "sjmy",
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
            string sText = "show databases";
            //读取数据库列表
            ds = myso.MySqlCommand_GetDataSet(SqlInitInfo, sText);

            SqlDatabase_ListBox.DataSource = ds.Tables[0];
            SqlDatabase_ListBox.DisplayMember = ds.Tables[0].Columns[0].ToString();

            //设置默认选择项
            SetListBoxSelectItem(SqlInitInfo[3]);
        }



        private void FileText_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            //回车读取
            if (e.KeyCode == Keys.Enter)
            {
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
                    for (int l = 0; l < SqlValue.Count; l ++)
                    {
                        TargetValue.Add(l, new List<string>(TargetSqlField.Count));
                    }


                    //比对字段
                    for (int j = 0; j < TargetSqlField.Count; j++)
                    {
                        for (int k = 0; k < SqlField.Count; k++)
                        {
                            if (TargetSqlField[j] == SqlField[k])
                            {
                                //插入相同字段的值
                                for (int m = 0; m < TargetValue.Count; m++)
                                {
                                    TargetValue[m].Insert(j, SqlValue[m][k]);
                                    Console.WriteLine(TargetValue[m][j]);
                                }
                                
                                continue;
                            }
                        }
                    }

                    //不同字段插入目标表的默认值
                    List<string> TargetSqlFieldType = myso.MySqlCommand_GetAllField(SqlInitInfo,
                        string.Format("select DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where table_name = '{0}'", SqlTableName));
                    for (int n = 0; n < TargetValue.Count; n++)
                    {
                        foreach (string str in TargetValue[n])
                        {
                            if (string.IsNullOrEmpty(str))
                            {
                                int index = TargetValue[n].IndexOf(str);
                                if (TargetSqlFieldType[index].Contains("char"))
                                {
                                    TargetValue[n].Insert(index, "\'\'");
                                }
                                else if (TargetSqlFieldType[index].Contains("int"))
                                {
                                    TargetValue[n].Insert(index, "0");
                                }
                            }
                        }
                        Console.WriteLine(TargetValue[n]);
                    }


                    //输出表
                    //Console.WriteLine(string.Format("INSERT INTO " + TargetSqlTableName + 
                    //    "({0}) VALUES" +
                    //    "{1}",
                    //    TargetSqlField,
                    //    targetvalues
                    //    ));
                }

            }
        }

        private void FileText_textBox_DragDrop(object sender, DragEventArgs e)
        {
            //获得路径
            string sPath = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string FileNameExtension = Path.GetExtension(sPath);
            string FileName = Path.GetFileName(sPath);

            if (FileNameExtension == ".sql")
            {
                //由一个textBox显示路径
                FileText_textBox.Text = sPath;

                //读取sql文件
                string AllTexts = File.ReadAllText(sPath, Encoding.Default);

                TableInfo = myso.GetTableInfo(AllTexts);

                FileText_textBox.Text += "\r\n请按回车键";
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


            //string str = myso.MySqlCommand_GetNameIndex(SqlInitInfo, "select *from cq_user", 0);
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
    }
}
