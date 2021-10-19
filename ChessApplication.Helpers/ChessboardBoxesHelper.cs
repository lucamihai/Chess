using System.Collections.Generic;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Helpers
{
    public static class ChessboardBoxesHelper
    {
        public static List<Box> GetBoxesThatHavePieces(IChessboard chessboard, PieceColor pieceColor = PieceColor.Undefined)
        {
            var boxes = new List<Box>();

            for (var row = 1; row < 9; row++)
            {
                for (var column = 1; column < 9; column++)
                {
                    var currentBox = chessboard[row, column];

                    if (currentBox.Piece != null && PieceHasDesiredColor(currentBox.Piece, pieceColor))
                    {
                        boxes.Add(currentBox);
                    }
                }
            }

            return boxes;
        }

        public static List<Box> GetAvailableBoxes(IChessboard chessboard)
        {
            var boxes = new List<Box>();

            for (var row = 1; row < 9; row++)
            {
                for (var column = 1; column < 9; column++)
                {
                    var currentBox = chessboard[row, column];

                    if (currentBox.Available)
                    {
                        boxes.Add(currentBox);
                    }
                }
            }

            return boxes;
        }

        private static bool PieceHasDesiredColor(ChessPiece chessPiece, PieceColor desiredColor)
        {
            return desiredColor == PieceColor.Undefined
                   || chessPiece.Color == desiredColor;
        }
    }
}