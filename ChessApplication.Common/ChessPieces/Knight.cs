using System.Drawing;
using ChessApplication.Common.ChessPieces.Helpers;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Common.ChessPieces
{
    public class Knight : ChessPiece
    {
        public Knight(PieceColor pieceColor)
        {
            Color = pieceColor;
            Image = pieceColor == PieceColor.White ? Properties.Resources.WhiteKnight : Properties.Resources.BlackKnight;
        }

        public override string Abbreviation
        {
            get
            {
                var abbreviation = string.Empty;
                abbreviation += Abbreviations.Knight;
                abbreviation += Color == PieceColor.White ? Abbreviations.White : Abbreviations.Black;

                return abbreviation;
            }
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(IChessboard chessBoard, Point location)
        {
            var row = location.X;
            var column = location.Y;

            var destinationNorthNorthEast = new Point(row + 1, column + 2);
            var destinationSouthSouthEast = new Point(row + 1, column - 2);
            var destinationNorthEastEast = new Point(row + 2, column + 1);
            var destinationSouthEastEast = new Point(row + 2, column - 1);

            var destinationNorthNorthWest = new Point(row - 1, column + 2);
            var destinationSouthSouthWest = new Point(row - 1, column - 2);
            var destinationNorthWestWest = new Point(row - 2, column + 1);
            var destinationSouthWestWest = new Point(row - 2, column -1);

            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, location, destinationNorthNorthEast);
            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, location, destinationSouthSouthEast);
            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, location, destinationNorthEastEast);
            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, location, destinationSouthEastEast);

            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, location, destinationNorthNorthWest);
            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, location, destinationSouthSouthWest);
            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, location, destinationNorthWestWest);
            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, location, destinationSouthWestWest);
        }
    }
}
