﻿namespace MyTool
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
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
            this.TypeList_comboBox.Location = new System.Drawing.Point(13, 98);
            this.TypeList_comboBox.Name = "TypeList_comboBox";
            this.TypeList_comboBox.Size = new System.Drawing.Size(113, 394);
            this.TypeList_comboBox.TabIndex = 1;
            // 
            // Activity_flowLayoutPanel
            // 
            this.Activity_flowLayoutPanel.Location = new System.Drawing.Point(172, 98);
            this.Activity_flowLayoutPanel.Name = "Activity_flowLayoutPanel";
            this.Activity_flowLayoutPanel.Size = new System.Drawing.Size(724, 380);
            this.Activity_flowLayoutPanel.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 505);
            this.Controls.Add(this.Activity_flowLayoutPanel);
            this.Controls.Add(this.TypeList_comboBox);
            this.Controls.Add(this.ReadFile_button);
            this.Name = "ActivityForm";
            this.Text = "火爆活动配置";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ReadFile_button;
        private System.Windows.Forms.ComboBox TypeList_comboBox;
        private System.Windows.Forms.FlowLayoutPanel Activity_flowLayoutPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}