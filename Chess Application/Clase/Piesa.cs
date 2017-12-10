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

        public bool SahAlb()
        {
            return true;
        }
        public bool SahAlb(LocatieTabla[,] loc, int orig1, int orig2, int curent1, int curent2)
        {
            int i = Form1.pozitieRegeAlb[0];
            int j = Form1.pozitieRegeAlb[1];

            int tempCuloareOrig = loc[orig1, orig2].culoare;
            loc[orig1, orig2].culoare = 0;
            int tempCuloareCurent = loc[curent1, curent2].culoare;
            loc[curent1, curent2].culoare = 1;
            for (int k = j; k >= 1; k--)
            {
                if (loc[i, k - 1] != null && loc[i, k - 1].culoare == loc[i, j].culoare)
                {
                    if (loc[i, k] != loc[i, j])
                    {
                        if ((loc[i, k].tipPiesa == 2 || loc[i, k].tipPiesa == 5) && loc[i, k].culoare == 2)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        } break;
                    }                   
                }
                if (loc[i, k].culoare != loc[i, j].culoare)
                {
                    if ((loc[i, k].tipPiesa == 2 || loc[i, k].tipPiesa == 5) && loc[i, k].culoare == 2)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                }
                if ((loc[i, k].culoare != loc[i, j].culoare && loc[i, k].culoare != 0)) break;
            }
            for (int k = j; k <= 8; k++)
            {
                if (loc[i, k + 1] != null && loc[i, k + 1].culoare == loc[i, j].culoare)
                {
                    if (loc[i, k] != loc[i, j])
                    {
                        if ((loc[i, k].tipPiesa == 2 || loc[i, k].tipPiesa == 5) && loc[i, k].culoare == 2)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                        break;
                    }
                    
                }
                if (loc[i, k].culoare != loc[i, j].culoare)
                {
                    if ((loc[i, k].tipPiesa == 2 || loc[i, k].tipPiesa == 5) && loc[i, k].culoare == 2)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                }
                if ((loc[i, k].culoare != loc[i, j].culoare && loc[i, k].culoare != 0)) break;
            }
            for (int k = i; k >= 1; k--)
            {
                if (loc[k - 1, j] != null && loc[k - 1, j].culoare == loc[i, j].culoare)
                {
                    if (loc[k, j] != loc[i, j])
                    {
                        if ((loc[k, j].tipPiesa == 2 || loc[k, j].tipPiesa == 5) && loc[k, j].culoare == 2)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                        break;
                    }
                    
                }
                if (loc[k, j].culoare != loc[i, j].culoare)
                {
                    if ((loc[k, j].tipPiesa == 2 || loc[k, j].tipPiesa == 5) && loc[k, j].culoare == 2)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                }
                if ((loc[k, j].culoare != loc[i, j].culoare && loc[k, j].culoare != 0)) break;
            }
            for (int k = i; k <= 8; k++)
            {
                if (loc[k + 1, j] != null && loc[k + 1, j].culoare == loc[i, j].culoare)
                {
                    if (loc[k, j] != loc[i, j])
                    {
                        if ((loc[k, j].tipPiesa == 2 || loc[k, j].tipPiesa == 5) && loc[k, j].culoare == 2)
                        {
                            loc[orig1, orig2].culoare = tempCuloareOrig;
                            loc[curent1, curent2].culoare = tempCuloareCurent;
                            return true;
                        }
                        break;
                    }
                    
                }
                if (loc[k, j].culoare != loc[i, j].culoare)
                {
                    if ((loc[k, j].tipPiesa == 2 || loc[k, j].tipPiesa == 5) && loc[k, j].culoare == 2)
                    {
                        loc[orig1, orig2].culoare = tempCuloareOrig;
                        loc[curent1, curent2].culoare = tempCuloareCurent;
                        return true;
                    }
                }
                if ((loc[k, j].culoare != loc[i, j].culoare && loc[k, j].culoare != 0)) break;
            }
            //=====
            /*for (int l = i, c = j; l >= 1 && c >= 1; l--, c--)
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
            }*/
            loc[orig1, orig2].culoare = tempCuloareOrig;
            loc[curent1, curent2].culoare = tempCuloareCurent;
            return true;
        }
    }
}

