using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Tests.Utilities
{
    [ExcludeFromCodeCoverage]
    public static class Methods
    {
        public static int GetNumberOfAvailableBoxes(IChessboard boxes)
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

        public static void SurroundBoxWithPawns(PieceColor pawnColor, Position piecePosition, IChessboard chessBoard)
        {
            var pawnPositionWest = new Position(piecePosition.Row, piecePosition.Column - 1);
            var pawnPositionNorthWest = new Position(piecePosition.Row + 1, piecePosition.Column - 1);
            var blackPawnPositionNorth = new Position(piecePosition.Row + 1, piecePosition.Column);
            var blackPawnPositionNorthEast = new Position(piecePosition.Row + 1, piecePosition.Column + 1);
            var blackPawnPositionEast = new Position(piecePosition.Row, piecePosition.Column + 1);
            var blackPawnPositionSouthEast = new Position(piecePosition.Row - 1, piecePosition.Column + 1);
            var blackPawnPositionSouth = new Position(piecePosition.Row - 1, piecePosition.Column);
            var blackPawnPositionSouthWest = new Position(piecePosition.Row - 1, piecePosition.Column - 1);

            chessBoard[pawnPositionWest.Row, pawnPositionWest.Column].Piece = new Pawn(pawnColor);
            chessBoard[pawnPositionNorthWest.Row, pawnPositionNorthWest.Column].Piece = new Pawn(pawnColor);
            chessBoard[blackPawnPositionNorth.Row, blackPawnPositionNorth.Column].Piece = new Pawn(pawnColor);
            chessBoard[blackPawnPositionNorthEast.Row, blackPawnPositionNorthEast.Column].Piece = new Pawn(pawnColor);
            chessBoard[blackPawnPositionEast.Row, blackPawnPositionEast.Column].Piece = new Pawn(pawnColor);
            chessBoard[blackPawnPositionSouthEast.Row, blackPawnPositionSouthEast.Column].Piece = new Pawn(pawnColor);
            chessBoard[blackPawnPositionSouth.Row, blackPawnPositionSouth.Column].Piece = new Pawn(pawnColor);
            chessBoard[blackPawnPositionSouthWest.Row, blackPawnPositionSouthWest.Column].Piece = new Pawn(pawnColor);
        }
    }
}
