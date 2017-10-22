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
        PictureBox[][] pozitie;
        int pozitieCifra;
        int pozitieLitera;
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
            //pozitie[0][0] = _1A;
            //... TBD in C++
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
        {//ana asre mere

        }
    }
}

