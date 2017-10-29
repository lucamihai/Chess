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
        string pozitieLitera1;
        int pozitieCifra2;
        string pozitieLitera2;

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
            public bool poateFaceMiscari = false;
            Piesa plm;
            int tipPiesa = 0;
            int culoare = 0;
            public bool sePoate = false;
            public PictureBox imagineLocatie;
            public LocatieTabla(Piesa p, PictureBox b)
            {
                plm = p;
                culoare = p.culoare;
                tipPiesa = p.tipPiesa;
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


            public void Verifica(int i, int j, LocatieTabla[,] loc)//apelata la click pe piesa; edit: de folosit doar culoarea in if-uri(casute goale==culoare 0) 
            {
                if (tipPiesa == 1)
                {
                    if (culoare == 1)//pion alb
                    {
                        if (loc[i + 1, j]!=null && loc[i + 1, j].imagineLocatie.BackgroundImage == null)
                        {
                            loc[i + 1, j].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if (i<8&&j < 8 && loc[i + 1, j + 1].culoare==2)
                        {
                            loc[i + 1, j + 1].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if (i<8&&j > 1 && loc[i + 1, j - 1].culoare == 2)
                        {
                            loc[i + 1, j - 1].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
                        }

                    }
                    if (culoare == 2)//pion negru
                    {
                        if (loc[i - 1, j]!=null && loc[i - 1, j].imagineLocatie.BackgroundImage == null)
                        {
                            loc[i - 1, j].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if (i>1&&j < 8 && loc[i - 1, j + 1].culoare == 1)
                        {
                            loc[i - 1, j + 1].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if (i>1&&j > 1 && loc[i - 1, j - 1].culoare == 1)
                        {
                            loc[i - 1, j - 1].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
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
                        if (loc[i, k -1] != null && loc[i, k - 1].culoare == loc[i, j].culoare) { if (loc[i, k] != loc[i, j]) { loc[i, k].Marcheaza(); loc[i, j].poateFaceMiscari = true; }  break; }
                        if (loc[i, k].culoare != loc[i, j].culoare)
                        {
                            loc[i, k].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if ((loc[i, k].culoare != loc[i, j].culoare && loc[i, k].culoare != 0)) break;
                    }
                    for (int k = j ; k <= 8; k++)
                    {
                        if (loc[i, k + 1] != null && loc[i, k + 1].culoare == loc[i, j].culoare) { if (loc[i, k] != loc[i, j]) { loc[i, k].Marcheaza(); loc[i, j].poateFaceMiscari = true; }  break; } 
                        if (loc[i, k].culoare != loc[i, j].culoare)
                        {
                            loc[i, k].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if ((loc[i, k].culoare !=  loc[i, j].culoare && loc[i, k].culoare != 0)) break;
                    }
                    for (int k = i ; k >= 1; k--)
                    {
                        if (loc[k - 1, j] != null && loc[k - 1, j].culoare == loc[i, j].culoare) { if (loc[k, j] != loc[i, j]) { loc[k, j].Marcheaza(); loc[i, j].poateFaceMiscari = true; } break; }
                        if (loc[k, j].culoare != loc[i, j].culoare)
                        {
                            loc[k, j].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if ((loc[k, j].culoare != loc[i, j].culoare && loc[k, j].culoare != 0)) break;
                    }
                    for (int k = i; k <= 8; k++)
                    {
                        if (loc[k + 1, j] != null && loc[k + 1, j].culoare == loc[i, j].culoare) { if (loc[k, j] != loc[i, j]) { loc[k, j].Marcheaza(); loc[i, j].poateFaceMiscari = true; } break; }
                        if (loc[k, j].culoare != loc[i, j].culoare)
                        {
                            loc[k, j].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
                        }
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
                        loc[i, j].poateFaceMiscari = true;
                    }
                    if ((i < 8 && j > 2) && (loc[i + 1, j - 2].culoare!= loc[i, j].culoare))
                    {
                        loc[i + 1, j - 2].Marcheaza();
                        loc[i, j].poateFaceMiscari = true;
                    }
                    //=====
                    if ((i < 7 && j < 8) && (loc[i + 2, j + 1].culoare != loc[i, j].culoare))
                    {
                        loc[i + 2, j + 1].Marcheaza();
                        loc[i, j].poateFaceMiscari = true;
                    }
                    if ((i < 7 && j > 1) && (loc[i + 2, j - 1].culoare != loc[i, j].culoare))
                    {
                        loc[i + 2, j - 1].Marcheaza();
                        loc[i, j].poateFaceMiscari = true;
                    }
                    //=====
                    if ((i > 1 && j < 7) && (loc[i - 1, j + 2].culoare != loc[i, j].culoare))
                    {
                        loc[i - 1, j + 2].Marcheaza();
                        loc[i, j].poateFaceMiscari = true;
                    }
                    if ((i > 1 && j > 2) && (loc[i - 1, j - 2].culoare != loc[i, j].culoare))
                    {
                        loc[i - 1, j - 2].Marcheaza();
                        loc[i, j].poateFaceMiscari = true;
                    }
                    //=====              
                    if ((i > 2 && j < 8) && (loc[i - 2, j + 1].culoare != loc[i, j].culoare))
                    {
                        loc[i - 2, j + 1].Marcheaza();
                        loc[i, j].poateFaceMiscari = true;
                    }
                    if ((i > 2 && j > 1) && (loc[i - 2, j - 1].culoare != loc[i, j].culoare))
                    {
                        loc[i - 2, j - 1].Marcheaza();
                        loc[i, j].poateFaceMiscari = true;
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
                            loc[i, j].poateFaceMiscari = true;
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
                            loc[i, j].poateFaceMiscari = true;
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
                            loc[i, j].poateFaceMiscari = true;
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
                            loc[i, j].poateFaceMiscari = true;
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
                if (tipPiesa == 5)//miscari regina obtinute din miscarile turei si miscarile nebunului
                {
                    for (int k = j; k >= 1; k--)
                    {
                        if (loc[i, k - 1] != null && loc[i, k - 1].culoare == loc[i, j].culoare) { if (loc[i, k] != loc[i, j]) { loc[i, k].Marcheaza(); loc[i, j].poateFaceMiscari = true; } break; }
                        if (loc[i, k].culoare != loc[i, j].culoare)
                        {
                            loc[i, k].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if ((loc[i, k].culoare != loc[i, j].culoare && loc[i, k].culoare != 0)) break;
                    }
                    for (int k = j; k <= 8; k++)
                    {
                        if (loc[i, k + 1] != null && loc[i, k + 1].culoare == loc[i, j].culoare) { if (loc[i, k] != loc[i, j]) { loc[i, k].Marcheaza(); loc[i, j].poateFaceMiscari = true; } break; }
                        if (loc[i, k].culoare != loc[i, j].culoare)
                        {
                            loc[i, k].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if ((loc[i, k].culoare != loc[i, j].culoare && loc[i, k].culoare != 0)) break;
                    }
                    for (int k = i; k >= 1; k--)
                    {
                        if (loc[k - 1, j] != null && loc[k - 1, j].culoare == loc[i, j].culoare) { if (loc[k, j] != loc[i, j]) { loc[k, j].Marcheaza(); loc[i, j].poateFaceMiscari = true; } break; }
                        if (loc[k, j].culoare != loc[i, j].culoare)
                        {
                            loc[k, j].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if ((loc[k, j].culoare != loc[i, j].culoare && loc[k, j].culoare != 0)) break;
                    }
                    for (int k = i; k <= 8; k++)
                    {
                        if (loc[k + 1, j] != null && loc[k + 1, j].culoare == loc[i, j].culoare) { if (loc[k, j] != loc[i, j]) { loc[k, j].Marcheaza(); loc[i, j].poateFaceMiscari = true; } break; }
                        if (loc[k, j].culoare != loc[i, j].culoare)
                        {
                            loc[k, j].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if ((loc[k, j].culoare != loc[i, j].culoare && loc[k, j].culoare != 0)) break;
                    }
                    //=====
                    for (int l = i, c = j; l >= 1 && c >= 1; l--, c--)
                    {
                        if (loc[i, j].culoare != loc[l, c].culoare)
                        {
                            loc[l, c].Marcheaza();
                            loc[i, j].poateFaceMiscari = true;
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
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if (culoare == 1)
                        {
                            if (loc[l + 1, c + 1] != null && (loc[l + 1, c + 1].culoare == 1 || loc[l, c].culoare == 2)) break;
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
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if (culoare == 1)
                        {
                            if (loc[l + 1, c - 1] != null && (loc[l + 1, c - 1].culoare == 1 || loc[l, c].culoare == 2)) break;
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
                            loc[i, j].poateFaceMiscari = true;
                        }
                        if (culoare == 1)
                        {
                            if (loc[l - 1, c + 1] != null && (loc[l - 1, c + 1].culoare == 1 || loc[l, c].culoare == 2)) break;
                        }
                        if (culoare == 2)
                        {
                            if (loc[l - 1, c + 1] != null && (loc[l - 1, c + 1].culoare == 2 || loc[l, c].culoare == 1)) break;
                        }
                    }

                }
                if (tipPiesa == 6)//rege, miscare obtinuta prin verificarea celor 8 casute adiacente (sau cate exista) ale acestuia
                {
                    if (loc[i + 1, j] != null && loc[i + 1, j].culoare != loc[i, j].culoare) { loc[i + 1, j].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    if (loc[i + 1, j + 1] != null && loc[i + 1, j + 1].culoare != loc[i, j].culoare) { loc[i + 1, j + 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; } 
                    if (loc[i, j + 1] != null && loc[i, j + 1].culoare != loc[i, j].culoare) { loc[i, j + 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; } 
                    if (loc[i - 1, j + 1] != null && loc[i - 1, j + 1].culoare != loc[i, j].culoare) { loc[i - 1, j + 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; } 

                    if (loc[i - 1, j] != null && loc[i - 1, j].culoare != loc[i, j].culoare) { loc[i - 1, j].Marcheaza(); loc[i, j].poateFaceMiscari = true; } 
                    if (loc[i - 1, j - 1] != null && loc[i - 1, j - 1].culoare != loc[i, j].culoare) { loc[i - 1, j - 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; } 
                    if (loc[i, j - 1] != null && loc[i, j - 1].culoare != loc[i, j].culoare) { loc[i, j - 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; } 
                    if (loc[i + 1, j - 1] != null && loc[i + 1, j - 1].culoare != loc[i, j].culoare) { loc[i + 1, j - 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; } 
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
            tura1Alb = new Piesa(1, 2, pbTuraAlb); tura2Alb = new Piesa(1, 2, pbTuraAlb);
            cal1Alb = new Piesa(1, 3, pbCalAlb); cal2Alb = new Piesa(1, 3, pbCalAlb);
            nebun1Alb = new Piesa(1, 4, pbNebunAlb); nebun2Alb = new Piesa(1, 4, pbNebunAlb);
            reginaAlb = new Piesa(1, 5, pbReginaAlb); regeAlb = new Piesa(1, 6, pbRegeAlb);
            pion1Alb = new Piesa(1, 1, pbPionAlb); pion2Alb = new Piesa(1, 1, pbPionAlb);
            pion3Alb = new Piesa(1, 1, pbPionAlb); pion4Alb = new Piesa(1, 1, pbPionAlb);
            pion5Alb = new Piesa(1, 1, pbPionAlb); pion6Alb = new Piesa(1, 1, pbPionAlb);
            pion7Alb = new Piesa(1, 1, pbPionAlb); pion8Alb = new Piesa(1, 1, pbPionAlb);

            pion1Negru = new Piesa(2, 1, pbPionNegru);
            tura1Negru = new Piesa(2, 2, pbTuraNegru); tura2Negru = new Piesa(2, 2, pbTuraNegru);
            cal1Negru = new Piesa(2, 3, pbCalNegru); cal2Negru = new Piesa(2, 3, pbCalNegru);
            nebun1Negru = new Piesa(2, 4, pbNebunNegru); nebun2Negru = new Piesa(2, 4, pbNebunNegru);
            reginaNegru = new Piesa(2, 5, pbReginaNegru); regeNegru = new Piesa(2, 6, pbRegeNegru);
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
            C2 = new LocatieTabla(_2C); D2 = new LocatieTabla(_2D);
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

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LocatieTabla h = new LocatieTabla(pion1Alb, _1A);
            h.MarcheazaVerde(checkBox1);

        }

        public void RandNou(LocatieTabla[,] loc)
        {
            for (int i=1; i<=8; i++)
            {
                for (int j=1; j<=8; j++)
                {
                    loc[i, j].sePoate = false;
                }
            }
        }


        private void _1A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _1A.BackgroundImage != null)
            {
                A1.Verifica(1, 1, locatii);
                if (A1.poateFaceMiscari == true)
                {
                    orig = A1;
                    clickCounter++;
                }
            }
            else if (A1 != orig && A1.sePoate == true)
            {
                A1.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _2A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _2A.BackgroundImage != null)
            {
                A2.Verifica(1, 2, locatii);
                if (A2.poateFaceMiscari == true)
                {
                    orig = A2;
                    clickCounter++;
                }
            }
            else if (A2 != orig && A2.sePoate == true)
            {
                A2.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _3A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _3A.BackgroundImage != null)
            {
                A3.Verifica(1, 3, locatii);
                if (A3.poateFaceMiscari == true)
                {
                    orig = A3;
                    clickCounter++;
                }
            }
            else if (A3 != orig && A3.sePoate == true)
            {
                A3.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _4A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _4A.BackgroundImage != null)
            {
                A4.Verifica(1, 4, locatii);
                if (A4.poateFaceMiscari == true)
                {
                    orig = A4;
                    clickCounter++;
                }
            }
            else if (A4 != orig && A4.sePoate == true)
            {
                A4.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _5A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _5A.BackgroundImage != null)
            {
                A5.Verifica(1, 5, locatii);
                if (A5.poateFaceMiscari == true)
                {
                    orig = A5;
                    clickCounter++;
                }
            }
            else if (A5 != orig && A5.sePoate == true)
            {
                A5.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _6A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _6A.BackgroundImage != null)
            {
                A6.Verifica(1, 6, locatii);
                if (A6.poateFaceMiscari == true)
                {
                    orig = A6;
                    clickCounter++;
                }
            }
            else if (A6 != orig && A6.sePoate == true)
            {
                A6.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _7A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _7A.BackgroundImage != null)
            {
                A7.Verifica(1, 7, locatii);
                if (A7.poateFaceMiscari == true)
                {
                    orig = A7;
                    clickCounter++;
                }
            }
            else if (A7 != orig && A7.sePoate == true)
            {
                A7.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _8A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _8A.BackgroundImage != null)
            {
                A8.Verifica(1, 8, locatii);
                if (A8.poateFaceMiscari == true)
                {
                    orig = A8;
                    clickCounter++;
                }
            }
            else if (A8 != orig && A8.sePoate == true)
            {
                A8.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _1B_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _1B.BackgroundImage != null)
            {
                B1.Verifica(2, 1, locatii);
                if (B1.poateFaceMiscari == true)
                {
                    orig = B1;
                    clickCounter++;
                }
            }
            else if (B1 != orig && B1.sePoate == true)
            {
                B1.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _2B_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _2B.BackgroundImage != null)
            {
                B2.Verifica(2, 2, locatii);
                if (B2.poateFaceMiscari == true)
                {
                    orig = B2;
                    clickCounter++;
                }
            }
            else if (B2 != orig && B2.sePoate == true)
            {
                B2.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _3B_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _3B.BackgroundImage != null)
            {
                B3.Verifica(2, 3, locatii);
                if (B3.poateFaceMiscari == true)
                {
                    orig = B3;
                    clickCounter++;
                }
            }
            else if (B3 != orig && B3.sePoate == true)
            {
                B3.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _4B_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _4B.BackgroundImage != null)
            {
                B4.Verifica(2, 4, locatii);
                if (B4.poateFaceMiscari == true)
                {
                    orig = B4;
                    clickCounter++;
                }
            }
            else if (B4 != orig && B4.sePoate == true)
            {
                B4.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _5B_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _5B.BackgroundImage != null)
            {
                B5.Verifica(2, 5, locatii);
                if (B5.poateFaceMiscari == true)
                {
                    orig = B5;
                    clickCounter++;
                }
            }
            else if (B5 != orig && B5.sePoate == true)
            {
                B5.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _6B_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _6B.BackgroundImage != null)
            {
                B6.Verifica(2, 6, locatii);
                if (B6.poateFaceMiscari == true)
                {
                    orig = B6;
                    clickCounter++;
                }
            }
            else if (B6 != orig && B6.sePoate == true)
            {
                B6.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _7B_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _7B.BackgroundImage != null)
            {
                B7.Verifica(2, 7, locatii);
                if (B7.poateFaceMiscari == true)
                {
                    orig = B7;
                    clickCounter++;
                }
            }
            else if (B7 != orig && B7.sePoate == true)
            {
                B7.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _8B_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _8B.BackgroundImage != null)
            {
                B8.Verifica(2, 8, locatii);
                if (B8.poateFaceMiscari == true)
                {
                    orig = B8;
                    clickCounter++;
                }
            }
            else if (B8 != orig && B8.sePoate == true)
            {
                B8.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _1C_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _1C.BackgroundImage != null)
            {
                C1.Verifica(3, 1, locatii);
                if (C1.poateFaceMiscari == true)
                {
                    orig = C1;
                    clickCounter++;
                }
            }
            else if (C1 != orig && C1.sePoate == true)
            {
                C1.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _2C_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _2C.BackgroundImage != null)
            {
                C2.Verifica(3, 2, locatii);
                if (C2.poateFaceMiscari == true)
                {
                    orig = C2;
                    clickCounter++;
                }
            }
            else if (C2 != orig && C2.sePoate == true)
            {
                C2.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _3C_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _3C.BackgroundImage != null)
            {
                C3.Verifica(3, 3, locatii);
                if (C3.poateFaceMiscari == true)
                {
                    orig = C3;
                    clickCounter++;
                }
            }
            else if (C3 != orig && C3.sePoate == true)
            {
                C3.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _4C_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _4C.BackgroundImage != null)
            {
                C4.Verifica(3, 4, locatii);
                if (C4.poateFaceMiscari == true)
                {
                    orig = C4;
                    clickCounter++;
                }
            }
            else if (C4 != orig && C4.sePoate == true)
            {
                C4.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _5C_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _5C.BackgroundImage != null)
            {
                C5.Verifica(3, 5, locatii);
                if (C5.poateFaceMiscari == true)
                {
                    orig = C5;
                    clickCounter++;
                }
            }
            else if (C5 != orig && C5.sePoate == true)
            {
                C5.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _6C_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _6C.BackgroundImage != null)
            {
                C6.Verifica(3, 6, locatii);
                if (C6.poateFaceMiscari == true)
                {
                    orig = C6;
                    clickCounter++;
                }
            }
            else if (C6 != orig && C6.sePoate == true)
            {
                C6.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _7C_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _7C.BackgroundImage != null)
            {
                C7.Verifica(3, 7, locatii);
                if (C7.poateFaceMiscari == true)
                {
                    orig = C7;
                    clickCounter++;
                }
            }
            else if (C7 != orig && C7.sePoate == true)
            {
                C7.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _8C_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _8C.BackgroundImage != null)
            {
                C8.Verifica(3, 8, locatii);
                if (C8.poateFaceMiscari == true)
                {
                    orig = C8;
                    clickCounter++;
                }
            }
            else if (C8 != orig && C8.sePoate == true)
            {
                C8.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _1D_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _1D.BackgroundImage != null)
            {
                D1.Verifica(4, 1, locatii);
                if (D1.poateFaceMiscari == true)
                {
                    orig = D1;
                    clickCounter++;
                }
            }
            else if (D1 != orig && D1.sePoate == true)
            {
                D1.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _2D_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _2D.BackgroundImage != null)
            {
                D2.Verifica(4, 2, locatii);
                if (D2.poateFaceMiscari == true)
                {
                    orig = D2;
                    clickCounter++;
                }
            }
            else if (D2 != orig && D2.sePoate == true)
            {
                D2.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _3D_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _3D.BackgroundImage != null)
            {
                D3.Verifica(4, 3, locatii);
                if (D3.poateFaceMiscari == true)
                {
                    orig = D3;
                    clickCounter++;
                }
            }
            else if (D3 != orig && D3.sePoate == true)
            {
                D3.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _4D_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _4D.BackgroundImage != null)
            {
                D4.Verifica(4, 4, locatii);
                if (D4.poateFaceMiscari == true)
                {
                    orig = D4;
                    clickCounter++;
                }
            }
            else if (D4 != orig && D4.sePoate == true)
            {
                D4.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _5D_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _5D.BackgroundImage != null)
            {
                D5.Verifica(4, 5, locatii);
                if (D5.poateFaceMiscari == true)
                {
                    orig = D5;
                    clickCounter++;
                }
            }
            else if (D5 != orig && D5.sePoate == true)
            {
                D5.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _6D_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _6D.BackgroundImage != null)
            {
                D6.Verifica(4, 6, locatii);
                if (D6.poateFaceMiscari == true)
                {
                    orig = D6;
                    clickCounter++;
                }
            }
            else if (D6 != orig && D6.sePoate == true)
            {
                D6.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _7D_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _7D.BackgroundImage != null)
            {
                D7.Verifica(4, 7, locatii);
                if (D7.poateFaceMiscari == true)
                {
                    orig = D7;
                    clickCounter++;
                }
            }
            else if (D7 != orig && D7.sePoate == true)
            {
                D7.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _8D_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _8D.BackgroundImage != null)
            {
                D8.Verifica(4, 8, locatii);
                if (D8.poateFaceMiscari == true)
                {
                    orig = D8;
                    clickCounter++;
                }
            }
            else if (D8 != orig && D8.sePoate == true)
            {
                D8.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _1E_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _1E.BackgroundImage != null)
            {
                E1.Verifica(5, 1, locatii);
                if (E1.poateFaceMiscari == true)
                {
                    orig = E1;
                    clickCounter++;
                }
            }
            else if (E1 != orig && E1.sePoate == true)
            {
                E1.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _2E_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _2E.BackgroundImage != null)
            {
                E2.Verifica(5, 2, locatii);
                if (E2.poateFaceMiscari == true)
                {
                    orig = E2;
                    clickCounter++;
                }
            }
            else if (E2 != orig && E2.sePoate == true)
            {
                E2.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _3E_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _3E.BackgroundImage != null)
            {
                E3.Verifica(5, 3, locatii);
                if (E3.poateFaceMiscari == true)
                {
                    orig = E3;
                    clickCounter++;
                }
            }
            else if (E3 != orig && E3.sePoate == true)
            {
                E3.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _4E_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _4E.BackgroundImage != null)
            {
                E4.Verifica(5, 4, locatii);
                if (E4.poateFaceMiscari == true)
                {
                    orig = E4;
                    clickCounter++;
                }
            }
            else if (E4 != orig && E4.sePoate == true)
            {
                E4.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _5E_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _5E.BackgroundImage != null)
            {
                E5.Verifica(5, 5, locatii);
                if (E5.poateFaceMiscari == true)
                {
                    orig = E5;
                    clickCounter++;
                }
            }
            else if (E5 != orig && E5.sePoate == true)
            {
                E5.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _6E_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _6E.BackgroundImage != null)
            {
                E6.Verifica(5, 6, locatii);
                if (E6.poateFaceMiscari == true)
                {
                    orig = E6;
                    clickCounter++;
                }
            }
            else if (E6 != orig && E6.sePoate == true)
            {
                E6.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _7E_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _7E.BackgroundImage != null)
            {
                E7.Verifica(5, 7, locatii);
                if (E7.poateFaceMiscari == true)
                {
                    orig = E7;
                    clickCounter++;
                }
            }
            else if (E7 != orig && E7.sePoate == true)
            {
                E7.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _8E_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _8E.BackgroundImage != null)
            {
                E8.Verifica(5, 8, locatii);
                if (E8.poateFaceMiscari == true)
                {
                    orig = E8;
                    clickCounter++;
                }
            }
            else if (E8 != orig && E8.sePoate == true)
            {
                E8.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _1F_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _1F.BackgroundImage != null)
            {
                F1.Verifica(6, 1, locatii);
                if (F1.poateFaceMiscari == true)
                {
                    orig = F1;
                    clickCounter++;
                }
            }
            else if (F1 != orig && F1.sePoate == true)
            {
                F1.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _2F_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _2F.BackgroundImage != null)
            {
                F2.Verifica(6, 2, locatii);
                if (F2.poateFaceMiscari == true)
                {
                    orig = F2;
                    clickCounter++;
                }
            }
            else if (F2 != orig && F2.sePoate == true)
            {
                F2.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _3F_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _3F.BackgroundImage != null)
            {
                F3.Verifica(6, 3, locatii);
                if (F3.poateFaceMiscari == true)
                {
                    orig = F3;
                    clickCounter++;
                }
            }
            else if (F3 != orig && F3.sePoate == true)
            {
                F3.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _4F_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _4F.BackgroundImage != null)
            {
                F4.Verifica(6, 4, locatii);
                if (F4.poateFaceMiscari == true)
                {
                    orig = F4;
                    clickCounter++;
                }
            }
            else if (F4 != orig && F4.sePoate == true)
            {
                F4.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _5F_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _5F.BackgroundImage != null)
            {
                F5.Verifica(6, 5, locatii);
                if (F5.poateFaceMiscari == true)
                {
                    orig = F5;
                    clickCounter++;
                }
            }
            else if (F5 != orig && F5.sePoate == true)
            {
                F5.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _6F_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _6F.BackgroundImage != null)
            {
                F6.Verifica(6, 6, locatii);
                if (F6.poateFaceMiscari == true)
                {
                    orig = F6;
                    clickCounter++;
                }
            }
            else if (F6 != orig && F6.sePoate == true)
            {
                F6.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _7F_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _7F.BackgroundImage != null)
            {
                F7.Verifica(6, 7, locatii);
                if (F7.poateFaceMiscari == true)
                {
                    orig = F7;
                    clickCounter++;
                }
            }
            else if (F7 != orig && F7.sePoate == true)
            {
                F7.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _8F_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _8F.BackgroundImage != null)
            {
                F8.Verifica(6, 8, locatii);
                if (F8.poateFaceMiscari == true)
                {
                    orig = F8;
                    clickCounter++;
                }
            }
            else if (F8 != orig && F8.sePoate == true)
            {
                F8.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _1G_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _1G.BackgroundImage != null)
            {
                G1.Verifica(7, 1, locatii);
                if (G1.poateFaceMiscari == true)
                {
                    orig = G1;
                    clickCounter++;
                }
            }
            else if (G1 != orig && G1.sePoate == true)
            {
                G1.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _2G_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _2G.BackgroundImage != null)
            {
                G2.Verifica(7, 2, locatii);
                if (G2.poateFaceMiscari == true)
                {
                    orig = G2;
                    clickCounter++;
                }
            }
            else if (G2 != orig && G2.sePoate == true)
            {
                G2.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _3G_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _3G.BackgroundImage != null)
            {
                G3.Verifica(7, 3, locatii);
                if (G3.poateFaceMiscari == true)
                {
                    orig = G3;
                    clickCounter++;
                }
            }
            else if (G3 != orig && G3.sePoate == true)
            {
                G3.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _4G_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _4G.BackgroundImage != null)
            {
                G4.Verifica(7, 4, locatii);
                if (G4.poateFaceMiscari == true)
                {
                    orig = G4;
                    clickCounter++;
                }
            }
            else if (G4 != orig && G4.sePoate == true)
            {
                G4.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _5G_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _5G.BackgroundImage != null)
            {
                G5.Verifica(7, 5, locatii);
                if (G5.poateFaceMiscari == true)
                {
                    orig = G5;
                    clickCounter++;
                }
            }
            else if (G5 != orig && G5.sePoate == true)
            {
                G5.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _6G_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _6G.BackgroundImage != null)
            {
                G6.Verifica(7, 6, locatii);
                if (G6.poateFaceMiscari == true)
                {
                    orig = G6;
                    clickCounter++;
                }
            }
            else if (G6 != orig && G6.sePoate == true)
            {
                G6.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _7G_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _7G.BackgroundImage != null)
            {
                G7.Verifica(7, 7, locatii);
                if (G7.poateFaceMiscari == true)
                {
                    orig = G7;
                    clickCounter++;
                }
            }
            else if (G7 != orig && G7.sePoate == true)
            {
                G7.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _8G_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _8G.BackgroundImage != null)
            {
                G8.Verifica(7, 8, locatii);
                if (G8.poateFaceMiscari == true)
                {
                    orig = G8;
                    clickCounter++;
                }
            }
            else if (G8 != orig && G8.sePoate == true)
            {
                G8.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _1H_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _1H.BackgroundImage != null)
            {
                H1.Verifica(8, 1, locatii);
                if (H1.poateFaceMiscari == true)
                {
                    orig = H1;
                    clickCounter++;
                }
            }
            else if (H1 != orig && H1.sePoate == true)
            {
                H1.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _2H_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _2H.BackgroundImage != null)
            {
                H2.Verifica(8, 2, locatii);
                if (H2.poateFaceMiscari == true)
                {
                    orig = H2;
                    clickCounter++;
                }
            }
            else if (H2 != orig && H2.sePoate == true)
            {
                H2.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _3H_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _3H.BackgroundImage != null)
            {
                H3.Verifica(8, 3, locatii);
                if (H3.poateFaceMiscari == true)
                {
                    orig = H3;
                    clickCounter++;
                }
            }
            else if (H3 != orig && H3.sePoate == true)
            {
                H3.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _4H_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _4H.BackgroundImage != null)
            {
                H4.Verifica(8, 4, locatii);
                if (H4.poateFaceMiscari == true)
                {
                    orig = H4;
                    clickCounter++;
                }
            }
            else if (H4 != orig && H4.sePoate == true)
            {
                H4.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _5H_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _5H.BackgroundImage != null)
            {
                H5.Verifica(8, 5, locatii);
                if (H5.poateFaceMiscari == true)
                {
                    orig = H5;
                    clickCounter++;
                }
            }
            else if (H5 != orig && H5.sePoate == true)
            {
                H5.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _6H_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _6H.BackgroundImage != null)
            {
                H6.Verifica(8, 6, locatii);
                if (H6.poateFaceMiscari == true)
                {
                    orig = H6;
                    clickCounter++;
                }
            }
            else if (H6 != orig && H6.sePoate == true)
            {
                H6.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _7H_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _7H.BackgroundImage != null)
            {
                H7.Verifica(8, 7, locatii);
                if (H7.poateFaceMiscari == true)
                {
                    orig = H7;
                    clickCounter++;
                }
            }
            else if (H7 != orig && H7.sePoate == true)
            {
                H7.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }

        private void _8H_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0 && _8H.BackgroundImage != null)
            {
                H8.Verifica(8, 8, locatii);
                if (H8.poateFaceMiscari == true)
                {
                    orig = H8;
                    clickCounter++;
                }
            }
            else if (H8 != orig && H8.sePoate == true)
            {
                H8.Muta(orig);
                orig.StergeLocatie();
                RandNou(locatii);
                clickCounter = 0;
                RestoreCulori(locatii);
            }
        }



    }
}

