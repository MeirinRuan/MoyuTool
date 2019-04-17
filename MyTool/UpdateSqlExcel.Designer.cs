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
            this.button2 = new System.Windows.Forms.Button();
            this.Update_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExcelStartSet_textBox = new System.Windows.Forms.TextBox();
            this.ExcelEndSet_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SetField_textBox = new System.Windows.Forms.TextBox();
            this.Set_label = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ExcelStartRange_textBox = new System.Windows.Forms.TextBox();
            this.ExcelEndRange_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.WhereField_textBox = new System.Windows.Forms.TextBox();
            this.Where_label = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(345, 148);
            this.button1.TabIndex = 0;
            this.button1.Text = "打开Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(393, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(425, 149);
            this.button2.TabIndex = 7;
            this.button2.Text = "生成";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Update_textBox
            // 
            this.Update_textBox.Location = new System.Drawing.Point(6, 29);
            this.Update_textBox.Name = "Update_textBox";
            this.Update_textBox.Size = new System.Drawing.Size(287, 21);
            this.Update_textBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.Update_textBox);
            this.groupBox1.Location = new System.Drawing.Point(59, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 70);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "update语句";
            // 
            // ExcelStartSet_textBox
            // 
            this.ExcelStartSet_textBox.Location = new System.Drawing.Point(63, 12);
            this.ExcelStartSet_textBox.Name = "ExcelStartSet_textBox";
            this.ExcelStartSet_textBox.Size = new System.Drawing.Size(108, 21);
            this.ExcelStartSet_textBox.TabIndex = 7;
            // 
            // ExcelEndSet_textBox
            // 
            this.ExcelEndSet_textBox.Location = new System.Drawing.Point(63, 39);
            this.ExcelEndSet_textBox.Name = "ExcelEndSet_textBox";
            this.ExcelEndSet_textBox.Size = new System.Drawing.Size(108, 21);
            this.ExcelEndSet_textBox.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "起始格";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "结束格";
            // 
            // SetField_textBox
            // 
            this.SetField_textBox.Location = new System.Drawing.Point(63, 72);
            this.SetField_textBox.Name = "SetField_textBox";
            this.SetField_textBox.Size = new System.Drawing.Size(108, 21);
            this.SetField_textBox.TabIndex = 13;
            // 
            // Set_label
            // 
            this.Set_label.AutoSize = true;
            this.Set_label.Location = new System.Drawing.Point(12, 75);
            this.Set_label.Name = "Set_label";
            this.Set_label.Size = new System.Drawing.Size(29, 12);
            this.Set_label.TabIndex = 14;
            this.Set_label.Text = "字段";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.Set_label);
            this.groupBox2.Controls.Add(this.SetField_textBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.ExcelEndSet_textBox);
            this.groupBox2.Controls.Add(this.ExcelStartSet_textBox);
            this.groupBox2.Location = new System.Drawing.Point(393, 178);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 102);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "更新行列";
            // 
            // ExcelStartRange_textBox
            // 
            this.ExcelStartRange_textBox.Location = new System.Drawing.Point(71, 12);
            this.ExcelStartRange_textBox.Name = "ExcelStartRange_textBox";
            this.ExcelStartRange_textBox.Size = new System.Drawing.Size(108, 21);
            this.ExcelStartRange_textBox.TabIndex = 8;
            // 
            // ExcelEndRange_textBox
            // 
            this.ExcelEndRange_textBox.Location = new System.Drawing.Point(71, 39);
            this.ExcelEndRange_textBox.Name = "ExcelEndRange_textBox";
            this.ExcelEndRange_textBox.Size = new System.Drawing.Size(108, 21);
            this.ExcelEndRange_textBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "起始格";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "结束格";
            // 
            // WhereField_textBox
            // 
            this.WhereField_textBox.Location = new System.Drawing.Point(71, 72);
            this.WhereField_textBox.Name = "WhereField_textBox";
            this.WhereField_textBox.Size = new System.Drawing.Size(108, 21);
            this.WhereField_textBox.TabIndex = 13;
            // 
            // Where_label
            // 
            this.Where_label.AutoSize = true;
            this.Where_label.Location = new System.Drawing.Point(10, 75);
            this.Where_label.Name = "Where_label";
            this.Where_label.Size = new System.Drawing.Size(29, 12);
            this.Where_label.TabIndex = 14;
            this.Where_label.Text = "字段";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.Where_label);
            this.groupBox3.Controls.Add(this.WhereField_textBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.ExcelEndRange_textBox);
            this.groupBox3.Controls.Add(this.ExcelStartRange_textBox);
            this.groupBox3.Location = new System.Drawing.Point(625, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(193, 102);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "条件行列";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "SET";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(584, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "WHERE";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "UPDATE";
            // 
            // UpdateSqlExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 302);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Update_textBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ExcelStartSet_textBox;
        private System.Windows.Forms.TextBox ExcelEndSet_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SetField_textBox;
        private System.Windows.Forms.Label Set_label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ExcelStartRange_textBox;
        private System.Windows.Forms.TextBox ExcelEndRange_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WhereField_textBox;
        private System.Windows.Forms.Label Where_label;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}