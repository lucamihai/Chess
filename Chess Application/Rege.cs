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
    public class Rege : Piesa
    {
        public Rege(int c, PictureBox p, PictureBox pm)
        {
            culoare = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
        }
        public override void VerificaPosibilitati(int i, int j, LocatieTabla[,] loc)
        {
            if (loc[i + 1, j] != null && loc[i + 1, j].culoare != loc[i, j].culoare) { loc[i + 1, j].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
            if (loc[i + 1, j + 1] != null && loc[i + 1, j + 1].culoare != loc[i, j].culoare) { loc[i + 1, j + 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
            if (loc[i, j + 1] != null && loc[i, j + 1].culoare != loc[i, j].culoare) { loc[i, j + 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
            if (loc[i - 1, j + 1] != null && loc[i - 1, j + 1].culoare != loc[i, j].culoare) { loc[i - 1, j + 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
            //=====
            if (loc[i - 1, j] != null && loc[i - 1, j].culoare != loc[i, j].culoare) { loc[i - 1, j].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
            if (loc[i - 1, j - 1] != null && loc[i - 1, j - 1].culoare != loc[i, j].culoare) { loc[i - 1, j - 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
            if (loc[i, j - 1] != null && loc[i, j - 1].culoare != loc[i, j].culoare) { loc[i, j - 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
            if (loc[i + 1, j - 1] != null && loc[i + 1, j - 1].culoare != loc[i, j].culoare) { loc[i + 1, j - 1].Marcheaza(); loc[i, j].poateFaceMiscari = true; }
        }
    }
}
