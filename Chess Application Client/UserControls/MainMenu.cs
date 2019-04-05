using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess_Application_Client.UserControls
{
    public partial class MainMenu : UserControl
    {
        private MainForm mainForm;
        private Options options;

        public MainMenu()
        {
            InitializeComponent();
        }

        public MainMenu(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            options = new Options(this);

            Controls.Add(options);
            options.BringToFront();
            options.Hide();

            options.MinimumSize = new Size(1200, 875);
            options.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            options.AutoSize = true;
            options.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        public void SetUsername(string username)
        {
            mainForm.SetUsernameFromMainMenuAndNotifyClient(username);
        }

        public void SetColors(string colorsString)
        {
            mainForm.SetColorsFromMainMenuAndNotifyClient(colorsString);
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            mainForm.HideMainMenu();
        }

        private void btnOptionsMenu_Click(object sender, EventArgs e)
        {
            options.Show();
        }

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
