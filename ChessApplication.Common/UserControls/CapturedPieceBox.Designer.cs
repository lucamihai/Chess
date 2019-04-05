namespace ChessApplication.Common.UserControls
{
    partial class CapturedPieceBox
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
            this.labelCount = new System.Windows.Forms.Label();
            this.pictureBoxPiece = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPiece)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCount
            // 
            this.labelCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCount.Location = new System.Drawing.Point(0, 67);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(64, 19);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Counter";
            this.labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCount.Click += new System.EventHandler(this.labelCount_Click);
            // 
            // pictureBoxPiece
            // 
            this.pictureBoxPiece.BackColor = System.Drawing.Color.RoyalBlue;
            this.pictureBoxPiece.BackgroundImage = Properties.Resources.BoxBorder;
            this.pictureBoxPiece.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPiece.Name = "pictureBoxPiece";
            this.pictureBoxPiece.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxPiece.TabIndex = 0;
            this.pictureBoxPiece.TabStop = false;
            this.pictureBoxPiece.Click += new System.EventHandler(this.pictureBoxPiece_Click);
            // 
            // CapturedPieceBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.pictureBoxPiece);
            this.Name = "CapturedPieceBox";
            this.Size = new System.Drawing.Size(64, 88);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPiece)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPiece;
        private System.Windows.Forms.Label labelCount;
    }
}
