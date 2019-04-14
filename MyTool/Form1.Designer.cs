namespace MyTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Sql_button = new System.Windows.Forms.Button();
            this.LuaShop_button = new System.Windows.Forms.Button();
            this.TenBox_button = new System.Windows.Forms.Button();
            this.ScratchDraw_button = new System.Windows.Forms.Button();
            this.Activity_button = new System.Windows.Forms.Button();
            this.update_button = new System.Windows.Forms.Button();
            this.insert_button = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupbox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupbox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Sql_button
            // 
            this.Sql_button.Location = new System.Drawing.Point(10, 20);
            this.Sql_button.Name = "Sql_button";
            this.Sql_button.Size = new System.Drawing.Size(86, 72);
            this.Sql_button.TabIndex = 1;
            this.Sql_button.Text = "SQL字段检测补全";
            this.Sql_button.UseVisualStyleBackColor = true;
            this.Sql_button.Click += new System.EventHandler(this.Sql_button_Click);
            // 
            // LuaShop_button
            // 
            this.LuaShop_button.Location = new System.Drawing.Point(98, 20);
            this.LuaShop_button.Name = "LuaShop_button";
            this.LuaShop_button.Size = new System.Drawing.Size(86, 72);
            this.LuaShop_button.TabIndex = 2;
            this.LuaShop_button.Text = "筹码币商店模板生成";
            this.toolTip1.SetToolTip(this.LuaShop_button, "请用中鸣工具");
            this.LuaShop_button.UseVisualStyleBackColor = true;
            this.LuaShop_button.Click += new System.EventHandler(this.LuaShop_button_Click);
            // 
            // TenBox_button
            // 
            this.TenBox_button.Location = new System.Drawing.Point(190, 20);
            this.TenBox_button.Name = "TenBox_button";
            this.TenBox_button.Size = new System.Drawing.Size(86, 72);
            this.TenBox_button.TabIndex = 3;
            this.TenBox_button.Text = "十连抽模板生成";
            this.toolTip1.SetToolTip(this.TenBox_button, "请用中鸣工具");
            this.TenBox_button.UseVisualStyleBackColor = true;
            this.TenBox_button.Click += new System.EventHandler(this.TenBox_button_Click);
            // 
            // ScratchDraw_button
            // 
            this.ScratchDraw_button.Location = new System.Drawing.Point(6, 20);
            this.ScratchDraw_button.Name = "ScratchDraw_button";
            this.ScratchDraw_button.Size = new System.Drawing.Size(86, 72);
            this.ScratchDraw_button.TabIndex = 4;
            this.ScratchDraw_button.Text = "刮刮卡抽奖模板生成";
            this.ScratchDraw_button.UseVisualStyleBackColor = true;
            this.ScratchDraw_button.Click += new System.EventHandler(this.ScratchDraw_button_Click);
            // 
            // Activity_button
            // 
            this.Activity_button.Location = new System.Drawing.Point(6, 20);
            this.Activity_button.Name = "Activity_button";
            this.Activity_button.Size = new System.Drawing.Size(85, 72);
            this.Activity_button.TabIndex = 5;
            this.Activity_button.Text = "火爆活动配置";
            this.Activity_button.UseVisualStyleBackColor = true;
            this.Activity_button.Click += new System.EventHandler(this.Activity_button_Click);
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(102, 20);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(86, 72);
            this.update_button.TabIndex = 6;
            this.update_button.Text = "Update语句批量生成";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // insert_button
            // 
            this.insert_button.Location = new System.Drawing.Point(10, 20);
            this.insert_button.Name = "insert_button";
            this.insert_button.Size = new System.Drawing.Size(86, 72);
            this.insert_button.TabIndex = 7;
            this.insert_button.Text = "数值数据SQL生成";
            this.insert_button.UseVisualStyleBackColor = true;
            this.insert_button.Click += new System.EventHandler(this.insert_button_Click);
            // 
            // groupbox1
            // 
            this.groupbox1.Controls.Add(this.Sql_button);
            this.groupbox1.Location = new System.Drawing.Point(12, 33);
            this.groupbox1.Name = "groupbox1";
            this.groupbox1.Size = new System.Drawing.Size(415, 175);
            this.groupbox1.TabIndex = 8;
            this.groupbox1.TabStop = false;
            this.groupbox1.Text = "SQL相关";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LuaShop_button);
            this.groupBox2.Controls.Add(this.TenBox_button);
            this.groupBox2.Controls.Add(this.ScratchDraw_button);
            this.groupBox2.Location = new System.Drawing.Point(433, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 175);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "运营单据相关";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.update_button);
            this.groupBox3.Controls.Add(this.insert_button);
            this.groupBox3.Location = new System.Drawing.Point(12, 215);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(415, 182);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Excel相关";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.Activity_button);
            this.groupBox4.Location = new System.Drawing.Point(433, 215);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(418, 182);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "客户端相关";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 435);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupbox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "MyTool";
            this.groupbox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Sql_button;
        private System.Windows.Forms.Button LuaShop_button;
        private System.Windows.Forms.Button TenBox_button;
        private System.Windows.Forms.Button ScratchDraw_button;
        private System.Windows.Forms.Button Activity_button;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Button insert_button;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupbox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

