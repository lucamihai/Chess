using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace UnitTestsUtilities
{
    public static class ChessboardProvider
    {
        public static Box[,] GetChessboardInitialState()
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

            AddWhitePieces(chessboard);
            AddBlackPieces(chessboard);

            return chessboard;
        }

        public static Point GetWhiteKingPositionForChessboardInitialState()
        {
            return new Point(1, 5);
        }

        public static Point GetBlackKingPositionForChessboardInitialState()
        {
            return new Point(8, 4);
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

        private static void AddWhitePieces(Box[,] ChessBoard)
        {
            ChessBoard[1, 1].Piece = new Rook(PieceColor.White);
            ChessBoard[1, 2].Piece = new Knight(PieceColor.White);
            ChessBoard[1, 3].Piece = new Bishop(PieceColor.White);
            ChessBoard[1, 4].Piece = new Queen(PieceColor.White);
            ChessBoard[1, 5].Piece = new King(PieceColor.White);
            ChessBoard[1, 6].Piece = new Bishop(PieceColor.White);
            ChessBoard[1, 7].Piece = new Knight(PieceColor.White);
            ChessBoard[1, 8].Piece = new Rook(PieceColor.White);

            for (int column = 1; column < 9; column++)
            {
                ChessBoard[2, column].Piece = new Pawn(PieceColor.White);
            }
        }

        private static void AddBlackPieces(Box[,] ChessBoard)
        {
            ChessBoard[8, 1].Piece = new Rook(PieceColor.Black);
            ChessBoard[8, 2].Piece = new Knight(PieceColor.Black);
            ChessBoard[8, 3].Piece = new Bishop(PieceColor.Black);
            ChessBoard[8, 4].Piece = new King(PieceColor.Black);
            ChessBoard[8, 5].Piece = new Queen(PieceColor.Black);
            ChessBoard[8, 6].Piece = new Bishop(PieceColor.Black);
            ChessBoard[8, 7].Piece = new Knight(PieceColor.Black);
            ChessBoard[8, 8].Piece = new Rook(PieceColor.Black);

            for (int column = 1; column < 9; column++)
            {
                ChessBoard[7, column].Piece = new Pawn(PieceColor.Black);
            }
        }
    }
}
