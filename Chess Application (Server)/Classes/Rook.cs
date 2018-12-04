﻿using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;


namespace Chess_Application
{
    public class Rook : ChessPiece
    {
        public Rook(int c, PictureBox p, PictureBox pm)
        {
            culoare = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
            tipPiesa = 2;
        }
        public override void CheckPossibilities(int i, int j, LocatieTabla[,] loc)
        {
            {
                //------------------------------explicatie universala pentru cele 4 for-uri-------------------------------------------------------------

                //primul if din for: daca urmatoarea casuta exista si are o piesa de aceeasi culoare intrerupe
                //aditional, daca locatia curenta este diferita de locatia originala(de la apelul functiei), marcheaza casuta respectiva
                //al doilea if din for: daca cele doua casute contin piese de culori diferite(printre care 0==casuta goala), marcheaza casuta curenta
                //al treilea if din for: daca casuta curenta are o piesa diferita de cea a casutei originale, intrerupe for-ul
                //obs. casuta respectiva "apuca" sa fie marcata, intrucat este marcata anterior
                //--------------------------------------------------------------------------------------------------------------------------------------
                for (int k = j; k >= 1; k--)
                {
                    if (loc[i, k - 1] != null && loc[i, k - 1].culoare == loc[i, j].culoare)
                    {
                        if (loc[i, k] != loc[i, j] && !TriggersCheck(loc, i, j, i, k))
                        {
                            loc[i, k].MarkAsAvailable(); loc[i, j].poateFaceMiscari = true;
                        }
                        break;
                    }
                    if (loc[i, k].culoare != loc[i, j].culoare && !TriggersCheck(loc, i, j, i, k))
                    {
                        loc[i, k].MarkAsAvailable();
                        loc[i, j].poateFaceMiscari = true;
                    }
                    if ((loc[i, k].culoare != loc[i, j].culoare && loc[i, k].culoare != 0)) break;
                }
                for (int k = j; k <= 8; k++)
                {
                    if (loc[i, k + 1] != null && loc[i, k + 1].culoare == loc[i, j].culoare)
                    {
                        if (loc[i, k] != loc[i, j] && !TriggersCheck(loc, i, j, i, k))
                        {
                            loc[i, k].MarkAsAvailable(); loc[i, j].poateFaceMiscari = true;
                        }
                        break;
                    }
                    if (loc[i, k].culoare != loc[i, j].culoare && !TriggersCheck(loc, i, j, i, k))
                    {
                        loc[i, k].MarkAsAvailable();
                        loc[i, j].poateFaceMiscari = true;
                    }
                    if ((loc[i, k].culoare != loc[i, j].culoare && loc[i, k].culoare != 0)) break;
                }
                for (int k = i; k >= 1; k--)
                {
                    if (loc[k - 1, j] != null && loc[k - 1, j].culoare == loc[i, j].culoare)
                    {
                        if (loc[k, j] != loc[i, j] && !TriggersCheck(loc, i, j, k, j))
                        {
                            loc[k, j].MarkAsAvailable(); loc[i, j].poateFaceMiscari = true;
                        }
                        break;
                    }
                    if (loc[k, j].culoare != loc[i, j].culoare && !TriggersCheck(loc, i, j, k, j))
                    {
                        loc[k, j].MarkAsAvailable();
                        loc[i, j].poateFaceMiscari = true;
                    }
                    if ((loc[k, j].culoare != loc[i, j].culoare && loc[k, j].culoare != 0)) break;
                }
                for (int k = i; k <= 8; k++)
                {
                    if (loc[k + 1, j] != null && loc[k + 1, j].culoare == loc[i, j].culoare)
                    {
                        if (loc[k, j] != loc[i, j] && !TriggersCheck(loc, i, j, k, j))
                        {
                            loc[k, j].MarkAsAvailable(); loc[i, j].poateFaceMiscari = true;
                        }
                        break;
                    }
                    if (loc[k, j].culoare != loc[i, j].culoare && !TriggersCheck(loc, i, j, k, j))
                    {
                        loc[k, j].MarkAsAvailable();
                        loc[i, j].poateFaceMiscari = true;
                    }
                    if ((loc[k, j].culoare != loc[i, j].culoare && loc[k, j].culoare != 0)) break;
                }
            }
        }
    }
}