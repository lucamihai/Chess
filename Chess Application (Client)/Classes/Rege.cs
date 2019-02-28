using System.Windows.Forms;

namespace Chess_Application_client.Classes
{
    public class Rege : Piesa
    {
        public Rege(int c, PictureBox p, PictureBox pm)
        {
            culoare = c;
            imaginePiesa = p;
            imagineMicaPiesa = pm;
            tipPiesa = 6;
        }
        public override void VerificaPosibilitati(int i, int j, LocatieTabla[,] loc)
        {
            SahDinRege(loc);
        }
    }
}
