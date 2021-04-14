using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using ChessApplication.Common;
using ChessApplication.GUI.Helpers;

namespace ChessApplication.GUI.UserControls.Chessboard
{
    [ExcludeFromCodeCoverage]
    public partial class CapturedPieceBoxUserControl : UserControl 
    {
        public ChessPiece ChessPiece { get; }

        public int Count
        {
            get => int.TryParse(labelCount.Text, out var count) ? count : -1;
            set
            {
                if (value == Count)
                {
                    return;
                }

                labelCount.Text = value.ToString();
            }
        }

        public CapturedPieceBoxUserControl(ChessPiece chessPiece)
        {
            InitializeComponent();

            ChessPiece = chessPiece;
            pictureBoxPiece.Image = ChessPieceImageProvider.GetImageForChessPiece(chessPiece);

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
