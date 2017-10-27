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

        Color[,] culoriCasute;

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
            Piesa plm;
            int tipPiesa = 0;
            int culoare = 0;
            bool arePiesa = false;
            public bool sePoate = false;
            public PictureBox imagineLocatie;
            public LocatieTabla(Piesa p, PictureBox b)
            {
                plm = p;
                culoare = p.culoare;
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
                    sePoate = true;
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
                tipPiesa = origine.tipPiesa;
                culoare = origine.culoare;
                origine.culoare = 0;
                origine.tipPiesa = 0;
            }

            public void RestaureazaCuloare(int i, int j, LocatieTabla[,] loc, Color[,] c)
            {
                loc[i, j].imagineLocatie.BackColor = c[i, j];
                c[i, j] = Color.Empty;
            }

            public void Verifica(int i, int j, LocatieTabla[,] loc, Color[,] culori )//apelata la click pe piesa; edit: de folosit doar culoarea in if-uri(casute goale==culoare 0) 
            {
                if (tipPiesa == 1)
                {
                    if (culoare == 1)//pion alb
                    {
                        if (loc[i + 1, j].imagineLocatie.BackgroundImage == null)
                        {
                            culori[i + 1, j] = loc[i + 1, j].imagineLocatie.BackColor;
                            loc[i + 1, j].Marcheaza();
                        }
                        if (j < 8 && loc[i + 1, j + 1].culoare==2)
                        {
                            culori[i + 1, j] = loc[i + 1, j].imagineLocatie.BackColor;
                            loc[i + 1, j + 1].Marcheaza();
                        }
                        if (j > 1 && loc[i + 1, j - 1].culoare == 2)
                        {
                            culori[i + 1, j] = loc[i + 1, j].imagineLocatie.BackColor;
                            loc[i + 1, j - 1].Marcheaza();
                        }

                    }
                    if (culoare == 2)//pion negru
                    {
                        if (loc[i - 1, j].imagineLocatie.BackgroundImage == null)
                        {
                            culori[i + 1, j] = loc[i + 1, j].imagineLocatie.BackColor;
                            loc[i + 1, j].Marcheaza();
                        }
                        if (j < 8 && loc[i - 1, j + 1].culoare == 2)
                        {
                            culori[i + 1, j] = loc[i + 1, j].imagineLocatie.BackColor;
                            loc[i + 1, j + 1].Marcheaza();
                        }
                        if (j > 1 && loc[i - 1, j - 1].culoare == 2)
                        {
                            culori[i + 1, j] = loc[i + 1, j].imagineLocatie.BackColor;
                            loc[i + 1, j - 1].Marcheaza();
                        }
                    }
                }
                if (tipPiesa == 2)//tura
                {
                    for (int k = j; k>=1; k--)
                    {
                        if (loc[i, k].imagineLocatie.BackgroundImage==null || loc[i,k].culoare==2)
                        {
                            loc[i, k].Marcheaza();
                        }
                    }
                    for (int k = j ; k <= 8; k++)
                    {
                        if (loc[i, k].imagineLocatie.BackgroundImage == null || loc[i, k].culoare == 2)
                        {
                            loc[i, k].Marcheaza();
                        }
                    }
                    for (int k = i ; k >= 1; k--)
                    {
                        if (loc[k, j].imagineLocatie.BackgroundImage == null || loc[k, j].culoare == 2)
                        {
                            loc[k, j].Marcheaza();
                        }
                    }
                    for (int k = j - 1; k > 1; k++)
                    {
                        if (loc[k, j].imagineLocatie.BackgroundImage == null || loc[k, j].culoare == 2)
                        {
                            loc[k, j].Marcheaza();
                        }
                    }
                }
                if (tipPiesa == 3)//cal
                {
                    if ((i < 8 && j < 7) && (loc[i + 1, j + 2].imagineLocatie.BackgroundImage==null || loc[i + 1, j + 2].culoare == 2))
                    {
                        loc[i + 1, j + 2].Marcheaza();
                    }
                    if ((i < 8 && j > 2) && (loc[i + 1, j - 2].imagineLocatie.BackgroundImage == null || loc[i + 1, j - 2].culoare == 2))
                    {
                        loc[i + 1, j - 2].Marcheaza();
                    }
                    //===
                    if ((i < 7 && j < 8) && (loc[i + 2, j + 1].imagineLocatie.BackgroundImage == null || loc[i + 2, j + 1].culoare == 2))
                    {
                        loc[i + 2, j + 1].Marcheaza();
                    }
                    if ((i < 7 && j > 1) && (loc[i + 2, j - 1].imagineLocatie.BackgroundImage == null || loc[i + 2, j - 1].culoare == 2))
                    {
                        loc[i + 2, j - 1].Marcheaza();
                    }
                    //===
                    if ((i > 1 && j < 7) && (loc[i - 1, j + 2].imagineLocatie.BackgroundImage == null || loc[i - 1, j + 2].culoare == 2))
                    {
                        loc[i - 1, j + 2].Marcheaza();
                    }
                    if ((i > 1 && j > 2) && (loc[i - 1, j - 2].imagineLocatie.BackgroundImage == null || loc[i - 1, j - 2].culoare == 2))
                    {
                        loc[i - 1, j - 2].Marcheaza();
                    }
                    //===                 
                    if ((i > 2 && j < 8) && (loc[i - 2, j + 1].imagineLocatie.BackgroundImage == null || loc[i - 2, j + 1].culoare == 2))
                    {
                        loc[i - 2, j + 1].Marcheaza();
                    }
                    if ((i > 2 && j > 1) && (loc[i - 2, j - 1].imagineLocatie.BackgroundImage == null || loc[i - 2, j - 1].culoare == 2))
                    {
                        loc[i - 2, j - 1].Marcheaza();
                    }
                }
                if (tipPiesa == 4)
                {

                }
                if (tipPiesa == 5)
                {

                }
                if (tipPiesa == 6)
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
            tura1Alb = new Piesa(1, 2, pbTuraAlb); tura2Alb = new Piesa(1, 2, pbTuraAlb);
            nebun1Alb = new Piesa(1, 1, pbNebunAlb); nebun2Alb = new Piesa(1, 1, pbNebunAlb);
            cal1Alb = new Piesa(1, 3, pbCalAlb); cal2Alb = new Piesa(1, 1, pbCalAlb);
            reginaAlb = new Piesa(1, 1, pbReginaAlb); regeAlb = new Piesa(1, 1, pbRegeAlb);
            pion1Alb = new Piesa(1, 1, pbPionAlb); pion2Alb = new Piesa(1, 1, pbPionAlb);
            pion3Alb = new Piesa(1, 1, pbPionAlb); pion4Alb = new Piesa(1, 1, pbPionAlb);
            pion5Alb = new Piesa(1, 1, pbPionAlb); pion6Alb = new Piesa(1, 1, pbPionAlb);
            pion7Alb = new Piesa(1, 1, pbPionAlb); pion8Alb = new Piesa(1, 1, pbPionAlb);

            pion1Negru = new Piesa(1, 1, pbPionNegru);
            tura1Negru = new Piesa(2, 2, pbTuraNegru); tura2Negru = new Piesa(1, 1, pbTuraNegru);
            nebun1Negru = new Piesa(1, 1, pbNebunNegru); nebun2Negru = new Piesa(1, 1, pbNebunNegru);
            cal1Negru = new Piesa(1, 1, pbCalNegru); cal2Negru = new Piesa(1, 1, pbCalNegru);
            reginaNegru = new Piesa(1, 1, pbReginaNegru); regeNegru = new Piesa(1, 1, pbRegeNegru);
            pion1Negru = new Piesa(1, 1, pbPionNegru); pion2Negru = new Piesa(1, 1, pbPionNegru);
            pion3Negru = new Piesa(1, 1, pbPionNegru); pion4Negru = new Piesa(1, 1, pbPionNegru);
            pion5Negru = new Piesa(1, 1, pbPionNegru); pion6Negru = new Piesa(1, 1, pbPionNegru);
            pion7Negru = new Piesa(1, 1, pbPionNegru); pion8Negru = new Piesa(1, 1, pbPionNegru);


            A1 = new LocatieTabla(tura1Alb, _1A);
            A2 = new LocatieTabla(cal1Alb, _2A);
            A3 = new LocatieTabla(nebun1Alb, _3A);
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
            C2 = new LocatieTabla(tura1Negru, _2C); D2 = new LocatieTabla(_2D);
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

            culoriCasute = new Color[70,70];
            locatii = new LocatieTabla[100, 100];
            locatii[1, 1] = A1;
            locatii[1, 2] = A2;
            locatii[1, 3] = A3;
            locatii[2, 1] = B1;
            locatii[2, 2] = B2;
            locatii[2, 3] = B3;
            locatii[2, 4] = B4;
            locatii[2, 5] = B5;
            locatii[2, 6] = B6;
            locatii[2, 7] = B7;
            locatii[2, 8] = B8;
            locatii[3, 1] = C1;
            locatii[3, 2] = C2;
            locatii[3, 3] = C3;
            locatii[3, 4] = C4;
            locatii[3, 5] = C5;
            locatii[4, 1] = D1;
            locatii[4, 2] = D2;
            locatii[5, 1] = E1;
            locatii[6, 1] = F1;
            locatii[7, 1] = G1;
            locatii[8, 1] = H1;

            //locatii[3,1].Marcheaza();
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
                A2.Verifica(1, 2, locatii, culoriCasute);
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
                B1.Verifica(2, 1, locatii, culoriCasute);

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

        private void _1C_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _1C.BackgroundImage != null)
            {

                orig = C1;
                pozitieCifra1 = 1;
                pozitieLitera1 = 1;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
                C1.Verifica(3, 1, locatii, culoriCasute);

            }
            else if (C1 != orig && C1.sePoate==true)
            {
                C1.Muta(orig);
                orig.StergeLocatie();
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 0;
                clickCounter = 0;
                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
                C1.sePoate = false;
            }
        }

        private void _2C_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _2C.BackgroundImage != null)
            {

                orig = C2;
                pozitieCifra1 = 1;
                pozitieLitera1 = 1;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
                C2.Verifica(2, 1, locatii, culoriCasute);

            }
            else if (C2 != orig && C2.sePoate == true)
            {
                C2.Muta(orig);
                orig.StergeLocatie();
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 0;
                clickCounter = 0;
                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
                //if (C2.imagineLocatie.BackgroundImage == null) C2.sePoate = true;
                //else C2.sePoate = false;

            }
        }
        private void _1H_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _1H.BackgroundImage != null)
            {
                orig = H1;

                pozitieCifra1 = 1;
                pozitieLitera1 = 1;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";

            }
            else if (H1 != orig)
            {
                H1.Muta(orig);
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

