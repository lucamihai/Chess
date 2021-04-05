using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using ChessApplication.Common;
using ChessApplication.Common.ChessPieces;

namespace ChessApplication.GUI.UserControls.Chessboard
{
    [ExcludeFromCodeCoverage]
    public partial class BoxUserControl : UserControl
    {
        public Box Box { get; set; }

        public bool Available
        {
            get => Box.Available;
            set
            {
                Box.Available = value;

                if (Box.Available && BeginnersMode)
                {
                    pictureBoxPiece.BackColor = Constants.BoxColorAvailable;
                }
            }
        }

        public ChessPiece Piece => Box.Piece;

        public bool BeginnersMode { get; set; } = true;

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
            pictureBoxPiece.Image = Box.Piece?.Image;
        }

        private void pictureBoxPiece_Click(object sender, EventArgs e)
        {
            this.OnClick(EventArgs.Empty);
        }
    }
}
