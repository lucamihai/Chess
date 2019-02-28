using System;
using System.Linq;
using System.Windows.Forms;

namespace Chess_Application.UserControls
{
    
    public partial class Options : UserControl
    {
        private MainMenu mainMenu;
        private char[] forbiddenUsernameCharacters = { '#', '!', ':' };

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
            var enteredUsername = textBoxUsername.Text;

            if (IsUsernameValid(enteredUsername))
            {               
                mainMenu.SetUsername(enteredUsername);
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

        private bool IsUsernameValid(string username)
        {
            var isValid = true;
            labelError.Text = "";

            if (username.Length < 3 || username.Length > 15)
            {
                labelError.Text += "Username must be between 3 and 15 characters";
                labelError.Text += Environment.NewLine;

                isValid = false;
            }

            foreach(char forbiddenCharacter in forbiddenUsernameCharacters)
            {
                if (username.Contains(forbiddenCharacter))
                {
                    labelError.Text += "Username shouldn't contain any of the following characters: ";
                    labelError.Text += string.Join(", ", forbiddenUsernameCharacters);
                    labelError.Text += Environment.NewLine;

                    isValid = false;
                    break;
                }
            }

            if (username.EndsWith(" "))
            {
                labelError.Text += "Username shouldn't end with a blank space";
                labelError.Text += Environment.NewLine;

                isValid = false;
            }

            return isValid;
        }
    }
}
