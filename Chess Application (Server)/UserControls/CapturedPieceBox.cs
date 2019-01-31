using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Application.UserControls
{
    public partial class CapturedPieceBox : UserControl
    {
        ChessPiece _ChessPiece;
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
