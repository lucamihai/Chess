using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using ChessApplication.Common;
using ChessApplication.GUI.Helpers;
using ChessApplication.GUI.UserControls.Chessboard;

namespace ChessApplication.GUI.UserControls.History
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
            
            pictureBoxOriginPiece.Image = ChessPieceImageProvider.GetImageForChessPiece(origin.Piece, new Size(32, 32));
            pictureBoxOriginPiece.BackColor = origin.BoxBackgroundColor;
            
            pictureBoxDestinationPiece.Image = ChessPieceImageProvider.GetImageForChessPiece(destination.Piece, new Size(32, 32));
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
