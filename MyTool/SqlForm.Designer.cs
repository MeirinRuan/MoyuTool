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
            this.button_output = new System.Windows.Forms.Button();
            this.button_client = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileText_textBox
            // 
            this.FileText_textBox.AllowDrop = true;
            this.FileText_textBox.Location = new System.Drawing.Point(156, 40);
            this.FileText_textBox.Multiline = true;
            this.FileText_textBox.Name = "FileText_textBox";
            this.FileText_textBox.ReadOnly = true;
            this.FileText_textBox.Size = new System.Drawing.Size(342, 244);
            this.FileText_textBox.TabIndex = 1;
            this.FileText_textBox.Text = "把sql文件拖进来";
            this.FileText_textBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileText_textBox_DragDrop);
            this.FileText_textBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileText_textBox_DragEnter);
            this.FileText_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileText_textBox_KeyDown);
            // 
            // SqlDatabase_ListBox
            // 
            this.SqlDatabase_ListBox.FormattingEnabled = true;
            this.SqlDatabase_ListBox.ItemHeight = 12;
            this.SqlDatabase_ListBox.Location = new System.Drawing.Point(12, 40);
            this.SqlDatabase_ListBox.Name = "SqlDatabase_ListBox";
            this.SqlDatabase_ListBox.Size = new System.Drawing.Size(138, 244);
            this.SqlDatabase_ListBox.TabIndex = 3;
            this.SqlDatabase_ListBox.SelectedIndexChanged += new System.EventHandler(this.SqlDatabase_ListBox_SelectedIndexChanged);
            this.SqlDatabase_ListBox.DoubleClick += new System.EventHandler(this.SqlDatabase_ListBox_DoubleClick);
            // 
            // button_output
            // 
            this.button_output.Location = new System.Drawing.Point(12, 290);
            this.button_output.Name = "button_output";
            this.button_output.Size = new System.Drawing.Size(138, 121);
            this.button_output.TabIndex = 5;
            this.button_output.Text = "导出SQL";
            this.button_output.UseVisualStyleBackColor = true;
            this.button_output.Click += new System.EventHandler(this.button_output_Click);
            // 
            // button_client
            // 
            this.button_client.Location = new System.Drawing.Point(156, 290);
            this.button_client.Name = "button_client";
            this.button_client.Size = new System.Drawing.Size(151, 121);
            this.button_client.TabIndex = 6;
            this.button_client.Text = "生成客户端配置";
            this.button_client.UseVisualStyleBackColor = true;
            this.button_client.Click += new System.EventHandler(this.button_client_Click);
            // 
            // SqlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 440);
            this.Controls.Add(this.button_client);
            this.Controls.Add(this.button_output);
            this.Controls.Add(this.SqlDatabase_ListBox);
            this.Controls.Add(this.FileText_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SqlForm";
            this.Text = "平移工具";
            this.Load += new System.EventHandler(this.SqlForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FileText_textBox_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileText_textBox;
        private System.Windows.Forms.ListBox SqlDatabase_ListBox;
        private System.Windows.Forms.Button button_output;
        private System.Windows.Forms.Button button_client;
    }
}