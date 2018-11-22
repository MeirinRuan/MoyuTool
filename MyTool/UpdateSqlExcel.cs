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
    public partial class UpdateSqlExcel : Form
    {
        ExcelOpration eo = new ExcelOpration();

        public UpdateSqlExcel()
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
                    eo.OpenExcel(openFileDialog1.FileName);

                }
                else
                {
                    MessageBox.Show("请打开excel。");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string UpdateStr = Update_textBox.Text;
            string ExcelRangeStart = ExcelStartRange_textBox.Text;
            string ExcelRangeEnd = ExcelEndRange_textBox.Text;
            string ExcelSetStart = ExcelStartSet_textBox.Text;
            string ExcelSetEnd = ExcelEndSet_textBox.Text;
            string str = eo.CreateUpdateSql(eo.wb.Worksheets[1], ExcelRangeStart, ExcelRangeEnd, ExcelSetStart, ExcelSetEnd);
        }
    }
}
