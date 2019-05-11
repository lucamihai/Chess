using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Enums;

namespace ChessApplication.Common.ChessPieces
{
    public abstract class ChessPiece
    {
        public PieceColor Color { get; protected set; }

        public bool CanMove { get; set; } = false;

        private Image _Image;
        public Image Image
        {
            get => _Image;
            set
            {
                _Image = value;

                if (_Image != null)
                {
                    ImageSmall = Utilities.ResizeImage(_Image, 32, 32);
                }
            }
        }

        public abstract string Abbreviation { get; }

        [ExcludeFromCodeCoverage]
        public Image ImageSmall { get; protected set; }

        public abstract void CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard chessBoard, Point location);

    }
}

