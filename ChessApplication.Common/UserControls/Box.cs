using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using ChessApplication.Common.ChessPieces;

namespace ChessApplication.Common.UserControls
{
    public partial class Box : UserControl
    {
        private bool available;
        public bool Available
        {
            get => available;
            set
            {
                available = value;

                if (available && BeginnersMode)
                {
                    pictureBoxPiece.BackColor = Constants.BoxColorAvailable;
                }
            }
        }

        private string boxName;
        public string BoxName
        {
            get => boxName;
            private set
            {
                boxName = value;

                var row = (int)boxName[0];
                row -= 'A';
                row += 1;

                var column = (int)boxName[1];
                column -= '1';
                column += 1;

                Position = new Point(row, column);
            }
        }

        private ChessPiece piece;
        public ChessPiece Piece
        {
            get => piece;
            set
            {
                piece = value;

                pictureBoxPiece.Image = piece != null ? piece.Image : null;
            }
        }

        public bool BeginnersMode { get; set; } = true;

        public Point Position { get; private set; }

        public Color BoxBackgroundColor
        {
            get => pictureBoxPiece.BackColor;
            set => pictureBoxPiece.BackColor = value;
        }

        public Box(string name, ChessPiece chessPiece = null)
        {
            InitializeComponent();

            BoxName = name;
            Piece = chessPiece;

            Available = false;
        }

        [ExcludeFromCodeCoverage]
        private void pictureBoxPiece_Click(object sender, EventArgs e)
        {
            this.OnClick(EventArgs.Empty);
        }
    }
}
