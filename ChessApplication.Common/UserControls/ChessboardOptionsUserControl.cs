using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Forms;

namespace ChessApplication.Common.UserControls
{
    [ExcludeFromCodeCoverage]
    public partial class ChessboardOptionsUserControl : UserControl
    {
        private readonly char[] forbiddenUsernameCharacters = { '#', '!', ':' };

        public delegate void Confirm(string username, string colorsString);
        public Confirm OnConfirm { get; set; }

        public delegate void Cancel();
        public Cancel OnCancel { get; set; }

        public ChessboardOptionsUserControl()
        {
            InitializeComponent();

            labelError.Text = string.Empty;
        }

        private void ConfirmEvent(object sender, EventArgs e)
        {
            var enteredUsername = textBoxUsername.Text;

            if (IsUsernameValid(enteredUsername))
            {
                var colorsString = radioButtonWhite.Checked ? "1 2" : "2 1";

                OnConfirm(enteredUsername, colorsString);
            }
        }

        private void CancelEvent(object sender, EventArgs e)
        {
            OnCancel();
        }

        private bool IsUsernameValid(string username)
        {
            var isValid = true;
            labelError.Text = "";

            if (username.Length < 3 || username.Length > 15)
            {
                labelError.Text += "PlayerUsername must be between 3 and 15 characters";
                labelError.Text += Environment.NewLine;

                isValid = false;
            }

            foreach (char forbiddenCharacter in forbiddenUsernameCharacters)
            {
                if (username.Contains(forbiddenCharacter))
                {
                    labelError.Text += "PlayerUsername shouldn't contain any of the following characters: ";
                    labelError.Text += string.Join(", ", forbiddenUsernameCharacters);
                    labelError.Text += Environment.NewLine;

                    isValid = false;
                    break;
                }
            }

            if (username.EndsWith(" "))
            {
                labelError.Text += "PlayerUsername shouldn't end with a blank space";
                labelError.Text += Environment.NewLine;

                isValid = false;
            }

            return isValid;
        }
    }
}
