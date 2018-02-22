﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel;
using System.Windows.Forms;

namespace MyTool
{
    public class ExcelOpration
    {
        public Excel.Application app;
        public Workbooks wbs;
        public Workbook wb;
        public Worksheet ws;
        public Range rng;

        //表名
        public static string sSheetLuaShopName = "筹码币商店";
        //表头长度
        public static int nLuaShopLength = 20;

        //打开excel文件
        public void OpenExcel(string FileName)
        {
            //打开excel
            app = new Excel.Application();
            wbs = app.Workbooks;
            wb = wbs.Add(FileName);
            //app.Visible = true;
        }

        //关闭Excel
        public void CloseExcel()
        {
            wb.Close();
            wbs.Close();
            app.Quit();
            wb = null;
            wbs = null;
            app = null;
            GC.Collect();
        }

        //表名判断
        public bool IsExcelSheetNameTrue(Workbook wb)
        {
            for (int i = 0; i < wb.Worksheets.Count;)
            {
                ws = wb.Worksheets[i + 1];
                string sSheetName = ws.Name;
                if (sSheetName == sSheetLuaShopName)
                {
                    return true;
                }

                i++;

                if (i == wb.Worksheets.Count)
                {
                    return false;
                }
            }
            return false;
        }

        //根据第一行单个表头读取列内容
        public ArrayList GetColumnValues(Worksheet ws, string ColumnName)
        {
            ArrayList sColumnsValues = new ArrayList();

            //遍历第一行表头的数据判断是否有该内容的表头
            int nColumns = 0;
            int i = 1;
            while (ws.Cells[1, i].Text.ToString() != "")
            {
                if (ws.Cells[1, i].Text.ToString() == ColumnName)
                {
                    nColumns = i;
                    break;
                }

                i++;
            }
            if (i == nLuaShopLength)
            {
                MessageBox.Show(string.Format("第一列不存在内容为{0}的单元格。", ColumnName));
                return null;
            }

            //根据该内容的单元格所在列返回该列表格内容
            int j = 2;
            while (ws.Cells[j, nColumns].Text.ToString() != "")
            {
                sColumnsValues.Add(ws.Cells[j, nColumns].Text.ToString());
                j++;
            }
            if (j == 2)
            {
                MessageBox.Show("该列无数据。");
                return null;
            }

            return sColumnsValues;
        }

        //返回单行内容
        public ArrayList GetRowValues(Worksheet ws, int nRow)
        {
            ArrayList sRowValues = new ArrayList();
            int nRows = nRow;
            int i = 1;
            //行的第一个内容不为空
            while (ws.Cells[nRows, i].Text.ToString() != "")
            {
                sRowValues.Add(ws.Cells[nRows, i].Text.ToString());
                i++;
            }
            if (i == 1)
            {
                MessageBox.Show("该行无数据。");
                return null;
            }

            return sRowValues;
        }

        //返回行数，从第二行开始
        public int GetRowNum(Worksheet ws)
        {
            int nRows = 2;
            //行的第一个内容不为空
            while (ws.Cells[nRows, 1].Text.ToString() != "")
            {
                nRows++;
            }
            if (nRows == 2)
            {
                MessageBox.Show("无行内容。");
                return 0;
            }
            return nRows - 2;
        }

        //拼接单行sql语句
        public string GetStatement(Worksheet ws, ArrayList RowValues)
        {
            string sSqlStatement = "";
            ArrayList sTempList = RowValues;
            sSqlStatement = string.Join(",", (string[])sTempList.ToArray(typeof(string)));
            return sSqlStatement;
        }

        //拼接字符串，用于拼接一条sql语句
        public string GetSqlStatement(string sString)
        {
            string sStatement = string.Format("({0}),", sString);
            return sStatement;
        }

