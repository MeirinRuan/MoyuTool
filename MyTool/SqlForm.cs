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
            String sText = "show databases";
            //读取数据库列表
            ds = myso.MySqlCommand_GetDataSet(SqlInitInfo,sText);

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
                //获取.sql文件中的表


                List<String> TargetSqlField = myso.MySqlCommand_GetAllField(SqlInitInfo, "select *from cq_itemtype");
                //foreach (String str in TargetSqlField)
                //{
                //    Console.WriteLine(str + "\n");
                //}

            }
        }

        private void FileText_textBox_DragDrop(object sender, DragEventArgs e)
        {
            //获得路径
            String sPath = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            String FileNameExtension = Path.GetExtension(sPath);
            String FileName = Path.GetFileName(sPath);

            if (FileNameExtension == ".sql")
            {
                //由一个textBox显示路径
                FileText_textBox.Text = sPath;

                //逐行读取sql文件
                String AllTexts = File.ReadAllText(sPath, Encoding.Default);

                List<SqlFileInfoStruct> TableInfo = myso.GetTableInfo(AllTexts);

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
        public void SetListBoxSelectItem(String TargetTable)
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
