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

namespace Chess_Application
{
    public class LocatieTabla
    {
        public string nume;
        public bool poateFaceMiscari = false;
        public ChessPiece piesa;
        public int tipPiesa = 0;
        public int culoare = 0;
        bool available = false;
        public PictureBox imagineLocatie;

        short row, column;

        // Used for instantiating the matrix of boxes
        public LocatieTabla()
        {

        }

        // Used for empty boxes
        public LocatieTabla(PictureBox pictureBox)
        {
            imagineLocatie = pictureBox;
            imagineLocatie.BackgroundImage = null;
            nume = pictureBox.Name;
            nume = nume.Substring(1);
            nume = Reverse(nume);

            row = (short)nume[0];
            row -= (short)'A';
            row += 1;

            column = (short)nume[1];
            column -= (short)'1';
            column += 1;
        }

        // Used for boxes with a chess piece on them
        public LocatieTabla(ChessPiece piece, PictureBox pictureBox)
        {
            piesa = piece;
            culoare = piece.culoare;
            tipPiesa = piece.tipPiesa;
            imagineLocatie = pictureBox;
            pictureBox.BackgroundImage = piece.imaginePiesa.BackgroundImage;
            nume = pictureBox.Name;
            nume = nume.Substring(1);
            nume = Reverse(nume);

            row = (short)nume[0];
            row -= (short)'A';
            row += 1;

            column = (short)nume[1];
            column -= (short)'1';
            column += 1;
        }

        /// <summary>
        /// Sets the color of the box.
        /// </summary>
        /// <param name="color"></param>
        public void SetColor(Color color)
        {
            imagineLocatie.BackColor = color;
        }

        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Marks the box as available for other pieces to move upon.
        /// </summary>
        public void MarkAsAvailable()
        {
            available = true;
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
            available = false;
        }

        public void RemovePieceImage()
        {
            imagineLocatie.BackgroundImage = null;
        }

        public short Row
        {
            get
            {
                return row;
            }
        }

        public short Column
        {
            get
            {
                return column;
            }
        }

        public bool Available
        {
            get
            {
                return available;
            }
        }

    }
}
