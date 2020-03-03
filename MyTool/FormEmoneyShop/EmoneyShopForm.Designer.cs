namespace MyTool.FormEmoneyShop
{
    partial class EmoneyShopForm
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
            this.flowLayoutPanel_combolist = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel_wnd = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_combolist
            // 
            this.flowLayoutPanel_combolist.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel_combolist.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel_combolist.Name = "flowLayoutPanel_combolist";
            this.flowLayoutPanel_combolist.Size = new System.Drawing.Size(183, 175);
            this.flowLayoutPanel_combolist.TabIndex = 0;
            // 
            // flowLayoutPanel_wnd
            // 
            this.flowLayoutPanel_wnd.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel_wnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel_wnd.Location = new System.Drawing.Point(201, 12);
            this.flowLayoutPanel_wnd.Name = "flowLayoutPanel_wnd";
            this.flowLayoutPanel_wnd.Size = new System.Drawing.Size(235, 175);
            this.flowLayoutPanel_wnd.TabIndex = 1;
            // 
            // EmoneyShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(448, 199);
            this.Controls.Add(this.flowLayoutPanel_wnd);
            this.Controls.Add(this.flowLayoutPanel_combolist);
            this.Name = "EmoneyShopForm";
            this.Text = "官方魔石商店生成";
            this.Load += new System.EventHandler(this.EmoneyShopForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_combolist;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_wnd;
    }
}