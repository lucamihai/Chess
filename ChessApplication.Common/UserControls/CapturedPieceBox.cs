using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using ChessApplication.Common.ChessPieces;

namespace ChessApplication.Common.UserControls
{
    public partial class CapturedPieceBox : UserControl
    {
        private ChessPiece _ChessPiece;
        public ChessPiece ChessPiece
        {
            get => _ChessPiece;
            private set
            {
                _ChessPiece = value;

                if (_ChessPiece != null)
                {
                    pictureBoxPiece.Image = _ChessPiece.Image;
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
