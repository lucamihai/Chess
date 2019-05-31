using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;

namespace UnitTestsUtilities
{
    [ExcludeFromCodeCoverage]
    public static class ChessboardProvider
    {
        public static ChessboardClassic GetChessboardWithNoPieces()
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

        public static ChessboardClassic GetChessboardFilledWithWhitePawns()
        {
            var chessboard = GetChessboardWithNoPieces();

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    chessboard[row, column].Piece = new Pawn(PieceColor.White);
                }
            }

            return chessboard;
        }

        public static ChessboardClassic GetChessboardFilledWithBlackPawns()
        {
            var chessboard = GetChessboardWithNoPieces();

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    chessboard[row, column].Piece = new Pawn(PieceColor.Black);
                }
            }

            return chessboard;
        }

        public static ChessboardClassic GetChessboardWithProvidedColorInCheckmate(PieceColor providedColor)
        {
            var chessboard = GetChessboardWithNoPieces();
            var opponentColor = providedColor == PieceColor.White ? PieceColor.Black : PieceColor.White;

            var kingPosition = new Point(1, 1);
            var opponentQueenPosition = new Point(kingPosition.X, kingPosition.Y + 1);
            var opponentBishopPosition = new Point(kingPosition.X + 1, kingPosition.Y);

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
