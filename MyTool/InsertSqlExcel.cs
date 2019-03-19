using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

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
                    FileStream fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
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
            int SheetIndex = Convert.ToInt32(sheetindex_textBox.Text);
            string TableNameIndex = tablename_textBox.Text;

            if (eo.wb.Worksheets[SheetIndex] == null)
            {
                MessageBox.Show("不存在该sheet。");
                return;
            }

            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            progressBar1.Step = 1;

            eo.ws = eo.wb.Worksheets[SheetIndex];

            string TableNameColumnStart = TableNameIndex.Substring(0, 1).ToUpper();
            int TableNameColumnEnd = Convert.ToInt32(TableNameIndex.Substring(1));

            string TableName = eo.ws.Cells[TableNameColumnEnd, TableNameColumnStart].Text;

            //表字段起始位置
            int TableValueColumn = TableNameColumnEnd + 1;
            int Length = eo.GetRowLength(eo.ws, TableValueColumn);
            List<string> TableValue = eo.GetRowValues(eo.ws, TableValueColumn, Length);

            string Str = "Insert Into " + TableName + " (" + string.Join(",", TableValue) + ")Values\r\n";

            progressBar1.Value += 10;

            //表字段值
            int ValueStartIndex = TableNameColumnEnd + 3;
            List<List<string>> ValueList = new List<List<string>>();

            //行数
            int Rows = eo.ws.UsedRange.Rows.Count - ValueStartIndex + 1;

            progressBar1.Value += 5;

            int CurValue = 35;
            int CurStep = 1;
            for (int i = 0; i < Rows; i++)
            {
                List<string> values = eo.GetRowValues(eo.ws, i + ValueStartIndex, Length, true);
                ValueList.Add(values);
                
                if ( i == Math.Ceiling(Convert.ToDecimal((CurStep / CurValue) * Rows)))
                {
                    progressBar1.Value += 1;
                    CurStep++;
                }
            }

            CurValue = 50;
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

            MessageBox.Show("导出成功，已在桌面生成，耗时：" + stopwatch.Elapsed);


            //生成
            //eo.CreateInsertSql(eo.wb.Worksheets[SheetIndex], SheetIndex.ToString(), TableNameIndex);

            //eo.CreateUpdateSql(eo.wb.Worksheets[1], ExcelRangeStart, ExcelRangeEnd, ExcelSetStart, ExcelSetEnd, UpdateStr, SetFieldStr, WhereFieldStr);
        }

    }
}
