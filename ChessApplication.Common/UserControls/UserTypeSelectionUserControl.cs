using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace ChessApplication.Common.UserControls
{
    [ExcludeFromCodeCoverage]
    public partial class UserTypeSelectionUserControl : UserControl
    {
        public delegate void UserTypeSelected(UserType userType);
        public UserTypeSelected OnUserTypeSelected { get; set; }

        public UserTypeSelectionUserControl()
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
