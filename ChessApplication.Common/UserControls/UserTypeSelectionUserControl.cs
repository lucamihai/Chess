using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace ChessApplication.Common.UserControls
{
    [ExcludeFromCodeCoverage]
    public partial class UserTypeSelection : UserControl
    {
        public delegate void UserTypeSelected(UserType userType);
        public UserTypeSelected OnUserTypeSelected { get; set; }

        public UserTypeSelection()
        {
            InitializeComponent();
        }

        private void Begin(object sender, EventArgs e)
        {
            if (radioButtonServer.Checked)
            {
                OnUserTypeSelected(UserType.Server);
                return;
            }

            if (radioButtonClient.Checked)
            {
                OnUserTypeSelected(UserType.Client);
            }

            if (radioButtonSinglePlayer.Checked)
            {
                OnUserTypeSelected(UserType.SinglePlayer);
            }
        }
    }
}
