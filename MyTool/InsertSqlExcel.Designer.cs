namespace MyTool
{
    partial class InsertSqlExcel
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.sheetindex_textBox = new System.Windows.Forms.TextBox();
            this.sheetindex_groupBox = new System.Windows.Forms.GroupBox();
            this.tablename_textBox = new System.Windows.Forms.TextBox();
            this.tablename_groupBox = new System.Windows.Forms.GroupBox();
            this.sheetindex_groupBox.SuspendLayout();
            this.tablename_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 122);
            this.button2.TabIndex = 9;
            this.button2.Text = "生成";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 121);
            this.button1.TabIndex = 8;
            this.button1.Text = "打开Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // sheetindex_textBox
            // 
            this.sheetindex_textBox.Location = new System.Drawing.Point(6, 20);
            this.sheetindex_textBox.Name = "sheetindex_textBox";
            this.sheetindex_textBox.Size = new System.Drawing.Size(100, 21);
            this.sheetindex_textBox.TabIndex = 10;
            // 
            // sheetindex_groupBox
            // 
            this.sheetindex_groupBox.Controls.Add(this.sheetindex_textBox);
            this.sheetindex_groupBox.Location = new System.Drawing.Point(183, 12);
            this.sheetindex_groupBox.Name = "sheetindex_groupBox";
            this.sheetindex_groupBox.Size = new System.Drawing.Size(121, 54);
            this.sheetindex_groupBox.TabIndex = 11;
            this.sheetindex_groupBox.TabStop = false;
            this.sheetindex_groupBox.Text = "输入sheet索引";
            // 
            // tablename_textBox
            // 
            this.tablename_textBox.Location = new System.Drawing.Point(6, 20);
            this.tablename_textBox.Name = "tablename_textBox";
            this.tablename_textBox.Size = new System.Drawing.Size(147, 21);
            this.tablename_textBox.TabIndex = 10;
            // 
            // tablename_groupBox
            // 
            this.tablename_groupBox.Controls.Add(this.tablename_textBox);
            this.tablename_groupBox.Location = new System.Drawing.Point(330, 12);
            this.tablename_groupBox.Name = "tablename_groupBox";
            this.tablename_groupBox.Size = new System.Drawing.Size(170, 54);
            this.tablename_groupBox.TabIndex = 12;
            this.tablename_groupBox.TabStop = false;
            this.tablename_groupBox.Text = "输入sql表所在表格位置";
            // 
            // InsertSqlExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 279);
            this.Controls.Add(this.tablename_groupBox);
            this.Controls.Add(this.sheetindex_groupBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "InsertSqlExcel";
            this.Text = "InsertSqlExcel";
            this.Load += new System.EventHandler(this.InsertSqlExcel_Load);
            this.sheetindex_groupBox.ResumeLayout(false);
            this.sheetindex_groupBox.PerformLayout();
            this.tablename_groupBox.ResumeLayout(false);
            this.tablename_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox sheetindex_textBox;
        private System.Windows.Forms.GroupBox sheetindex_groupBox;
        private System.Windows.Forms.TextBox tablename_textBox;
        private System.Windows.Forms.GroupBox tablename_groupBox;
    }
}