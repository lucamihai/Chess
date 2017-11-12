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
    }
}
