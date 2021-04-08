using System.Diagnostics.CodeAnalysis;

namespace ChessApplication.GUI.UserControls.Chessboard
{
    public partial class BoxUserControl
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
            this.pictureBoxPiece = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPiece)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPiece
            // 
            this.pictureBoxPiece.BackgroundImage = Properties.Resources.BoxBorder;
            this.pictureBoxPiece.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPiece.Name = "pictureBoxPiece";
            this.pictureBoxPiece.Size = new System.Drawing.Size(64, 64);
            this.pictureBoxPiece.TabIndex = 0;
            this.pictureBoxPiece.TabStop = false;
            this.pictureBoxPiece.Click += new System.EventHandler(this.pictureBoxPiece_Click);
            // 
            // Box
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxPiece);
            this.Name = "BoxUserControl";
            this.Size = new System.Drawing.Size(64, 64);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPiece)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPiece;
    }
}
