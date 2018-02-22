﻿using System;
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
        SqlForm sqlform;
        LuaShopForm luashopform;
        TenRollForm tenrollform;
        public Form1()
        {
            InitializeComponent();
        }

        //sql字段补全功能界面
        private void Sql_button_Click(object sender, EventArgs e)
        {
            sqlform = new SqlForm();
            sqlform.ShowDialog();
        }

        //筹码币商店功能界面
        private void LuaShop_button_Click(object sender, EventArgs e)
        {
            luashopform = new LuaShopForm();
            luashopform.ShowDialog();
        }

        private void TenBox_button_Click(object sender, EventArgs e)
        {
            tenrollform = new TenRollForm();
            tenrollform.ShowDialog();
        }
    }
}