using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MyTool
{
    public partial class InsertSqlExcel : Form
    {
        ExcelOpration eo = new ExcelOpration();

        public InsertSqlExcel()
        {
            InitializeComponent();
        }

        private void InsertSqlExcel_Load(object sender, EventArgs e)
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
                    FileStream fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read,FileShare.ReadWrite);
                    eo.OpenExcel(fileStream, openFileDialog1.FileName);
                    MessageBox.Show("打开excel成功。");
                }
                else
                {
                    MessageBox.Show("请打开excel。");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();


            //表格索引
            int SheetIndex = Convert.ToInt32(sheetindex_textBox.Text) - 1;
            string TableNameIndex = tablename_textBox.Text;

            //if (eo.wb.Worksheets[SheetIndex] == null)
            //{
            //    MessageBox.Show("不存在该sheet。");
            //    return;
            //}

            if (eo.workbook == null)
            {
                MessageBox.Show("不存在该工作簿。");
                return;
            }

            eo.sheet = eo.workbook.GetSheetAt(SheetIndex);

            if (eo.sheet == null)
            {
                MessageBox.Show("不存在该sheet。");
                return;
            }

            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            //eo.ws = eo.wb.Worksheets[SheetIndex];

            string TableNameColumnStart = TableNameIndex.Substring(0, 1).ToUpper();
            int TableNameColumnEnd = Convert.ToInt32(TableNameIndex.Substring(1)) - 1;

            //string TableName = eo.ws.Cells[TableNameColumnEnd, TableNameColumnStart].Text;

            string TableName = eo.sheet.GetRow(TableNameColumnEnd).GetCell(eo.ToIndex(TableNameColumnStart)).ToString();

            //表字段起始位置
            int TableValueColumn = TableNameColumnEnd + 1;
            //int Length = eo.GetRowLength(eo.ws, TableValueColumn);
            int Length = eo.sheet.GetRow(TableValueColumn).LastCellNum;
            List<string> TableField = eo.GetRowValues(eo.sheet, TableValueColumn);

            string Str = "Insert Into " + TableName + " (" + string.Join(",", TableField) + ")Values\r\n";

            progressBar1.Value += 10;

            //表字段值
            int ValueStartIndex = TableNameColumnEnd + 3;
            List<List<string>> ValueList = new List<List<string>>();

            //行数
            //int Rows = eo.ws.UsedRange.Rows.Count - ValueStartIndex + 1;
            int Rows = eo.sheet.LastRowNum - ValueStartIndex + 1;

            progressBar1.Value += 5;

            int CurValue = 80;
            int CurStep = 1;


            //试着开个线程
            //int startindex, int RowLength, int ValueStartIndex, int TableFieldCount
            int startindex = 0;
            int RowLength1 = 0;
            int RowLength2 = 0;
            //int valuestartindex = ValueStartIndex;
            //int tablefieldcount = TableField.Count;

            //超过1000行，对半处理
            if (Rows >= 1000)
            {
                startindex = Rows / 2;
                RowLength1 = startindex;
                RowLength2 = Rows;

                Func<int, int, int, int, List<List<string>>> t1 = ThreadGetValueList;
                Func<int, int, int, int, List<List<string>>> t2 = ThreadGetValueList;

                IAsyncResult result1 = t1.BeginInvoke(0, RowLength1, ValueStartIndex, TableField.Count, null, null);
                IAsyncResult result2 = t2.BeginInvoke(startindex, RowLength2, ValueStartIndex, TableField.Count, null, null);
                List<List<string>> valuelist1 = t1.EndInvoke(result1);
                List<List<string>> valuelist2 = t2.EndInvoke(result2);

                valuelist1.AddRange(valuelist2);

                ValueList = valuelist1;
            }
            else
            {
                RowLength1 = Rows;
                for (int i = 0; i < RowLength1; i++)
                {
                    List<string> values = eo.GetRowValues(eo.sheet, i + ValueStartIndex, TableField.Count);
                    ValueList.Add(values);

                }
            }

            

            progressBar1.Value = 95;
            CurValue = 5;
            CurStep = 1;

            

            //获取每一行的数据
            for (int index = 0; index < ValueList.Count; index++)
            {
                if (index == ValueList.Count - 1)
                {
                    Str += "(" + string.Join(",", ValueList[index]) + ");\r\n\r\n";
                }
                else
                {
                    Str += "(" + string.Join(",", ValueList[index]) + "),\r\n";
                }
                if (index == Math.Ceiling(Convert.ToDecimal((CurStep / CurValue) * Rows)))
                {
                    progressBar1.Value += 1;
                    CurStep++;
                }
            }

            stopwatch.Stop();

            //桌面路径
            string Deskdir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            File.WriteAllText(@Deskdir + "\\SQL.sql", Str);
            Process.Start(Deskdir);
            

            progressBar1.Value = progressBar1.Maximum;

            MessageBox.Show("导出成功，已在桌面生成。\r\n总耗时：" + stopwatch.Elapsed.TotalSeconds);

            

            //生成
            //eo.CreateInsertSql(eo.wb.Worksheets[SheetIndex], SheetIndex.ToString(), TableNameIndex);

            //eo.CreateUpdateSql(eo.wb.Worksheets[1], ExcelRangeStart, ExcelRangeEnd, ExcelSetStart, ExcelSetEnd, UpdateStr, SetFieldStr, WhereFieldStr);
        }

        /// <summary>
        /// 开启线程执行
        /// </summary>
        public List<List<string>> ThreadGetValueList(int startindex, int RowLength, int ValueStartIndex, int TableFieldCount)
        {
            
            List<List<string>> valuelist = new List<List<string>>();
            for (int i = startindex; i < RowLength; i++)
            {
                List<string> values = eo.GetRowValues(eo.sheet, i + ValueStartIndex, TableFieldCount);
                valuelist.Add(values);
                Console.WriteLine("i:" + i);
            }

            return valuelist;
        }

    }
}
