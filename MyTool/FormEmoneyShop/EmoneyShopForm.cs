using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace MyTool.FormEmoneyShop
{
    public partial class EmoneyShopForm : Form
    {

        public string[] button = { "输入基础数据", "打开客户端路径", "导出"};

        public int step = 0;
        public Control[] controls = { new UserControl_EnterId(), new UserControl_OpenFile(), new UserControl_Output() };
        public string newshopstr = "";
        public bool begintimeflag = false;
        public bool endtimeflag = false;

        //输出目录
        public string Targetroot = Directory.GetCurrentDirectory() + "\\输出目录\\"+ DateTime.Now.ToString("M月d日") +"官方魔石商店配置";

        public EmoneyShopForm()
        {
            InitializeComponent();
        }

        private void EmoneyShopForm_Load(object sender, EventArgs e)
        {

            //加载combolist
            for (int i = 0; i < button.Length; i++)
            {
                UserControl_CombList combList = new UserControl_CombList();
                combList.Controls["button"].Text = button[i];

                if (i > step)
                {
                    combList.Controls["button"].Enabled = false;
                }

                combList.Controls["pictureBox_tick"].Visible = false;

                flowLayoutPanel_combolist.Controls.Add(combList);
            }

            //加载wnd
            foreach (var control in controls)
            {
                flowLayoutPanel_wnd.Controls.Add(control);
            }

            //默认第一个窗口
            InitWndByStep(0);
        }

        /// <summary>
        /// 按照步骤切换窗口
        /// </summary>
        /// <param name="step"></param>
        public void InitWndByStep(int step)
        {
            for (int i = 0; i < controls.Length; i++)
            {
                if (i != step)
                {
                    flowLayoutPanel_wnd.Controls[i].Visible = false;
                }
            }

            flowLayoutPanel_wnd.Controls[step].Visible = true;
        }

        /// <summary>
        /// 下一步骤
        /// </summary>
        public void NextStep()
        {
            if (step + 1 < controls.Length)
            {
                flowLayoutPanel_combolist.Controls[step].Controls["pictureBox_tick"].Visible = true;
                
                step += 1;

                flowLayoutPanel_combolist.Controls[step].Controls["button"].Enabled = true;
            }
        }

        /// <summary>
        /// 生成客户端配置
        /// </summary>
        /// <param name="inipath"></param>
        public void CreateNewShopFile(string inipath)
        {
            //创建下输出目录
            if (!Directory.Exists(Targetroot))
            { 
                Directory.CreateDirectory(Targetroot);
            }

            string newinipath = Targetroot + "\\newshop.ini";

            //先复制下ini配置
            File.Copy(inipath, newinipath, true);

            IniFiles ini = new IniFiles(newinipath);

            if (!ini.ExistINIFile())
            {
                MessageBox.Show("文件不存在。");
                return;
            }

            string itemtypeId = flowLayoutPanel_wnd.Controls[0].Controls["textBox_itemtype"].Text;
            string goodsId = flowLayoutPanel_wnd.Controls[0].Controls["textBox_goods"].Text;

            DateTimePicker dateTimePicker_begintime = (DateTimePicker)flowLayoutPanel_wnd.Controls[0].Controls["dateTimePicker_begintime"];
            DateTimePicker dateTimePicker_endtime = (DateTimePicker)flowLayoutPanel_wnd.Controls[0].Controls["dateTimePicker_endtime"];
            CheckBox checkFlag = (CheckBox)flowLayoutPanel_wnd.Controls[0].Controls["checkBox_onspend"];
            ComboBox comboBox_paytype = (ComboBox)flowLayoutPanel_wnd.Controls[0].Controls["comboBox_paytype"];
            ComboBox comboBox_shoptype = (ComboBox)flowLayoutPanel_wnd.Controls[0].Controls["comboBox_shoptype"];

            //开始时间
            string begintime = (!begintimeflag) ? "0" : dateTimePicker_begintime.Value.ToString("yyMMdd1000");
            //结束时间
            string endtime = (!endtimeflag) ? "0" : dateTimePicker_endtime.Value.ToString("yyMMdd2359");
            //是否计入累消
            string check = checkFlag.Checked ? "1" : "0";
            //购买方式
            string paytype = comboBox_paytype.SelectedItem.ToString();
            //商店分类
            string index = Regex.Match(comboBox_shoptype.SelectedItem.ToString(), @"\d*").Value;


            //生成客户端配置
            //先读取物品总数
            int itemAmount = Convert.ToInt32(ini.IniReadValue("ShopInfo", "ItemAmount"));

            ini.IniWriteValue("ShopInfo", "ItemAmount", (itemAmount+1).ToString());

            //新增一个物品
            IniFiles ShopTypeini = new IniFiles(Directory.GetCurrentDirectory() + @"\ini\ShopType.ini");

            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                {"ItemType",itemtypeId},
                {"CostType",paytype},
                {"Version","31"},
                {"AniTitle","null"},
                {"Commend","1"},
                {"Describe","null"} ,
            };

            if (endtimeflag && begintimeflag)
            {
                dic.Add("TimeType", "2");
                dic.Add("TimeBegin", dateTimePicker_begintime.Value.ToString("yyyy/MM/dd 10:00:00"));
                dic.Add("TimeEnd", dateTimePicker_endtime.Value.ToString("yyyy/MM/dd 23:59:59"));
            }
            

            foreach (var v in dic)
            {
                ini.IniWriteValue("Item" + (itemAmount+1), v.Key, v.Value);
            }

            //在增加商品分类中增加该物品
            int itemsortAmount = Convert.ToInt32(ini.IniReadValue("ItemSort" + index, "Amount"));
            ini.IniWriteValue("ItemSort", "Amount", (itemsortAmount + 1).ToString());

            ini.IniWriteValue("ItemSort" + index , "ItemID" + (itemsortAmount+1), (itemAmount + 1).ToString());


            //生成sql文件
            string title = "#注释部分\n#Delete from cq_goods where id = " + goodsId + " and itemtype = " + itemtypeId + ";\n";

            string sqltext = title + "Insert Into cq_goods(id,type,begin_time,end_time," +
                "ownerid,itemtype,paytype,srvmask,rebate,recycle_percent,onspend_flag,open_mask) values\n";

            sqltext += "(" + goodsId + ",0," + begintime + "," + endtime + ",1207," + itemtypeId + "," + paytype + ",31,0,0," + check + ",0);";

            //MessageBox.Show(sqltext);

            File.WriteAllText(Targetroot + "\\goods.sql", sqltext, Encoding.Default);
        }



    }
}
