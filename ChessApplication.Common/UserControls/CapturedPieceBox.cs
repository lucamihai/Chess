using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using ChessApplication.Common.ChessPieces;

namespace ChessApplication.Common.UserControls
{
    public partial class CapturedPieceBox : UserControl
    {
        private ChessPiece chessPiece;
        public ChessPiece ChessPiece
        {
            get => chessPiece;
            private set
            {
                chessPiece = value;

                if (chessPiece != null)
                {
                    pictureBoxPiece.Image = chessPiece.Image;
                }
            }
        }

        public int Count
        {
            get => Convert.ToInt32(labelCount.Text);
            set => labelCount.Text = value.ToString();
        }

        public CapturedPieceBox(ChessPiece chessPiece)
        {
            InitializeComponent();

            ChessPiece = chessPiece;
            Count = 0;
        }

        [ExcludeFromCodeCoverage]
        private void pictureBoxPiece_Click(object sender, EventArgs e)
        {
            this.OnClick(EventArgs.Empty);
        }

        [ExcludeFromCodeCoverage]
        private void labelCount_Click(object sender, EventArgs e)
        {
            this.OnClick(EventArgs.Empty);
        }
    }
}
