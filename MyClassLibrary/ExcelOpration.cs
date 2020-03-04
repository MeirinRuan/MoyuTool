using System;
using System.Collections.Generic;
using Excel;
using System.Windows.Forms;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Text.RegularExpressions;


    public class ExcelOpration
    {
        public Excel.Application app;
        public Workbooks wbs;
        public Workbook wb;
        public Worksheet ws;
        public Range rng;
        public IWorkbook workbook;
        public ISheet sheet;
        

        //表头长度
        public static int nLuaShopLength = 20;

        /// <summary>
        /// 基于excel.dll打开excel文件
        /// </summary>
        /// <param name="FileName">文件名</param>
        public void OpenExcel(string FileName)
        {
            //打开excel
            app = new Excel.Application();
            wbs = app.Workbooks;
            wb = wbs.Add(FileName);
            app.Visible = true;
        }

        /// <summary>
        /// 基于npoi打开excel文件
        /// </summary>
        /// <param name="fs">文件流</param>
        /// <param name="FileName">文件名</param>
        /// <returns></returns>
        public void OpenExcel(FileStream fs, string FileName)
        {
            //打开excel
            if (FileName.IndexOf(".xlsx") > 0)
            {
                workbook = new XSSFWorkbook(fs);
            }
            else if (FileName.IndexOf(".xls") > 0)
            {
                workbook = new HSSFWorkbook(fs);
            }
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
        public bool IsExcelSheetNameTrue(Workbook wb, string SheetName)
        {
            for (int i = 0; i < wb.Worksheets.Count;)
            {
                
                ws = (Worksheet)wb.Worksheets[i + 1];
                string sSheetName = ws.Name;
                if (sSheetName == SheetName)
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
        public List<String> GetColumnValues(Worksheet ws, string ColumnName)
        {
            List<String> sColumnsValues = new List<String>();

            //遍历第一行表头的数据判断是否有该内容的表头
            int nColumns = 0;
            int i = 1;
            while (ws.Cells[1, i].ToString() != "")
            {
                if (ws.Cells[1, i].ToString() == ColumnName)
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
            while (ws.Cells[j, nColumns].ToString() != "")
            {
                sColumnsValues.Add(ws.Cells[j, nColumns].ToString());
                j++;
            }
            if (j == 2)
            {
                MessageBox.Show("该列无数据。");
                return null;
            }

            return sColumnsValues;
        }

        //返回单行长度
        public int GetRowLength(Worksheet ws, int nRows)
        {
            int i = 1;
            while (ws.Cells[nRows, i].ToString() != "")
            {
                i ++;
            }

            return i;
        }

        /// <summary>
        /// 返回单行内容
        /// </summary>
        /// <param name="ws">Worksheet</param>
        /// <param name="nRows">行数</param>
        /// <param name="Length">每行长度</param>
        /// <param name="IsNumber">类型(0表示过滤非数字字符用于加引号)</param>
        /// <returns></returns>
        public List<String> GetRowValues(Worksheet ws, int nRows, int Length, bool IsNumber)
        {
            List<String> sRowValues = new List<String>();
            int i = 1;
            if (Length >= 1)
            {
                //行的第一个内容不为空
                for (int index = 1; index < Length; index++)
                {
                    if (ws.Cells[nRows, index].ToString() == "")
                    {
                        sRowValues.Add("\"\"");
                    }
                    else
                    {
                        if (IsNumber)
                        {
                            MyRegularExpression mre = new MyRegularExpression();
                            if (mre.IsNumber(ws.Cells[nRows, index].ToString()))
                            {
                                sRowValues.Add(ws.Cells[nRows, index].ToString());
                            }
                            else
                            {
                                sRowValues.Add("\"" + ws.Cells[nRows, index].ToString() + "\"");
                            }
                        }
                        else
                        {
                            sRowValues.Add(ws.Cells[nRows, index].ToString());
                        }
                    }
                    i++;
                }
            }
            else
            {
                MessageBox.Show("行数小于1。");
                return null;
            }

            if (i == 1)
            {
                MessageBox.Show("该行无数据。");
                return null;
            }

            return sRowValues;
        }
        //返回单行内容 参数2行数 参数3每行长度
        public List<String> GetRowValues(Worksheet ws, int nRows, int Length)
        {
            List<String> sRowValues = new List<String>();
            int i = 1;
            if (Length >= 1)
            {
                //行的第一个内容不为空
                for (int index = 1; index < Length; index++)
                {
                    if (ws.Cells[nRows, index].ToString() == "")
                    {
                        sRowValues.Add("\"\"");
                    }
                    else
                    {
                        sRowValues.Add(ws.Cells[nRows, index].ToString());
                    }
                    i++;
                }
            }
            else
            {
                MessageBox.Show("行数小于1。");
                return null;
            }

            if (i == 1)
            {
                MessageBox.Show("该行无数据。");
                return null;
            }

            return sRowValues;
        }
        //返回单行内容 参数2行数
        public List<String> GetRowValues(Worksheet ws, int nRows)
        {
            List<String> sRowValues = new List<String>();
            int i = 1;
            while (ws.Cells[nRows, i].ToString() != "")
            {
                if (ws.Cells[nRows, i].ToString() == "")
                {
                    sRowValues.Add("\"\"");
                }
                else
                {
                    sRowValues.Add(ws.Cells[nRows, i].ToString());
                }
                i++;
            }
            if (i == 1)
            {
                MessageBox.Show("该行无数据。");
                return null;
            }

            return sRowValues;
        }

        /// <summary>
        /// 返回单行内容根据长度 基于NPOI
        /// </summary>
        /// <param name="sheet">ISheet</param>
        /// <param name="nRow">行数</param>
        /// <param name="Length">长度</param>
        /// <returns></returns>
        public List<String> GetRowValues(ISheet sheet, int nRow, int Length)
        {
            List<String> sRowValues = new List<String>();

            IRow cells = sheet.GetRow(nRow);
            if (cells != null)
            {
                for (int i = 0; i < Length; i++)
                {
                    if (cells.GetCell(i) == null)
                    {
                        sRowValues.Add("\"\"");
                    }
                    else
                    {
                        //如果是含有公式的格子
                        if (cells.GetCell(i).CellType == CellType.Formula)
                        {
                            XSSFFormulaEvaluator eva = new XSSFFormulaEvaluator(workbook);
                            if (eva.Evaluate(cells.GetCell(i)).CellType == CellType.Numeric)
                            {
                                sRowValues.Add(eva.Evaluate(cells.GetCell(i)).NumberValue.ToString());
                            }
                            else
                            {
                                sRowValues.Add("\"" + eva.Evaluate(cells.GetCell(i)).StringValue + "\"");
                            }
                                
                        }
                        else
                        {
                            MyRegularExpression mre = new MyRegularExpression();
                            if (mre.IsNumber(cells.GetCell(i).ToString()))
                            {
                                sRowValues.Add(cells.GetCell(i).ToString());
                            }
                            else
                            {
                                sRowValues.Add("\"" + cells.GetCell(i).ToString() + "\"");
                            }
                        }
                    }
                    
                }
            }

            return sRowValues;
        }

        /// <summary>
        /// 返回单行内容 基于NPOI
        /// </summary>
        /// <param name="sheet">ISheet</param>
        /// <param name="nRow">行数</param>
        /// <returns></returns>
        public List<String> GetRowValues(ISheet sheet, int nRow)
        {
            List<String> sRowValues = new List<String>();

            IRow cells = sheet.GetRow(nRow);
            if (cells != null)
            {
                for (int i = 0;i < cells.LastCellNum; i++)
                {
                    sRowValues.Add(cells.GetCell(i).ToString());
                }
            }

            return sRowValues;
        }

        //返回行数，从第二行开始
        public int GetRowNum(Worksheet ws)
        {
            int nRows = 2;
            //行的第一个内容不为空
            while (ws.Cells[nRows, 1].ToString() != "")
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

        //拼接单行sql内容语句（不带括号）
        public string GetStatement(Worksheet ws, List<String> RowValues)
        {
            string sSqlStatement = "";
            try
            {
                List<String> sTempList = RowValues;
                sSqlStatement = string.Join(",", sTempList);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                CloseExcel();
            }
            return sSqlStatement;
        }

        //拼接字符串，用于拼接一条sql语句
        public string GetSqlStatement(string sString)
        {
            string sStatement = string.Format("({0}),", sString);
            return sStatement;
        }

        //物品绑定字符转换
        public string CharBindConvert(string sStr)
        {
            if (sStr.Contains("非") || sStr == "1" || sStr == "可交易")
            {
                sStr = "0";
            }
            else
            {
                sStr = "1";
            }
            return sStr;
        }

        /*
         用于十连抽的一些方法
             */

        //获取行数
        public int GetRowNumFromItemId(Worksheet ws)
        {
            int nRows = 2;
            //内容不为空
            while (ws.Cells[nRows, 6].ToString() != "")
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


        /*
         用于luashop的一些方法
             */

        //排序行内容
        public List<String> LuaShopStatementSort(List<String> sStatement, int RowCount)
        {
            //判断数组长度
            if (sStatement.Count != 16)
            {
                //表头检测

                MessageBox.Show("表头缺少");
                return null;
            }

            List<String> sTempStatement = new List<String>()
            {
                "0",              //id
                "11",             //type
                sStatement[10],    //data1 npcid
                sStatement[3],    //data2 itemtypeid
                sStatement[2],    //data3 是否给与绑定物品 0=非绑 1=绑
                sStatement[7],    //data4 价格
                sStatement[8],    //data5 价钱类型 0=魔石 1=绑定魔石 2-物品货币 3=金币
                sStatement[5],    //data6 限购数量，999999 为不限制
                sStatement[9],    //data7 物品货币id
                sStatement[0],    //data8 排序,从大到小，倒序
                sStatement[11],  //data9 索引rwtLuaShopData的配置
                "0",             //记录重置时间，配置0
                sStatement[12],  //西山居log掩码ID
                sStatement[13],  //物品分类，支持累加
                "1",             //支持绑定物品购买绑定道具，非绑物品购买非绑道具
                sStatement[14],  //出售开始时间,格式yyyyMMddHHmm =0表示 没限制
                sStatement[15],  //出售结束时间,格式yyyyMMddHHmm =0表示 没限制
                "'0'",
                "'0'",
            };

            //属性字段绑转换
            sTempStatement[4] = CharBindConvert(sTempStatement[4].ToString());

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
                    sLuaShopSql = string.Format("{0}{1}\r\n", sLuaShopSql, GetSqlStatement(GetStatement(ws, LuaShopStatementSort(GetRowValues(ws, i + 11), nRowNum))));
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
            string sNpcId = ws.Cells[2, 11].ToString();

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
            int nTaskId = Convert.ToInt32(ws.Cells[nRow, 12].ToString());

            //获取个人限购数量
            int nTotalAmount = Convert.ToInt32(ws.Cells[nRow, 7].ToString());

            sItem = string.Format("[{0}]={{\r\n\t\tTotalAmount={1},\r\n\t\tResetDay=1,\r\n\t\tResetAmount=true,\r\n\t\tTaskId={2},\r\n\t}},", nTaskId, nTotalAmount, nTaskId);

            return sItem;

        }

        //生成update语句
        public void CreateUpdateSql(string ExcelRangeStart, string ExcelRangeEnd, string ExcelSetStart, string ExcelSetEnd,string UpdateStr, string SetFieldStr, string WHereFieldStr)
        {
            string RangeColumnStart = ExcelRangeStart.Substring(0, 1).ToUpper();
            string SetColumnStart = ExcelSetStart.Substring(0, 1).ToUpper();
            int RangeRowStart = Convert.ToInt32(ExcelRangeStart.Substring(1, 2));
            //string RangeColumnEnd = ExcelRangeEnd.Substring(0, 1).ToUpper();
            int RangeRowEnd = Convert.ToInt32(ExcelRangeEnd.Substring(1, 2));
            string newstr = "";

            ws = (Worksheet)wb.Worksheets[1];

            for (int i = RangeRowStart; i <= RangeRowEnd; i++)
            {
                string Rangestr = ws.Cells[i, RangeColumnStart].ToString();
                string Setstr = ws.Cells[i, SetColumnStart].ToString();
                newstr += "Update " + UpdateStr + " set " + SetFieldStr + " = " + Setstr + " where " + WHereFieldStr + " = " + Rangestr + ";\r\n"; 
                
                //Console.WriteLine(newstr);
            }

            //桌面路径
            string Deskdir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            File.WriteAllText(@Deskdir+"\\SQL.sql", newstr);

        }

        /// <summary>
        /// 将excel中字符列转换为数字
        /// </summary>
        /// <param name="columnName">字母列名称</param>
        /// <returns></returns>
        public int ToIndex(string columnName)
        {
            if (!Regex.IsMatch(columnName.ToUpper(), @"[A-Z]+")) { throw new Exception("invalid parameter"); }


            int index = 0;
            char[] chars = columnName.ToUpper().ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                index += ((int)chars[i] - (int)'A' + 1) * (int)Math.Pow(26, chars.Length - i - 1);
            }
            return index - 1;
        }

        /// <summary>
        /// 根据单元格内容查找指定内容单元格所在位置
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="str">单元格内容</param>
        /// <returns></returns>
        public int[] GetRowAndColumn(ISheet sheet, string str)
        {
            int RowRange = sheet.LastRowNum;

            for (int i = 0; i < RowRange; i++)
            {
                IRow cells = sheet.GetRow(i);
                if (cells != null)
                {
                    int ColumnRange = sheet.GetRow(i).LastCellNum;
                    for (int j = 0; j < ColumnRange; j++)
                    {
                        if (cells.GetCell(j) != null && cells.GetCell(j).ToString() == str)
                        {
                            return new int[2] { i, j };
                        }
                    }
                }
                    
            }
            return new int[2] {0, 0};
        }

        /// <summary>
        /// 获取合并单元格位置
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="cellname">单元格内容</param>
        /// <returns></returns>
        public int[] GetMerGedRegionRange(ISheet sheet, string cellname)
        {
            for (int i = 0; i < sheet.NumMergedRegions; i++)
            {
                var cellrange = sheet.GetMergedRegion(i);
                if (sheet.GetRow(cellrange.FirstRow).GetCell(cellrange.FirstColumn).ToString() == cellname)
                {
                    return new int[] { cellrange.FirstRow, cellrange.FirstColumn, cellrange.LastRow, cellrange.LastColumn};
                }
                //Console.WriteLine(cellrange.FirstColumn + " " + cellrange.FirstRow + " " + cellrange.LastColumn + " " + cellrange.LastRow);
            }

            return new int[] { 0, 0, 0, 0 }; 
        }

        /// <summary>
        /// 获取广播类型
        /// </summary>
        /// <param name="cellname">单元格内容</param>
        /// <returns></returns>
        public int GetNoticeType(string cellname)
        {
            if (cellname == "全服广播")
                return 1;
            else if (cellname == "地图广播")
                return 2;
            else
                return 3;
        }

    }

