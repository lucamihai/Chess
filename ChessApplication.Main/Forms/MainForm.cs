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
        private UserType userType;
        private readonly Panel menuContainer;
        private UserTypeSelection userTypeSelection;
        private ChessboardMainMenu mainMenu;
        private ChessboardUserControl chessboard;

        public MainForm()
        {
            InitializeComponent();
            InitializeUserTypeSelection();
            InitializeChessboard();
            InitializeChatBox();
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
            mainMenu = new ChessboardMainMenu
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
            userTypeSelection = new UserTypeSelection
            {
                MinimumSize = new Size(this.Width, this.Height),
                MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            userTypeSelection.OnUserTypeSelected += type =>
            {
                userType = type;
                userTypeSelection.Hide();
                MessageBox.Show($"You selected user type '{userType}'");
            };
        }

        private void InitializeChessboard()
        {
            chessboard = new ChessboardUserControl(UserType.Server);
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
            chessboard.StopNetworkStuff();
        }
    }
}
