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


namespace Chess_Application
{
    public class Piesa
    {
        public PictureBox imaginePiesa;
        public PictureBox imagineMicaPiesa;
        public Piesa()
        {

        }
        public Piesa(int c, int t, PictureBox pct)//constructor cu initializare tip si culoare piesa
        {
            culoare = c;
            tipPiesa = t;
            imaginePiesa = pct;
        }
        public Piesa(int t, PictureBox pct)//constructor cu initializare tip piesa(in cazul in care piesele sunt albe, nefiind necesara initializarii valorii culoare)
        {
            tipPiesa = t;
            imaginePiesa = pct;
        }
        public int culoare = 1;//1-alb, 2-negru;
        public int tipPiesa = 0;//0-nici una, 1-pion, 2-tura, 3-cal, 4-nebun, 5-regina, 6-rege;
        public virtual void VerificaPosibilitati(int i, int j, LocatieTabla[,] loc)//self-explanatory -  verifica posibilitatile de miscare a piesei: tipul ofera comportamentul miscarii, iar culoarea directia in cazul pioniilor...
        {

        }
        public void SahDinRege(LocatieTabla[,] loc)
        {
            int i, j;
            int tempCuloare;
            if (Form1.randMutare == 1)
            {
                i = Form1.pozitieRegeAlb.X; j = Form1.pozitieRegeAlb.Y;               
                if (loc[i + 1, j - 1] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i + 1, j - 1].culoare;
                    loc[i + 1, j - 1].culoare = 1;
                    if (!Sah(loc, i + 1, j - 1))
                    {
                        loc[i + 1, j - 1].culoare = tempCuloare;
                        if (loc[i + 1, j - 1].culoare != 1) { loc[i + 1, j - 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i + 1, j - 1].culoare = tempCuloare;
                    loc[i, j].culoare = 1;
                }
                if (loc[i + 1, j + 1] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i + 1, j + 1].culoare;
                    loc[i + 1, j + 1].culoare = 1;
                    if (!Sah(loc, i + 1, j + 1))
                    {
                        loc[i + 1, j + 1].culoare = tempCuloare;
                        if (loc[i + 1, j + 1].culoare != 1) { loc[i + 1, j + 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i + 1, j + 1].culoare = tempCuloare;
                    loc[i, j].culoare = 1;
                }
                if (loc[i + 1, j] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i + 1, j].culoare;
                    loc[i + 1, j].culoare = 1;
                    if (!Sah(loc, i + 1, j))
                    {
                        loc[i + 1, j].culoare = tempCuloare;
                        if (loc[i + 1, j].culoare != 1) { loc[i + 1, j].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i + 1, j].culoare = tempCuloare;
                    loc[i, j].culoare = 1;
                }
                if (loc[i, j - 1] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i, j - 1].culoare;
                    loc[i, j - 1].culoare = 1;
                    if (!Sah(loc, i, j - 1))
                    {
                        loc[i, j - 1].culoare = tempCuloare;
                        if (loc[i, j - 1].culoare != 1) { loc[i, j - 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i, j - 1].culoare = tempCuloare;
                    loc[i, j].culoare = 1;
                }
                if (loc[i, j + 1] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i, j + 1].culoare;
                    loc[i, j + 1].culoare = 1;
                    if (!Sah(loc, i, j + 1))
                    {
                        loc[i, j + 1].culoare = tempCuloare;
                        if (loc[i, j + 1].culoare != 1) { loc[i, j + 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i, j + 1].culoare = tempCuloare;
                    loc[i, j].culoare = 1;
                }
                if (loc[i - 1, j - 1] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i - 1, j - 1].culoare;
                    loc[i - 1, j - 1].culoare = 1;
                    if (!Sah(loc, i - 1, j - 1))
                    {
                        loc[i - 1, j - 1].culoare = tempCuloare;
                        if (loc[i - 1, j - 1].culoare != 1) { loc[i - 1, j - 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i - 1, j - 1].culoare = tempCuloare;
                    loc[i, j].culoare = 1;
                }
                if (loc[i - 1, j] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i - 1, j].culoare;
                    loc[i - 1, j].culoare = 1;
                    if (!Sah(loc, i - 1, j))
                    {
                        loc[i - 1, j].culoare = tempCuloare;
                        if (loc[i - 1, j].culoare != 1) { loc[i - 1, j].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i - 1, j].culoare = tempCuloare;
                    loc[i, j].culoare = 1;
                }
                if (loc[i - 1, j + 1] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i - 1, j + 1].culoare;
                    loc[i - 1, j + 1].culoare = 1;
                    if (!Sah(loc, i - 1, j + 1))
                    {
                        loc[i - 1, j + 1].culoare = tempCuloare;
                        if (loc[i - 1, j + 1].culoare != 1) { loc[i - 1, j + 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i - 1, j + 1].culoare = tempCuloare;
                    loc[i, j].culoare = 1;
                }
                loc[i, j].culoare = 1;
            }
            else
            {
                i = Form1.pozitieRegeNegru.X; j = Form1.pozitieRegeNegru.Y;
                if (loc[i + 1, j - 1] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i + 1, j - 1].culoare;
                    loc[i + 1, j - 1].culoare = 2;
                    if (!Sah(loc, i + 1, j - 1))
                    {
                        loc[i + 1, j - 1].culoare = tempCuloare;
                        if (loc[i + 1, j - 1].culoare != 2) { loc[i + 1, j - 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i + 1, j - 1].culoare = tempCuloare;
                    loc[i, j].culoare = 2;
                }
                if (loc[i + 1, j + 1] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i + 1, j + 1].culoare;
                    loc[i + 1, j + 1].culoare = 2;
                    if (!Sah(loc, i + 1, j + 1))
                    {
                        loc[i + 1, j + 1].culoare = tempCuloare;
                        if (loc[i + 1, j + 1].culoare != 2) { loc[i + 1, j + 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i + 1, j + 1].culoare = tempCuloare;
                    loc[i, j].culoare = 2;
                }
                if (loc[i + 1, j] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i + 1, j].culoare;
                    loc[i + 1, j].culoare = 2;
                    if (!Sah(loc, i + 1, j))
                    {
                        loc[i + 1, j].culoare = tempCuloare;
                        if (loc[i + 1, j].culoare != 2) { loc[i + 1, j].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i + 1, j].culoare = tempCuloare;
                    loc[i, j].culoare = 2;
                }
                if (loc[i, j - 1] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i, j - 1].culoare;
                    loc[i, j - 1].culoare = 2;
                    if (!Sah(loc, i, j - 1))
                    {
                        loc[i, j - 1].culoare = tempCuloare;
                        if (loc[i, j - 1].culoare != 2) { loc[i, j - 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i, j - 1].culoare = tempCuloare;
                    loc[i, j].culoare = 2;
                }
                if (loc[i, j + 1] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i, j + 1].culoare;
                    loc[i, j + 1].culoare = 2;
                    if (!Sah(loc, i, j + 1))
                    {
                        loc[i, j + 1].culoare = tempCuloare;
                        if (loc[i, j + 1].culoare != 2) { loc[i, j + 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i, j + 1].culoare = tempCuloare;
                    loc[i, j].culoare = 2;
                }
                if (loc[i - 1, j - 1] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i - 1, j - 1].culoare;
                    loc[i - 1, j - 1].culoare = 2;
                    if (!Sah(loc, i - 1, j - 1))
                    {
                        loc[i - 1, j - 1].culoare = tempCuloare;
                        if (loc[i - 1, j - 1].culoare != 2) { loc[i - 1, j - 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i - 1, j - 1].culoare = tempCuloare;
                    loc[i, j].culoare = 2;
                }
                if (loc[i - 1, j] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i - 1, j].culoare;
                    loc[i - 1, j].culoare = 2;
                    if (!Sah(loc, i - 1, j))
                    {
                        loc[i - 1, j].culoare = tempCuloare;
                        if (loc[i - 1, j].culoare != 2) { loc[i - 1, j].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i - 1, j].culoare = tempCuloare;
                    loc[i, j].culoare = 2;
                }
                if (loc[i - 1, j + 1] != null)
                {
                    loc[i, j].culoare = 0;
                    tempCuloare = loc[i - 1, j + 1].culoare;
                    loc[i - 1, j + 1].culoare = 2;
                    if (!Sah(loc, i - 1, j + 1))
                    {
                        loc[i - 1, j + 1].culoare = tempCuloare;
                        if (loc[i - 1, j + 1].culoare != 2) { loc[i - 1, j + 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
                    }
                    loc[i - 1, j + 1].culoare = tempCuloare;
                    loc[i, j].culoare = 2;
                }
                loc[i, j].culoare = 2;
            }
        }
        public bool Sah(LocatieTabla[,] loc, int i, int j)
        {
            if (loc[i, j].culoare == 1)
            {
                if (loc[i + 1, j - 1] != null)
                {
                    if (loc[i + 1, j - 1].culoare == 2 && (loc[i + 1, j - 1].tipPiesa == 1 || loc[i + 1, j - 1].tipPiesa == 6))
                    {
                        return true;
                    }
                }
                if (loc[i + 1, j + 1] != null)
                {
                    if (loc[i + 1, j + 1].culoare == 2 && (loc[i + 1, j + 1].tipPiesa == 1 || loc[i + 1, j + 1].tipPiesa == 6))
                    {
                        return true;
                    }
                }
                //========== rege ========
                if (loc[i + 1, j] != null)
                {
                    if (loc[i + 1, j].culoare == 2 && loc[i + 1, j].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (loc[i, j - 1] != null)
                {
                    if (loc[i, j - 1].culoare == 2 && loc[i, j - 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (loc[i, j + 1] != null)
                {
                    if (loc[i, j + 1].culoare == 2 && loc[i, j + 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (loc[i - 1, j - 1] != null)
                {
                    if (loc[i - 1, j - 1].culoare == 2 && loc[i - 1, j - 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (loc[i - 1, j] != null)
                {
                    if (loc[i - 1, j].culoare == 2 && loc[i - 1, j].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (loc[i - 1, j + 1] != null)
                {
                    if (loc[i - 1, j + 1].culoare == 2 && loc[i - 1, j + 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                //========== cal ========
                if ((i < 8 && j < 7) && loc[i + 1, j + 2].culoare == 2 && loc[i + 1, j + 2].tipPiesa == 3)
                {
                    return true;
                }
                if ((i < 8 && j > 2) && loc[i + 1, j - 2].culoare == 2 && loc[i + 1, j - 2].tipPiesa == 3)
                {
                    return true;
                }
                //-----
                if ((i < 7 && j < 8) && loc[i + 2, j + 1].culoare == 2 && loc[i + 2, j + 1].tipPiesa == 3)
                {
                    return true;
                }
                if ((i < 7 && j > 1) && loc[i + 2, j - 1].culoare == 2 && loc[i + 2, j - 1].tipPiesa == 3)
                {
                    return true;
                }
                //-----
                if ((i > 1 && j < 7) && loc[i - 1, j + 2].culoare == 2 && loc[i - 1, j + 2].tipPiesa == 3)
                {
                    return true;
                }
                if ((i > 1 && j > 2) && loc[i - 1, j - 2].culoare == 2 && loc[i - 1, j - 2].tipPiesa == 3)
                {
                    return true;
                }
                //-----             
                if ((i > 2 && j < 8) && loc[i - 2, j + 1].culoare == 2 && loc[i - 2, j + 1].tipPiesa == 3)
                {
                    return true;
                }
                if ((i > 2 && j > 1) && loc[i - 2, j - 1].culoare == 2 && loc[i - 2, j - 1].tipPiesa == 3)
                {
                    return true;
                }
                //========== tura / regina ========
                int ct1 = 0;
                int ct2 = 0;
                int ct3 = 0;
                int ct4 = 0;
                Console.WriteLine("----------------------------------------------------");
                for (int k = j; k >= 1; k--)
                {
                    ct1++;
                    Console.WriteLine("Pe linia " + i + ", coloana" + k + " se afla tipPiesa = " + loc[i, k].tipPiesa + " de culoare " + loc[i, k].culoare);
                    if (loc[i, k].culoare != loc[i, j].culoare)
                    {
                        if ((loc[i, k].tipPiesa == 2 || loc[i, k].tipPiesa == 5) && loc[i, k].culoare == 2)
                        {
                            Console.WriteLine("sah la verificare in stanga");
                            return true;
                        }
                    }
                    if (loc[i, k].culoare == loc[i, j].culoare && loc[i, k] != loc[i, j]) break;
                    if ((loc[i, k].culoare == 2) && loc[i, k].tipPiesa != 2 && loc[i, k].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                for (int k = j; k <= 8; k++)
                {
                    ct2++;
                    Console.WriteLine("Pe linia " + i + ", coloana" + k + " se afla tipPiesa = " + loc[i, k].tipPiesa + " de culoare " + loc[i, k].culoare);
                    if (loc[i, k].culoare != loc[i, j].culoare)
                    {
                        if ((loc[i, k].tipPiesa == 2 || loc[i, k].tipPiesa == 5) && loc[i, k].culoare == 2)
                        {
                            Console.WriteLine("sah la verificare in dreapta");
                            return true;
                        }
                    }
                    if (loc[i, k].culoare == loc[i, j].culoare && loc[i, k] != loc[i, j]) break;
                    if ((loc[i, k].culoare == 2) && loc[i, k].tipPiesa != 2 && loc[i, k].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                for (int k = i; k >= 1; k--)
                {
                    ct3++;
                    Console.WriteLine("Pe linia " + k + ", coloana" + j + " se afla tipPiesa = " + loc[k, j].tipPiesa + " de culoare " + loc[k, j].culoare);
                    if (loc[k, j].culoare != loc[i, j].culoare)
                    {
                        if ((loc[k, j].tipPiesa == 2 || loc[k, j].tipPiesa == 5) && loc[k, j].culoare == 2)
                        {
                            Console.WriteLine("sah la verificare in jos");
                            return true;
                        }
                    }
                    if (loc[k, j].culoare == loc[i, j].culoare && loc[k, j] != loc[i, j]) break;
                    if ((loc[k, j].culoare == 2) && loc[k, j].tipPiesa != 2 && loc[k, j].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                for (int k = i; k <= 8; k++)
                {
                    ct4++;
                    Console.WriteLine("Pe linia " + k + ", coloana" + j + " se afla tipPiesa = " + loc[k, j].tipPiesa + " de culoare " + loc[k, j].culoare);
                    if (loc[k, j].culoare != loc[i, j].culoare)
                    {
                        if ((loc[k, j].tipPiesa == 2 || loc[k, j].tipPiesa == 5) && loc[k, j].culoare == 2)
                        {
                            Console.WriteLine("sah la verificare in sus");
                            return true;
                        }
                    }
                    if (loc[k, j].culoare == loc[i, j].culoare && loc[k, j] != loc[i, j]) break;
                    if ((loc[k, j].culoare == 2) && loc[k, j].tipPiesa != 2 && loc[k, j].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("ct1: " + ct1 + ", ct2: " + ct2 + ", ct3: " + ct3 + ", ct4: " + ct4);
                //========== nebun / regina ========
                for (int l = i, c = j; l >= 1 && c >= 1; l--, c--)
                {
                    if (loc[l, c].culoare == 2 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4)) 
                    {
                        Console.WriteLine("sah la verificare in diagonala stanga jos");
                        return true;
                    }
                    if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                }
                for (int l = i, c = j; l <= 8 && c <= 8; l++, c++)
                {
                    if (loc[l, c].culoare == 2 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala dreapta sus");
                        return true;
                    }
                    if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                }
                for (int l = i, c = j; l <= 8 && c >= 1; l++, c--)
                {
                    if (loc[l, c].culoare == 2 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala stanga sus");
                        return true;
                    }
                    if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                }
                for (int l = i, c = j; l >= 1 && c <= 8; l--, c++)
                {
                    if (loc[l, c].culoare == 2 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala dreapta jos");
                        return true;
                    }
                    if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                }
                return false;
            }
            else
            {
                //========== pion / rege ========
                if (loc[i - 1, j - 1] != null)
                {
                    if (loc[i - 1, j - 1].culoare == 1 && (loc[i - 1, j - 1].tipPiesa == 1 || loc[i - 1, j - 1].tipPiesa == 6))
                    {
                        return true;
                    }
                }
                if (loc[i - 1, j + 1] != null)
                {
                    if (loc[i - 1, j + 1].culoare == 1 && (loc[i - 1, j + 1].tipPiesa == 1 || loc[i - 1, j + 1].tipPiesa == 6))
                    {
                        return true;
                    }
                }
                //========== rege ========
                if (loc[i + 1, j] != null)
                {
                    if (loc[i + 1, j].culoare == 1 && loc[i + 1, j].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (loc[i, j - 1] != null)
                {
                    if (loc[i, j - 1].culoare == 1 && loc[i, j - 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (loc[i, j + 1] != null)
                {
                    if (loc[i, j + 1].culoare == 1 && loc[i, j + 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (loc[i + 1, j - 1] != null)
                {
                    if (loc[i - 1, j - 1].culoare == 1 && loc[i - 1, j - 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (loc[i - 1, j] != null)
                {
                    if (loc[i - 1, j].culoare == 1 && loc[i - 1, j].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                if (loc[i + 1, j + 1] != null)
                {
                    if (loc[i - 1, j + 1].culoare == 1 && loc[i - 1, j + 1].tipPiesa == 6)
                    {
                        return true;
                    }
                }
                //========== cal ========
                if ((i < 8 && j < 7) && loc[i + 1, j + 2].culoare == 1 && loc[i + 1, j + 2].tipPiesa == 3)
                {
                    return true;
                }
                if ((i < 8 && j > 2) && loc[i + 1, j - 2].culoare == 1 && loc[i + 1, j - 2].tipPiesa == 3)
                {
                    return true;
                }
                //-----
                if ((i < 7 && j < 8) && loc[i + 2, j + 1].culoare == 1 && loc[i + 2, j + 1].tipPiesa == 3)
                {
                    return true;
                }
                if ((i < 7 && j > 1) && loc[i + 2, j - 1].culoare == 1 && loc[i + 2, j - 1].tipPiesa == 3)
                {
                    return true;
                }
                //-----
                if ((i > 1 && j < 7) && loc[i - 1, j + 2].culoare == 1 && loc[i - 1, j + 2].tipPiesa == 3)
                {
                    return true;
                }
                if ((i > 1 && j > 2) && loc[i - 1, j - 2].culoare == 1 && loc[i - 1, j - 2].tipPiesa == 3)
                {
                    return true;
                }
                //-----             
                if ((i > 2 && j < 8) && loc[i - 2, j + 1].culoare == 1 && loc[i - 2, j + 1].tipPiesa == 3)
                {
                    return true;
                }
                if ((i > 2 && j > 1) && loc[i - 2, j - 1].culoare == 1 && loc[i - 2, j - 1].tipPiesa == 3)
                {
                    return true;
                }
                //========== tura / regina ========
                int ct1 = 0;
                int ct2 = 0;
                int ct3 = 0;
                int ct4 = 0;
                Console.WriteLine("----------------------------------------------------");
                for (int k = j; k >= 1; k--)
                {
                    ct1++;
                    Console.WriteLine("Pe linia " + i + ", coloana" + k + " se afla tipPiesa = " + loc[i, k].tipPiesa + " de culoare " + loc[i, k].culoare);
                    if (loc[i, k].culoare != loc[i, j].culoare)
                    {
                        if ((loc[i, k].tipPiesa == 2 || loc[i, k].tipPiesa == 5) && loc[i, k].culoare == 1)
                        {
                            Console.WriteLine("sah la verificare in stanga");
                            return true;
                        }
                    }
                    if (loc[i, k].culoare == loc[i, j].culoare && loc[i, k] != loc[i, j]) break;
                    if ((loc[i, k].culoare == 1) && loc[i, k].tipPiesa != 2 && loc[i, k].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                for (int k = j; k <= 8; k++)
                {
                    ct2++;
                    Console.WriteLine("Pe linia " + i + ", coloana" + k + " se afla tipPiesa = " + loc[i, k].tipPiesa + " de culoare " + loc[i, k].culoare);
                    if (loc[i, k].culoare != loc[i, j].culoare)
                    {
                        if ((loc[i, k].tipPiesa == 2 || loc[i, k].tipPiesa == 5) && loc[i, k].culoare == 1)
                        {
                            Console.WriteLine("sah la verificare in dreapta");
                            return true;
                        }
                    }
                    if (loc[i, k].culoare == loc[i, j].culoare && loc[i, k] != loc[i, j]) break;
                    if ((loc[i, k].culoare == 1) && loc[i, k].tipPiesa != 2 && loc[i, k].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                for (int k = i; k >= 1; k--)
                {
                    ct3++;
                    Console.WriteLine("Pe linia " + k + ", coloana" + j + " se afla tipPiesa = " + loc[k, j].tipPiesa + " de culoare " + loc[k, j].culoare);
                    if (loc[k, j].culoare != loc[i, j].culoare)
                    {
                        if ((loc[k, j].tipPiesa == 2 || loc[k, j].tipPiesa == 5) && loc[k, j].culoare == 1)
                        {
                            Console.WriteLine("sah la verificare in jos");
                            return true;
                        }
                    }
                    if (loc[k, j].culoare == loc[i, j].culoare && loc[k, j] != loc[i, j]) break;
                    if ((loc[k, j].culoare == 1) && loc[k, j].tipPiesa != 2 && loc[k, j].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                for (int k = i; k <= 8; k++)
                {
                    ct4++;
                    Console.WriteLine("Pe linia " + k + ", coloana" + j + " se afla tipPiesa = " + loc[k, j].tipPiesa + " de culoare " + loc[k, j].culoare);
                    if (loc[k, j].culoare != loc[i, j].culoare)
                    {
                        if ((loc[k, j].tipPiesa == 2 || loc[k, j].tipPiesa == 5) && loc[k, j].culoare == 1)
                        {
                            Console.WriteLine("sah la verificare in sus");
                            return true;
                        }
                    }
                    if (loc[k, j].culoare == loc[i, j].culoare && loc[k, j] != loc[i, j]) break;
                    if ((loc[k, j].culoare == 1) && loc[k, j].tipPiesa != 2 && loc[k, j].tipPiesa != 5) break;
                }
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("ct1: " + ct1 + ", ct2: " + ct2 + ", ct3: " + ct3 + ", ct4: " + ct4);
                //========== nebun / regina ========
                for (int l = i, c = j; l >= 1 && c >= 1; l--, c--)
                {
                    if (loc[l, c].culoare == 1 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala stanga jos");
                        return true;
                    }
                    if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                }
                for (int l = i, c = j; l <= 8 && c <= 8; l++, c++)
                {
                    if (loc[l, c].culoare == 1 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala dreapta sus");
                        return true;
                    }
                    if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                }
                for (int l = i, c = j; l <= 8 && c >= 1; l++, c--)
                {
                    if (loc[l, c].culoare == 1 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala stanga sus");
                        return true;
                    }
                    if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                }
                for (int l = i, c = j; l >= 1 && c <= 8; l--, c++)
                {
                    if (loc[l, c].culoare == 1 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4))
                    {
                        Console.WriteLine("sah la verificare in diagonala dreapta jos");
                        return true;
                    }
                    if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                }
                return false;
            }
        }

        public bool Sah(LocatieTabla[,] loc, int orig1, int orig2, int curent1, int curent2)
        {
            if (loc[orig1, orig2].tipPiesa != 6)
            {
                if (Form1.randMutare == 1)
                {
                    int i = Form1.pozitieRegeAlb.X;//linia rege
                    int j = Form1.pozitieRegeAlb.Y;//coloana rege
                    Console.WriteLine("Pozititie rege: " + i + " " + j);
                    int tempCuloareOrig = loc[orig1, orig2].culoare;
                    int tempCuloareCurent = loc[curent1, curent2].culoare;
                    loc[orig1, orig2].culoare = 0;
                    loc[curent1, curent2].culoare = 1;
                    //========== pion / rege ========
                    if (loc[i + 1, j - 1] != null)
                    {
                        if (loc[i + 1, j - 1].culoare == 2 && (loc[i + 1, j - 1].tipPiesa == 1 || loc[i + 1, j - 1].tipPiesa == 6))
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (loc[i + 1, j + 1] != null)
                    {
                        if (loc[i + 1, j + 1].culoare == 2 && (loc[i + 1, j + 1].tipPiesa == 1 || loc[i + 1, j + 1].tipPiesa == 6))
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    //========== rege ========
                    if (loc[i + 1, j] != null)
                    {
                        if (loc[i + 1, j].culoare == 2 && loc[i + 1, j].tipPiesa == 6)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (loc[i, j - 1] != null)
                    {
                        if (loc[i, j - 1].culoare == 2 && loc[i, j - 1].tipPiesa == 6)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (loc[i, j + 1] != null)
                    {
                        if (loc[i, j + 1].culoare == 2 && loc[i, j + 1].tipPiesa == 6)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (loc[i - 1, j - 1] != null)
                    {
                        if (loc[i - 1, j - 1].culoare == 2 && loc[i - 1, j - 1].tipPiesa == 6)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (loc[i - 1, j] != null)
                    {
                        if (loc[i - 1, j].culoare == 2 && loc[i - 1, j].tipPiesa == 6)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (loc[i - 1, j + 1] != null)
                    {
                        if (loc[i - 1, j + 1].culoare == 2 && loc[i - 1, j + 1].tipPiesa == 6)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    //========== cal ========
                    if ((i < 8 && j < 7) && loc[i + 1, j + 2].culoare == 2 && loc[i + 1, j + 2].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i < 8 && j > 2) && loc[i + 1, j - 2].culoare == 2 && loc[i + 1, j - 2].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //-----
                    if ((i < 7 && j < 8) && loc[i + 2, j + 1].culoare == 2 && loc[i + 2, j + 1].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i < 7 && j > 1) && loc[i + 2, j - 1].culoare == 2 && loc[i + 2, j - 1].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //-----
                    if ((i > 1 && j < 7) && loc[i - 1, j + 2].culoare == 2 && loc[i - 1, j + 2].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i > 1 && j > 2) && loc[i - 1, j - 2].culoare == 2 && loc[i - 1, j - 2].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //-----             
                    if ((i > 2 && j < 8) && loc[i - 2, j + 1].culoare == 2 && loc[i - 2, j + 1].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i > 2 && j > 1) && loc[i - 2, j - 1].culoare == 2 && loc[i - 2, j - 1].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //========== tura / regina ========
                    int ct1 = 0;
                    int ct2 = 0;
                    int ct3 = 0;
                    int ct4 = 0;
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = j; k >= 1; k--)
                    {
                        ct1++;
                        Console.WriteLine("Pe linia " + i + ", coloana" + k + " se afla tipPiesa = " + loc[i, k].tipPiesa + " de culoare " + loc[i, k].culoare);
                        if (loc[i, k].culoare != loc[i, j].culoare)
                        {
                            if ((loc[i, k].tipPiesa == 2 || loc[i, k].tipPiesa == 5) && loc[i, k].culoare == 2)
                            {
                                loc[orig1, orig2].culoare = tempCuloareOrig;
                                loc[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in stanga");
                                return true;
                            }
                        }
                        if (loc[i, k].culoare == loc[i, j].culoare && loc[i, k] != loc[i, j]) break;
                        if ((loc[i, k].culoare == 2) && loc[i, k].tipPiesa != 2 && loc[i, k].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = j; k <= 8; k++)
                    {
                        ct2++;
                        Console.WriteLine("Pe linia " + i + ", coloana" + k + " se afla tipPiesa = " + loc[i, k].tipPiesa + " de culoare " + loc[i, k].culoare);
                        if (loc[i, k].culoare != loc[i, j].culoare)
                        {
                            if ((loc[i, k].tipPiesa == 2 || loc[i, k].tipPiesa == 5) && loc[i, k].culoare == 2)
                            {
                                loc[orig1, orig2].culoare = tempCuloareOrig;
                                loc[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in dreapta");
                                return true;
                            }
                        }
                        if (loc[i, k].culoare == loc[i, j].culoare && loc[i, k] != loc[i, j]) break;
                        if ((loc[i, k].culoare == 2) && loc[i, k].tipPiesa != 2 && loc[i, k].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = i; k >= 1; k--)
                    {
                        ct3++;
                        Console.WriteLine("Pe linia " + k + ", coloana" + j + " se afla tipPiesa = " + loc[k, j].tipPiesa + " de culoare " + loc[k, j].culoare);
                        if (loc[k, j].culoare != loc[i, j].culoare)
                        {
                            if ((loc[k, j].tipPiesa == 2 || loc[k, j].tipPiesa == 5) && loc[k, j].culoare == 2)
                            {
                                loc[orig1, orig2].culoare = tempCuloareOrig;
                                loc[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in jos");
                                return true;
                            }
                        }
                        if (loc[k, j].culoare == loc[i, j].culoare && loc[k, j] != loc[i, j]) break;
                        if ((loc[k, j].culoare == 2) && loc[k, j].tipPiesa != 2 && loc[k, j].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = i; k <= 8; k++)
                    {
                        ct4++;
                        Console.WriteLine("Pe linia " + k + ", coloana" + j + " se afla tipPiesa = " + loc[k, j].tipPiesa + " de culoare " + loc[k, j].culoare);
                        if (loc[k, j].culoare != loc[i, j].culoare)
                        {
                            if ((loc[k, j].tipPiesa == 2 || loc[k, j].tipPiesa == 5) && loc[k, j].culoare == 2)
                            {
                                loc[orig1, orig2].culoare = tempCuloareOrig;
                                loc[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in sus");
                                return true;
                            }
                        }
                        if (loc[k, j].culoare == loc[i, j].culoare && loc[k, j] != loc[i, j]) break;
                        if ((loc[k, j].culoare == 2) && loc[k, j].tipPiesa != 2 && loc[k, j].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("ct1: " + ct1 + ", ct2: " + ct2 + ", ct3: " + ct3 + ", ct4: " + ct4);
                    //========== nebun / regina ========
                    for (int l = i, c = j; l >= 1 && c >= 1; l--, c--)
                    {
                        if (loc[l, c].culoare == 2 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4))
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala stanga jos");
                            return true;
                        }
                        if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                    }
                    for (int l = i, c = j; l <= 8 && c <= 8; l++, c++)
                    {
                        if (loc[l, c].culoare == 2 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4))
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala dreapta sus");
                            return true;
                        }
                        if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                    }
                    for (int l = i, c = j; l <= 8 && c >= 1; l++, c--)
                    {
                        if (loc[l, c].culoare == 2 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4)) 
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala stanga sus de la pozitia "+l+" "+c);
                            return true;
                        }
                        if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                    }
                    for (int l = i, c = j; l >= 1 && c <= 8; l--, c++)
                    {
                        if (loc[l, c].culoare == 2 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4))
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala dreapta jos");
                            return true;
                        }
                        if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                    }
                    Console.WriteLine("pe pozitia 3,5 se exista: " + loc[3, 5].tipPiesa + " de culoarea: " + loc[3, 5].culoare);
                    loc[orig1, orig2].culoare = tempCuloareOrig;
                    loc[curent1, curent2].culoare = tempCuloareCurent;
                    return false;
                }
                else
                {
                    Console.WriteLine("TBD");
                    int i = Form1.pozitieRegeNegru.X;
                    int j = Form1.pozitieRegeNegru.Y;
                    Console.WriteLine("Pozititie rege: " + i + " " + j);
                    int tempCuloareOrig = loc[orig1, orig2].culoare;
                    int tempCuloareCurent = loc[curent1, curent2].culoare;
                    loc[orig1, orig2].culoare = 0;
                    loc[curent1, curent2].culoare = 1;
                    //========== pion / rege ========
                    if (loc[i - 1, j - 1] != null)
                    {
                        if (loc[i - 1, j - 1].culoare == 1 && (loc[i - 1, j - 1].tipPiesa == 1 || loc[i - 1, j - 1].tipPiesa == 6))
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (loc[i - 1, j + 1] != null)
                    {
                        if (loc[i - 1, j + 1].culoare == 1 && (loc[i - 1, j + 1].tipPiesa == 1 || loc[i - 1, j + 1].tipPiesa == 6))
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    //========== rege ========
                    if (loc[i + 1, j] != null)
                    {
                        if (loc[i + 1, j].culoare == 1 && loc[i + 1, j].tipPiesa == 6)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (loc[i, j - 1] != null)
                    {
                        if (loc[i, j - 1].culoare == 1 && loc[i, j - 1].tipPiesa == 6)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (loc[i, j + 1] != null)
                    {
                        if (loc[i, j + 1].culoare == 1 && loc[i, j + 1].tipPiesa == 6)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (loc[i + 1, j - 1] != null)
                    {
                        if (loc[i - 1, j - 1].culoare == 1 && loc[i - 1, j - 1].tipPiesa == 6)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (loc[i - 1, j] != null)
                    {
                        if (loc[i - 1, j].culoare == 1 && loc[i - 1, j].tipPiesa == 6)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    if (loc[i + 1, j + 1] != null)
                    {
                        if (loc[i - 1, j + 1].culoare == 1 && loc[i - 1, j + 1].tipPiesa == 6)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                    }
                    //========== cal ========
                    if ((i < 8 && j < 7) && loc[i + 1, j + 2].culoare == 1 && loc[i + 1, j + 2].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i < 8 && j > 2) && loc[i + 1, j - 2].culoare == 1 && loc[i + 1, j - 2].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //-----
                    if ((i < 7 && j < 8) && loc[i + 2, j + 1].culoare == 1 && loc[i + 2, j + 1].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i < 7 && j > 1) && loc[i + 2, j - 1].culoare == 1 && loc[i + 2, j - 1].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //-----
                    if ((i > 1 && j < 7) && loc[i - 1, j + 2].culoare == 1 && loc[i - 1, j + 2].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i > 1 && j > 2) && loc[i - 1, j - 2].culoare == 1 && loc[i - 1, j - 2].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //-----             
                    if ((i > 2 && j < 8) && loc[i - 2, j + 1].culoare == 1 && loc[i - 2, j + 1].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    if ((i > 2 && j > 1) && loc[i - 2, j - 1].culoare == 1 && loc[i - 2, j - 1].tipPiesa == 3)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                    //========== tura / regina ========
                    int ct1 = 0;
                    int ct2 = 0;
                    int ct3 = 0;
                    int ct4 = 0;
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = j; k >= 1; k--)
                    {
                        ct1++;
                        Console.WriteLine("Pe linia " + i + ", coloana" + k + " se afla tipPiesa = " + loc[i, k].tipPiesa + " de culoare " + loc[i, k].culoare);
                        if (loc[i, k].culoare != loc[i, j].culoare)
                        {
                            if ((loc[i, k].tipPiesa == 2 || loc[i, k].tipPiesa == 5) && loc[i, k].culoare == 1)
                            {
                                loc[orig1, orig2].culoare = tempCuloareOrig;
                                loc[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in stanga");
                                return true;
                            }
                        }
                        if (loc[i, k].culoare == loc[i, j].culoare && loc[i, k] != loc[i, j]) break;
                        if ((loc[i, k].culoare == 1) && loc[i, k].tipPiesa != 2 && loc[i, k].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = j; k <= 8; k++)
                    {
                        ct2++;
                        Console.WriteLine("Pe linia " + i + ", coloana" + k + " se afla tipPiesa = " + loc[i, k].tipPiesa + " de culoare " + loc[i, k].culoare);
                        if (loc[i, k].culoare != loc[i, j].culoare)
                        {
                            if ((loc[i, k].tipPiesa == 2 || loc[i, k].tipPiesa == 5) && loc[i, k].culoare == 1)
                            {
                                loc[orig1, orig2].culoare = tempCuloareOrig;
                                loc[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in dreapta");
                                return true;
                            }
                        }
                        if (loc[i, k].culoare == loc[i, j].culoare && loc[i, k] != loc[i, j]) break;
                        if ((loc[i, k].culoare == 1) && loc[i, k].tipPiesa != 2 && loc[i, k].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = i; k >= 1; k--)
                    {
                        ct3++;
                        Console.WriteLine("Pe linia " + k + ", coloana" + j + " se afla tipPiesa = " + loc[k, j].tipPiesa + " de culoare " + loc[k, j].culoare);
                        if (loc[k, j].culoare != loc[i, j].culoare)
                        {
                            if ((loc[k, j].tipPiesa == 2 || loc[k, j].tipPiesa == 5) && loc[k, j].culoare == 1)
                            {
                                loc[orig1, orig2].culoare = tempCuloareOrig;
                                loc[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in jos");
                                return true;
                            }
                        }
                        if (loc[k, j].culoare == loc[i, j].culoare && loc[k, j] != loc[i, j]) break;
                        if ((loc[k, j].culoare == 1) && loc[k, j].tipPiesa != 2 && loc[k, j].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    for (int k = i; k <= 8; k++)
                    {
                        ct4++;
                        Console.WriteLine("Pe linia " + k + ", coloana" + j + " se afla tipPiesa = " + loc[k, j].tipPiesa + " de culoare " + loc[k, j].culoare);
                        if (loc[k, j].culoare != loc[i, j].culoare)
                        {
                            if ((loc[k, j].tipPiesa == 2 || loc[k, j].tipPiesa == 5) && loc[k, j].culoare == 1)
                            {
                                loc[orig1, orig2].culoare = tempCuloareOrig;
                                loc[curent1, curent2].culoare = tempCuloareCurent;
                                Console.WriteLine("sah la verificare in sus");
                                return true;
                            }
                        }
                        if (loc[k, j].culoare == loc[i, j].culoare && loc[k, j] != loc[i, j]) break;
                        if ((loc[k, j].culoare == 1) && loc[k, j].tipPiesa != 2 && loc[k, j].tipPiesa != 5) break;
                    }
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("ct1: " + ct1 + ", ct2: " + ct2 + ", ct3: " + ct3 + ", ct4: " + ct4);
                    //========== nebun / regina ========
                    for (int l = i, c = j; l >= 1 && c >= 1; l--, c--)
                    {
                        if (loc[l, c].culoare == 1 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4)) 
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala stanga jos");
                            return true;
                        }
                        if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                    }
                    for (int l = i, c = j; l <= 8 && c <= 8; l++, c++)
                    {
                        if (loc[l, c].culoare == 1 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4))
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala dreapta sus");
                            return true;
                        }
                        if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                    }
                    for (int l = i, c = j; l <= 8 && c >= 1; l++, c--)
                    {
                        if (loc[l, c].culoare == 1 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4))
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala stanga sus");
                            return true;
                        }
                        if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                    }
                    for (int l = i, c = j; l >= 1 && c <= 8; l--, c++)
                    {
                        if (loc[l, c].culoare == 1 && (loc[l, c].tipPiesa == 5 || loc[l, c].tipPiesa == 4))
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            Console.WriteLine("sah la verificare in diagonala dreapta jos");
                            return true;
                        }
                        if (loc[l, c].culoare != 0 && loc[l, c] != loc[i, j]) break;
                    }
                    //Console.WriteLine("pe pozitia 3,5 se exista: " + loc[3, 5].tipPiesa + " de culoarea: " + loc[3, 5].culoare);
                    loc[orig1, orig2].culoare = tempCuloareOrig;
                    loc[curent1, curent2].culoare = tempCuloareCurent;
                    return false;
                }
            }
            return false;
        }

    }
}

