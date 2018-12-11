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
        char[] forbiddenUsernameCharacters = { '#', '!', ':' };

        public Options()
        {
            InitializeComponent();           
        }

        public Options(MainMenu mainMenu)
        {
            InitializeComponent();
            this.mainMenu = mainMenu;
            labelError.Text = "";
        }

        private void Cancel(object sender, EventArgs e)
        {
            Hide();
        }

        private void Confirm(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;

            if (IsUsernameValid(username))
            {               
                mainMenu.SetUsername(username);
                labelError.Text = "";

                if (radioButtonWhite.Checked == true)
                {
                    mainMenu.SetColors("1 2");
                }

                else
                {
                    mainMenu.SetColors("2 1");
                }

                Hide();
            }
        }

        bool IsUsernameValid(string username)
        {
            bool isValid = true;
            labelError.Text = "";

            if (username.Length < 3 || username.Length > 15)
            {
                labelError.Text += "Username must be between 3 and 15 characters\r\n";
                isValid = false;
            }

            foreach(char forbiddenCharacter in forbiddenUsernameCharacters)
            {
                if (username.Contains(forbiddenCharacter))
                {
                    labelError.Text += "Username shouldn't contain any of the following characters: ";
                    labelError.Text += String.Join(", ", forbiddenUsernameCharacters);
                    labelError.Text += "\r\n";

                    isValid = false;
                    break;
                }
            }

            if (username.EndsWith(" "))
            {
                labelError.Text += "Username shouldn't end with a blank space\r\n";
                isValid = false;
            }

            return isValid;
        }
    }
}
