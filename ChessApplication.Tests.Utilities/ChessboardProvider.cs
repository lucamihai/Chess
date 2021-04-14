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

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    chessboard[row, column].Piece = null;
                }
            }

            return chessboard;
        }

        public static ChessboardClassic GetChessboardClassicFilledWithWhitePawns()
        {
            var chessboard = GetChessboardClassicWithNoPieces();

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    chessboard[row, column].Piece = new Pawn(PieceColor.White);
                }
            }

            return chessboard;
        }

        public static ChessboardClassic GetChessboardClassicFilledWithBlackPawns()
        {
            var chessboard = GetChessboardClassicWithNoPieces();

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    chessboard[row, column].Piece = new Pawn(PieceColor.Black);
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

    }
}
