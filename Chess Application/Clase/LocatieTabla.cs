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
        public static int count = 0;
        public string nume;
        public bool poateFaceMiscari = false;
        public Piesa piesa;
        public int tipPiesa = 0;
        public int culoare = 0;
        public bool sePoate = false;
        public PictureBox imagineLocatie;

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public LocatieTabla(Piesa p, PictureBox b)
        {
            piesa = p;
            culoare = p.culoare;
            tipPiesa = p.tipPiesa;
            imagineLocatie = b;
            b.BackgroundImage = p.imaginePiesa.BackgroundImage;
            nume = b.Name;
            nume = nume.Substring(1);
            nume=Reverse(nume);
        }

        public LocatieTabla()
        {

        }
        public LocatieTabla(PictureBox b)
        {
            imagineLocatie = b;
            imagineLocatie.BackgroundImage = null;
            nume = b.Name;
            nume = nume.Substring(1);
            nume=Reverse(nume);
        }

        public void MarcheazaSimplu(CheckBox c)//daca sunt indeplinite regulile, marcheaza locatia ca fiind accesibila; optional afiseaza verde pe casuta respectiva
        {
            sePoate = true;
        }
        public void Marcheaza()//daca sunt indeplinite regulile, marcheaza locatia ca fiind accesibila; optional afiseaza verde pe casuta respectiva
        {
            sePoate = true;
            if (Form1.modInceptator)
            {
                imagineLocatie.BackColor = Color.Green;
            }
        }

        public void StergeLocatie()
        {
            imagineLocatie.BackgroundImage = null;
        }
        
    }
}
