using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using Chess_Application.Classes;

namespace Chess_Application
{
    public class Box
    {
        public string nume;
        public PictureBox imagineLocatie;

        #region Properties

        public ChessPiece Piece{ get; set; }

        public short Row { get; }

        public short Column { get; }

        bool _Available;
        public bool Available
        {
            get
            {
                return _Available;
            }
            set
            {
                _Available = value;

                if (_Available && MainForm.modInceptator)
                {
                    imagineLocatie.BackColor = Color.Green;
                }
            }
        }

        #endregion

        public Box()
        {

        }

        public Box(PictureBox pictureBox, ChessPiece piece = null)
        {
            nume = pictureBox.Name;
            nume = nume.Substring(1);
            nume = Utilities.GetReversedString(nume);

            Row = (short)nume[0];
            Row -= (short)'A';
            Row += 1;

            Column = (short)nume[1];
            Column -= (short)'1';
            Column += 1;

            Piece = piece;

            imagineLocatie = pictureBox;
            imagineLocatie.BackgroundImage = (Piece != null) ? piece.PictureBox.BackgroundImage : null;

            Available = false;
        }

        public void RemovePieceImage()
        {
            imagineLocatie.BackgroundImage = null;
        }
    }
}
