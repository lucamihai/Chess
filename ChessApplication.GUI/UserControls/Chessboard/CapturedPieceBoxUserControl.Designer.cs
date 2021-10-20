using System.Diagnostics.CodeAnalysis;

namespace ChessApplication.GUI.UserControls.Chessboard
{
    public partial class CapturedPieceBoxUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        [ExcludeFromCodeCoverage]
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
            this.labelCount.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCount.Location = new System.Drawing.Point(0, 67);
            this.labelCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.pictureBoxPiece.BackgroundImage = global::ChessApplication.GUI.Properties.Resources.BoxBorder;
            this.pictureBoxPiece.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPiece.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxPiece.Name = "pictureBoxPiece";
            this.pictureBoxPiece.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxPiece.TabIndex = 0;
            this.pictureBoxPiece.TabStop = false;
            this.pictureBoxPiece.Click += new System.EventHandler(this.pictureBoxPiece_Click);
            // 
            // CapturedPieceBoxUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.pictureBoxPiece);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CapturedPieceBoxUserControl";
            this.Size = new System.Drawing.Size(64, 88);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPiece)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPiece;
        private System.Windows.Forms.Label labelCount;
    }
}
