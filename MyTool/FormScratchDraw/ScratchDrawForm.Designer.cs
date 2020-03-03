namespace MyTool
{
    partial class ScratchDrawForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LuaDataType_textBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TaskId_textBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LogId_textBox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.LogId_XSJ_textBox = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LuaDataType_textBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LuaDataType";
            // 
            // LuaDataType_textBox
            // 
            this.LuaDataType_textBox.Location = new System.Drawing.Point(7, 20);
            this.LuaDataType_textBox.Name = "LuaDataType_textBox";
            this.LuaDataType_textBox.Size = new System.Drawing.Size(101, 21);
            this.LuaDataType_textBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TaskId_textBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 58);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "掩码id";
            this.toolTip1.SetToolTip(this.groupBox2, "需要申请5个掩码id，填入起始id即可");
            // 
            // TaskId_textBox
            // 
            this.TaskId_textBox.Location = new System.Drawing.Point(7, 21);
            this.TaskId_textBox.Name = "TaskId_textBox";
            this.TaskId_textBox.Size = new System.Drawing.Size(101, 21);
            this.TaskId_textBox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Location = new System.Drawing.Point(13, 222);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(114, 120);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "LogId";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LogId_textBox);
            this.groupBox5.Location = new System.Drawing.Point(6, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(101, 45);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "官方log";
            // 
            // LogId_textBox
            // 
            this.LogId_textBox.Location = new System.Drawing.Point(6, 17);
            this.LogId_textBox.Name = "LogId_textBox";
            this.LogId_textBox.Size = new System.Drawing.Size(89, 21);
            this.LogId_textBox.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.LogId_XSJ_textBox);
            this.groupBox4.Location = new System.Drawing.Point(7, 71);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(101, 43);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "西山居log";
            // 
            // LogId_XSJ_textBox
            // 
            this.LogId_XSJ_textBox.Location = new System.Drawing.Point(6, 16);
            this.LogId_XSJ_textBox.Name = "LogId_XSJ_textBox";
            this.LogId_XSJ_textBox.Size = new System.Drawing.Size(89, 21);
            this.LogId_XSJ_textBox.TabIndex = 5;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 354);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(674, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 56);
            this.button2.TabIndex = 5;
            this.button2.Text = "生成";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ScratchDrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 376);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScratchDrawForm";
            this.Text = "刮刮卡抽奖模板生成";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox LuaDataType_textBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TaskId_textBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox LogId_textBox;
        private System.Windows.Forms.TextBox LogId_XSJ_textBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button button2;
    }
}