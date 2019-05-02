using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace UnitTestsUtilities
{
    [ExcludeFromCodeCoverage]
    public static class ChessboardProvider
    {
        public static Box[,] GetChessboardWithNoPieces()
        {
            var chessboard = new Box[10, 10];

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    var boxName = GenerateBoxNameBasedOnRowAndColumn(row, column);
                    var boxLocation = GenerateBoxLocationBasedOnRowAndColumn(row, column);

                    chessboard[row, column] = new Box(boxName);
                    chessboard[row, column].Location = boxLocation;
                }
            }

            return chessboard;
        }

        public static Box[,] GetChessboardFilledWithWhitePawns()
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

        public static Box[,] GetChessboardFilledWithBlackPawns()
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

        private static string GenerateBoxNameBasedOnRowAndColumn(int row, int column)
        {
            char rowLetter = (char)('A' + row - 1);
            return $"{rowLetter}{column}";
        }

        private static Point GenerateBoxLocationBasedOnRowAndColumn(int row, int column)
        {
            return new Point
            {
                X = (column - 1) * 64,
                Y = (8 - row) * 64
            };
        }

    }
}
