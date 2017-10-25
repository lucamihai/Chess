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
        int clickCounter = 0;
        int pozitieCifra1;
        int pozitieLitera1;
        int pozitieCifra2;
        int pozitieLitera2;

        public LocatieTabla[,] locatii;

        Piesa pion1Alb, pion2Alb, pion3Alb, pion4Alb, pion5Alb, pion6Alb, pion7Alb, pion8Alb;
        Piesa pion1Negru, pion2Negru, pion3Negru, pion4Negru, pion5Negru, pion6Negru, pion7Negru, pion8Negru;

        Piesa tura1Alb, tura2Alb;
        Piesa nebun1Alb, nebun2Alb;
        Piesa cal1Alb, cal2Alb;
        Piesa reginaAlb; Piesa regeAlb;

        Piesa tura1Negru, tura2Negru;

        Piesa nebun1Negru, nebun2Negru;
        Piesa cal1Negru, cal2Negru;
        Piesa reginaNegru, regeNegru;

        LocatieTabla orig;

        LocatieTabla A1, A2, A3, A4, A5, A6, A7, A8, B1, B2, B3, B4, B5, B6, B7, B8;
        LocatieTabla H1, H2, H3, H4, H5, H6, H7, H8, G1, G2, G3, G4, G5, G6, G7, G8;

        LocatieTabla C1, C2, C3, C4, C5, C6, C7, C8, D1, D2, D3, D4, D5, D6, D7, D8;
        LocatieTabla E1, E2, E3, E4, E5, E6, E7, E8, F1, F2, F3, F4, F5, F6, F7, F8;
       
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
            public void VerificaPosibilitati(int i, int j, LocatieTabla[,] loc)//self-explanatory -  verifica posibilitatile de miscare a piesei: tipul ofera comportamentul miscarii, iar culoarea directia...
            {
               
            }            
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        public class LocatieTabla
        {
            public Piesa piesa = null;
            
            int tipPiesa = 0;
            bool arePiesa = false;
            public bool sePoate = false;
            public PictureBox imagineLocatie;
            public LocatieTabla(Piesa p, PictureBox b)
            {
                arePiesa = true;
                tipPiesa = p.tipPiesa;
                imagineLocatie = b;
                b.BackgroundImage = p.imaginePiesa.BackgroundImage;
            }
            public LocatieTabla(PictureBox b)
            {
                imagineLocatie = b;
                
            }

            public void SelecteazaCasute(int i, int j)
            {
                if (tipPiesa == 1)
                {
                    
                }
            }
            public void MarcheazaVerde(CheckBox c)//daca sunt indeplinite regulile, marcheaza locatia ca fiind accesibila; optional afiseaza verde pe casuta respectiva
            {

                if (c.Checked == true)
                {
                    imagineLocatie.BackColor = Color.Green;
                }
            }
            public void Marcheaza()//daca sunt indeplinite regulile, marcheaza locatia ca fiind accesibila; optional afiseaza verde pe casuta respectiva
            {

                
                {
                    imagineLocatie.BackColor = Color.Green;
                }
            }

            public void StergeLocatie()
            {
                imagineLocatie.BackgroundImage = null;
            }
            public void Muta(LocatieTabla origine)
            {
                imagineLocatie.BackgroundImage = origine.imagineLocatie.BackgroundImage;
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

        class Pion :Piesa
        {

        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //LocatieTabla A1 = new LocatieTabla(10,_1A);
            tura1Alb = new Piesa(1, 1, pbTuraAlb); tura2Alb = new Piesa(1, 2, pbTuraAlb);
            nebun1Alb = new Piesa(1, 1, pbNebunAlb); nebun2Alb = new Piesa(1, 1, pbNebunAlb);
            cal1Alb = new Piesa(1, 1, pbCalAlb); cal2Alb = new Piesa(1, 1, pbCalAlb);
            reginaAlb = new Piesa(1, 1, pbReginaAlb); regeAlb = new Piesa(1, 1, pbRegeAlb);
            pion1Alb = new Piesa(1, 1, pbPionAlb); pion2Alb = new Piesa(1, 1, pbPionAlb);
            pion3Alb = new Piesa(1, 1, pbPionAlb); pion4Alb = new Piesa(1, 1, pbPionAlb);
            pion5Alb = new Piesa(1, 1, pbPionAlb); pion6Alb = new Piesa(1, 1, pbPionAlb);
            pion7Alb = new Piesa(1, 1, pbPionAlb); pion8Alb = new Piesa(1, 1, pbPionAlb);

            pion1Negru = new Piesa(1, 1, pbPionNegru);
            tura1Negru = new Piesa(1, 1, pbTuraNegru); tura2Negru = new Piesa(1, 1, pbTuraNegru);
            nebun1Negru = new Piesa(1, 1, pbNebunNegru); nebun2Negru = new Piesa(1, 1, pbNebunNegru);
            cal1Negru = new Piesa(1, 1, pbCalNegru); cal2Negru = new Piesa(1, 1, pbCalNegru);
            reginaNegru = new Piesa(1, 1, pbReginaNegru); regeNegru = new Piesa(1, 1, pbRegeNegru);
            pion1Negru = new Piesa(1, 1, pbPionNegru); pion2Negru = new Piesa(1, 1, pbPionNegru);
            pion3Negru = new Piesa(1, 1, pbPionNegru); pion4Negru = new Piesa(1, 1, pbPionNegru);
            pion5Negru = new Piesa(1, 1, pbPionNegru); pion6Negru = new Piesa(1, 1, pbPionNegru);
            pion7Negru = new Piesa(1, 1, pbPionNegru); pion8Negru = new Piesa(1, 1, pbPionNegru);

            A1 = new LocatieTabla(tura1Alb, _1A);
            A2 = new LocatieTabla(nebun1Alb, _2A);
            A3 = new LocatieTabla(cal1Alb, _3A);
            A4 = new LocatieTabla(reginaAlb, _4A);
            A5 = new LocatieTabla(regeAlb, _5A);
            A6 = new LocatieTabla(nebun2Alb, _6A);
            A7 = new LocatieTabla(cal2Alb, _7A);
            A8 = new LocatieTabla(tura2Alb, _8A);
            B1 = new LocatieTabla(pion1Alb, _1B);
            B2 = new LocatieTabla(pion2Alb, _2B);
            B3 = new LocatieTabla(pion3Alb, _3B);
            B4 = new LocatieTabla(pion4Alb, _4B);
            B5 = new LocatieTabla(pion5Alb, _5B);
            B6 = new LocatieTabla(pion6Alb, _6B);
            B7 = new LocatieTabla(pion7Alb, _7B);
            B8 = new LocatieTabla(pion8Alb, _8B);

            H1 = new LocatieTabla(tura1Negru, _1H);
            H2 = new LocatieTabla(cal1Negru, _2H);
            H3 = new LocatieTabla(nebun1Negru, _3H);
            H4 = new LocatieTabla(regeNegru, _4H);
            H5 = new LocatieTabla(reginaNegru, _5H);
            H6 = new LocatieTabla(nebun2Negru, _6H);
            H7 = new LocatieTabla(cal2Negru, _7H);
            H8 = new LocatieTabla(tura2Negru, _8H);
            G1 = new LocatieTabla(pion1Negru, _1G);
            G2 = new LocatieTabla(pion2Negru, _2G);
            G3 = new LocatieTabla(pion3Negru, _3G);
            G4 = new LocatieTabla(pion4Negru, _4G);
            G5 = new LocatieTabla(pion5Negru, _5G);
            G6 = new LocatieTabla(pion6Negru, _6G);
            G7 = new LocatieTabla(pion7Negru, _7G);
            G8 = new LocatieTabla(pion8Negru, _8G);

            C1 = new LocatieTabla(_1C); D1 = new LocatieTabla(_1D);
            C2 = new LocatieTabla(_2C); D2 = new LocatieTabla(_2D);
            C3 = new LocatieTabla(_3C); D3 = new LocatieTabla(_3D);
            C4 = new LocatieTabla(_4C); D4 = new LocatieTabla(_4D);
            C5 = new LocatieTabla(_5C); D5 = new LocatieTabla(_5D);
            C6 = new LocatieTabla(_6C); D6 = new LocatieTabla(_6D);
            C7 = new LocatieTabla(_7C); D7 = new LocatieTabla(_7D);
            C8 = new LocatieTabla(_8C); D8 = new LocatieTabla(_8D);

            E1 = new LocatieTabla(_1C); F1 = new LocatieTabla(_1D);
            E2 = new LocatieTabla(_2C); F2 = new LocatieTabla(_2D);
            E3 = new LocatieTabla(_3C); F3 = new LocatieTabla(_3D);
            E4 = new LocatieTabla(_4C); F4 = new LocatieTabla(_4D);
            E5 = new LocatieTabla(_5C); F5 = new LocatieTabla(_5D);
            E6 = new LocatieTabla(_6C); F6 = new LocatieTabla(_6D);
            E7 = new LocatieTabla(_7C); F7 = new LocatieTabla(_7D);
            E8 = new LocatieTabla(_8C); F8 = new LocatieTabla(_8D);

            locatii = new LocatieTabla[10, 10];
            locatii[1, 1] = A1;
            locatii[1, 2] = A2;
            locatii[1, 3] = A3;
            locatii[2, 1] = B1;
            locatii[3, 1] = C1;


        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LocatieTabla h = new LocatieTabla(pion1Alb, _1A);
            h.MarcheazaVerde(checkBox1);

        }


        private void _1A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _1A.BackgroundImage != null)
            {
                orig = A1;
                
                pozitieCifra1 = 1;
                pozitieLitera1 = 1;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
                
            }
            else if (A1 != orig)
            {
                A1.Muta(orig);
                orig.StergeLocatie();
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
            if (clickCounter == 0 && _2A.BackgroundImage != null)
            {
                
                orig = A2;
                pozitieCifra1 = 1;
                pozitieLitera1 = 1;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
            }
            else if (A2 != orig)
            {
                A2.Muta(orig);
                orig.StergeLocatie();
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 0;
                clickCounter = 0;
                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
            }
        }

        private void _1B_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _1B.BackgroundImage != null)
            {
                
                orig = B1;
                pozitieCifra1 = 1;
                pozitieLitera1 = 1;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
                

            }
            else if (B1 != orig)
            {
                B1.Muta(orig);
                orig.StergeLocatie();
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 0;
                clickCounter = 0;
                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
            }
        }
    }
}

