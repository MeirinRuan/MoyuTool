using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Design;

namespace MyTool
{
    public partial class TenRollForm : Form
    {
        public TenRollForm()
        {
            InitializeComponent();
        }

        private void TenRollForm_Load(object sender, EventArgs e)
        {
            TenRollSettings trs = new TenRollSettings();
            propertyGrid1.SelectedObject = trs;

            //动态添加
            DynaProperty dp = new DynaProperty();
            dp.Name = "1";
            dp.Value = new AwardList();
            dp.Description = "";
            dp.Category = "抽奖规则表";
            dp.Converter = new OptionConvert();

            trs.MAC.Add(dp);


        }

        //可见属性的修改
        public void SetPropertyVisibility(object obj, string propertyName, bool visible)
        {
            Type type = typeof(BrowsableAttribute);
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            AttributeCollection attrs = props[propertyName].Attributes;
            FieldInfo fld = type.GetField("browsable", BindingFlags.Instance | BindingFlags.NonPublic);
            fld.SetValue(attrs[type], visible);
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (e.ChangedItem.Label == "可选配置")
            {
                var item = propertyGrid1.SelectedObject;
                if (e.ChangedItem.Value.ToString().Contains("阶段性保底抽奖"))
                {
                    SetPropertyVisibility(item, "Ls", true);
                }
                else
                {
                    SetPropertyVisibility(item, "Ls", false);
                }
                if (e.ChangedItem.Value.ToString().Contains("循环类保底抽奖"))
                {
                    SetPropertyVisibility(item, "LstAwd", true);
                }
                else
                {
                    SetPropertyVisibility(item, "LstAwd", false);
                }
                if (e.ChangedItem.Value.ToString().Contains("十连抽追加抽奖次数"))
                {
                    SetPropertyVisibility(item, "TC", true);
                }
                else
                {
                    SetPropertyVisibility(item, "TC", false);
                }
                propertyGrid1.SelectedObject = item;
            }
        }

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {

        }
    }

}
