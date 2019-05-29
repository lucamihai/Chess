using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using ChessApplication.Common;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Main.Forms
{
    [ExcludeFromCodeCoverage]
    public partial class MainForm : Form
    {
        private readonly Panel menuContainer;
        private UserTypeSelectionUserControl userTypeSelection;
        private ChessboardMainMenuUserControl mainMenu;
        private ChessboardUserControl chessboard;

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
            menuContainer.Controls.Add(userTypeSelection);
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
                chessboard.SetUsernameAndNotifyOpponent(username);
                chessboard.SetColorsAndNotifyOpponent(colorsString);

                chatBox.Username = username;

                menuContainer.Hide();
            };

            mainMenu.OnStartGame += () => menuContainer.Hide();
        }

        private void InitializeUserTypeSelection()
        {
            userTypeSelection = new UserTypeSelectionUserControl
            {
                MinimumSize = new Size(this.Width, this.Height),
                MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            userTypeSelection.OnUserTypeSelected += userType =>
            {
                if (userType == UserType.SinglePlayer)
                {
                    MessageBox.Show("Single player not supported yet. Exiting application.");
                    Environment.Exit(0);
                }

                UpdateApplicationTextByUserType(userType);
                InitializeChessboard(userType);
                InitializeChatBox();
                userTypeSelection.Hide();
            };
        }

        private void UpdateApplicationTextByUserType(UserType userType)
        {
            this.Text = $"Chess application ({userType})";
        }

        private void InitializeChessboard(UserType userType)
        {
            if (userType == UserType.Client)
            {
                var hostname = PromptIpAddress.ShowDialog();
                chessboard = new ChessboardUserControl(userType, hostname);
            }
            else
            {
                chessboard = new ChessboardUserControl(userType);
            }

            panelChessboard.Controls.Add(chessboard);

            chessboard.OnMadeMove += (origin, destination) =>
            {
                historyEntries.AddEntry(origin, destination);
            };

            chessboard.OnNotification += (notificationMessage) =>
            {
                notifications.AddNotification(notificationMessage);
            };

            chessboard.OnReceivedChatMessage += (username, message) =>
            {
                chatBox.AddChatMessage(username, message);
            };
        }

        private void InitializeChatBox()
        {
            chatBox.Username = chessboard.PlayerUsername;
            chatBox.OnSentChat += (message) =>
            {
                chessboard.SendMessageToOpponent(message);
            };
        }

        private void ToolStripEnableSound(object sender, EventArgs e)
        {
            chessboard.SoundEnabled = true;
            toolStripMenuItemEnableSound.Visible = false;
            toolStripMenuItemDisableSound.Visible = true;
        }

        private void ToolStripDisableSound(object sender, EventArgs e)
        {
            chessboard.SoundEnabled = false;
            toolStripMenuItemEnableSound.Visible = true;
            toolStripMenuItemDisableSound.Visible = false;
        }

        private void ToolStripEnableBeginnerMode(object sender, EventArgs e)
        {
            chessboard.BeginnersMode = true;
            toolStripMenuItemEnableBeginnersMode.Available = false;
            toolStripMenuItemDisableBeginnersMode.Available = true;
        }

        private void ToolStripDisableBeginnerMode(object sender, EventArgs e)
        {
            chessboard.BeginnersMode = false;
            toolStripMenuItemEnableBeginnersMode.Available = true;
            toolStripMenuItemDisableBeginnersMode.Available = false;
        }

        private void ToolStripNewGame(object sender, EventArgs e)
        {
            chessboard.RequestNewGame();
        }

        private void ToolStripQuit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            chessboard?.StopNetworkStuff();
        }
    }
}
