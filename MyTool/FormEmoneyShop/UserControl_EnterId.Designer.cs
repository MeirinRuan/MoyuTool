namespace MyTool.FormEmoneyShop
{
    partial class UserControl_EnterId
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox_itemtype = new System.Windows.Forms.TextBox();
            this.label_itemtype = new System.Windows.Forms.Label();
            this.textBox_goods = new System.Windows.Forms.TextBox();
            this.label_goods = new System.Windows.Forms.Label();
            this.label_begintime = new System.Windows.Forms.Label();
            this.label_endtime = new System.Windows.Forms.Label();
            this.dateTimePicker_begintime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endtime = new System.Windows.Forms.DateTimePicker();
            this.label_onspnedflag = new System.Windows.Forms.Label();
            this.checkBox_onspend = new System.Windows.Forms.CheckBox();
            this.comboBox_paytype = new System.Windows.Forms.ComboBox();
            this.label_paytype = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox_shoptype = new System.Windows.Forms.ComboBox();
            this.label_shoptype = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_itemtype
            // 
            this.textBox_itemtype.Location = new System.Drawing.Point(93, 3);
            this.textBox_itemtype.Name = "textBox_itemtype";
            this.textBox_itemtype.Size = new System.Drawing.Size(124, 21);
            this.textBox_itemtype.TabIndex = 4;
            this.textBox_itemtype.Validated += new System.EventHandler(this.textBox_itemtype_Validated);
            // 
            // label_itemtype
            // 
            this.label_itemtype.AutoSize = true;
            this.label_itemtype.Location = new System.Drawing.Point(4, 6);
            this.label_itemtype.Name = "label_itemtype";
            this.label_itemtype.Size = new System.Drawing.Size(83, 12);
            this.label_itemtype.TabIndex = 5;
            this.label_itemtype.Text = "物品itemtype:";
            // 
            // textBox_goods
            // 
            this.textBox_goods.Location = new System.Drawing.Point(93, 29);
            this.textBox_goods.Name = "textBox_goods";
            this.textBox_goods.Size = new System.Drawing.Size(124, 21);
            this.textBox_goods.TabIndex = 6;
            this.textBox_goods.Validated += new System.EventHandler(this.textBox_goods_Validated);
            // 
            // label_goods
            // 
            this.label_goods.AutoSize = true;
            this.label_goods.Location = new System.Drawing.Point(4, 32);
            this.label_goods.Name = "label_goods";
            this.label_goods.Size = new System.Drawing.Size(83, 12);
            this.label_goods.TabIndex = 3;
            this.label_goods.Text = "cq_goods表id:";
            // 
            // label_begintime
            // 
            this.label_begintime.AutoSize = true;
            this.label_begintime.Location = new System.Drawing.Point(28, 62);
            this.label_begintime.Name = "label_begintime";
            this.label_begintime.Size = new System.Drawing.Size(59, 12);
            this.label_begintime.TabIndex = 7;
            this.label_begintime.Text = "起始时间:";
            // 
            // label_endtime
            // 
            this.label_endtime.AutoSize = true;
            this.label_endtime.Location = new System.Drawing.Point(28, 89);
            this.label_endtime.Name = "label_endtime";
            this.label_endtime.Size = new System.Drawing.Size(59, 12);
            this.label_endtime.TabIndex = 9;
            this.label_endtime.Text = "结束时间:";
            // 
            // dateTimePicker_begintime
            // 
            this.dateTimePicker_begintime.CustomFormat = "yyMMddHHmm";
            this.dateTimePicker_begintime.Location = new System.Drawing.Point(93, 56);
            this.dateTimePicker_begintime.Name = "dateTimePicker_begintime";
            this.dateTimePicker_begintime.Size = new System.Drawing.Size(124, 21);
            this.dateTimePicker_begintime.TabIndex = 11;
            this.toolTip.SetToolTip(this.dateTimePicker_begintime, "无时间限制不需要修改此项");
            this.dateTimePicker_begintime.ValueChanged += new System.EventHandler(this.dateTimePicker_begintime_ValueChanged);
            // 
            // dateTimePicker_endtime
            // 
            this.dateTimePicker_endtime.CustomFormat = "yyMMddHHmm";
            this.dateTimePicker_endtime.Location = new System.Drawing.Point(93, 83);
            this.dateTimePicker_endtime.Name = "dateTimePicker_endtime";
            this.dateTimePicker_endtime.Size = new System.Drawing.Size(124, 21);
            this.dateTimePicker_endtime.TabIndex = 12;
            this.toolTip.SetToolTip(this.dateTimePicker_endtime, "无时间限制不需要修改此项");
            this.dateTimePicker_endtime.ValueChanged += new System.EventHandler(this.dateTimePicker_endtime_ValueChanged);
            // 
            // label_onspnedflag
            // 
            this.label_onspnedflag.AutoSize = true;
            this.label_onspnedflag.Location = new System.Drawing.Point(4, 113);
            this.label_onspnedflag.Name = "label_onspnedflag";
            this.label_onspnedflag.Size = new System.Drawing.Size(83, 12);
            this.label_onspnedflag.TabIndex = 13;
            this.label_onspnedflag.Text = "是否计入累消:";
            // 
            // checkBox_onspend
            // 
            this.checkBox_onspend.AutoSize = true;
            this.checkBox_onspend.Location = new System.Drawing.Point(93, 113);
            this.checkBox_onspend.Name = "checkBox_onspend";
            this.checkBox_onspend.Size = new System.Drawing.Size(15, 14);
            this.checkBox_onspend.TabIndex = 14;
            this.checkBox_onspend.UseVisualStyleBackColor = true;
            // 
            // comboBox_paytype
            // 
            this.comboBox_paytype.FormattingEnabled = true;
            this.comboBox_paytype.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBox_paytype.Location = new System.Drawing.Point(179, 110);
            this.comboBox_paytype.Name = "comboBox_paytype";
            this.comboBox_paytype.Size = new System.Drawing.Size(38, 20);
            this.comboBox_paytype.TabIndex = 15;
            this.toolTip.SetToolTip(this.comboBox_paytype, "1魔石2绑魔3全部");
            // 
            // label_paytype
            // 
            this.label_paytype.AutoSize = true;
            this.label_paytype.Location = new System.Drawing.Point(114, 113);
            this.label_paytype.Name = "label_paytype";
            this.label_paytype.Size = new System.Drawing.Size(59, 12);
            this.label_paytype.TabIndex = 16;
            this.label_paytype.Text = "消费类型:";
            // 
            // comboBox_shoptype
            // 
            this.comboBox_shoptype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_shoptype.FormattingEnabled = true;
            this.comboBox_shoptype.Location = new System.Drawing.Point(93, 137);
            this.comboBox_shoptype.Name = "comboBox_shoptype";
            this.comboBox_shoptype.Size = new System.Drawing.Size(121, 20);
            this.comboBox_shoptype.TabIndex = 17;
            // 
            // label_shoptype
            // 
            this.label_shoptype.AutoSize = true;
            this.label_shoptype.Location = new System.Drawing.Point(4, 140);
            this.label_shoptype.Name = "label_shoptype";
            this.label_shoptype.Size = new System.Drawing.Size(59, 12);
            this.label_shoptype.TabIndex = 18;
            this.label_shoptype.Text = "商店分类:";
            // 
            // UserControl_EnterId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label_shoptype);
            this.Controls.Add(this.comboBox_shoptype);
            this.Controls.Add(this.label_paytype);
            this.Controls.Add(this.comboBox_paytype);
            this.Controls.Add(this.checkBox_onspend);
            this.Controls.Add(this.label_onspnedflag);
            this.Controls.Add(this.dateTimePicker_endtime);
            this.Controls.Add(this.dateTimePicker_begintime);
            this.Controls.Add(this.label_endtime);
            this.Controls.Add(this.label_begintime);
            this.Controls.Add(this.textBox_itemtype);
            this.Controls.Add(this.label_itemtype);
            this.Controls.Add(this.textBox_goods);
            this.Controls.Add(this.label_goods);
            this.Name = "UserControl_EnterId";
            this.Size = new System.Drawing.Size(220, 167);
            this.Load += new System.EventHandler(this.UserControl_EnterId_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_itemtype;
        private System.Windows.Forms.Label label_itemtype;
        private System.Windows.Forms.TextBox textBox_goods;
        private System.Windows.Forms.Label label_goods;
        private System.Windows.Forms.Label label_begintime;
        private System.Windows.Forms.Label label_endtime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_begintime;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endtime;
        private System.Windows.Forms.Label label_onspnedflag;
        private System.Windows.Forms.CheckBox checkBox_onspend;
        private System.Windows.Forms.ComboBox comboBox_paytype;
        private System.Windows.Forms.Label label_paytype;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox comboBox_shoptype;
        private System.Windows.Forms.Label label_shoptype;
    }
}
