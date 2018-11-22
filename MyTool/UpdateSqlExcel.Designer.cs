namespace MyTool
{
    partial class UpdateSqlExcel
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
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Update_textBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExcelEndSet_textBox = new System.Windows.Forms.TextBox();
            this.ExcelStartSet_textBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ExcelEndRange_textBox = new System.Windows.Forms.TextBox();
            this.ExcelStartRange_textBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(339, 148);
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
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.Update_textBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 70);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "update语句";
            // 
            // Update_textBox
            // 
            this.Update_textBox.Location = new System.Drawing.Point(7, 29);
            this.Update_textBox.Name = "Update_textBox";
            this.Update_textBox.Size = new System.Drawing.Size(326, 21);
            this.Update_textBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.ExcelEndSet_textBox);
            this.groupBox2.Controls.Add(this.ExcelStartSet_textBox);
            this.groupBox2.Location = new System.Drawing.Point(369, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 70);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "更新起始行列";
            // 
            // ExcelEndSet_textBox
            // 
            this.ExcelEndSet_textBox.Location = new System.Drawing.Point(6, 39);
            this.ExcelEndSet_textBox.Name = "ExcelEndSet_textBox";
            this.ExcelEndSet_textBox.Size = new System.Drawing.Size(108, 21);
            this.ExcelEndSet_textBox.TabIndex = 9;
            // 
            // ExcelStartSet_textBox
            // 
            this.ExcelStartSet_textBox.Location = new System.Drawing.Point(6, 12);
            this.ExcelStartSet_textBox.Name = "ExcelStartSet_textBox";
            this.ExcelStartSet_textBox.Size = new System.Drawing.Size(108, 21);
            this.ExcelStartSet_textBox.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.ExcelEndRange_textBox);
            this.groupBox3.Controls.Add(this.ExcelStartRange_textBox);
            this.groupBox3.Location = new System.Drawing.Point(510, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 70);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "条件起始行列";
            // 
            // ExcelEndRange_textBox
            // 
            this.ExcelEndRange_textBox.Location = new System.Drawing.Point(6, 39);
            this.ExcelEndRange_textBox.Name = "ExcelEndRange_textBox";
            this.ExcelEndRange_textBox.Size = new System.Drawing.Size(108, 21);
            this.ExcelEndRange_textBox.TabIndex = 9;
            // 
            // ExcelStartRange_textBox
            // 
            this.ExcelStartRange_textBox.Location = new System.Drawing.Point(6, 12);
            this.ExcelStartRange_textBox.Name = "ExcelStartRange_textBox";
            this.ExcelStartRange_textBox.Size = new System.Drawing.Size(108, 21);
            this.ExcelStartRange_textBox.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(369, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(255, 149);
            this.button2.TabIndex = 7;
            this.button2.Text = "生成";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // UpdateSqlExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 260);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "UpdateSqlExcel";
            this.Text = "UpdateSqlExcel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Update_textBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ExcelStartSet_textBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox ExcelStartRange_textBox;
        private System.Windows.Forms.TextBox ExcelEndSet_textBox;
        private System.Windows.Forms.TextBox ExcelEndRange_textBox;
        private System.Windows.Forms.Button button2;
    }
}