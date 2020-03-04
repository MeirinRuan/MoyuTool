using System;
using System.Windows.Forms;

namespace MyTool
{
    public partial class ActivityItemDetailForm : Form
    {
        //活动时间
        public string[] DetailTime;
        //等级
        public string Level;
        //描述
        public string Description;

        public ActivityItemDetailForm()
        {
            InitializeComponent();
        }

        private void ActivityItemDetailForm_Load(object sender, EventArgs e)
        {
            Time_label.Text = "活动时间： " + DetailTime[0] + " - " + DetailTime[1];
            Level_label.Text = "等级限制：等级≥" + Level;
            Description_textBox.Text = Description;
        }
    }
}
