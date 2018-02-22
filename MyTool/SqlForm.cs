using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTool
{
    public partial class SqlForm : Form
    {
        public SqlForm()
        {
            MySqlOpration myso = new MySqlOpration();

            //初始化界面
            InitializeComponent();

            //连接数据库
            if (!myso.MySqlConncet(myso.InitSqlInfo()))
            {
                MessageBox.Show("连接数据库失败。");
            }
        }



        private void FileText_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            //回车读取
            if (e.KeyCode == Keys.Enter)
                MessageBox.Show("aaa");
        }

        private void FileText_textBox_DragDrop(object sender, DragEventArgs e)
        {
            //获得路径
            string sPath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            //由一个textBox显示路径
            FileText_textBox.Text = sPath;
        }

        private void SqlDatabase_ListBox_DoubleClick(object sender, EventArgs e)
        {
            //获取选定项
            string sSqldatabase = SqlDatabase_ListBox.GetItemText(SqlDatabase_ListBox.SelectedItem);
            MessageBox.Show(sSqldatabase);

        }

        private void SqlDatabase_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
