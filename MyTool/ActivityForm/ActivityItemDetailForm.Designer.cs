namespace MyTool
{
    partial class ActivityItemDetailForm
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
            this.Time_label = new System.Windows.Forms.Label();
            this.Level_label = new System.Windows.Forms.Label();
            this.Description_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Time_label
            // 
            this.Time_label.AutoSize = true;
            this.Time_label.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Time_label.Location = new System.Drawing.Point(13, 13);
            this.Time_label.Name = "Time_label";
            this.Time_label.Size = new System.Drawing.Size(0, 25);
            this.Time_label.TabIndex = 0;
            // 
            // Level_label
            // 
            this.Level_label.AutoSize = true;
            this.Level_label.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Level_label.Location = new System.Drawing.Point(13, 42);
            this.Level_label.Name = "Level_label";
            this.Level_label.Size = new System.Drawing.Size(0, 25);
            this.Level_label.TabIndex = 1;
            // 
            // Description_textBox
            // 
            this.Description_textBox.BackColor = System.Drawing.Color.White;
            this.Description_textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Description_textBox.Location = new System.Drawing.Point(18, 72);
            this.Description_textBox.Multiline = true;
            this.Description_textBox.Name = "Description_textBox";
            this.Description_textBox.ReadOnly = true;
            this.Description_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Description_textBox.Size = new System.Drawing.Size(570, 46);
            this.Description_textBox.TabIndex = 3;
            // 
            // ActivityItemDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 130);
            this.Controls.Add(this.Description_textBox);
            this.Controls.Add(this.Level_label);
            this.Controls.Add(this.Time_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActivityItemDetailForm";
            this.Text = "ActivityItemDetailForm";
            this.Load += new System.EventHandler(this.ActivityItemDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Time_label;
        private System.Windows.Forms.Label Level_label;
        private System.Windows.Forms.TextBox Description_textBox;
    }
}