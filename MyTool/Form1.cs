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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\ini"))
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\ini");
        }

        //sql字段补全功能界面
        private void Sql_button_Click(object sender, EventArgs e)
        {
            //读取下ini配置
            IniFiles ini = new IniFiles(Directory.GetCurrentDirectory() + @"\ini\mysqlconfig.ini");

            List<string> SqlInitInfo = ini.GetSelectedSqlConfig();

            if (SqlInitInfo == null)
            {
                MessageBox.Show("请先添加数据库配置！");
                SqlConfigForm sqlConfigForm = new SqlConfigForm();
                sqlConfigForm.Show();
                return;
            }

            SqlForm sqlform = new SqlForm();
            sqlform.Show();
        }

        //筹码币商店功能界面
        private void LuaShop_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请用中鸣工具。");
            //LuaShopForm luashopform = new LuaShopForm();
            //luashopform.Show();
        }

        private void TenBox_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请用中鸣工具。");
            //TenRollForm tenrollform = new TenRollForm();
            //tenrollform.Show();
        }

        private void ScratchDraw_button_Click(object sender, EventArgs e)
        {
            ScratchDrawForm scratchDrawForm = new ScratchDrawForm();
            scratchDrawForm.Show();
        }

        private void Activity_button_Click(object sender, EventArgs e)
        {
            ActivityForm activityform = new ActivityForm();
            activityform.Show();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            UpdateSqlExcel updatesqlexcelform = new UpdateSqlExcel();
            updatesqlexcelform.Show();
        }

        private void insert_button_Click(object sender, EventArgs e)
        {
            InsertSqlExcel insertsqlexcelform = new InsertSqlExcel();
            insertsqlexcelform.Show();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SqlConfigForm sqlConfigForm = new SqlConfigForm();
            sqlConfigForm.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ScriptLogForm getScriptLogForm = new ScriptLogForm();
            getScriptLogForm.Show();
        }
    }
}
