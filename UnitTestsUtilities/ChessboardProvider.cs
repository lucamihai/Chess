using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace UnitTestsUtilities
{
    [ExcludeFromCodeCoverage]
    public static class ChessboardProvider
    {
        public static Chessboard GetChessboardWithNoPieces()
        {
            var chessboard = new Chessboard();

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    chessboard[row, column].Piece = null;
                }
            }

            return chessboard;
        }

        public static Chessboard GetChessboardFilledWithWhitePawns()
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

        public static Chessboard GetChessboardFilledWithBlackPawns()
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

    }
}
