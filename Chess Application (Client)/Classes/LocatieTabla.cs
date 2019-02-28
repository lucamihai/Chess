using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess_Application_client.Classes
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
            nume = Reverse(nume);
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
            nume = Reverse(nume);
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
        
        public void Muta(LocatieTabla origine, LocatieTabla destinatie, DataGridView miscari)
        {
            if (piesa != null)
            {
                miscari.Rows.Add(++count, origine.nume + " -> " + nume, origine.piesa.imagineMicaPiesa.Image, piesa.imagineMicaPiesa.Image);
                if (count == 7)
                {
                    miscari.Width = miscari.Width + 17;
                }
            }
            if (piesa == null)
            {
                Bitmap img = new Bitmap(25, 25);
                miscari.Rows.Add(++count, origine.nume + " -> " + nume, origine.piesa.imagineMicaPiesa.Image, img);
                if (count == 7)
                {
                    miscari.Width = miscari.Width + 17;
                }
            }
            miscari.FirstDisplayedScrollingRowIndex = miscari.RowCount - 1;
            piesa = origine.piesa;
            imagineLocatie.BackgroundImage = origine.imagineLocatie.BackgroundImage;
            tipPiesa = origine.tipPiesa;
            culoare = origine.culoare;
            origine.culoare = 0;
            origine.tipPiesa = 0;
            origine.piesa = null;
        }
        public void Muta(LocatieTabla origine, LocatieTabla destinatie, DataGridView miscari, string mesaj)
        {
            if (piesa != null)
            {
                miscari.Rows.Add(++count, origine.nume + " -> " + nume, origine.piesa.imagineMicaPiesa.Image, piesa.imagineMicaPiesa.Image);
                if (count == 7)
                {
                    miscari.Width = miscari.Width + 17;
                }
            }
            if (piesa == null)
            {
                Bitmap img = new Bitmap(25, 25);
                miscari.Rows.Add(++count, origine.nume + " -> " + nume, origine.piesa.imagineMicaPiesa.Image, img);
                if (count == 7)
                {
                    miscari.Width = miscari.Width + 17;
                }
            }
           
            mesaj = origine.nume.ToString() + " " + nume.ToString();
            Form1.mesajDeTransmis = mesaj;
            miscari.FirstDisplayedScrollingRowIndex = miscari.RowCount - 1;
            piesa = origine.piesa;
            imagineLocatie.BackgroundImage = origine.imagineLocatie.BackgroundImage;
            tipPiesa = origine.tipPiesa;
            culoare = origine.culoare;
            origine.culoare = 0;
            origine.tipPiesa = 0;
            origine.piesa = null;
            
        }
    }
}
