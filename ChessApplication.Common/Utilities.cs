using ChessApplication.Common.ChessPieces;
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

        public static void RetakeCapturedPiece(CapturedPieceBox capturedPieceBox, Box destination)
        {
            var capturedPieceColor = capturedPieceBox.ChessPiece.Color;
            var retakingWasSuccessful = false;

            if (capturedPieceBox.ChessPiece is Rook)
            {
                destination.Piece = new Rook(capturedPieceColor);
                retakingWasSuccessful = true;
            }

            if (capturedPieceBox.ChessPiece is Knight)
            {
                destination.Piece = new Knight(capturedPieceColor);
                retakingWasSuccessful = true;
            }

            if (capturedPieceBox.ChessPiece is Bishop)
            {
                destination.Piece = new Bishop(capturedPieceColor);
                retakingWasSuccessful = true;
            }

            if (capturedPieceBox.ChessPiece is Queen)
            {
                destination.Piece = new Queen(capturedPieceColor);
                retakingWasSuccessful = true;
            }

            if (retakingWasSuccessful)
            {
                capturedPieceBox.Count--;
            }
        }
    }
}
