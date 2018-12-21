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
    public partial class ActivityItemDetailForm : Form
    {
        public string[] DetailTime;

        public ActivityItemDetailForm()
        {
            InitializeComponent();
        }

        private void ActivityItemDetailForm_Load(object sender, EventArgs e)
        {
            Time_label.Text = "活动时间： " + DetailTime[0] + " - " + DetailTime[1];
        }
    }
}
