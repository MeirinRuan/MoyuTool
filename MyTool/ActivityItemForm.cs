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
    public partial class ActivityItemForm : Form
    {
        public ActivityItemForm()
        {
            InitializeComponent();
        }

        private void ActivityItemForm_Load(object sender, EventArgs e)
        {

        }

        private void ActivityItemForm_MouseClick(object sender, MouseEventArgs e)
        {
            Form form = sender as Form;
            MyRegularExpression mre = new MyRegularExpression();


            //Console.WriteLine(form.Tag);
        }
    }
}
