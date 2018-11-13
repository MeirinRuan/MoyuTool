namespace MyTool
{
    partial class ActivityForm
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
            this.ReadFile_button = new System.Windows.Forms.Button();
            this.TypeList_comboBox = new System.Windows.Forms.ComboBox();
            this.Activity_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ActivityList_tableLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Main_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Activity_flowLayoutPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReadFile_button
            // 
            this.ReadFile_button.Location = new System.Drawing.Point(13, 13);
            this.ReadFile_button.Name = "ReadFile_button";
            this.ReadFile_button.Size = new System.Drawing.Size(113, 63);
            this.ReadFile_button.TabIndex = 0;
            this.ReadFile_button.Text = "读取配置文件";
            this.ReadFile_button.UseVisualStyleBackColor = true;
            this.ReadFile_button.Click += new System.EventHandler(this.ReadFile_button_Click);
            // 
            // TypeList_comboBox
            // 
            this.TypeList_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.TypeList_comboBox.FormattingEnabled = true;
            this.TypeList_comboBox.Location = new System.Drawing.Point(4, 14);
            this.TypeList_comboBox.Name = "TypeList_comboBox";
            this.TypeList_comboBox.Size = new System.Drawing.Size(113, 441);
            this.TypeList_comboBox.TabIndex = 1;
            this.TypeList_comboBox.SelectedIndexChanged += new System.EventHandler(this.TypeList_comboBox_SelectedIndexChanged);
            // 
            // Activity_flowLayoutPanel
            // 
            this.Activity_flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Activity_flowLayoutPanel.Controls.Add(this.ActivityList_tableLayoutPanel);
            this.Activity_flowLayoutPanel.Controls.Add(this.Main_flowLayoutPanel);
            this.Activity_flowLayoutPanel.Location = new System.Drawing.Point(169, 98);
            this.Activity_flowLayoutPanel.Name = "Activity_flowLayoutPanel";
            this.Activity_flowLayoutPanel.Size = new System.Drawing.Size(861, 443);
            this.Activity_flowLayoutPanel.TabIndex = 2;
            // 
            // ActivityList_tableLayoutPanel
            // 
            this.ActivityList_tableLayoutPanel.AutoScroll = true;
            this.ActivityList_tableLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ActivityList_tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.ActivityList_tableLayoutPanel.Name = "ActivityList_tableLayoutPanel";
            this.ActivityList_tableLayoutPanel.Size = new System.Drawing.Size(224, 437);
            this.ActivityList_tableLayoutPanel.TabIndex = 0;
            // 
            // Main_flowLayoutPanel
            // 
            this.Main_flowLayoutPanel.AutoScroll = true;
            this.Main_flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Main_flowLayoutPanel.Location = new System.Drawing.Point(233, 3);
            this.Main_flowLayoutPanel.Name = "Main_flowLayoutPanel";
            this.Main_flowLayoutPanel.Size = new System.Drawing.Size(616, 439);
            this.Main_flowLayoutPanel.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TypeList_comboBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 457);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "活动索引列表";
            // 
            // ActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 553);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Activity_flowLayoutPanel);
            this.Controls.Add(this.ReadFile_button);
            this.Name = "ActivityForm";
            this.Text = "火爆活动配置";
            this.Load += new System.EventHandler(this.ActivityForm_Load);
            this.Activity_flowLayoutPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReadFile_button;
        private System.Windows.Forms.ComboBox TypeList_comboBox;
        private System.Windows.Forms.FlowLayoutPanel Activity_flowLayoutPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel Main_flowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel ActivityList_tableLayoutPanel;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}