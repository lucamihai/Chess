using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using ChessApplication.Common.Enums;

namespace ChessApplication.GUI.UserControls.Menus
{
    [ExcludeFromCodeCoverage]
    public partial class GameConfigurationUserControl : UserControl
    {
        public delegate void ConfigurationMade(UserType userType, ChessboardType chessboardType);
        public ConfigurationMade OnConfigurationMade { get; set; }

        public GameConfigurationUserControl()
        {
            InitializeComponent();
        }

        private void Begin(object sender, EventArgs e)
        {
            var userType = GetUserType();
            var chessboardType = GetChessboardType();

            OnConfigurationMade(userType, chessboardType);
        }

        private UserType GetUserType()
        {
            if (radioButtonServer.Checked)
            {
                return UserType.Server;
            }

            if (radioButtonClient.Checked)
            {
                return UserType.Client;
            }

            if (radioButtonSinglePlayer.Checked)
            {
                return UserType.SinglePlayer;
            }

            throw new InvalidOperationException("User type must be selected");
        }

        private ChessboardType GetChessboardType()
        {
            if (radioButtonChessboardClassic.Checked)
            {
                return ChessboardType.Classic;
            }

            if (radioButtonChessboardShatranj.Checked)
            {
                return ChessboardType.Shatranj;
            }

            throw new InvalidOperationException("Chessboard type must be selected");
        }
    }
}
