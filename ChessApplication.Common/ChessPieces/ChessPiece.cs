using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Common.ChessPieces
{
    public abstract class ChessPiece
    {
        public PieceColor Color { get; set; }

        public bool CanMove { get; set; } = false;

        public abstract void CheckPossibilitiesForProvidedLocationAndMarkThem(IChessboard chessBoard, Position position);
    }
}

