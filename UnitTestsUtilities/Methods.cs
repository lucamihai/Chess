using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace UnitTestsUtilities
{
    [ExcludeFromCodeCoverage]
    public static class Methods
    {
        public static int GetNumberOfAvailableBoxes(Box[,] boxes)
        {
            int counter = 0;

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    if (boxes[row, column].Available)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        public static void SurroundBoxWithPawns(PieceColor pawnColor, Point pieceLocation, Box[,] chessBoard)
        {
            var pawnPositionWest = new Point(pieceLocation.X, pieceLocation.Y - 1);
            var pawnPositionNorthWest = new Point(pieceLocation.X + 1, pieceLocation.Y - 1);
            var blackPawnPositionNorth = new Point(pieceLocation.X + 1, pieceLocation.Y);
            var blackPawnPositionNorthEast = new Point(pieceLocation.X + 1, pieceLocation.Y + 1);
            var blackPawnPositionEast = new Point(pieceLocation.X, pieceLocation.Y + 1);
            var blackPawnPositionSouthEast = new Point(pieceLocation.X - 1, pieceLocation.Y + 1);
            var blackPawnPositionSouth = new Point(pieceLocation.X - 1, pieceLocation.Y);
            var blackPawnPositionSouthWest = new Point(pieceLocation.X - 1, pieceLocation.Y - 1);

            chessBoard[pawnPositionWest.X, pawnPositionWest.Y].Piece = new Pawn(pawnColor);
            chessBoard[pawnPositionNorthWest.X, pawnPositionNorthWest.Y].Piece = new Pawn(pawnColor);
            chessBoard[blackPawnPositionNorth.X, blackPawnPositionNorth.Y].Piece = new Pawn(pawnColor);
            chessBoard[blackPawnPositionNorthEast.X, blackPawnPositionNorthEast.Y].Piece = new Pawn(pawnColor);
            chessBoard[blackPawnPositionEast.X, blackPawnPositionEast.Y].Piece = new Pawn(pawnColor);
            chessBoard[blackPawnPositionSouthEast.X, blackPawnPositionSouthEast.Y].Piece = new Pawn(pawnColor);
            chessBoard[blackPawnPositionSouth.X, blackPawnPositionSouth.Y].Piece = new Pawn(pawnColor);
            chessBoard[blackPawnPositionSouthWest.X, blackPawnPositionSouthWest.Y].Piece = new Pawn(pawnColor);
        }
    }
}
