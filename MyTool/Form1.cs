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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //sql字段补全功能界面
        private void Sql_button_Click(object sender, EventArgs e)
        {
            SqlForm sqlform = new SqlForm();
            sqlform.ShowDialog();
        }

        //筹码币商店功能界面
        private void LuaShop_button_Click(object sender, EventArgs e)
        {
            LuaShopForm luashopform = new LuaShopForm();
            luashopform.ShowDialog();
        }

        private void TenBox_button_Click(object sender, EventArgs e)
        {
            TenRollForm tenrollform = new TenRollForm();
            tenrollform.ShowDialog();
        }

        private void ScratchDraw_button_Click(object sender, EventArgs e)
        {
            ScratchDrawForm scratchDrawForm = new ScratchDrawForm();
            scratchDrawForm.ShowDialog();
        }

        private void Activity_button_Click(object sender, EventArgs e)
        {
            ActivityForm activityform = new ActivityForm();
            activityform.ShowDialog();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            UpdateSqlExcel updatesqlexcelform = new UpdateSqlExcel();
            updatesqlexcelform.ShowDialog();
        }

        private void insert_button_Click(object sender, EventArgs e)
        {
            InsertSqlExcel insertsqlexcelform = new InsertSqlExcel();
            insertsqlexcelform.ShowDialog();
        }
    }
}
