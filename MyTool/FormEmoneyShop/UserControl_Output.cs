using System;
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
    public partial class UserControl_Output : UserControl
    {
        public UserControl_Output()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            //打开输出目录
            EmoneyShopForm eshop = (EmoneyShopForm)ParentForm;
            System.Diagnostics.Process.Start(eshop.Targetroot);

            MessageBox.Show("已导出成功！ini文件复制到客户端后用DataCovert加密即可。");
        }
    }
}
