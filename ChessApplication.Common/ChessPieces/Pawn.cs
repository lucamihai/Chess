using ChessApplication.Common.ChessPieces.Helpers;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Common.ChessPieces
{
    public class Pawn : ChessPiece
    {
        public Pawn(PieceColor pieceColor)
        {
            Color = pieceColor;
            Image = pieceColor == PieceColor.White ? Properties.Resources.WhitePawn : Properties.Resources.BlackPawn;
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(IChessboard chessBoard, Position position)
        {
            var row = position.Row;
            var column = position.Column;
            var startingRow = GetStartingRowForColor();
            var forwardOffset = GetForwardOffsetForColor();

            var positionForward = new Position(row + forwardOffset, column);
            var positionForwardWest = new Position(row + forwardOffset, column - 1);
            var positionForwardEast = new Position(row + forwardOffset, column + 1);
            var positionForwardForward = new Position(row + forwardOffset * 2, column);

            if (!positionForward.IsOutOfBounds() && chessBoard[positionForward].Piece == null)
            {
                AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, positionForward);
            }

            if (!positionForwardWest.IsOutOfBounds() && chessBoard[positionForwardWest].Piece != null)
            {
                AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, positionForwardWest);
            }

            if (!positionForwardEast.IsOutOfBounds() && chessBoard[positionForwardEast].Piece != null)
            {
                AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, positionForwardEast);
            }

            if (row == startingRow && !positionForwardForward.IsOutOfBounds() && chessBoard[positionForward].Piece == null && chessBoard[positionForwardForward].Piece == null)
            {
                AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, positionForwardForward);
            }
        }

        private int GetStartingRowForColor()
        {
            switch (Color)
            {
                case PieceColor.White:
                    return 2;
                case PieceColor.Black:
                    return 7;
                default:
                    return 100;
            }
        }

        private int GetForwardOffsetForColor()
        {
            switch (Color)
            {
                case PieceColor.White:
                    return 1;
                case PieceColor.Black:
                    return -1;
                default:
                    return 100;
            }
        }
    }
}
