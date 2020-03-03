namespace MyTool.FormEmoneyShop
{
    partial class UserControl_Output
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(28, 30);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(178, 101);
            this.button.TabIndex = 1;
            this.button.Text = "输出配置";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // UserControl_Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button);
            this.Name = "UserControl_Output";
            this.Size = new System.Drawing.Size(235, 161);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button;
    }
}
