namespace ChessApplication.Notifications
{
    partial class NotificationsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxNotifications = new System.Windows.Forms.TextBox();
            this.labelNotifications = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxNotifications
            // 
            this.textBoxNotifications.Location = new System.Drawing.Point(3, 43);
            this.textBoxNotifications.Multiline = true;
            this.textBoxNotifications.Name = "textBoxNotifications";
            this.textBoxNotifications.ReadOnly = true;
            this.textBoxNotifications.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNotifications.Size = new System.Drawing.Size(344, 129);
            this.textBoxNotifications.TabIndex = 0;
            // 
            // labelNotifications
            // 
            this.labelNotifications.AutoSize = true;
            this.labelNotifications.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotifications.Location = new System.Drawing.Point(17, 11);
            this.labelNotifications.Name = "labelNotifications";
            this.labelNotifications.Size = new System.Drawing.Size(85, 19);
            this.labelNotifications.TabIndex = 1;
            this.labelNotifications.Text = "Notifications";
            // 
            // NotificationsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.labelNotifications);
            this.Controls.Add(this.textBoxNotifications);
            this.Name = "NotificationsUserControl";
            this.Size = new System.Drawing.Size(350, 175);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNotifications;
        private System.Windows.Forms.Label labelNotifications;
    }
}
