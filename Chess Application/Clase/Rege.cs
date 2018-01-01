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
            tipPiesa = 6;
        }
        public override void VerificaPosibilitati(int i, int j, LocatieTabla[,] loc)
        {
            SahDinRege(loc);
        }
    }
}
