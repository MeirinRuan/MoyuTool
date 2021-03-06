﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MyTool.FormEmoneyShop
{
    public partial class UserControl_OpenFile : UserControl
    {
        public UserControl_OpenFile()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                //shop文件路径
                string shopini = folderBrowserDialog1.SelectedPath + "\\ini\\newshop.ini";

                if (!File.Exists(shopini))
                {
                    MessageBox.Show("文件不存在。");
                    return;
                }

                EmoneyShopForm eshop = (EmoneyShopForm)ParentForm;

                //生成客户端配置
                eshop.CreateNewShopFile(shopini);

                eshop.NextStep();
            }
        }
    }
}
