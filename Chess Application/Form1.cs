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
            bool poateFaceMiscari = false;
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


            public void Verifica(int i, int j, LocatieTabla[,] loc, Color[,] culori )//apelata la click pe piesa; edit: de folosit doar culoarea in if-uri(casute goale==culoare 0) 
            {
                if (tipPiesa == 1)
                {
                    if (culoare == 1)//pion alb
                    {
                        if (loc[i + 1, j].imagineLocatie.BackgroundImage == null)
                        {
                            loc[i + 1, j].Marcheaza();
                        }
                        if (j < 8 && loc[i + 1, j + 1].culoare==2)
                        {
                            loc[i + 1, j + 1].Marcheaza();
                        }
                        if (j > 1 && loc[i + 1, j - 1].culoare == 2)
                        {
                            loc[i + 1, j - 1].Marcheaza();
                        }

                    }
                    if (culoare == 2)//pion negru
                    {
                        if (loc[i - 1, j].imagineLocatie.BackgroundImage == null)
                        {
                            loc[i - 1, j].Marcheaza();
                        }
                        if (j < 8 && loc[i - 1, j + 1].culoare == 2)
                        {
                            loc[i - 1, j + 1].Marcheaza();
                        }
                        if (j > 1 && loc[i - 1, j - 1].culoare == 2)
                        {
                            loc[i - 1, j - 1].Marcheaza();
                        }
                    }
                }
                if (tipPiesa == 2)//tura
                {
                    //------------------------------explicatie universala pentru cele 4 for-uri-------------------------------------------------------------

                    //prima linie din for: daca urmatoarea casuta exista si are o piesa de aceeasi culoare intrerupe
                    //aditional, daca locatia curenta este diferita de locatia originala(de la apelul functiei), marcheaza casuta respectiva
                    //a doua linie din for: daca cele doua casute contin piese de culori diferite(printre care 0==casuta goala), marcheaza casuta curenta
                    //a treia linie din for: daca casuta curenta are o piesa diferita de cea a casutei originale, intrerupe for-ul
                    //obs. casuta respectiva "apuca" sa fie marcata, intrucat este marcata anterior
                    //--------------------------------------------------------------------------------------------------------------------------------------
                    for (int k = j; k>=1; k--)
                    {
                        if (loc[i, k -1] != null && loc[i, k - 1].culoare == loc[i, j].culoare) { if (loc[i, k] != loc[i, j]) loc[i, k].Marcheaza(); break; }
                        if (loc[i, k].culoare != loc[i, j].culoare) loc[i, k].Marcheaza();                         
                        if ((loc[i, k].culoare != loc[i, j].culoare && loc[i, k].culoare != 0)) break;
                    }
                    for (int k = j ; k <= 8; k++)
                    {
                        if (loc[i, k + 1] != null && loc[i, k + 1].culoare == loc[i, j].culoare) { if (loc[i, k] != loc[i, j]) loc[i, k].Marcheaza(); break; } 
                        if (loc[i, k].culoare != loc[i, j].culoare) loc[i, k].Marcheaza();                       
                        if ((loc[i, k].culoare !=  loc[i, j].culoare && loc[i, k].culoare != 0)) break;
                    }
                    for (int k = i ; k >= 1; k--)
                    {
                        if (loc[k - 1, j] != null && loc[k - 1, j].culoare == loc[i, j].culoare) { if (loc[k, j] != loc[i, j]) loc[k, j].Marcheaza(); break; }
                        if (loc[k, j].culoare != loc[i, j].culoare) loc[k, j].Marcheaza();
                        if ((loc[k, j].culoare != loc[i, j].culoare && loc[k, j].culoare != 0)) break;
                    }
                    for (int k = i; k <= 8; k++)
                    {
                        if (loc[k + 1, j] != null && loc[k + 1, j].culoare == loc[i, j].culoare) { if (loc[k, j] != loc[i, j]) loc[k, j].Marcheaza(); break; }
                        if (loc[k, j].culoare != loc[i, j].culoare) loc[k, j].Marcheaza();
                        if ((loc[k, j].culoare != loc[i, j].culoare && loc[k, j].culoare != 0)) break;
                    }
                }
                if (tipPiesa == 3)//cal
                {
                    //self explanatory right here
                    //=====
                    if ((i < 8 && j < 7) && (loc[i + 1, j + 2].culoare!= loc[i, j].culoare))
                    {
                        loc[i + 1, j + 2].Marcheaza();
                    }
                    if ((i < 8 && j > 2) && (loc[i + 1, j - 2].culoare!= loc[i, j].culoare))
                    {
                        loc[i + 1, j - 2].Marcheaza();
                    }
                    //=====
                    if ((i < 7 && j < 8) && (loc[i + 2, j + 1].culoare != loc[i, j].culoare))
                    {
                        loc[i + 2, j + 1].Marcheaza();
                    }
                    if ((i < 7 && j > 1) && (loc[i + 2, j - 1].culoare != loc[i, j].culoare))
                    {
                        loc[i + 2, j - 1].Marcheaza();
                    }
                    //=====
                    if ((i > 1 && j < 7) && (loc[i - 1, j + 2].culoare != loc[i, j].culoare))
                    {
                        loc[i - 1, j + 2].Marcheaza();
                    }
                    if ((i > 1 && j > 2) && (loc[i - 1, j - 2].culoare != loc[i, j].culoare))
                    {
                        loc[i - 1, j - 2].Marcheaza();
                    }
                    //=====              
                    if ((i > 2 && j < 8) && (loc[i - 2, j + 1].culoare != loc[i, j].culoare))
                    {
                        loc[i - 2, j + 1].Marcheaza();
                    }
                    if ((i > 2 && j > 1) && (loc[i - 2, j - 1].culoare != loc[i, j].culoare))
                    {
                        loc[i - 2, j - 1].Marcheaza();
                    }
                    //=====
                }
                if (tipPiesa == 4)//nebun
                {
                    //------------------------------explicatie universala pentru cele 4 for-uri-------------------------------------------------------------

                    //primul if din for: daca urmatoarea casuta exista si are o piesa de culoare diferita, o marcheaza 
                    //al doilea if din for: daca exista urmatoarea casuta si daca contine o piesa de orice culoare, interupe for-ul (aplicabil pentru alb)
                    //al treilea if din for: daca exista urmatoarea casuta si daca contine o piesa de orice culoare, interupe for-ul (aplicabil pentru negru)
                    //obs. casuta respectiva "apuca" sa fie marcata, intrucat este marcata anterior
                    //--------------------------------------------------------------------------------------------------------------------------------------
                    for (int l = i, c = j; l>=1 && c>=1; l--, c--)
                    {
                        if (loc[i, j].culoare != loc[l, c].culoare)
                        {
                            loc[l, c].Marcheaza();
                        }
                        if (culoare == 1)
                        {
                            if (loc[l - 1, c - 1] != null && (loc[l - 1, c - 1].culoare == 1 || loc[l, c].culoare == 2)) break;
                        }
                        if (culoare == 2)
                        {
                            if (loc[l - 1, c - 1] != null && (loc[l - 1, c - 1].culoare == 2 || loc[l, c].culoare == 1)) break;
                        }

                    }
                    for (int l = i, c = j; l <= 8 && c <= 8; l++, c++)  
                    {
                        if (loc[i, j].culoare != loc[l, c].culoare)
                        {
                            loc[l, c].Marcheaza();
                        }
                        if (culoare == 1)
                        {
                            if (loc[l + 1, c + 1] != null && (loc[l+1, c+1].culoare == 1 || loc[l, c].culoare == 2)) break;
                        }
                        if (culoare == 2)
                        {
                            if (loc[l + 1, c + 1] != null && (loc[l + 1, c + 1].culoare == 2 || loc[l, c].culoare == 1)) break;
                        }
                    }
                    for (int l = i, c = j; l <= 8 && c >= 1; l++, c--)
                    {
                        if (loc[i, j].culoare != loc[l, c].culoare)
                        {
                            loc[l, c].Marcheaza();
                        }
                        if (culoare == 1)
                        {
                            if (loc[l + 1, c - 1] != null && (loc[l+1, c-1].culoare == 1 || loc[l, c].culoare == 2)) break;
                        }
                        if (culoare == 2)
                        {
                            if (loc[l + 1, c - 1] != null && (loc[l + 1, c - 1].culoare == 2 || loc[l, c].culoare == 1)) break;
                        }
                    }
                    for (int l = i, c = j; l >= 1 && c <= 8; l--, c++)
                    {
                        if (loc[i, j].culoare != loc[l, c].culoare)
                        {
                            loc[l, c].Marcheaza();
                        }
                        if (culoare == 1)
                        {
                            if (loc[l - 1, c + 1] != null && (loc[l-1, c+1].culoare == 1 || loc[l, c].culoare == 2)) break;
                        }
                        if (culoare == 2)
                        {
                            if (loc[l - 1, c + 1] != null && (loc[l - 1, c + 1].culoare == 2 || loc[l, c].culoare == 1)) break;
                        }
                    }
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
            nebun1Alb = new Piesa(1, 4, pbNebunAlb); nebun2Alb = new Piesa(1, 1, pbNebunAlb);
            cal1Alb = new Piesa(1, 3, pbCalAlb); cal2Alb = new Piesa(1, 1, pbCalAlb);
            reginaAlb = new Piesa(1, 1, pbReginaAlb); regeAlb = new Piesa(1, 1, pbRegeAlb);
            pion1Alb = new Piesa(1, 1, pbPionAlb); pion2Alb = new Piesa(1, 1, pbPionAlb);
            pion3Alb = new Piesa(1, 1, pbPionAlb); pion4Alb = new Piesa(1, 1, pbPionAlb);
            pion5Alb = new Piesa(1, 1, pbPionAlb); pion6Alb = new Piesa(1, 1, pbPionAlb);
            pion7Alb = new Piesa(1, 1, pbPionAlb); pion8Alb = new Piesa(1, 1, pbPionAlb);

            pion1Negru = new Piesa(2, 1, pbPionNegru);
            tura1Negru = new Piesa(2, 2, pbTuraNegru); tura2Negru = new Piesa(2, 1, pbTuraNegru);
            nebun1Negru = new Piesa(2, 4, pbNebunNegru); nebun2Negru = new Piesa(2, 2, pbNebunNegru);
            cal1Negru = new Piesa(2, 3, pbCalNegru); cal2Negru = new Piesa(2, 3, pbCalNegru);
            reginaNegru = new Piesa(2, 1, pbReginaNegru); regeNegru = new Piesa(2, 1, pbRegeNegru);
            pion1Negru = new Piesa(2, 1, pbPionNegru); pion2Negru = new Piesa(2, 1, pbPionNegru);
            pion3Negru = new Piesa(2, 1, pbPionNegru); pion4Negru = new Piesa(2, 1, pbPionNegru);
            pion5Negru = new Piesa(2, 1, pbPionNegru); pion6Negru = new Piesa(2, 1, pbPionNegru);
            pion7Negru = new Piesa(2, 1, pbPionNegru); pion8Negru = new Piesa(2, 1, pbPionNegru);


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

            E1 = new LocatieTabla(_1E); F1 = new LocatieTabla(_1F);
            E2 = new LocatieTabla(_2E); F2 = new LocatieTabla(_2F);
            E3 = new LocatieTabla(_3E); F3 = new LocatieTabla(_3F);
            E4 = new LocatieTabla(_4E); F4 = new LocatieTabla(_4F);
            E5 = new LocatieTabla(_5E); F5 = new LocatieTabla(_5F);
            E6 = new LocatieTabla(_6E); F6 = new LocatieTabla(_6F);
            E7 = new LocatieTabla(_7E); F7 = new LocatieTabla(_7F);
            E8 = new LocatieTabla(_8E); F8 = new LocatieTabla(_8F);

            culoriCasute = new Color[70,70];

            for (int i = 1; i <= 64; i++)
            {
                for (int j = 1; j <= 64; j++)
                {
                    culoriCasute[i, j] = Color.Empty;

                }
            }

            locatii = new LocatieTabla[100, 100];
            locatii[1, 1] = A1;
            locatii[1, 2] = A2;
            locatii[1, 3] = A3;
            locatii[1, 4] = A4;
            locatii[1, 5] = A5;
            locatii[1, 6] = A6;
            locatii[1, 7] = A7;
            locatii[1, 8] = A8;
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
            locatii[3, 6] = C6;
            locatii[3, 7] = C7;
            locatii[3, 8] = C8;
            locatii[4, 1] = D1;
            locatii[4, 2] = D2;
            locatii[4, 3] = D3;
            locatii[4, 4] = D4;
            locatii[4, 5] = D5;
            locatii[4, 6] = D6;
            locatii[4, 7] = D7;
            locatii[4, 8] = D8;
            locatii[5, 1] = E1;
            locatii[5, 2] = E2;
            locatii[5, 3] = E3;
            locatii[5, 4] = E4;
            locatii[5, 5] = E5;
            locatii[5, 6] = E6;
            locatii[5, 7] = E7;
            locatii[5, 8] = E8;
            locatii[6, 1] = F1;
            locatii[6, 2] = F2;
            locatii[6, 3] = F3;
            locatii[6, 4] = F4;
            locatii[6, 5] = F5;
            locatii[6, 6] = F6;
            locatii[6, 7] = F7;
            locatii[6, 8] = F8;
            locatii[7, 1] = G1;
            locatii[7, 2] = G2;
            locatii[7, 3] = G3;
            locatii[7, 4] = G4;
            locatii[7, 5] = G5;
            locatii[7, 6] = G6;
            locatii[7, 7] = G7;
            locatii[7, 8] = G8;
            locatii[8, 1] = H1;
            locatii[8, 2] = H2;
            locatii[8, 3] = H3;
            locatii[8, 4] = H4;
            locatii[8, 5] = H5;
            locatii[8, 6] = H6;
            locatii[8, 7] = H7;
            locatii[8, 8] = H8;
            

            //locatii[3,1].Marcheaza();
        }
        public void RestoreCulori(LocatieTabla[,] loc)
        {
            A1.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            A2.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            A3.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            A4.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            A5.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            A6.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            A7.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            A8.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            B1.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            B2.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            B3.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            B4.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            B5.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            B6.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            B7.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            B8.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            C1.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            C2.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            C3.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            C4.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            C5.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            C6.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            C7.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            C8.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            D1.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            D2.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            D3.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            D4.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            D5.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            D6.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            D7.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            D8.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            E1.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            E2.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            E3.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            E4.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            E5.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            E6.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            E7.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            E8.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            F1.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            F2.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            F3.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            F4.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            F5.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            F6.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            F7.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            F8.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            G1.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            G2.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            G3.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            G4.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            G5.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            G6.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            G7.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            G8.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            H1.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            H2.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            H3.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            H4.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            H5.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            H6.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
            H7.imagineLocatie.BackColor = System.Drawing.Color.Silver;
            H8.imagineLocatie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(107)))), ((int)(((byte)(86)))));
        }

        public void RestaureazaCuloare(LocatieTabla[,] loc, Color[,] c)
        {
            for (int i = 1; i <= 64; i++)
            {
                for (int j = 1; j <= 64; j++)
                {
                    if (c[i, j] != Color.Empty)
                    {
                        loc[i, j].imagineLocatie.BackColor = c[i, j];
                        c[i, j] = Color.Empty;
                    }

                }
            }

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
                A1.Verifica(1, 1, locatii, culoriCasute);

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
                RestoreCulori(locatii);
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
                RestoreCulori(locatii);
            }
        }

        private void _3A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _3A.BackgroundImage != null)
            {
                orig = A3;

                pozitieCifra1 = 1;
                pozitieLitera1 = 1;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
                A3.Verifica(1, 3, locatii, culoriCasute);

            }
            else if (A3 != orig)
            {
                A3.Muta(orig);
                orig.StergeLocatie();
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 0;
                clickCounter = 0;
                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
                RestoreCulori(locatii);
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
                RestoreCulori(locatii);

            }
        }

        private void _2B_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _2B.BackgroundImage != null)
            {

                orig = B2;
                pozitieCifra1 = 1;
                pozitieLitera1 = 1;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
                B2.Verifica(2, 2, locatii, culoriCasute);

            }
            else if (B2 != orig)
            {
                B2.Muta(orig);
                orig.StergeLocatie();
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 0;
                clickCounter = 0;
                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
                RestoreCulori(locatii);

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
                RestoreCulori(locatii);
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
                C2.Verifica(3, 2, locatii, culoriCasute);

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
                RestoreCulori(locatii);
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
                H1.Verifica(8, 1, locatii, culoriCasute);

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
                RestoreCulori(locatii);
            }
        }

        private void _2H_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _2H.BackgroundImage != null)
            {
                orig = H2;

                pozitieCifra1 = 1;
                pozitieLitera1 = 1;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
                H2.Verifica(8, 2, locatii, culoriCasute);

            }
            else if (H2 != orig)
            {
                H2.Muta(orig);
                orig.StergeLocatie();
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 0;
                clickCounter = 0;
                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
                RestoreCulori(locatii);
            }
        }

        private void _3H_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _3H.BackgroundImage != null)
            {
                orig = H3;

                pozitieCifra1 = 1;
                pozitieLitera1 = 1;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
                H3.Verifica(8, 3, locatii, culoriCasute);

            }
            else if (H3 != orig)
            {
                H3.Muta(orig);
                orig.StergeLocatie();
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 0;
                clickCounter = 0;
                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
                RestoreCulori(locatii);
            }
        }
    }
}

