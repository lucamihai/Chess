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
    
    public partial class Options : UserControl
    {
        public System.Delegate _SchimbareUsername;
        public Delegate apeleaza
        {
            set { _SchimbareUsername = value; }
        }

        public Options()
        {
            InitializeComponent();           
        }

        private void checkBoxWhite_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWhite.Checked == true && checkBoxBlack.Checked == true) checkBoxBlack.Checked = false;
        }

        private void checkBoxBlack_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWhite.Checked == true && checkBoxBlack.Checked == true) checkBoxWhite.Checked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text != "" && !textBoxUsername.Text.EndsWith(" "))
            {               
                MainForm._username = textBoxUsername.Text;
                labelError.Text = "";          
                this.Hide();
            }
            else labelError.Text = "Format username inacceptabil";          
            if (checkBoxWhite.Checked == true) MainForm._culoriUseri = "1 2";
            else MainForm._culoriUseri = "2 1";
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
