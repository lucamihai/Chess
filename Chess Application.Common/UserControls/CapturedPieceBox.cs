using System;
using System.Windows.Forms;
using Chess_Application.Common.ChessPieces;

namespace Chess_Application.Common.UserControls
{
    public partial class CapturedPieceBox : UserControl
    {
        private ChessPiece _ChessPiece;
        public ChessPiece ChessPiece
        {
            get
            {
                return _ChessPiece;
            }
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
            get
            {
                return Convert.ToInt32(labelCount.Text);
            }
            set
            {
                labelCount.Text = value.ToString();
            }
        }

        public CapturedPieceBox(ChessPiece chessPiece)
        {
            InitializeComponent();

            ChessPiece = chessPiece;
            Count = 0;
        }

        private void pictureBoxPiece_Click(object sender, EventArgs e)
        {
            this.OnClick(EventArgs.Empty);
        }

        private void labelCount_Click(object sender, EventArgs e)
        {
            this.OnClick(EventArgs.Empty);
        }
    }
}
