using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using ChessApplication.Common.ChessPieces;

namespace ChessApplication.Common.UserControls
{
    public partial class Box : UserControl
    {
        private bool _Available;
        public bool Available
        {
            get => _Available;
            set
            {
                _Available = value;

                if (_Available && BeginnersMode)
                {
                    pictureBoxPiece.BackColor = Constants.BoxColorAvailable;
                }
            }
        }

        private string _BoxName;
        public string BoxName
        {
            get => _BoxName;
            private set
            {
                _BoxName = value;

                var row = (int)_BoxName[0];
                row -= 'A';
                row += 1;

                var column = (int)_BoxName[1];
                column -= '1';
                column += 1;

                Position = new Point(row, column);
            }
        }

        private ChessPiece _Piece;
        public ChessPiece Piece
        {
            get => _Piece;
            set
            {
                _Piece = value;

                pictureBoxPiece.Image = _Piece != null ? _Piece.Image : null;
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
