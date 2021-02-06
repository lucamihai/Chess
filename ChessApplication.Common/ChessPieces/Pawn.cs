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

        public override string Abbreviation
        {
            get
            {
                var abbreviation = string.Empty;
                abbreviation += Abbreviations.Pawn;
                abbreviation += Color == PieceColor.White ? Abbreviations.White : Abbreviations.Black;

                return abbreviation;
            }
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(IChessboard chessBoard, Position position)
        {
            var row = position.Row;
            var column = position.Column;

            if (Color == PieceColor.White)
            {
                var positionNorth = new Position(row + 1, column);
                var positionNorthWest = new Position(row + 1, column - 1);
                var positionNorthEast = new Position(row + 1, column + 1);
                var positionNorthNorth = new Position(row + 2, column);

                if (!positionNorth.IsOutOfBounds() && chessBoard[positionNorth].Piece == null)
                {
                    AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, positionNorth);
                }

                if (!positionNorthWest.IsOutOfBounds() && chessBoard[positionNorthWest].Piece != null)
                {
                    AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, positionNorthWest);
                }

                if (!positionNorthEast.IsOutOfBounds() && chessBoard[positionNorthEast].Piece != null)
                {
                    AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, positionNorthEast);
                }

                if (row == 2 && !positionNorthNorth.IsOutOfBounds() && chessBoard[positionNorth].Piece == null && chessBoard[positionNorthNorth].Piece == null)
                {
                    AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, positionNorthNorth);
                }
            }

            if (Color == PieceColor.Black)
            {
                var positionSouth = new Position(row - 1, column);
                var positionSouthWest = new Position(row - 1, column - 1);
                var positionSouthEast = new Position(row - 1, column + 1);
                var positionSouthNorth = new Position(row - 2, column);

                if (!positionSouth.IsOutOfBounds() && chessBoard[positionSouth].Piece == null)
                {
                    AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, positionSouth);
                }

                if (!positionSouthWest.IsOutOfBounds() && chessBoard[positionSouthWest].Piece != null)
                {
                    AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, positionSouthWest);
                }

                if (!positionSouthEast.IsOutOfBounds() && chessBoard[positionSouthEast].Piece != null)
                {
                    AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, positionSouthEast);
                }

                if (row == 7 && !positionSouthNorth.IsOutOfBounds() && chessBoard[positionSouth].Piece == null && chessBoard[positionSouthNorth].Piece == null)
                {
                    AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, positionSouthNorth);
                }
            }
        }
    }
}
