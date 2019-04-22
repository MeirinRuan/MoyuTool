namespace MyTool
{
    partial class ActivityItemForm
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
            this.Title_label = new System.Windows.Forms.Label();
            this.TeamNumStr_label = new System.Windows.Forms.Label();
            this.Recommend_label = new System.Windows.Forms.Label();
            this.label_activity = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Title_label
            // 
            this.Title_label.AutoSize = true;
            this.Title_label.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Title_label.Location = new System.Drawing.Point(30, 110);
            this.Title_label.Name = "Title_label";
            this.Title_label.Size = new System.Drawing.Size(63, 31);
            this.Title_label.TabIndex = 1;
            this.Title_label.Text = "Title";
            this.Title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TeamNumStr_label
            // 
            this.TeamNumStr_label.AutoSize = true;
            this.TeamNumStr_label.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TeamNumStr_label.ForeColor = System.Drawing.Color.Black;
            this.TeamNumStr_label.Location = new System.Drawing.Point(46, 259);
            this.TeamNumStr_label.Name = "TeamNumStr_label";
            this.TeamNumStr_label.Size = new System.Drawing.Size(62, 31);
            this.TeamNumStr_label.TabIndex = 2;
            this.TeamNumStr_label.Text = "单人";
            this.TeamNumStr_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Recommend_label
            // 
            this.Recommend_label.AutoSize = true;
            this.Recommend_label.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Recommend_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Recommend_label.Location = new System.Drawing.Point(5, 12);
            this.Recommend_label.Name = "Recommend_label";
            this.Recommend_label.Size = new System.Drawing.Size(33, 28);
            this.Recommend_label.TabIndex = 3;
            this.Recommend_label.Text = "荐";
            this.Recommend_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Recommend_label.Visible = false;
            // 
            // label_activity
            // 
            this.label_activity.BackColor = System.Drawing.Color.Transparent;
            this.label_activity.Location = new System.Drawing.Point(74, 24);
            this.label_activity.Name = "label_activity";
            this.label_activity.Size = new System.Drawing.Size(82, 86);
            this.label_activity.TabIndex = 4;
            // 
            // ActivityItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(218, 310);
            this.Controls.Add(this.label_activity);
            this.Controls.Add(this.Recommend_label);
            this.Controls.Add(this.TeamNumStr_label);
            this.Controls.Add(this.Title_label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActivityItemForm";
            this.Text = "ActivityItemForm";
            this.Load += new System.EventHandler(this.ActivityItemForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ActivityItemForm_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Title_label;
        private System.Windows.Forms.Label TeamNumStr_label;
        private System.Windows.Forms.Label Recommend_label;
        private System.Windows.Forms.Label label_activity;
    }
}