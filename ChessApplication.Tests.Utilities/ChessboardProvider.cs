using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;

namespace ChessApplication.Tests.Utilities
{
    [ExcludeFromCodeCoverage]
    public static class ChessboardProvider
    {
        public static ChessboardClassic GetChessboardClassicWithNoPieces()
        {
            var chessboard = new ChessboardClassic();

            for (var row = 1; row < 9; row++)
            {
                for (var column = 1; column < 9; column++)
                {
                    chessboard[row, column].Piece = null;
                }
            }

            return chessboard;
        }

        public static ChessboardClassic GetChessboardClassicFilledWithPawns(PieceColor pawnPieceColor)
        {
            var chessboard = GetChessboardClassicWithNoPieces();

            for (var row = 1; row < 9; row++)
            {
                for (var column = 1; column < 9; column++)
                {
                    chessboard[row, column].Piece = new Pawn(pawnPieceColor);
                }
            }

            return chessboard;
        }

        public static ChessboardClassic GetChessboardClassicWithProvidedColorInCheckmate(PieceColor providedColor)
        {
            var chessboard = GetChessboardClassicWithNoPieces();
            var opponentColor = providedColor == PieceColor.White ? PieceColor.Black : PieceColor.White;

            var kingPosition = new Position(1, 1);
            var opponentQueenPosition = new Position(kingPosition.Row, kingPosition.Column + 1);
            var opponentBishopPosition = new Position(kingPosition.Row + 1, kingPosition.Column);

            chessboard[kingPosition].Piece = new King(providedColor);
            chessboard[opponentQueenPosition].Piece = new Queen(opponentColor);
            chessboard[opponentBishopPosition].Piece = new Bishop(opponentColor);

            if (providedColor == PieceColor.White)
            {
                chessboard.PositionWhiteKing = kingPosition;
            }

            if (providedColor == PieceColor.Black)
            {
                chessboard.PositionBlackKing = kingPosition;
            }

            return chessboard;
        }

        public static ChessboardClassic GetChessboardClassicWithProvidedColorAboutToRetakePiece(PieceColor providedColor, params ChessPiece[] capturedPieces)
        {
            var chessboard = GetChessboardClassicWithNoPieces();
            var beforeLastRow = providedColor == PieceColor.White ? 7 : 2;
            var lastRow = providedColor == PieceColor.White ? 8 : 1;

            chessboard[beforeLastRow, 8].Piece = new Pawn(providedColor);

            chessboard[beforeLastRow, 1].Piece = new Pawn(providedColor);
            chessboard[beforeLastRow, 2].Piece = new Pawn(providedColor);
            chessboard[lastRow, 2].Piece = new Pawn(providedColor);

            var kingPosition = new Position(lastRow, 1);
            chessboard[kingPosition].Piece = new King(providedColor);

            if (providedColor == PieceColor.White)
            {
                chessboard.PositionWhiteKing = kingPosition;
            }

            if (providedColor == PieceColor.Black)
            {
                chessboard.PositionBlackKing = kingPosition;
            }

            foreach (var capturedPiece in capturedPieces)
            {
                chessboard.CapturedPieceCollection.AddEntry(capturedPiece);
            }

            return chessboard;
        }

        public static ChessboardClassic GetChessboardClassicSingleMoveAvailableForProvidedColor(PieceColor providedColor)
        {
            var chessboard = GetChessboardClassicWithNoPieces();
            var beforeLastRow = providedColor == PieceColor.White ? 7 : 2;
            var lastRow = providedColor == PieceColor.White ? 8 : 1;

            chessboard[beforeLastRow, 8].Piece = new Pawn(providedColor);

            chessboard[beforeLastRow, 1].Piece = new Pawn(providedColor);
            chessboard[beforeLastRow, 2].Piece = new Pawn(providedColor);
            chessboard[lastRow, 2].Piece = new Pawn(providedColor);

            var kingPosition = new Position(lastRow, 1);
            chessboard[kingPosition].Piece = new King(providedColor);

            if (providedColor == PieceColor.White)
            {
                chessboard.PositionWhiteKing = kingPosition;
            }

            if (providedColor == PieceColor.Black)
            {
                chessboard.PositionBlackKing = kingPosition;
            }

            return chessboard;
        }
    }
}
