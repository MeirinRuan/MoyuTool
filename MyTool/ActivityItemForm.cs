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
        public string GamePath;
        public string TaskId;
        public string TableText;

        public ActivityItemForm()
        {
            InitializeComponent();
        }

        private void ActivityItemForm_Load(object sender, EventArgs e)
        {
            Form form = sender as Form;
            MyRegularExpression mre = new MyRegularExpression();
            MyFilesOpration mfo = new MyFilesOpration();
            string ImagePath = mfo.GetImagePathByControl(GamePath, mfo.GetControlText(GamePath), mre.GetTaskListIcoByItem(TableText), 0);

            //设置图标
            if (ImagePath != "")
            {
                //设置button边框样式
                label_activity.BackgroundImage = Image.FromFile(ImagePath);
                label_activity.Height = label_activity.BackgroundImage.Height;
                label_activity.Width = label_activity.BackgroundImage.Width;
            }
            //读取不到图片
            else
            {
                //判断button代表的类型，设置button文字
                label_activity.Text = TaskId;
            }

            //标题文字
            Title_label.Text = mre.GetTaskListTitleByItem(TableText);

            //推荐图标
            if (mre.GetTaskListRecommendByItem(TableText))
            {
                Recommend_label.Visible = true;
            }

            //人数文字
            if (mre.GetTaskListTeamNumStrByItem(TableText) != "")
            {
                TeamNumStr_label.Text = mre.GetTaskListTeamNumStrByItem(TableText);
            }

            //展示物品组


        }

        private void ActivityItemForm_MouseClick(object sender, MouseEventArgs e)
        {
            Form form = sender as Form;

            FlowLayoutPanel ActivityDetail_flowLayoutPanel = (FlowLayoutPanel)form.Parent.Parent.Controls["ActivityDetail_flowLayoutPanel"];
            ActivityDetail_flowLayoutPanel.Controls.Clear();
            
            ActivityItemDetailForm activityItemDetailForm = new ActivityItemDetailForm();
            activityItemDetailForm.TopLevel = false;

            MyRegularExpression mre = new MyRegularExpression();

            //刷新详细信息界面
            string[] DetailTime = mre.GetTaskListDetailTimeByItem(TableText);
            activityItemDetailForm.DetailTime = DetailTime;

            
            ActivityDetail_flowLayoutPanel.Controls.Add(activityItemDetailForm);
            activityItemDetailForm.Show();

        }
    }
}
