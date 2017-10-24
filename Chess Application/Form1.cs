using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Application
{
    public partial class Form1 : Form
    {
        //LocatieTabla[,] locatii = new LocatieTabla[10, 10];
        //PictureBox[,] pozitie = new PictureBox[9, 9];
        int clickCounter = 0;
        int pozitieCifra1;
        int pozitieLitera1;
        int pozitieCifra2;
        int pozitieLitera2;
        Piesa pion1alb, pion2alb, pion3alb, pion4alb, pion5alb, pion6alb, pion7alb, pion8alb;
        Piesa pion1negru, pion2negru, pion3negru, pion4negru, pion5negru, pion6negru, pion7negru, pion8negru;

        LocatieTabla A1;
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public class Piesa
        {
            public PictureBox imaginePiesa;
            public Piesa()
            {//constructor fara parametrii
                
            }
            public Piesa(int c, int t, PictureBox pct)//constructor cu initializare tip si culoare piesa
            {
                culoare = c;
                tipPiesa = t;
                imaginePiesa = pct;
            }
            public Piesa(int t, PictureBox pct)//constructor cu initializare tip piesa(in cazul in care piesele sunt albe, nefiind necesara initializarii valorii culoare)
            {
                this.tipPiesa = t;
                imaginePiesa = pct;
            }
            public int culoare = 1;//1-alb, 2-negru;
            public int tipPiesa = 0;//0-nici una, 1-pion, 2-tura, 3-cal, 4-nebun, 5-regina, 6-rege;
            public void VerificaPosibilitati()//self-explanatory -  verifica posibilitatile de miscare a piesei: tipul ofera comportamentul miscarii, iar culoarea directia...
            {

            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public class LocatieTabla
        {
            bool arePiesa = false;
            PictureBox imagineLocatie;
            public LocatieTabla(Piesa p, PictureBox b)
            {
                imagineLocatie = b;
                b.BackgroundImage = p.imaginePiesa.BackgroundImage;
            }
            public LocatieTabla(PictureBox b)
            {
                imagineLocatie = b;
            }
            public void MarcheazaVerde(CheckBox c)//daca sunt indeplinite regulile, marcheaza locatia ca fiind accesibila; optional afiseaza verde pe casuta respectiva
            {
                
                if (c.Checked == true)
                {
                    imagineLocatie.BackColor=Color.Green;
                }
            }

            public void Verifica(Piesa a)//apelata la click pe piesa
            {
                if (a.tipPiesa == 1)
                {
                    if (a.culoare == 1)//merge 
                    {

                    }
                    if (a.culoare == 2)
                    {

                    }
                }
                if (a.tipPiesa == 2)
                {

                }
                if (a.tipPiesa == 3)
                {

                }
                if (a.tipPiesa == 4)
                {

                }
                if (a.tipPiesa == 5)
                {

                }
                if (a.tipPiesa == 6)
                {

                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LocatieTabla A1 = new LocatieTabla(10,_1A);
            pion1alb = new Piesa(1, 1, pbTuraAlb);
            A1 = new LocatieTabla(pion1alb, _1B);

            LocatieTabla[,] locatii = new LocatieTabla[10, 10];
            LocatieTabla[1, 1] = A1;


        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LocatieTabla h = new LocatieTabla(pion1alb, _1A);
            h.MarcheazaVerde(checkBox1);

        }

        
        private void _1A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0)
            {
                pozitieCifra1 = 0;
                pozitieLitera1 = 0;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
            }
            else
            {
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 0;
                clickCounter = 0;

                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
            }
            
        }

       

        private void _2A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0)
            {
                pozitieCifra1 = 2;
                pozitieLitera1 = 1;
                x.Text = pozitieCifra1.ToString();

                y.Text = ((char)(pozitieLitera1-1+(int)'A')).ToString();
                
                
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
            }
            else
            {
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 1;
                clickCounter = 0;
                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
            }
        }

        private void _1B_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0)
            {
                pozitieCifra1 = 1;
                pozitieLitera1 = 2;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();

                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
            }
            else
            {
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 1;
                pozitieLitera2 = 2;
                clickCounter = 0;
                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
            }
        }
    }
}

