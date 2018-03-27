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
using System.Collections;

namespace MyTool
{
    public partial class TenRollForm : Form
    {
        ExcelOpration eo = new ExcelOpration();
        public TenRollForm()
        {
            InitializeComponent();
        }

        private void TenRollForm_Load(object sender, EventArgs e)
        {
            TenRollSettings trs = new TenRollSettings();
            propertyGrid1.SelectedObject = trs;
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

        private void button1_Click(object sender, EventArgs e)
        {
            //成功
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //判断是否是excel
                string FileNameExtension = System.IO.Path.GetExtension(openFileDialog1.FileName);
                if (FileNameExtension == ".xls" || FileNameExtension == ".xlsx")
                {
                    //打开excel
                    eo.OpenExcel(openFileDialog1.FileName);

                    //表名不正确
                    if (!eo.IsExcelSheetNameTrue(eo.wb, "十连抽"))
                    {
                        MessageBox.Show("十连抽表不存在。");
                    }
                    else
                    {
                        MessageBox.Show("读取成功！");
                    }

                    //关闭excel
                    //eo.CloseExcel();
                }
                else
                {
                    MessageBox.Show("请打开excel。");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TenRollSettings trs = new TenRollSettings();
            List<AwardList> al = eo.TenRollStatementSort(eo.ws);
            
            for (int i = al.Count-1; i >= 0; i--)
            {
                trs.MAC.Add(al[i]);
            }

            propertyGrid1.SelectedObject = trs;
        }
    }

}
