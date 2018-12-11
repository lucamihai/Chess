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
    public partial class MainMenu : UserControl
    {
        MainForm mainForm;
        Options options;

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

            options.MinimumSize = new System.Drawing.Size(1200, 875);
            options.MaximumSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            options.AutoSize = true;
            options.AutoSizeMode = AutoSizeMode.GrowAndShrink;
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

        public void HideMainMenu()
        {
            Hide();
        }

        public void SetUsername(string username)
        {
            mainForm.SetUsername(username);
        }

        public void SetColors(string colorsString)
        {
            mainForm.SetColors(colorsString);
        }
    }
}
