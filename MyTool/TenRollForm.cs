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



            //修改类的属性可见
            //var item = propertyGrid1.SelectedObject;
            //bool bVisiable = true;
            //SetPropertyVisibility(item, "Ls", bVisiable);
            //propertyGrid1.SelectedObject = item;
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
                
                
                //MessageBox.Show(e.ChangedItem.PropertyDescriptor.GetEditor(typeof(UITypeEditor)).ToString());
                //MessageBox.Show("aa");
            }
        }

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            
        }
    }

}
