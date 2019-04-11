using System;
using System.Drawing;
using System.Windows.Forms;
using ChessApplication.Common.UserControls;

namespace ChessApplication.History
{
    public partial class HistoryEntry : UserControl
    {
        public int EntryNumber
        {
            get => Convert.ToInt32((string) labelMoveNumber.Text);
            private set => labelMoveNumber.Text = value.ToString();
        }

        public string OriginName
        {
            get => labelOriginName.Text;
            private set => labelOriginName.Text = value;
        }

        public string DestinationName
        {
            get => labelDestinationName.Text;
            private set => labelDestinationName.Text = value;
        }

        public HistoryEntry(int entryNumber, Box origin, Box destination)
        {
            InitializeComponent();

            EntryNumber = entryNumber;

            OriginName = origin.BoxName;
            DestinationName = destination.BoxName;

            pictureBoxOriginPiece.Image = origin.Piece.ImageSmall;
            pictureBoxOriginPiece.BackColor = origin.BoxBackgroundColor;

            pictureBoxDestinationPiece.Image = (destination.Piece != null) ? destination.Piece.ImageSmall : new Bitmap(32, 32);
            pictureBoxDestinationPiece.BackColor = destination.BoxBackgroundColor;
        }
    }
}
