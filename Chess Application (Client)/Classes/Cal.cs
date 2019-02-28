using System.Windows.Forms;

namespace Chess_Application_client.Classes
{
    public class Cal : Piesa
    {
        public Cal(int c, PictureBox p, PictureBox pm)
        {
            culoare = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
            tipPiesa = 3;
        }
        public override void VerificaPosibilitati(int i, int j, LocatieTabla[,] loc)
        {
            //self explanatory right here
            //=====
            if ((i < 8 && j < 7) && (loc[i + 1, j + 2].culoare != loc[i, j].culoare) && !Sah(loc, i, j, i + 1, j + 2))
            {
                loc[i + 1, j + 2].Marcheaza();
                loc[i, j].poateFaceMiscari = true;
            }
            if ((i < 8 && j > 2) && (loc[i + 1, j - 2].culoare != loc[i, j].culoare) && !Sah(loc, i, j, i + 1, j - 2))
            {
                loc[i + 1, j - 2].Marcheaza();
                loc[i, j].poateFaceMiscari = true;
            }
            //=====
            if ((i < 7 && j < 8) && (loc[i + 2, j + 1].culoare != loc[i, j].culoare) && !Sah(loc, i, j, i + 2, j + 1))
            {
                loc[i + 2, j + 1].Marcheaza();
                loc[i, j].poateFaceMiscari = true;
            }
            if ((i < 7 && j > 1) && (loc[i + 2, j - 1].culoare != loc[i, j].culoare) && !Sah(loc, i, j, i + 2, j - 1))
            {
                loc[i + 2, j - 1].Marcheaza();
                loc[i, j].poateFaceMiscari = true;
            }
            //=====
            if ((i > 1 && j < 7) && (loc[i - 1, j + 2].culoare != loc[i, j].culoare) && !Sah(loc, i, j, i - 1, j + 2))
            {
                loc[i - 1, j + 2].Marcheaza();
                loc[i, j].poateFaceMiscari = true;
            }
            if ((i > 1 && j > 2) && (loc[i - 1, j - 2].culoare != loc[i, j].culoare) && !Sah(loc, i, j, i - 1, j - 2))
            {
                loc[i - 1, j - 2].Marcheaza();
                loc[i, j].poateFaceMiscari = true;
            }
            //=====              
            if ((i > 2 && j < 8) && (loc[i - 2, j + 1].culoare != loc[i, j].culoare) && !Sah(loc, i, j, i - 2, j + 1))
            {
                loc[i - 2, j + 1].Marcheaza();
                loc[i, j].poateFaceMiscari = true;
            }
            if ((i > 2 && j > 1) && (loc[i - 2, j - 1].culoare != loc[i, j].culoare) && !Sah(loc, i, j, i - 2, j - 1))
            {
                loc[i - 2, j - 1].Marcheaza();
                loc[i, j].poateFaceMiscari = true;
            }
            //=====
        }
    }
}
