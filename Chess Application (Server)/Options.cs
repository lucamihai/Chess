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
        MainMenu mainMenu;
        public System.Delegate _SchimbareUsername;
        public Delegate apeleaza
        {
            set { _SchimbareUsername = value; }
        }

        public Options()
        {
            InitializeComponent();           
        }

        public Options(MainMenu mainMenu)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
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
                mainMenu.SetUsername(textBoxUsername.Text);
                labelError.Text = "";

                if (checkBoxWhite.Checked == true)
                {
                    mainMenu.SetColors("1 2");
                }
                else
                {
                    mainMenu.SetColors("2 1");
                }

                Hide();
            }
            else
            {
                labelError.Text = "Please enter a non-blank username, without spaces at the end";
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
