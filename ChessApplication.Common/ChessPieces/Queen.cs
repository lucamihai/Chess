using System.Drawing;
using ChessApplication.Common.ChessPieces.Helpers;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Common.ChessPieces
{
    public class Queen : ChessPiece
    {
        public Queen(PieceColor pieceColor)
        {
            Color = pieceColor;
            Image = pieceColor == PieceColor.White ? Properties.Resources.WhiteQueen : Properties.Resources.BlackQueen;
        }

        public override string Abbreviation
        {
            get
            {
                var abbreviation = string.Empty;
                abbreviation += Abbreviations.Queen;
                abbreviation += Color == PieceColor.White ? Abbreviations.White : Abbreviations.Black;

                return abbreviation;
            }
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(IChessboard chessBoard, Point location)
        {
            AccessibleBoxesUtil.MarkAccessibleBoxesForWest(chessBoard, location);
            AccessibleBoxesUtil.MarkAccessibleBoxesForEast(chessBoard, location);
            AccessibleBoxesUtil.MarkAccessibleBoxesForSouth(chessBoard, location);
            AccessibleBoxesUtil.MarkAccessibleBoxesForNorth(chessBoard, location);

            AccessibleBoxesUtil.MarkAccessibleBoxesForSouthWest(chessBoard, location);
            AccessibleBoxesUtil.MarkAccessibleBoxesForNorthEast(chessBoard, location);
            AccessibleBoxesUtil.MarkAccessibleBoxesForNorthWest(chessBoard, location);
            AccessibleBoxesUtil.MarkAccessibleBoxesForSouthEast(chessBoard, location);
        }
    }
}
