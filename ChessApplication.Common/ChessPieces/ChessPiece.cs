using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Common.ChessPieces
{
    public abstract class ChessPiece
    {
        public PieceColor Color { get; set; }

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

        [ExcludeFromCodeCoverage]
        public Image ImageSmall { get; protected set; }

        public abstract void CheckPossibilitiesForProvidedLocationAndMarkThem(IChessboard chessBoard, Position position);
    }
}

