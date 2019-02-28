using System;
using System.Drawing;
using System.Windows.Forms;
using Chess_Application.Common.ChessPieces;

namespace Chess_Application.Common.UserControls
{
    public partial class Box : UserControl
    {
        private bool _Available;
        public bool Available
        {
            get
            {
                return _Available;
            }
            set
            {
                _Available = value;

                if (_Available && BeginnersMode)
                {
                    pictureBoxPiece.BackColor = Color.Green;
                }
            }
        }

        private string _BoxName;
        public string BoxName
        {
            get
            {
                return _BoxName;
            }
            set
            {
                _BoxName = value;

                Row = (short)_BoxName[0];
                Row -= (short)'A';
                Row += 1;

                Column = (short)_BoxName[1];
                Column -= (short)'1';
                Column += 1;
            }
        }

        private ChessPiece _Piece;
        public ChessPiece Piece
        {
            get
            {
                return _Piece;
            }
            set
            {
                _Piece = value;

                pictureBoxPiece.Image = _Piece != null ? _Piece.Image : null;
            }
        }

        public bool BeginnersMode { get; set; } = true;

        public short Row { get; private set; }

        public short Column { get; private set; }

        public Color BoxBackgroundColor
        {
            get
            {
                return pictureBoxPiece.BackColor;
            }
            set
            {
                pictureBoxPiece.BackColor = value;
            }
        }


        public Box()
        {
            InitializeComponent();
        }

        public Box(string name, ChessPiece chessPiece = null)
        {
            InitializeComponent();

            BoxName = name;
            Piece = chessPiece;

            Available = false;
        }

        private void pictureBoxPiece_Click(object sender, EventArgs e)
        {
            this.OnClick(EventArgs.Empty);
        }
    }
}
