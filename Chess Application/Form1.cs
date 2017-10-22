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
        PictureBox[,] pozitie = new PictureBox[8, 8];
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
            pozitie[0, 0] = _1A;
            pozitie[0, 1] = _2A;
            pozitie[0, 2] = _3A;
            pozitie[0, 3] = _4A;
            pozitie[0, 4] = _5A;
            pozitie[0, 5] = _6A;
            pozitie[0, 6] = _7A;
            pozitie[0, 7] = _8A;
            pozitie[1, 0] = _1B;
            pozitie[1, 1] = _2B;
            pozitie[1, 2] = _3B;
            pozitie[1, 3] = _4B;
            pozitie[1, 4] = _5B;
            pozitie[1, 5] = _6B;
            pozitie[1, 6] = _7B;
            pozitie[1, 7] = _8B;
            pozitie[2, 0] = _1C;
            pozitie[2, 1] = _2C;
            pozitie[2, 2] = _3C;
            pozitie[2, 3] = _4C;
            pozitie[2, 4] = _5C;
            pozitie[2, 5] = _6C;
            pozitie[2, 6] = _7C;
            pozitie[2, 7] = _8C;
            pozitie[3, 0] = _1D;
            pozitie[3, 1] = _2D;
            pozitie[3, 2] = _3D;
            pozitie[3, 3] = _4D;
            pozitie[3, 4] = _5D;
            pozitie[3, 5] = _6D;
            pozitie[3, 6] = _7D;
            pozitie[3, 7] = _8D;
            pozitie[4, 0] = _1E;
            pozitie[4, 1] = _2E;
            pozitie[4, 2] = _3E;
            pozitie[4, 3] = _4E;
            pozitie[4, 4] = _5E;
            pozitie[4, 5] = _6E;
            pozitie[4, 6] = _7E;
            pozitie[4, 7] = _8E;
            pozitie[5, 0] = _1F;
            pozitie[5, 1] = _2F;
            pozitie[5, 2] = _3F;
            pozitie[5, 3] = _4F;
            pozitie[5, 4] = _5F;
            pozitie[5, 5] = _6F;
            pozitie[5, 6] = _7F;
            pozitie[5, 7] = _8F;
            pozitie[6, 0] = _1G;
            pozitie[6, 1] = _2G;
            pozitie[6, 2] = _3G;
            pozitie[6, 3] = _4G;
            pozitie[6, 4] = _5G;
            pozitie[6, 5] = _6G;
            pozitie[6, 6] = _7G;
            pozitie[6, 7] = _8G;
            pozitie[7, 0] = _1H;
            pozitie[7, 1] = _2H;
            pozitie[7, 2] = _3H;
            pozitie[7, 3] = _4H;
            pozitie[7, 4] = _5H;
            pozitie[7, 5] = _6H;
            pozitie[7, 6] = _7H;
            pozitie[7, 7] = _8H;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMisca_Click(object sender, EventArgs e)
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
                clkCount.Text = clickCounter.ToString();
            }
            else
            {
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 0;
                clickCounter = 0;
                clkCount.Text = clickCounter.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
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
                clkCount.Text = clickCounter.ToString();
            }
            else
            {
                x.Text = pozitieCifra2.ToString();
                y.Text = pozitieLitera2.ToString();
                pozitieCifra2 = 0;
                pozitieLitera2 = 1;
                clickCounter = 0;
                clkCount.Text = clickCounter.ToString();
            }
        }
    }
}

