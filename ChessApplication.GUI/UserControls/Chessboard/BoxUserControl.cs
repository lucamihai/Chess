using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using ChessApplication.Common;
using ChessApplication.GUI.Helpers;

namespace ChessApplication.GUI.UserControls.Chessboard
{
    [ExcludeFromCodeCoverage]
    public partial class BoxUserControl : UserControl
    {
        public Box Box { get; set; }

        public bool Available => Box.Available;
        public ChessPiece Piece => Box.Piece;
        public Position Position => Box.Position;

        public Color BoxBackgroundColor
        {
            get => pictureBoxPiece.BackColor;
            set => pictureBoxPiece.BackColor = value;
        }

        public BoxUserControl(Box box)
        {
            InitializeComponent();

            Box = box;
            
            Draw();
        }

        public void Draw()
        {
            pictureBoxPiece.Image = ChessPieceImageProvider.GetImageForChessPiece(Box.Piece);
        }

        private void pictureBoxPiece_Click(object sender, EventArgs e)
        {
            this.OnClick(EventArgs.Empty);
        }
    }
}
