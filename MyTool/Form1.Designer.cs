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
            this.Sql_button = new System.Windows.Forms.Button();
            this.LuaShop_button = new System.Windows.Forms.Button();
            this.TenBox_button = new System.Windows.Forms.Button();
            this.CopyMap_button = new System.Windows.Forms.Button();
            this.Activity_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Sql_button
            // 
            this.Sql_button.Location = new System.Drawing.Point(12, 12);
            this.Sql_button.Name = "Sql_button";
            this.Sql_button.Size = new System.Drawing.Size(86, 72);
            this.Sql_button.TabIndex = 1;
            this.Sql_button.Text = "sql字段检测补全";
            this.Sql_button.UseVisualStyleBackColor = true;
            this.Sql_button.Click += new System.EventHandler(this.Sql_button_Click);
            // 
            // LuaShop_button
            // 
            this.LuaShop_button.Location = new System.Drawing.Point(119, 12);
            this.LuaShop_button.Name = "LuaShop_button";
            this.LuaShop_button.Size = new System.Drawing.Size(86, 72);
            this.LuaShop_button.TabIndex = 2;
            this.LuaShop_button.Text = "筹码币商店模板生成";
            this.LuaShop_button.UseVisualStyleBackColor = true;
            this.LuaShop_button.Click += new System.EventHandler(this.LuaShop_button_Click);
            // 
            // TenBox_button
            // 
            this.TenBox_button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TenBox_button.Location = new System.Drawing.Point(232, 12);
            this.TenBox_button.Name = "TenBox_button";
            this.TenBox_button.Size = new System.Drawing.Size(86, 72);
            this.TenBox_button.TabIndex = 3;
            this.TenBox_button.Text = "十连抽模板生成";
            this.TenBox_button.UseVisualStyleBackColor = true;
            this.TenBox_button.Click += new System.EventHandler(this.TenBox_button_Click);
            // 
            // CopyMap_button
            // 
            this.CopyMap_button.Location = new System.Drawing.Point(12, 106);
            this.CopyMap_button.Name = "CopyMap_button";
            this.CopyMap_button.Size = new System.Drawing.Size(86, 72);
            this.CopyMap_button.TabIndex = 4;
            this.CopyMap_button.Text = "副本模板生成";
            this.CopyMap_button.UseVisualStyleBackColor = true;
            this.CopyMap_button.Click += new System.EventHandler(this.CopyMap_button_Click);
            // 
            // Activity_button
            // 
            this.Activity_button.Location = new System.Drawing.Point(334, 12);
            this.Activity_button.Name = "Activity_button";
            this.Activity_button.Size = new System.Drawing.Size(85, 72);
            this.Activity_button.TabIndex = 5;
            this.Activity_button.Text = "火爆活动配置";
            this.Activity_button.UseVisualStyleBackColor = true;
            this.Activity_button.Click += new System.EventHandler(this.Activity_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 272);
            this.Controls.Add(this.Activity_button);
            this.Controls.Add(this.CopyMap_button);
            this.Controls.Add(this.TenBox_button);
            this.Controls.Add(this.LuaShop_button);
            this.Controls.Add(this.Sql_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "MyTool";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Sql_button;
        private System.Windows.Forms.Button LuaShop_button;
        private System.Windows.Forms.Button TenBox_button;
        private System.Windows.Forms.Button CopyMap_button;
        private System.Windows.Forms.Button Activity_button;
    }
}

