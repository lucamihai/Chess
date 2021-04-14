using ChessApplication.Common.Enums;

namespace ChessApplication.Common
{
    public static class Utilities
    { 
        public static bool LocationContainsPiece<TChessPiece>(Box location, PieceColor color = PieceColor.Undefined) where TChessPiece : ChessPiece
        {
            var piece = location?.Piece;

            if (piece is TChessPiece)
            {
                if (piece.Color == color || color == PieceColor.Undefined)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
