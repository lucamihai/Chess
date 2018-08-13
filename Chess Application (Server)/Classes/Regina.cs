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
    public class Regina : Piesa
    {
       
        public Regina(int c, PictureBox p, PictureBox pm)
        {
            culoare = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
            tipPiesa = 5;
        }
        public override void VerificaPosibilitati(int i, int j, LocatieTabla[,] loc)
        {
            for (int m = 1; m <= 8; m++)
            {
                for (int n = 1; m <= 8; m++)
                {
                    loc[m, n].sePoate = false;
                }
            }
            //miscarea reginei este obtinuta din miscarea nebunului combinata cu miscarea turei
            for (int k = j; k >= 1; k--)
            {
                if (loc[i, k - 1] != null && loc[i, k - 1].culoare == loc[i, j].culoare)
                {
                    if (loc[i, k] != loc[i, j] && !Sah(loc, i, j, i, k)) 
                    {
                        loc[i, k].Marcheaza(); loc[i, j].poateFaceMiscari = true;
                    } break;
                }
                if (loc[i, k].culoare != loc[i, j].culoare && !Sah(loc, i, j, i, k)) 
                {
                    loc[i, k].Marcheaza();
                    loc[i, j].poateFaceMiscari = true;
                }
                if ((loc[i, k].culoare != loc[i, j].culoare && loc[i, k].culoare != 0)) break;
            }
            for (int k = j; k <= 8; k++)
            {
                if (loc[i, k + 1] != null && loc[i, k + 1].culoare == loc[i, j].culoare)
                {
                    if (loc[i, k] != loc[i, j] && !Sah(loc, i, j, i, k)) 
                    {
                        loc[i, k].Marcheaza(); loc[i, j].poateFaceMiscari = true;
                    } break;
                }
                if (loc[i, k].culoare != loc[i, j].culoare && !Sah(loc, i, j, i, k))
                {
                    loc[i, k].Marcheaza();
                    loc[i, j].poateFaceMiscari = true;
                }
                if ((loc[i, k].culoare != loc[i, j].culoare && loc[i, k].culoare != 0)) break;
            }
            for (int k = i; k >= 1; k--)
            {
                if (loc[k - 1, j] != null && loc[k - 1, j].culoare == loc[i, j].culoare)
                {
                    if (loc[k, j] != loc[i, j] && !Sah(loc, i, j, k, j))
                    {
                        loc[k, j].Marcheaza(); loc[i, j].poateFaceMiscari = true;
                    } break;
                }
                if (loc[k, j].culoare != loc[i, j].culoare && !Sah(loc, i, j, k, j))
                {
                    loc[k, j].Marcheaza();
                    loc[i, j].poateFaceMiscari = true;
                }
                if ((loc[k, j].culoare != loc[i, j].culoare && loc[k, j].culoare != 0)) break;
            }
            for (int k = i; k <= 8; k++)
            {
                if (loc[k + 1, j] != null && loc[k + 1, j].culoare == loc[i, j].culoare)
                {
                    if (loc[k, j] != loc[i, j] && !Sah(loc, i, j, k, j))
                    {
                        loc[k, j].Marcheaza(); loc[i, j].poateFaceMiscari = true;
                    } break;
                }
                if (loc[k, j].culoare != loc[i, j].culoare && !Sah(loc, i, j, k, j))
                {
                    loc[k, j].Marcheaza();
                    loc[i, j].poateFaceMiscari = true;
                }
                if ((loc[k, j].culoare != loc[i, j].culoare && loc[k, j].culoare != 0)) break;
            }
            //=====
            for (int l = i, c = j; l >= 1 && c >= 1; l--, c--)
            {
                if (loc[i, j].culoare != loc[l, c].culoare && !Sah(loc, i, j, l, c)) 
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
                if (loc[i, j].culoare != loc[l, c].culoare && !Sah(loc, i, j, l, c))
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
                if (loc[i, j].culoare != loc[l, c].culoare && !Sah(loc, i, j, l, c))
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
                if (loc[i, j].culoare != loc[l, c].culoare && !Sah(loc, i, j, l, c))
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
    }
}
