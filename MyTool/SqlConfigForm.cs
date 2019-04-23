using System;
using System.IO;
using System.Windows.Forms;

namespace MyTool
{
    public partial class SqlConfigForm : Form
    {
        IniFiles ini = new IniFiles(Directory.GetCurrentDirectory() + @"\ini\mysqlstatus.ini");
        public SqlConfigForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            

            ini.IniWriteValue("MysqlConfig", "Server", textBox1.Text);
            ini.IniWriteValue("MysqlConfig", "Uid", textBox2.Text);
            ini.IniWriteValue("MysqlConfig", "Pwd", textBox3.Text);
            ini.IniWriteValue("MysqlConfig", "Database", textBox4.Text);

            //textBox2.Text = ini.IniReadValue("MysqlConfig", "Server");

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MySqlOpration mso = new MySqlOpration();

            string[] SqlInitInfo = new string[4]
            {
                ini.IniReadValue("MysqlConfig", "Server"),
                ini.IniReadValue("MysqlConfig", "Uid"),
                ini.IniReadValue("MysqlConfig", "Pwd"),
                ini.IniReadValue("MysqlConfig", "Database"),
            };

            if (ini.ExistINIFile())
            {
                if (mso.MySqlConncet(SqlInitInfo) != null)
                {
                    MessageBox.Show("连接成功!");
                }
                else
                {
                    MessageBox.Show("请先保存配置！");
                }
            }
        }
    }
}
