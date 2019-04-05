﻿using System;
using System.Drawing;
using System.Windows.Forms;
using Chess_Application.Chessboard;

namespace Chess_Application_Client
{
    public partial class MainForm : Form
    {
        private Panel menuContainer;
        private UserControls.MainMenu mainMenu;
        private Chessboard chessboard;

        public MainForm()
        {
            InitializeComponent();
            menuContainer = new Panel
            {
                MinimumSize = new Size(this.Width, this.Height),
                MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
            };

            mainMenu = new UserControls.MainMenu(this)
            {
                MinimumSize = new Size(this.Width, this.Height),
                MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };
            menuContainer.Controls.Add(mainMenu);

            Controls.Add(menuContainer);
            menuContainer.BringToFront();

            toolStripMenuItemEnableBeginnersMode.Available = false;
            toolStripMenuItemEnableSound.Available = false;

            buttonConnect.BringToFront();
            tbAddress.BringToFront();
            tbAddress.Text = "127.0.0.1";
        }

        public void SetUsernameFromMainMenuAndNotifyClient(string username)
        {
            chessboard.SetUsernameFromMainMenuAndNotifyClient(username);
        }

        public void SetColorsFromMainMenuAndNotifyClient(string colorsString)
        {
            chessboard.SetColorsFromMainMenuAndNotifyClient(colorsString);
        }

        private void ToolStripEnableSound(object sender, EventArgs e)
        {

        }

        private void ToolStripDisableSound(object sender, EventArgs e)
        {

        }

        private void ToolStripEnableBeginnerMode(object sender, EventArgs e)
        {

        }

        private void ToolStripDisableBeginnerMode(object sender, EventArgs e)
        {

        }

        private void ToolStripNewGame(object sender, EventArgs e)
        {
            chessboard.RequestNewGame();
        }

        private void ToolStripQuit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void HideMainMenu()
        {
            menuContainer.Hide();
        }

        private void buttonConnect_Click(object sender, System.EventArgs e)
        {
            if (buttonConnect.Text == "Connect")
            {
                if (tbAddress.Text.Length > 0)
                {
                    chessboard = new Chessboard(UserType.Client, tbAddress.Text);
                    chessboard.SetColorsFromMainMenuAndNotifyClient("2 1");
                    panelChessboard.Controls.Add(chessboard);

                    tbAddress.Visible = false;
                    buttonConnect.Text = "Disconnect";
                }
                else
                {
                    MessageBox.Show("You must specify an IP address");
                }
            }

            else
            {
                chessboard.StopNetworkStuff();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            chessboard.StopNetworkStuff();
        }
    }
}
