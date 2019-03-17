using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    eo.OpenExcel(openFileDialog1.FileName);
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
            //表格索引
            int SheetIndex = Convert.ToInt32(sheetindex_textBox.Text);
            string TableNameIndex = tablename_textBox.Text;

            if (eo.wb.Worksheets[SheetIndex] == null)
            {
                MessageBox.Show("不存在该sheet。");
                return;
            }

            //生成
            eo.CreateInsertSql(eo.wb.Worksheets[SheetIndex], SheetIndex.ToString(), TableNameIndex);

           // eo.CreateUpdateSql(eo.wb.Worksheets[1], ExcelRangeStart, ExcelRangeEnd, ExcelSetStart, ExcelSetEnd, UpdateStr, SetFieldStr, WhereFieldStr);
        }

    }
}
