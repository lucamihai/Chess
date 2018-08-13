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
    public partial class Meniu : UserControl
    {
        public Meniu()
        {
            InitializeComponent();
            this.Focus();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOptionsMenu_Click(object sender, EventArgs e)
        {
            optiuni1.Show();
        }

        private void optiuni1_Load(object sender, EventArgs e)
        {

        }
    }
}
