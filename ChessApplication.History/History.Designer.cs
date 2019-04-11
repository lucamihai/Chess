namespace ChessApplication.History
{
    partial class History
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
            this.panelHistoryEntries = new System.Windows.Forms.Panel();
            this.labelMoveNumber = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelHistoryEntries
            // 
            this.panelHistoryEntries.AutoScroll = true;
            this.panelHistoryEntries.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelHistoryEntries.Location = new System.Drawing.Point(0, 30);
            this.panelHistoryEntries.Name = "panelHistoryEntries";
            this.panelHistoryEntries.Size = new System.Drawing.Size(200, 270);
            this.panelHistoryEntries.TabIndex = 0;
            // 
            // labelMoveNumber
            // 
            this.labelMoveNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoveNumber.Location = new System.Drawing.Point(3, 9);
            this.labelMoveNumber.Name = "labelMoveNumber";
            this.labelMoveNumber.Size = new System.Drawing.Size(35, 18);
            this.labelMoveNumber.TabIndex = 1;
            this.labelMoveNumber.Text = "No.";
            // 
            // labelFrom
            // 
            this.labelFrom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFrom.Location = new System.Drawing.Point(44, 9);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(74, 18);
            this.labelFrom.TabIndex = 2;
            this.labelFrom.Text = "From";
            // 
            // labelTo
            // 
            this.labelTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTo.Location = new System.Drawing.Point(124, 9);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(73, 18);
            this.labelTo.TabIndex = 3;
            this.labelTo.Text = "To";
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.labelTo);
            this.Controls.Add(this.labelFrom);
            this.Controls.Add(this.labelMoveNumber);
            this.Controls.Add(this.panelHistoryEntries);
            this.Name = "History";
            this.Size = new System.Drawing.Size(200, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHistoryEntries;
        private System.Windows.Forms.Label labelMoveNumber;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.Label labelTo;
    }
}
