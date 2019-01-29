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
        public bool poateFaceMiscari = false;
        public PictureBox imagineLocatie;

        #region Properties

        public ChessPiece Piece{ get; set; }

        public short Row { get; }

        public short Column { get; }

        public bool Available { get; private set; } = false;

        #endregion

        public Box()
        {

        }

        // Used for empty boxes
        public Box(PictureBox pictureBox)
        {
            imagineLocatie = pictureBox;
            imagineLocatie.BackgroundImage = null;
            nume = pictureBox.Name;
            nume = nume.Substring(1);
            nume = Utilities.GetReversedString(nume);

            Row = (short)nume[0];
            Row -= (short)'A';
            Row += 1;

            Column = (short)nume[1];
            Column -= (short)'1';
            Column += 1;

            Piece = null;
        }

        // Used for boxes with a chess piece on them
        public Box(ChessPiece piece, PictureBox pictureBox)
        {
            Piece = piece;
            imagineLocatie = pictureBox;
            pictureBox.BackgroundImage = piece.imaginePiesa.BackgroundImage;
            nume = pictureBox.Name;
            nume = nume.Substring(1);
            nume = Utilities.GetReversedString(nume);

            Row = (short)nume[0];
            Row -= (short)'A';
            Row += 1;

            Column = (short)nume[1];
            Column -= (short)'1';
            Column += 1;
        }

        /// <summary>
        /// Marks the box as available for other pieces to move upon.
        /// </summary>
        public void MarkAsAvailable()
        {
            Available = true;

            if (MainForm.modInceptator)
            {
                imagineLocatie.BackColor = Color.Green;
            }
        }

        /// <summary>
        /// Marks the box as unavailable for other pieces to move upon.
        /// </summary>
        public void MarkAsUnavailable()
        {
            Available = false;
        }

        public void RemovePieceImage()
        {
            imagineLocatie.BackgroundImage = null;
        }
    }
}
