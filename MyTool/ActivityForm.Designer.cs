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
            this.components = new System.ComponentModel.Container();
            this.ReadFile_button = new System.Windows.Forms.Button();
            this.TypeList_comboBox = new System.Windows.Forms.ComboBox();
            this.Activity_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ActivityList_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Main_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ActivityItem_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ActivityDetail_flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.Activity_flowLayoutPanel.SuspendLayout();
            this.Main_flowLayoutPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
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
            this.TypeList_comboBox.Size = new System.Drawing.Size(113, 513);
            this.TypeList_comboBox.TabIndex = 1;
            this.TypeList_comboBox.SelectedIndexChanged += new System.EventHandler(this.TypeList_comboBox_SelectedIndexChanged);
            // 
            // Activity_flowLayoutPanel
            // 
            this.Activity_flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Activity_flowLayoutPanel.Controls.Add(this.ActivityList_flowLayoutPanel);
            this.Activity_flowLayoutPanel.Controls.Add(this.Main_flowLayoutPanel);
            this.Activity_flowLayoutPanel.Location = new System.Drawing.Point(169, 98);
            this.Activity_flowLayoutPanel.Name = "Activity_flowLayoutPanel";
            this.Activity_flowLayoutPanel.Size = new System.Drawing.Size(861, 508);
            this.Activity_flowLayoutPanel.TabIndex = 2;
            // 
            // ActivityList_flowLayoutPanel
            // 
            this.ActivityList_flowLayoutPanel.AutoScroll = true;
            this.ActivityList_flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ActivityList_flowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.ActivityList_flowLayoutPanel.Name = "ActivityList_flowLayoutPanel";
            this.ActivityList_flowLayoutPanel.Size = new System.Drawing.Size(224, 491);
            this.ActivityList_flowLayoutPanel.TabIndex = 0;
            // 
            // Main_flowLayoutPanel
            // 
            this.Main_flowLayoutPanel.AutoScroll = true;
            this.Main_flowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Main_flowLayoutPanel.Controls.Add(this.ActivityItem_flowLayoutPanel);
            this.Main_flowLayoutPanel.Controls.Add(this.ActivityDetail_flowLayoutPanel);
            this.Main_flowLayoutPanel.Location = new System.Drawing.Point(233, 3);
            this.Main_flowLayoutPanel.Name = "Main_flowLayoutPanel";
            this.Main_flowLayoutPanel.Size = new System.Drawing.Size(616, 491);
            this.Main_flowLayoutPanel.TabIndex = 1;
            this.Main_flowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_flowLayoutPanel_Paint);
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
            this.groupBox1.Size = new System.Drawing.Size(124, 522);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "活动索引列表";
            // 
            // ActivityItem_flowLayoutPanel
            // 
            this.ActivityItem_flowLayoutPanel.AutoScroll = true;
            this.ActivityItem_flowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.ActivityItem_flowLayoutPanel.Name = "ActivityItem_flowLayoutPanel";
            this.ActivityItem_flowLayoutPanel.Size = new System.Drawing.Size(605, 339);
            this.ActivityItem_flowLayoutPanel.TabIndex = 1;
            this.ActivityItem_flowLayoutPanel.WrapContents = false;
            // 
            // ActivityDetail_flowLayoutPanel
            // 
            this.ActivityDetail_flowLayoutPanel.Location = new System.Drawing.Point(3, 348);
            this.ActivityDetail_flowLayoutPanel.Name = "ActivityDetail_flowLayoutPanel";
            this.ActivityDetail_flowLayoutPanel.Size = new System.Drawing.Size(605, 133);
            this.ActivityDetail_flowLayoutPanel.TabIndex = 2;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // ActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 618);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Activity_flowLayoutPanel);
            this.Controls.Add(this.ReadFile_button);
            this.Name = "ActivityForm";
            this.Text = "火爆活动配置";
            this.Load += new System.EventHandler(this.ActivityForm_Load);
            this.Activity_flowLayoutPanel.ResumeLayout(false);
            this.Main_flowLayoutPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReadFile_button;
        private System.Windows.Forms.ComboBox TypeList_comboBox;
        private System.Windows.Forms.FlowLayoutPanel Activity_flowLayoutPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FlowLayoutPanel Main_flowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel ActivityList_flowLayoutPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.FlowLayoutPanel ActivityItem_flowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel ActivityDetail_flowLayoutPanel;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}