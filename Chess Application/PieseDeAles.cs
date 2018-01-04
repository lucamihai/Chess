using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Application
{
    public partial class PieseDeAles : UserControl
    {
        Form1 f;
        public static Piesa tura, cal, nebun, regina;
        LocatieTabla t, c, n, r;
        public string adresa;
        public string alegere
        {
            set
            {
                adresa = value;
            }
        }
        public void setare(string a)
        {
            adresa = a;
        }
        public PieseDeAles()
        {
            InitializeComponent();
            tura = new Tura(1, pbTuraAlb, pbTuraAlb);
        }
        public PieseDeAles(Form ff)
        {

            InitializeComponent();
            tura = new Tura(1, pbTuraAlb, pbTuraAlb);
        }
        public PieseDeAles(Form1 ff)
        {
            f = ff;
            InitializeComponent();
            tura = new Tura(1, pbTuraAlb, pbTuraAlb);
        }

        private void PieseDeAles_Load(object sender, EventArgs e)
        {
            if (Form1.randMutare == 1) { panelPieseAlbe.Visible = true; panelPieseNegre.Visible = false; }
            else { panelPieseAlbe.Visible = false; panelPieseNegre.Visible = false; }
        }

        private void pbTuraAlb_Click(object sender, EventArgs e)
        {         
            Console.WriteLine("s-a apasat Tura alba");
            //f.piesaAleasa = "tura";               
        }

        private void pbCalAlb_Click(object sender, EventArgs e)
        {

        }

        private void pbNebunAlb_Click(object sender, EventArgs e)
        {

        }

        private void pbReginaAlb_Click(object sender, EventArgs e)
        {

        }

        private void pbTuraNegru_Click(object sender, EventArgs e)
        {
            Console.WriteLine("s-a apasat Tura neagra");
        }

        private void pbCalNegru_Click(object sender, EventArgs e)
        {

        }

        private void pbNebunNegru_Click(object sender, EventArgs e)
        {

        }

        private void pbReginaNegru_Click(object sender, EventArgs e)
        {

        }
    }
}
