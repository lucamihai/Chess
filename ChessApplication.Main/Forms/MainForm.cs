using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Main.Forms
{
    [ExcludeFromCodeCoverage]
    public partial class MainForm : Form
    {
        private readonly Panel menuContainer;
        private GameConfigurationUserControl gameConfigurationUserControl;
        private ChessboardMainMenuUserControl mainMenu;
        private ChessboardUserControl chessboardUserControl;

        public MainForm()
        {
            InitializeComponent();
            InitializeUserTypeSelection();
            
            InitializeMainMenu();

            menuContainer = new Panel
            {
                MinimumSize = new Size(this.Width, this.Height),
                MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
            };
            menuContainer.Controls.Add(gameConfigurationUserControl);
            menuContainer.Controls.Add(mainMenu);

            Controls.Add(menuContainer);
            menuContainer.BringToFront();

            toolStripMenuItemEnableBeginnersMode.Available = false;
            toolStripMenuItemEnableSound.Available = false;
        }

        private void InitializeMainMenu()
        {
            mainMenu = new ChessboardMainMenuUserControl
            {
                MinimumSize = new Size(this.Width, this.Height),
                MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            mainMenu.OnOptionsChanged += (username, colorsString) =>
            {
                chessboardUserControl.SetUsernameAndNotifyOpponent(username);
                chessboardUserControl.SetColorsAndNotifyOpponent(colorsString);

                chatBox.Username = username;

                menuContainer.Hide();
            };

            mainMenu.OnStartGame += () => menuContainer.Hide();
        }

        private void InitializeUserTypeSelection()
        {
            gameConfigurationUserControl = new GameConfigurationUserControl
            {
                MinimumSize = new Size(this.Width, this.Height),
                MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            gameConfigurationUserControl.OnConfigurationMade += (userType, chessboardType) =>
            {
                if (userType == UserType.SinglePlayer)
                {
                    MessageBox.Show("Single player not supported yet. Exiting application.");
                    Environment.Exit(0);
                }

                UpdateApplicationTextByUserType(userType);
                InitializeChessboard(chessboardType, userType);
                InitializeChatBox();
                gameConfigurationUserControl.Hide();
            };
        }

        private void UpdateApplicationTextByUserType(UserType userType)
        {
            this.Text = string.Format(Strings.ApplicationText, userType);
        }

        private void InitializeChessboard(ChessboardType chessboardType, UserType userType)
        {
            if (userType == UserType.Client)
            {
                var hostname = PromptIpAddress.ShowDialog();
                chessboardUserControl = new ChessboardUserControl(chessboardType, userType, hostname);
            }
            else
            {
                chessboardUserControl = new ChessboardUserControl(chessboardType, userType);
            }

            panelChessboard.Controls.Add(chessboardUserControl);

            chessboardUserControl.OnMadeMove += (origin, destination) =>
            {
                historyEntries.AddEntry(origin, destination);
            };

            chessboardUserControl.OnNotification += (notificationMessage) =>
            {
                notifications.AddNotification(notificationMessage);
            };

            chessboardUserControl.OnReceivedChatMessage += (username, message) =>
            {
                chatBox.AddChatMessage(username, message);
            };
        }

        private void InitializeChatBox()
        {
            chatBox.Username = chessboardUserControl.PlayerUsername;
            chatBox.OnSentChat += (message) =>
            {
                chessboardUserControl.SendMessageToOpponent(message);
            };
        }

        private void ToolStripEnableSound(object sender, EventArgs e)
        {
            chessboardUserControl.SoundEnabled = true;
            toolStripMenuItemEnableSound.Visible = false;
            toolStripMenuItemDisableSound.Visible = true;
        }

        private void ToolStripDisableSound(object sender, EventArgs e)
        {
            chessboardUserControl.SoundEnabled = false;
            toolStripMenuItemEnableSound.Visible = true;
            toolStripMenuItemDisableSound.Visible = false;
        }

        private void ToolStripEnableBeginnerMode(object sender, EventArgs e)
        {
            chessboardUserControl.BeginnersMode = true;
            toolStripMenuItemEnableBeginnersMode.Available = false;
            toolStripMenuItemDisableBeginnersMode.Available = true;
        }

        private void ToolStripDisableBeginnerMode(object sender, EventArgs e)
        {
            chessboardUserControl.BeginnersMode = false;
            toolStripMenuItemEnableBeginnersMode.Available = true;
            toolStripMenuItemDisableBeginnersMode.Available = false;
        }

        private void ToolStripNewGame(object sender, EventArgs e)
        {
            chessboardUserControl.RequestNewGame();
        }

        private void ToolStripQuit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            chessboardUserControl?.StopNetworkStuff();
        }
    }
}
