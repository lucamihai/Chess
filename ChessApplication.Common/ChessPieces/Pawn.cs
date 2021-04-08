using ChessApplication.Common.ChessPieces.Helpers;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Common.ChessPieces
{
    public class Pawn : ChessPiece
    {
        public Pawn()
        {
            Color = PieceColor.Undefined;
        }

        public Pawn(PieceColor pieceColor)
        {
            Color = pieceColor;
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(IChessboard chessBoard, Position position)
        {
            var row = position.Row;
            var column = position.Column;
            var startingRow = GetStartingRow();
            var forwardOffset = GetForwardOffset();

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

        private int GetStartingRow()
        {
            return Color == PieceColor.White
                ? 2
                : 7;
        }

        private int GetForwardOffset()
        {
            return Color == PieceColor.White
                ? 1
                : -1;
        }
    }
}
