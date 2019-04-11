namespace ChessApplication.History
{
    partial class HistoryEntry
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
            this.pictureBoxOriginPiece = new System.Windows.Forms.PictureBox();
            this.pictureBoxDestinationPiece = new System.Windows.Forms.PictureBox();
            this.labelMoveNumber = new System.Windows.Forms.Label();
            this.labelOriginName = new System.Windows.Forms.Label();
            this.labelDestinationName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginPiece)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestinationPiece)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOriginPiece
            // 
            this.pictureBoxOriginPiece.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxOriginPiece.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOriginPiece.Location = new System.Drawing.Point(47, 3);
            this.pictureBoxOriginPiece.Name = "pictureBoxOriginPiece";
            this.pictureBoxOriginPiece.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxOriginPiece.TabIndex = 0;
            this.pictureBoxOriginPiece.TabStop = false;
            // 
            // pictureBoxDestinationPiece
            // 
            this.pictureBoxDestinationPiece.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxDestinationPiece.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDestinationPiece.Location = new System.Drawing.Point(115, 3);
            this.pictureBoxDestinationPiece.Name = "pictureBoxDestinationPiece";
            this.pictureBoxDestinationPiece.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxDestinationPiece.TabIndex = 1;
            this.pictureBoxDestinationPiece.TabStop = false;
            // 
            // labelMoveNumber
            // 
            this.labelMoveNumber.AutoSize = true;
            this.labelMoveNumber.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoveNumber.Location = new System.Drawing.Point(3, 16);
            this.labelMoveNumber.Name = "labelMoveNumber";
            this.labelMoveNumber.Size = new System.Drawing.Size(21, 19);
            this.labelMoveNumber.TabIndex = 2;
            this.labelMoveNumber.Text = "1.";
            // 
            // labelOriginName
            // 
            this.labelOriginName.AutoSize = true;
            this.labelOriginName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOriginName.Location = new System.Drawing.Point(48, 38);
            this.labelOriginName.Name = "labelOriginName";
            this.labelOriginName.Size = new System.Drawing.Size(28, 19);
            this.labelOriginName.TabIndex = 3;
            this.labelOriginName.Text = "A1";
            // 
            // labelDestinationName
            // 
            this.labelDestinationName.AutoSize = true;
            this.labelDestinationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDestinationName.Location = new System.Drawing.Point(116, 37);
            this.labelDestinationName.Name = "labelDestinationName";
            this.labelDestinationName.Size = new System.Drawing.Size(29, 20);
            this.labelDestinationName.TabIndex = 4;
            this.labelDestinationName.Text = "A2";
            // 
            // HistoryEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Controls.Add(this.labelDestinationName);
            this.Controls.Add(this.labelOriginName);
            this.Controls.Add(this.labelMoveNumber);
            this.Controls.Add(this.pictureBoxDestinationPiece);
            this.Controls.Add(this.pictureBoxOriginPiece);
            this.Name = "HistoryEntry";
            this.Size = new System.Drawing.Size(175, 65);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginPiece)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDestinationPiece)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOriginPiece;
        private System.Windows.Forms.PictureBox pictureBoxDestinationPiece;
        private System.Windows.Forms.Label labelMoveNumber;
        private System.Windows.Forms.Label labelOriginName;
        private System.Windows.Forms.Label labelDestinationName;
    }
}
