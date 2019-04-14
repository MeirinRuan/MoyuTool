using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace MyTool
{
    public partial class ScratchDrawForm : Form
    {
        ExcelOpration eo = new ExcelOpration();

        //表名
        public static string rwTable = "rwScratchDraw";


        public ScratchDrawForm()
        {
            InitializeComponent();
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
                    FileStream fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    eo.OpenExcel(fileStream, openFileDialog1.FileName);
                    //MessageBox.Show("打开excel成功。");

                    toolStripStatusLabel.Text = "";

                    int SheetNum = eo.workbook.NumberOfSheets;
                    for (int i = 0; i < SheetNum; i++)
                    {
                        if (eo.workbook.GetSheetName(i) == "刮刮卡配置")
                        {
                            eo.sheet = eo.workbook.GetSheetAt(i);
                            toolStripStatusLabel.Text = "成功打开excel！";
                            return;
                        }
                    }
                    MessageBox.Show("请检查是否存在“刮刮卡配置”表！");
                    return;
                }
                else
                {
                    MessageBox.Show("请打开excel。");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LuaDataType_textBox.Text) ||
                string.IsNullOrWhiteSpace(TaskId_textBox.Text) ||
                string.IsNullOrWhiteSpace(LogId_textBox.Text) ||
                string.IsNullOrWhiteSpace(LogId_XSJ_textBox.Text)
                )
            {
                MessageBox.Show("请先填入基础数据。");
                return;
            }

            //基础配置
            ScratchDrawBaseData baseData = new ScratchDrawBaseData();
            baseData.nLuaDataType = Convert.ToInt32(LuaDataType_textBox.Text);
            baseData.nTaskId = Convert.ToInt32(TaskId_textBox.Text);
            baseData.nLogId = Convert.ToInt32(LogId_textBox.Text);
            baseData.nLogId_XSJ = Convert.ToInt32(LogId_XSJ_textBox.Text);

            //规则配置
            ScratchDrawOption Optin = new ScratchDrawOption();

            //消耗的筹码币
            ScratchDrawOptionCost OptionCost = new ScratchDrawOptionCost();

            int[] vs = eo.GetRowAndColumn(eo.sheet, "活动时间");

            string time = eo.sheet.GetRow(vs[0] + 1).GetCell(vs[1]).ToString();
            string sStartTime = DateTime.Parse(time.Substring(0, time.IndexOf("-"))).ToString("yyyy-MM-dd 10:00");
            string sEndTime = DateTime.Parse(time.Substring(time.IndexOf("-")+1, time.Length-time.IndexOf("-")-1)).ToString("yyyy-MM-dd 23:59");

            Optin.sStartTime = sStartTime;
            Optin.sEndTime = sEndTime;

            Optin.OptionCost = OptionCost;

            //Console.WriteLine(sStartTime + " " + sEndTime);

        }
    }
}
