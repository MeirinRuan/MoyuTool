using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTool.FormEmoneyShop
{
    public partial class UserControl_CombList : UserControl
    {
        public UserControl_CombList()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            int index = Parent.Controls.IndexOf(this);

            EmoneyShopForm eshop = (EmoneyShopForm)ParentForm;

            eshop.InitWndByStep(index);

        }
    }
}
