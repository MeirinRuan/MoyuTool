﻿namespace MyTool
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
            this.toolTip1.SetToolTip(this.LuaShop_button, "请用中鸣工具");
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
            this.toolTip1.SetToolTip(this.TenBox_button, "请用中鸣工具");
            this.TenBox_button.UseVisualStyleBackColor = true;
            this.TenBox_button.Click += new System.EventHandler(this.TenBox_button_Click);
            // 
            // ScratchDraw_button
            // 
            this.ScratchDraw_button.Location = new System.Drawing.Point(232, 106);
            this.ScratchDraw_button.Name = "ScratchDraw_button";
            this.ScratchDraw_button.Size = new System.Drawing.Size(86, 72);
            this.ScratchDraw_button.TabIndex = 4;
            this.ScratchDraw_button.Text = "刮刮卡抽奖模板生成";
            this.ScratchDraw_button.UseVisualStyleBackColor = true;
            this.ScratchDraw_button.Click += new System.EventHandler(this.ScratchDraw_button_Click);
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
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(12, 106);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(86, 72);
            this.update_button.TabIndex = 6;
            this.update_button.Text = "Update语句批量生成";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // insert_button
            // 
            this.insert_button.Location = new System.Drawing.Point(119, 106);
            this.insert_button.Name = "insert_button";
            this.insert_button.Size = new System.Drawing.Size(86, 72);
            this.insert_button.TabIndex = 7;
            this.insert_button.Text = "数值数据sql生成";
            this.insert_button.UseVisualStyleBackColor = true;
            this.insert_button.Click += new System.EventHandler(this.insert_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 272);
            this.Controls.Add(this.insert_button);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.Activity_button);
            this.Controls.Add(this.ScratchDraw_button);
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
        private System.Windows.Forms.Button ScratchDraw_button;
        private System.Windows.Forms.Button Activity_button;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Button insert_button;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