        //排序行内容
        public ArrayList LuaShopStatementSort(ArrayList sStatement, int RowCount)
        {
            //判断数组长度
            if (sStatement.Count != 15)
            {
                //表头检测

                MessageBox.Show("表头缺少");
                return null;
            }

            ArrayList sTempStatement = new ArrayList()
            {
                "0",              //id
                "11",             //type
                sStatement[9],    //data1 npcid
                sStatement[3],    //data2 itemtypeid
                sStatement[2],    //data3 是否给与绑定物品 0=非绑 1=绑
                sStatement[7],    //data4 价格
                sStatement[8],    //data5 价钱类型 0=魔石 1=绑定魔石 2-物品货币 3=金币
                sStatement[5],    //data6 限购数量，999999 为不限制
                sStatement[8],    //data7 物品货币id
                sStatement[0],    //data8 排序,从大到小，倒序
                sStatement[10],  //data9 索引rwtLuaShopData的配置
                "0",             //记录重置时间，配置0
                sStatement[11],  //西山居log掩码ID
                sStatement[12],  //物品分类，支持累加
                "1",             //支持绑定物品购买绑定道具，非绑物品购买非绑道具
                sStatement[13],  //出售开始时间,格式yyyyMMddHHmm =0表示 没限制
                sStatement[14],  //出售结束时间,格式yyyyMMddHHmm =0表示 没限制
                "'0'",
                "'0'",
            };

            //属性字段绑转换
            if (sTempStatement[4].ToString().Contains("非"))
            {
                sTempStatement[4] = "0";
            }
            else
            {
                sTempStatement[4] = "1";
            }

            //摆放顺序倒序
            sTempStatement[9] = (RowCount - Convert.ToInt32(sTempStatement[9]) + 1).ToString();

            return sTempStatement;
        }

        //返回所有行内容
        public string GetLuaShopSql(Worksheet ws)
        {
            if (ws == null)
            {
                MessageBox.Show("请先打开excel文件。");
                return null;
            }
            string sLuaShopSql = "";
            int nRowNum = GetRowNum(ws);
            for (int i = 1; i <= nRowNum; i++)
             {
                if (i == nRowNum)
                {
                    sLuaShopSql = string.Format("{0}({1});\r\n", sLuaShopSql, GetStatement(ws, LuaShopStatementSort(GetRowValues(ws, i + 1), nRowNum)));
                }
                else
                {
                    sLuaShopSql = string.Format("{0}{1}\r\n", sLuaShopSql, GetSqlStatement(GetStatement(ws, LuaShopStatementSort(GetRowValues(ws, i + 1), nRowNum))));
                }
            }
            return sLuaShopSql; 
        }

        //返回cq_lua_data表头
        public string GetLuaDataTitle()
        {
            string sTitle = "Insert into cq_lua_data(id,type,data1,data2,data3,data4,data5,data6,data7,data8,data9,data10,data11,data12,data13,dataStr1,dataStr2,dataStr3,dataStr4)values";
            return sTitle;
        }


        //生成lua的个人限购代码
        public string GetLuaShopTable(Worksheet ws)
        {
            if (ws == null)
            {
                MessageBox.Show("请先打开excel文件。");
                return null;
            }

            int nRowNum = GetRowNum(ws);

            //获取npcid
            string sNpcId = ws.Cells[2, 10].Text.ToString();

            string sItemsCode = "";

            for (int i = 2; i <= nRowNum + 1; i++)
            {
                sItemsCode = string.Format("{0}{1}\r\n\t", sItemsCode, GetLuaShopItem(ws, i));
            }

            string sTable = "rwtLuaShopData[" + sNpcId + "]={\r\n\t" + sItemsCode + "\r\n}";

            return sTable;

        }

        //生成单个物品的luacode
        public string GetLuaShopItem(Worksheet ws, int nRow)
        {
            /*
            [19139]={
			    TotalAmount=99,	--可购买最大数（用于重置）
			    ResetDay=1,		--掩码间隔多少天重置 没有配置不重置
			    ResetAmount=true,--是否重置数量		
			    TaskId= 19139,		--掩码ID 个人限购配置，配置了这个则data6限购无效
		    },*/

            string sItem = "";

            //获取掩码
            int nTaskId = Convert.ToInt32(ws.Cells[nRow, 11].Text);

            //获取个人限购数量
            int nTotalAmount = Convert.ToInt32(ws.Cells[nRow, 7].Text);

            sItem = string.Format("[{0}]={{\r\n\t\tTotalAmount={1},\r\n\t\tResetDay=1,\r\n\t\tResetAmount=true,\r\n\t\tTaskId={2},\r\n\t}},", nTaskId, nTotalAmount, nTaskId);

            return sItem;

        }

    }
}