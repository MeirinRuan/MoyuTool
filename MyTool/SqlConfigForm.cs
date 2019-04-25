using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MyTool
{
    public partial class SqlConfigForm : Form
    {
        IniFiles ini = new IniFiles(Directory.GetCurrentDirectory() + @"\ini\mysqlconfig.ini");
        string Section = "";

        List<string> Keys = new List<string>()
        {
            "Server",
            "Uid",
            "Pwd",
            "Database",
            "Port",
        };

        List<string> Values = new List<string>(){ };

        public SqlConfigForm()
        {
            InitializeComponent();
        }

        private void SqlConfigForm_Load(object sender, EventArgs e)
        {
            //读取已有配置
            if (ini.ExistINIFile())
            {
                List<string> section = ini.ReadSections();
                if (section.Count <= 0)
                {
                    listBox1.Items.Add("请添加新的配置");
                    listBox1.SetSelected(0, true);
                    return;
                }
                for (int i = 0; i < section.Count; i++)
                {
                    listBox1.Items.Add(section[i]);
                }
                //默认第一个配置的数据即可
                for (int j = 0; j < ini.ReadKeys(section[0]).Count; j++)
                {
                    foreach (Control ctr in Controls)
                    {
                        if (ctr is TextBox && ctr.Name == "textBox" + (j + 1).ToString())
                        {
                            ctr.Text = ini.ReadValues(section[0])[j];
                            break;
                        }
                    }
                }
                textBox7.Text = section[0];
                listBox1.SetSelected(0, true);
            }
            else
            {
                listBox1.Items.Add("请添加新的配置");
                listBox1.SetSelected(0, true);
            }
        }

        //保存
        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox7.Text)
                )
            {
                MessageBox.Show("请填入配置信息。");
                return;
            }

            if (IsConnectSucess())
            {
                SaveConfig();
                MessageBox.Show("保存成功!");
            }
            else
            {
                DialogResult dr = MessageBox.Show("当前配置无法在当前环境连接数据库\n是否保存？", "提示", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    SaveConfig();
                else
                    return;
            }
        }

        //测试连接
        private void Button2_Click(object sender, EventArgs e)
        {
            if (IsConnectSucess())
                MessageBox.Show("连接成功!");
            else
            {
                MessageBox.Show("连接数据库失败！");
                return;
            }
                
        }

        //应用
        private void Button3_Click(object sender, EventArgs e)
        {
            if (ini.ExistINIFile())
            {
                List<string> section = ini.ReadSections();
                if (section.Count <= 0)
                {
                    MessageBox.Show("请先保存至少一个配置！");
                    return;
                }
                if (!section.Contains(listBox1.SelectedItem.ToString()))
                {
                    MessageBox.Show("不存在" + listBox1.SelectedItem.ToString() + "的配置，请先保存！");
                    return;
                }
                //连接成功才能应用
                if (!IsConnectSucess())
                { 
                    MessageBox.Show("连接数据库失败，无法应用当前配置！");
                    return;
                }

                //其他的要变成0
                for (int i = 0; i < section.Count; i++)
                {
                    if (listBox1.SelectedItem.ToString() == section[i])
                        ini.IniWriteValue(listBox1.SelectedItem.ToString(), "Checked", "1");
                    else
                        ini.IniWriteValue(section[i], "Checked", "0");
                }

                MessageBox.Show("已应用当前配置！");
            }
            else
            {
                MessageBox.Show("配置文件不存在，请先保存至少一个配置！");
                return;
            }
            
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Section = listBox1.GetItemText(listBox1.SelectedItem);

            for (int j = 0; j < ini.ReadKeys(Section).Count; j++)
            {
                foreach (Control ctr in Controls)
                {
                    if (ctr is TextBox && ctr.Name == "textBox" + (j + 1).ToString())
                    {
                        ctr.Text = ini.ReadValues(Section)[j];
                        break;
                    }
                }
            }
            textBox7.Text = Section;
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("请添加新的配置");

            listBox1.SetSelected(listBox1.Items.Count-1, true);

            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("请先选中需要删除的配置。");
                return;
            }
            ini.DeleteSection(listBox1.SelectedItem.ToString());

            listBox1.Items.Remove(listBox1.SelectedItem);

            foreach (Control ctr in Controls)
            {
                if (ctr is TextBox)
                {
                    ctr.Text = "";
                }
            }

        }

        /// <summary>
        /// 是否连接成功
        /// </summary>
        /// <returns></returns>
        public bool IsConnectSucess()
        {
            MySqlOpration mso = new MySqlOpration();

            List<string> SqlInitInfo = new List<string>()
            {
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                textBox5.Text,
            };

            if (mso.MySqlConncet(SqlInitInfo) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SaveConfig()
        {
            //写入ini
            Values = new List<string>()
            {
                textBox1.Text,
                textBox2.Text,
                textBox3.Text,
                textBox4.Text,
                textBox5.Text,
            };

            for (int i = 0; i < 5; i++)
            {
                ini.IniWriteValue(textBox7.Text, Keys[i], Values[i]);
            }

            //同时保存到listbox中
            if (listBox1.Items.Count > 0 && listBox1.SelectedItem.ToString() == "请添加新的配置")
                listBox1.Items[listBox1.SelectedIndex] = textBox7.Text;
            else if (listBox1.Items.Contains(textBox7.Text))
            {

            }
            else
            {
                listBox1.Items.Add(textBox7.Text);
            }

            ini.IniWriteValue(textBox7.Text, "Checked", "0");
            listBox1.SetSelected(listBox1.Items.Count - 1, true);
        }

    }
}
