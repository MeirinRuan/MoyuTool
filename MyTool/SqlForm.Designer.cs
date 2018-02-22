namespace MyTool
{
    partial class SqlForm
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
            this.SqlDatabase_ListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FileText_textBox
            // 
            this.FileText_textBox.AllowDrop = true;
            this.FileText_textBox.Location = new System.Drawing.Point(12, 290);
            this.FileText_textBox.Multiline = true;
            this.FileText_textBox.Name = "FileText_textBox";
            this.FileText_textBox.Size = new System.Drawing.Size(486, 121);
            this.FileText_textBox.TabIndex = 1;
            this.FileText_textBox.Text = "把sql文件拖进来";
            this.FileText_textBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileText_textBox_DragDrop);
            this.FileText_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileText_textBox_KeyDown);
            // 
            // SqlDatabase_ListBox
            // 
            this.SqlDatabase_ListBox.FormattingEnabled = true;
            this.SqlDatabase_ListBox.ItemHeight = 12;
            this.SqlDatabase_ListBox.Location = new System.Drawing.Point(12, 28);
            this.SqlDatabase_ListBox.Name = "SqlDatabase_ListBox";
            this.SqlDatabase_ListBox.Size = new System.Drawing.Size(138, 256);
            this.SqlDatabase_ListBox.TabIndex = 3;
            this.SqlDatabase_ListBox.SelectedIndexChanged += new System.EventHandler(this.SqlDatabase_ListBox_SelectedIndexChanged);
            this.SqlDatabase_ListBox.DoubleClick += new System.EventHandler(this.SqlDatabase_ListBox_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "数据库选择";
            // 
            // SqlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 423);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SqlDatabase_ListBox);
            this.Controls.Add(this.FileText_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SqlForm";
            this.Text = "sql字段检测";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileText_textBox_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileText_textBox;
        private System.Windows.Forms.ListBox SqlDatabase_ListBox;
        private System.Windows.Forms.Label label1;
    }
}