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
            this.btn_activity = new System.Windows.Forms.Button();
            this.Title_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_activity
            // 
            this.btn_activity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_activity.FlatAppearance.BorderSize = 0;
            this.btn_activity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_activity.Location = new System.Drawing.Point(12, 12);
            this.btn_activity.Name = "btn_activity";
            this.btn_activity.Size = new System.Drawing.Size(194, 91);
            this.btn_activity.TabIndex = 0;
            this.btn_activity.UseVisualStyleBackColor = true;
            // 
            // Title_label
            // 
            this.Title_label.AutoSize = true;
            this.Title_label.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Title_label.Location = new System.Drawing.Point(29, 106);
            this.Title_label.Name = "Title_label";
            this.Title_label.Size = new System.Drawing.Size(95, 33);
            this.Title_label.TabIndex = 1;
            this.Title_label.Text = "Title";
            this.Title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActivityItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(218, 310);
            this.Controls.Add(this.Title_label);
            this.Controls.Add(this.btn_activity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ActivityItemForm";
            this.Text = "ActivityItemForm";
            this.Load += new System.EventHandler(this.ActivityItemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_activity;
        private System.Windows.Forms.Label Title_label;
    }
}