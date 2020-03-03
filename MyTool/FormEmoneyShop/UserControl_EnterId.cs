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
    public partial class UserControl_EnterId : UserControl
    {
        private int steps = 2;


        public UserControl_EnterId()
        {
            InitializeComponent();
        }

        private void textBox_itemtype_Validated(object sender, EventArgs e)
        {
            if (textBox_itemtype.TextLength != 0 && steps > 0)
            {
                steps -= 1;

                if (steps == 0)
                {
                    EmoneyShopForm eshop = (EmoneyShopForm)ParentForm;
                    eshop.NextStep();
                }
            }
        }

        private void textBox_goods_Validated(object sender, EventArgs e)
        {
            if (textBox_goods.TextLength != 0 && steps > 0)
            {
                steps -= 1;

                if (steps == 0)
                {
                    EmoneyShopForm eshop = (EmoneyShopForm)ParentForm;
                    eshop.NextStep();
                }
            }
        }

        private void dateTimePicker_begintime_ValueChanged(object sender, EventArgs e)
        {
            EmoneyShopForm eshop = (EmoneyShopForm)ParentForm;
            eshop.begintimeflag = true;
        }

        private void dateTimePicker_endtime_ValueChanged(object sender, EventArgs e)
        {
            EmoneyShopForm eshop = (EmoneyShopForm)ParentForm;
            eshop.endtimeflag = true;
        }

        private void UserControl_EnterId_Load(object sender, EventArgs e)
        {
            //paytype默认第一个
            comboBox_paytype.SelectedIndex = 0;


            //先读取下商店分类配置
            IniFiles ShopTypeini = new IniFiles(Directory.GetCurrentDirectory() + @"\ini\ShopType.ini");

            //不存在默认放热销
            if (!ShopTypeini.ExistINIFile())
            {
                comboBox_shoptype.Items[0] = "21";
            }
            else
            {
                List<string> Values = ShopTypeini.ReadValues("ItemSort");

                //加到comobo中
                comboBox_shoptype.DataSource = Values;

                comboBox_shoptype.SelectedIndex = 20;
            }


        }
    }
}
