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
    public class Pion : Piesa
    {
        public Pion(int c, PictureBox p, PictureBox pm)
        {
            culoare = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
        }
        public override void VerificaPosibilitati(int i, int j, LocatieTabla[,] loc)
        {
            if (culoare == 1)//pion alb
            {
                if (loc[i + 1, j] != null && loc[i + 1, j].imagineLocatie.BackgroundImage == null)
                {
                    loc[i + 1, j].Marcheaza();
                    loc[i, j].poateFaceMiscari = true;
                }
                if (i < 8 && j < 8 && loc[i + 1, j + 1].culoare == 2)
                {
                    loc[i + 1, j + 1].Marcheaza();
                    loc[i, j].poateFaceMiscari = true;
                }
                if (i < 8 && j > 1 && loc[i + 1, j - 1].culoare == 2)
                {
                    loc[i + 1, j - 1].Marcheaza();
                    loc[i, j].poateFaceMiscari = true;
                }
                if ((i == 2) && loc[i + 2, j] != null && loc[i + 2, j].imagineLocatie.BackgroundImage == null && loc[i + 1, j].imagineLocatie.BackgroundImage == null)
                {
                    loc[i + 2, j].Marcheaza();
                    loc[i, j].poateFaceMiscari = true;
                }

            }
            if (culoare == 2)//pion negru
            {
                if (loc[i - 1, j] != null && loc[i - 1, j].imagineLocatie.BackgroundImage == null)
                {
                    loc[i - 1, j].Marcheaza();
                    loc[i, j].poateFaceMiscari = true;
                }
                if (i > 1 && j < 8 && loc[i - 1, j + 1].culoare == 1)
                {
                    loc[i - 1, j + 1].Marcheaza();
                    loc[i, j].poateFaceMiscari = true;
                }
                if (i > 1 && j > 1 && loc[i - 1, j - 1].culoare == 1)
                {
                    loc[i - 1, j - 1].Marcheaza();
                    loc[i, j].poateFaceMiscari = true;
                }
                if ((i == 7) && loc[i - 2, j] != null && loc[i - 2, j].imagineLocatie.BackgroundImage == null && loc[i - 1, j].imagineLocatie.BackgroundImage == null)
                {
                    loc[i - 2, j].Marcheaza();
                    loc[i, j].poateFaceMiscari = true;
                }
            }
        }
    }
}
