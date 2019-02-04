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
    public partial class HistoryEntry : UserControl
    {
        #region Properties

        public int EntryNumber
        {
            get
            {
                return Convert.ToInt32(labelMoveNumber.Text);
            }
            private set
            {
                labelMoveNumber.Text = value.ToString();
            }
        }

        public string OriginName
        {
            get
            {
                return labelOriginName.Text;
            }
            private set
            {
                labelOriginName.Text = value;
            }
        }

        public string DestinationName
        {
            get
            {
                return labelDestinationName.Text;
            }
            private set
            {
                labelDestinationName.Text = value;
            }
        }

        #endregion

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
