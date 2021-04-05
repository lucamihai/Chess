using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using ChessApplication.Common;
using ChessApplication.GUI.UserControls.Chessboard;

namespace ChessApplication.GUI.History
{
    [ExcludeFromCodeCoverage]
    public partial class HistoryEntryUserControl : UserControl
    {
        public int EntryNumber
        {
            get => Convert.ToInt32((string) labelMoveNumber.Text);
            private set => labelMoveNumber.Text = value.ToString();
        }

        public string OriginName
        {
            get => labelOriginName.Text;
            private set => labelOriginName.Text = value;
        }

        public string DestinationName
        {
            get => labelDestinationName.Text;
            private set => labelDestinationName.Text = value;
        }

        public HistoryEntryUserControl(int entryNumber, BoxUserControl origin, BoxUserControl destination)
        {
            InitializeComponent();

            EntryNumber = entryNumber;

            OriginName = GenerateNameForPosition(origin.Position);
            DestinationName = GenerateNameForPosition(destination.Position);

            pictureBoxOriginPiece.Image = (origin.Piece != null) ? origin.Piece.ImageSmall : new Bitmap(32, 32);
            pictureBoxOriginPiece.BackColor = origin.BoxBackgroundColor;

            pictureBoxDestinationPiece.Image = (destination.Piece != null) ? destination.Piece.ImageSmall : new Bitmap(32, 32);
            pictureBoxDestinationPiece.BackColor = destination.BoxBackgroundColor;
        }

        private static string GenerateNameForPosition(Position position)
        {
            var firstChar = (char)('A' + position.Row - 1);
            var secondChar = position.Column.ToString();

            return $"{firstChar}{secondChar}";
        }
    }
}
