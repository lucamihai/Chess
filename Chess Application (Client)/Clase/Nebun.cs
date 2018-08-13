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
    public class Nebun : Piesa
    {
        public Nebun(int c, PictureBox p, PictureBox pm)
        {
            culoare = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
            tipPiesa = 4;
        }
        public override void VerificaPosibilitati(int i, int j, LocatieTabla[,] loc)
        {
            //------------------------------explicatie universala pentru cele 4 for-uri-------------------------------------------------------------

            //primul if din for: daca urmatoarea casuta exista si are o piesa de culoare diferita, o marcheaza 
            //al doilea if din for: daca exista urmatoarea casuta si daca contine o piesa de orice culoare, interupe for-ul (aplicabil pentru alb)
            //al treilea if din for: daca exista urmatoarea casuta si daca contine o piesa de orice culoare, interupe for-ul (aplicabil pentru negru)
            //obs. casuta respectiva "apuca" sa fie marcata, intrucat este marcata anterior
            //--------------------------------------------------------------------------------------------------------------------------------------
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
