using System.Drawing;
using ChessApplication.Common.ChessPieces.Helpers;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Common.ChessPieces
{
    public class Rook : ChessPiece
    {
        public Rook(PieceColor pieceColor)
        {
            Color = pieceColor;
            Image = pieceColor == PieceColor.White ? Properties.Resources.WhiteRook : Properties.Resources.BlackRook;
        }

        public override string Abbreviation
        {
            get
            {
                var abbreviation = string.Empty;
                abbreviation += Abbreviations.Rook;
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
        }
    }
}
