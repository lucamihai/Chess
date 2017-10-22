using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Application
{
    public partial class Form1 : Form
    {
        PictureBox[,] pozitie = new PictureBox[9, 9];
        int clickCounter = 0;
        int pozitieCifra1;
        int pozitieLitera1;
        int pozitieCifra2;
        int pozitieLitera2;
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public class Piesa
        {
            public Piesa()
            {//constructor fara parametrii

            }
            public Piesa(int c, int t)//constructor cu initializare tip si culoare piesa
            {
                this.culoare = c;
                this.tipPiesa = t;
            }
            public Piesa(int t)//constructor cu initializare tip piesa(in cazul in care piesele sunt albe, nefiind necesara initializarii valorii culoare)
            {
                this.tipPiesa = t;
            }
            public int culoare = 1;//1-alb, 2-negru;
            public int tipPiesa = 1;//1-pion, 2-tura, 3-cal, 4-nebun, 5-regina, 6-rege;
            public void VerificaPosibilitati()//self-explanatory -  verifica posibilitatile de miscare a piesei: tipul ofera comportamentul miscarii, iar culoarea directia...
            {

            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public class LocatieTabla
        {
            int arePiesa = 0;//0-nu are, 1-pion, 2-tura, 3-cal, 4-nebun, 5-regina, 6-rege;
            bool sePoate = false;
            public LocatieTabla(int a)
            {

            }
            public void MarcheazaVerde(CheckBox c)//daca sunt indeplinite regulile, marcheaza locatia ca fiin accesibila; optional afiseaza verde pe casuta respectiva
            {
                this.sePoate = true;
                if (c.Checked == true)
                {

                }
            }

            public void Verifica(Piesa a)//apelata la click pe piesa
            {
                if (a.tipPiesa == 1)
                {
                    if (a.culoare == 1)//merge 
                    {

                    }
                    if (a.culoare == 2)
                    {

                    }
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pozitie[1, 1] = _1A;
            pozitie[1, 2] = _2A;
            pozitie[1, 3] = _3A;
            pozitie[1, 4] = _4A;
            pozitie[1, 5] = _5A;
            pozitie[1, 6] = _6A;
            pozitie[1, 7] = _7A;
            pozitie[1, 8] = _8A;
            pozitie[2, 1] = _1B;
            pozitie[2, 2] = _2B;
            pozitie[2, 3] = _3B;
            pozitie[2, 4] = _4B;
            pozitie[2, 5] = _5B;
            pozitie[2, 6] = _6B;
            pozitie[2, 7] = _7B;
            pozitie[2, 8] = _8B;
            pozitie[3, 1] = _1C;
            pozitie[3, 2] = _2C;
            pozitie[3, 3] = _3C;
            pozitie[3, 4] = _4C;
            pozitie[3, 5] = _5C;
            pozitie[3, 6] = _6C;
            pozitie[3, 7] = _7C;
            pozitie[3, 8] = _8C;
            pozitie[4, 1] = _1D;
            pozitie[4, 2] = _2D;
            pozitie[4, 3] = _3D;
            pozitie[4, 4] = _4D;
            pozitie[4, 5] = _5D;
            pozitie[4, 6] = _6D;
            pozitie[4, 7] = _7D;
            pozitie[4, 8] = _8D;
            pozitie[5, 1] = _1E;
            pozitie[5, 2] = _2E;
            pozitie[5, 3] = _3E;
            pozitie[5, 4] = _4E;
            pozitie[5, 5] = _5E;
            pozitie[5, 6] = _6E;
            pozitie[5, 7] = _7E;
            pozitie[5, 8] = _8E;
            pozitie[6, 1] = _1F;
            pozitie[6, 2] = _2F;
            pozitie[6, 3] = _3F;
            pozitie[6, 4] = _4F;
            pozitie[6, 5] = _5F;
            pozitie[6, 6] = _6F;
            pozitie[6, 7] = _7F;
            pozitie[6, 8] = _8F;
            pozitie[7, 1] = _1G;
            pozitie[7, 2] = _2G;
            pozitie[7, 3] = _3G;
            pozitie[7, 4] = _4G;
            pozitie[7, 5] = _5G;
            pozitie[7, 6] = _6G;
            pozitie[7, 7] = _7G;
            pozitie[7, 8] = _8G;
            pozitie[8, 1] = _1H;
            pozitie[8, 2] = _2H;
            pozitie[8, 3] = _3H;
            pozitie[8, 4] = _4H;
            pozitie[8, 5] = _5H;
            pozitie[8, 6] = _6H;
            pozitie[8, 7] = _7H;
            pozitie[8, 8] = _8H;
            _1A.Controls.Add(pctBlackBishop);
            pctBlackBishop.Location = new Point(0, 0);
            pctBlackBishop.BackColor = Color.Transparent;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        
        private void _1A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0)
            {
                pozitieCifra1 = 0;
                pozitieLitera1 = 0;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
            }
            else
            {
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 0;
                clickCounter = 0;
                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
            }
            
        }

       

        private void _2A_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0)
            {
                pozitieCifra1 = 0;
                pozitieLitera1 = 1;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();
                
                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
            }
            else
            {
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 1;
                clickCounter = 0;
                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
            }
        }

        private void _1B_Click(object sender, EventArgs e)
        {
            if (clickCounter == 0)
            {
                pozitieCifra1 = 1;
                pozitieLitera1 = 2;
                x.Text = pozitieCifra1.ToString();
                y.Text = pozitieLitera1.ToString();

                clickCounter++;
                clkCounter.Text = "Selecteaza casuta in care sa muti";
            }
            else
            {
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 1;
                pozitieLitera2 = 2;
                clickCounter = 0;
                clkCounter.Text = "Selecteaza piesa pe care s-o muti";
            }
        }
    }
}

