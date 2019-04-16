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

            MyRegularExpression mre = new MyRegularExpression();
            if (!mre.IsNumber(LuaDataType_textBox.Text) ||
                !mre.IsNumber(TaskId_textBox.Text) ||
                !mre.IsNumber(LogId_textBox.Text) ||
                !mre.IsNumber(LogId_XSJ_textBox.Text)
                )
            {
                MessageBox.Show("请在基础数据中填入数值。");
                return;
            }
            
            //起始掩码id
            int nTaskId = Convert.ToInt32(TaskId_textBox.Text);
            int nLuaDataType = Convert.ToInt32(LuaDataType_textBox.Text);

            //抽奖表
            ScratchDraw scratchDraw = new ScratchDraw();
            scratchDraw.nLuaDataType = nLuaDataType;


            //基础配置
            ScratchDrawBaseData baseData = new ScratchDrawBaseData();
            baseData.nLuaDataType = nLuaDataType;
            baseData.nTaskId = nTaskId;
            baseData.nLogId = Convert.ToInt32(LogId_textBox.Text);
            baseData.nLogId_XSJ = Convert.ToInt32(LogId_XSJ_textBox.Text);

            //规则配置
            ScratchDrawOption Op = new ScratchDrawOption();


            //基础配置所在位置
            int[] vs = eo.GetRowAndColumn(eo.sheet, "活动时间");
            int BaseRow = vs[0]+1;
            int BaseColumn = vs[1];

            //活动时间
            string time = eo.sheet.GetRow(BaseRow).GetCell(BaseColumn).ToString();
            string sStartTime = DateTime.Parse(time.Substring(0, time.IndexOf("-"))).ToString("yyyy-MM-dd 10:00");
            string sEndTime = DateTime.Parse(time.Substring(time.IndexOf("-")+1, time.Length-time.IndexOf("-")-1)).ToString("yyyy-MM-dd 23:59");
            Op.sStartTime = sStartTime;
            Op.sEndTime = sEndTime;

            //OptionCost
            //消耗的筹码币
            ScratchDrawOptionCost OptionCost = new ScratchDrawOptionCost();
            int OptionCostItemType = Convert.ToInt32(eo.sheet.GetRow(BaseRow).GetCell(BaseColumn + 2).ToString());
            int OptionCostItemNum= Convert.ToInt32(eo.sheet.GetRow(BaseRow).GetCell(BaseColumn + 3).ToString());
            OptionCost.nItemType = OptionCostItemType;
            OptionCost.nItemNum = OptionCostItemNum;
            Op.OptionCost = OptionCost;

            //OptionAward
            //不一致的奖励
            ScratchDrawOptionAward OptionAward = new ScratchDrawOptionAward();
            int OptionAwardItemType = Convert.ToInt32(eo.sheet.GetRow(BaseRow).GetCell(BaseColumn + 6).ToString());
            int OptionAwardItemNum = Convert.ToInt32(eo.sheet.GetRow(BaseRow).GetCell(BaseColumn + 7).ToString());
            int OptionAwardItemMonpoly = Convert.ToInt32(eo.CharBindConvert(eo.sheet.GetRow(BaseRow).GetCell(BaseColumn + 8).ToString()));
            OptionAward.nItemType = OptionAwardItemType;
            OptionAward.nItemNum = OptionAwardItemNum;
            OptionAward.nItemMonpoly = OptionAwardItemMonpoly; 
            Op.OptionAward = OptionAward;

            //ResetAllDraw
            //重置奖池的配置
            ScratchDrawResetAllDraw ResetAllDraw = new ScratchDrawResetAllDraw();
            int ResetAllDrawItemType = OptionCostItemType;
            int ResetAllDrawItemNum = Convert.ToInt32(eo.sheet.GetRow(BaseRow).GetCell(BaseColumn + 4).ToString());
            ResetAllDraw.nTaskId = nTaskId + 1;
            ResetAllDraw.nItemType = ResetAllDrawItemType;
            ResetAllDraw.nItemNum = ResetAllDrawItemNum;
            Op.ResetAllDraw = ResetAllDraw;

            //ReasetItem
            //重置物品的配置
            ScratchDrawResetItem ResetItem = new ScratchDrawResetItem();
            int ResetItemItemNum = Convert.ToInt32(eo.sheet.GetRow(BaseRow).GetCell(BaseColumn + 5).ToString());
            for (int i = 0; i < 3; i ++)
            {
                ScratchDrawResetItemValue ResetItemValue = new ScratchDrawResetItemValue();
                ResetItemValue.nTaskId = nTaskId + 2 + i;
                ResetItemValue.nItemType = OptionCostItemType;
                ResetItemValue.nItemNum = ResetItemItemNum;
                ResetItem.ResetItemValue.Add(ResetItemValue);
            }
            Op.ResetItem = ResetItem;

            //AwardList
            ScratchDrawAwardList AwardList = new ScratchDrawAwardList();
            
            //奖励表所在位置
            //int[] AwardListPos = eo.GetRowAndColumn(eo.sheet, "超高价值道具");
            for (int i = 0; i < AwardList.AwardListItemName.Count; i++)
            {
                ScratchDrawAwardListItem AwardListItem = new ScratchDrawAwardListItem();
                int[] pos = eo.GetMerGedRegionRange(eo.sheet, AwardList.AwardListItemName[i]);
                int Length = pos[2] - pos[0];
                for (int j = 0; j < Length; j++)
                {
                    int AwardListItemValueRow = pos[0] + 1 + j;
                    ScratchDrawAwardListItemValue AwardListItemValue = new ScratchDrawAwardListItemValue();
                    ScratchDrawAwardListNotice Notice = new ScratchDrawAwardListNotice();
                    AwardListItemValue.nItemType = Convert.ToInt32(eo.sheet.GetRow(AwardListItemValueRow).GetCell(pos[1] + 2).ToString());
                    AwardListItemValue.nItemMonpoly = Convert.ToInt32(eo.CharBindConvert(eo.sheet.GetRow(AwardListItemValueRow).GetCell(pos[1] + 3).ToString()));
                    AwardListItemValue.nItemNum = Convert.ToInt32(eo.sheet.GetRow(AwardListItemValueRow).GetCell(pos[1] + 4).ToString());
                    AwardListItemValue.nChance = Convert.ToInt32(Convert.ToDouble(eo.sheet.GetRow(AwardListItemValueRow).GetCell(pos[1] + 5).NumericCellValue)*10000);
                    AwardListItemValue.nIndex = j + 1;
                    AwardListItemValue.nAwardLev = AwardList.AwardListItemName.Count - i;

                    string nServerLimit = eo.sheet.GetRow(AwardListItemValueRow).GetCell(pos[1] + 6).ToString();
                    if (string.IsNullOrWhiteSpace(nServerLimit))
                    {
                        AwardListItemValue.nServerLimit = 0;
                    }
                    else
                    {
                        AwardListItemValue.nServerLimit = Convert.ToInt32(nServerLimit);
                    }

                    Notice.Type.Add(eo.GetNoticeType(eo.sheet.GetRow(AwardListItemValueRow).GetCell(pos[1] + 7).ToString()));

                    AwardListItemValue.tNotice = Notice;
                    AwardListItem.AwardListItemValue.Add(AwardListItemValue);
                }
                AwardList.AwardListItem.Add(AwardListItem);
            }
            //int[] AwardListItemPos = eo.GetMerGedRegionRange(eo.sheet, "超高价值道具");



            scratchDraw.BaseData = baseData;
            scratchDraw.OptionData = Op;
            scratchDraw.AwardList = AwardList;

           // Console.WriteLine(scratchDraw.GetStr());
           //桌面路径
            string Deskdir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            File.WriteAllText(@Deskdir + "\\刮刮卡配置.lua", scratchDraw.GetStr());
            Process.Start(Deskdir);
            toolStripStatusLabel.Text = "已导出至桌面！";
        }
    }
}
