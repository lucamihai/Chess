using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Enums;

namespace ChessApplication.Common.ChessPieces
{
    public abstract class ChessPiece
    {
        public PieceColor Color { get; protected set; }

        public bool CanMove { get; set; } = false;

        private Image image;
        public Image Image
        {
            get => image;
            set
            {
                image = value;

                if (image != null)
                {
                    ImageSmall = Utilities.ResizeImage(image, 32, 32);
                }
            }
        }

        public abstract string Abbreviation { get; }

        [ExcludeFromCodeCoverage]
        public Image ImageSmall { get; protected set; }

        public abstract void CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard chessBoard, Point location);

    }
}

