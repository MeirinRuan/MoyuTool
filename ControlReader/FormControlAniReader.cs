using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ControlReader
{
    public partial class FormControlAniReader : Form
    {
        public FormControlAniReader()
        {
            InitializeComponent();
        }

        private void FormControlAniReader_Load(object sender, EventArgs e)
        {
            
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                //control文件路径
                string controlpath = folderBrowserDialog1.SelectedPath + "\\ani\\control.ani";

                if (!File.Exists(controlpath))
                {
                    MessageBox.Show("文件不存在。");
                    return;
                }

                IniFiles controlani = new IniFiles(controlpath);

                List<string> controllist = controlani.ReadSections();

                //读取下注释
                foreach (var v in controllist)
                {
                    
                }

            }
        }
    }
}
