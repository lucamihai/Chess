using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using ChessApplication.Common.Enums;

namespace ChessApplication.Common.UserControls
{
    [ExcludeFromCodeCoverage]
    public partial class ChessboardMainMenuUserControl : UserControl
    {
        public delegate void StartGame();
        public StartGame OnStartGame { get; set; }

        public delegate void OptionsChanged(string username, Turn color);
        public OptionsChanged OnOptionsChanged { get; set; }

        public ChessboardMainMenuUserControl()
        {
            InitializeComponent();
        }

        private void StartGameEvent(object sender, EventArgs e)
        {
            OnStartGame();
        }

        private void OptionsMenuEvent(object sender, EventArgs e)
        {
            var optionsUserControl = GetOptionsUserControl();
            Controls.Add(optionsUserControl);
            optionsUserControl.BringToFront();
        }

        private void ExitAppEvent(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private ChessboardOptionsUserControl GetOptionsUserControl()
        {
            var optionsUserControl = new ChessboardOptionsUserControl
            {
                MinimumSize = new Size(this.Width, this.Height),
                MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            optionsUserControl.OnCancel += () =>
            {
                optionsUserControl.Hide(); 
                Controls.Remove(optionsUserControl);
            };

            optionsUserControl.OnConfirm += (username, color) =>
            {
                optionsUserControl.Hide();
                Controls.Remove(optionsUserControl);

                OnOptionsChanged(username, color);
            };

            return optionsUserControl;
        }
    }
}
