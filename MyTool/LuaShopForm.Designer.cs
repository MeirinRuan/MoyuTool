namespace MyTool
{
    partial class LuaShopForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.OpenExcel_button1 = new System.Windows.Forms.Button();
            this.CreateSql_button1 = new System.Windows.Forms.Button();
            this.CreateLua_button2 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Location = new System.Drawing.Point(12, 72);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(676, 255);
            this.textBox1.TabIndex = 0;
            // 
            // OpenExcel_button1
            // 
            this.OpenExcel_button1.Location = new System.Drawing.Point(12, 12);
            this.OpenExcel_button1.Name = "OpenExcel_button1";
            this.OpenExcel_button1.Size = new System.Drawing.Size(101, 24);
            this.OpenExcel_button1.TabIndex = 1;
            this.OpenExcel_button1.Text = "选择Excel文件";
            this.OpenExcel_button1.UseVisualStyleBackColor = true;
            this.OpenExcel_button1.Click += new System.EventHandler(this.OpenExcel_button1_Click);
            // 
            // CreateSql_button1
            // 
            this.CreateSql_button1.Location = new System.Drawing.Point(141, 12);
            this.CreateSql_button1.Name = "CreateSql_button1";
            this.CreateSql_button1.Size = new System.Drawing.Size(107, 24);
            this.CreateSql_button1.TabIndex = 2;
            this.CreateSql_button1.Text = "生成sql代码";
            this.CreateSql_button1.UseVisualStyleBackColor = true;
            this.CreateSql_button1.Click += new System.EventHandler(this.CreateSql_button1_Click);
            // 
            // CreateLua_button2
            // 
            this.CreateLua_button2.Location = new System.Drawing.Point(274, 12);
            this.CreateLua_button2.Name = "CreateLua_button2";
            this.CreateLua_button2.Size = new System.Drawing.Size(85, 24);
            this.CreateLua_button2.TabIndex = 3;
            this.CreateLua_button2.Text = "生成lua代码";
            this.CreateLua_button2.UseVisualStyleBackColor = true;
            this.CreateLua_button2.Click += new System.EventHandler(this.CreateLua_button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FilterIndex = 0;
            // 
            // LuaShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 339);
            this.Controls.Add(this.CreateLua_button2);
            this.Controls.Add(this.CreateSql_button1);
            this.Controls.Add(this.OpenExcel_button1);
            this.Controls.Add(this.textBox1);
            this.Name = "LuaShopForm";
            this.Text = "筹码币商店模板";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button OpenExcel_button1;
        private System.Windows.Forms.Button CreateSql_button1;
        private System.Windows.Forms.Button CreateLua_button2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}