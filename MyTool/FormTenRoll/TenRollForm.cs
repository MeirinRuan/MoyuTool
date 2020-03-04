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

        //检查是否为可见属性
        public bool IsPropertyVisible(object obj, string propertyName)
        {
            //MessageBox.Show(propertyName);
            Type type = typeof(BrowsableAttribute);
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(obj);
            AttributeCollection attrs = props[propertyName].Attributes;
            FieldInfo fld = type.GetField("browsable", BindingFlags.Instance | BindingFlags.NonPublic);
            if ((Boolean)fld.GetValue(attrs[type]))
            {
                //MessageBox.Show(propertyName);
                return true;
            }
            return false;

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

        //打开excel
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

        //导入奖励表
        private void button2_Click(object sender, EventArgs e)
        {
            if (eo.ws == null)
            {
                MessageBox.Show("请先打开excel。");
                return;
            }
            TenRollSettings trs = (TenRollSettings)propertyGrid1.SelectedObject;

            //排序十连抽奖励表内容
            int nRows = eo.GetRowNumFromItemId(eo.ws);
            List<AwardList> Statement = new List<AwardList>(nRows);
            for (int i = 1; i <= nRows; i++)
            {
                AwardList al2 = new AwardList();
                al2.ALI.ItemId = Convert.ToInt32(eo.ws.Cells[i + 1, 6].ToString());//物品id
                al2.ALI.IsBind = Convert.ToInt32(eo.CharBindConvert(eo.ws.Cells[i + 1, 3].ToString()));//绑定
                al2.ALI.Count = Convert.ToInt32(eo.ws.Cells[i + 1, 5].ToString());//数量
                al2.ALI.Chance = Convert.ToInt32(eo.ws.Cells[i + 1, 7]) * 10000;//概率
                //播报
                //全服产出

                Statement.Add(al2);
            }

            List<AwardList> al = Statement;

            trs.tAwardList.Clear();

            for (int i = al.Count-1; i >= 0; i--)
            {
                trs.tAwardList.Add(al[i]);
            }

            propertyGrid1.SelectedObject = trs;
        }

        //生成代码
        private void button3_Click(object sender, EventArgs e)
        {
            var item = (TenRollSettings)propertyGrid1.SelectedObject;
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(item);
            PropertyDescriptorCollection opt = TypeDescriptor.GetProperties(item.tOption);
            PropertyDescriptorCollection least = TypeDescriptor.GetProperties(item.tLeast);
            PropertyDescriptorCollection lstawd = TypeDescriptor.GetProperties(item.tLstAwd);
            PropertyDescriptorCollection tencount = TypeDescriptor.GetProperties(item.tTenCount);

            string TitleStr = "rwtLuckDrawTable[{0}]={{ \r\n\t{1}\r\n }}";
            string tBaseData = "tBaseData = {{ \r\n\t\t{0}\r\n\t }},";
            string BaseDataStr = "";
            string tRule = "tRule = {{ \r\n\t\t{0}\r\n\t }},";
            string RuleStr = "";
            string tOption = "tOption = {{ \r\n\t\t\t{0}\r\n\t }},";
            string OptionStr = "";
            string tLstAwd = "tLstAwd = {{ \r\n\t\t\t{0}\r\n\t }},";
            string LstAwdStr = "";
            string tLeast = "tLeast = {{ \r\n\t\t\t{0}\r\n\t }},";
            string LeastStr = "";
            string tTenCount = "tTenCount = {{ \r\n\t\t\t{0}\r\n\t }},";
            string TenCountStr = "";


            //tBaseData
            for (int i = 0; i< props.Count; i++)
            {
                if (IsPropertyVisible(item, props[i].Name))
                {
                    //按照分类
                    if (props[i].Category == "\t基础数据配置表")
                    {
                        BaseDataStr = BaseDataStr + props[i].Name + "=" + props[i].GetValue(item).ToString() + ",\r\n\t\t";
                    }
                }
            }
            tBaseData = string.Format(tBaseData, BaseDataStr);
            TitleStr = string.Format(TitleStr, item.nType, tBaseData);

            //tOption


            //tLeast


            MessageBox.Show(TitleStr);
        }

        //重置刷新界面
        private void button4_Click(object sender, EventArgs e)
        {
            TenRollSettings trs = new TenRollSettings();
            propertyGrid1.SelectedObject = trs;
        }


    }

}
