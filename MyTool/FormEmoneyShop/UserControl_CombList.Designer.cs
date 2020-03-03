namespace MyTool.FormEmoneyShop
{
    partial class UserControl_CombList
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
            this.pictureBox_tick = new System.Windows.Forms.PictureBox();
            this.button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tick)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_tick
            // 
            this.pictureBox_tick.BackColor = System.Drawing.Color.White;
            this.pictureBox_tick.Image = global::MyTool.Properties.Resources.tick;
            this.pictureBox_tick.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_tick.Name = "pictureBox_tick";
            this.pictureBox_tick.Size = new System.Drawing.Size(48, 42);
            this.pictureBox_tick.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_tick.TabIndex = 0;
            this.pictureBox_tick.TabStop = false;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(57, 3);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(116, 42);
            this.button.TabIndex = 3;
            this.button.TabStop = false;
            this.button.Text = "button";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
            // 
            // UserControl_CombList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button);
            this.Controls.Add(this.pictureBox_tick);
            this.Name = "UserControl_CombList";
            this.Size = new System.Drawing.Size(177, 49);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tick)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_tick;
        private System.Windows.Forms.Button button;
    }
}
