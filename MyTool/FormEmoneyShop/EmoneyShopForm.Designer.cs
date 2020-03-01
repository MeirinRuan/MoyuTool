namespace MyTool
{
    partial class EmoneyShopForm
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
            this.FileText_textBox = new System.Windows.Forms.TextBox();
            this.ReadFile_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileText_textBox
            // 
            this.FileText_textBox.AllowDrop = true;
            this.FileText_textBox.Location = new System.Drawing.Point(277, 12);
            this.FileText_textBox.Multiline = true;
            this.FileText_textBox.Name = "FileText_textBox";
            this.FileText_textBox.ReadOnly = true;
            this.FileText_textBox.Size = new System.Drawing.Size(279, 222);
            this.FileText_textBox.TabIndex = 2;
            this.FileText_textBox.Text = "把sql文件拖进来";
            this.FileText_textBox.TextChanged += new System.EventHandler(this.FileText_textBox_TextChanged);
            // 
            // ReadFile_button
            // 
            this.ReadFile_button.Location = new System.Drawing.Point(158, 12);
            this.ReadFile_button.Name = "ReadFile_button";
            this.ReadFile_button.Size = new System.Drawing.Size(113, 63);
            this.ReadFile_button.TabIndex = 3;
            this.ReadFile_button.Text = "打开客户端路径";
            this.ReadFile_button.UseVisualStyleBackColor = true;
            this.ReadFile_button.Click += new System.EventHandler(this.ReadFile_button_Click);
            // 
            // EmoneyShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 392);
            this.Controls.Add(this.ReadFile_button);
            this.Controls.Add(this.FileText_textBox);
            this.Name = "EmoneyShopForm";
            this.Text = "官方魔石商店生成";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileText_textBox;
        private System.Windows.Forms.Button ReadFile_button;
    }
}