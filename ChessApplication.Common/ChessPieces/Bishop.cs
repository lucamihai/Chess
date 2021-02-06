using ChessApplication.Common.ChessPieces.Helpers;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Common.ChessPieces
{
    public class Bishop : ChessPiece
    {
        public Bishop(PieceColor pieceColor)
        {
            Color = pieceColor;
            Image = Color == PieceColor.White ? Properties.Resources.WhiteBishop : Properties.Resources.BlackBishop;
        }

        public override string Abbreviation
        {
            get
            {
                var abbreviation = string.Empty;
                abbreviation += Abbreviations.Bishop;
                abbreviation += Color == PieceColor.White ? Abbreviations.White : Abbreviations.Black;

                return abbreviation;
            }
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(IChessboard chessBoard, Position position)
        {
            AccessibleBoxesUtil.MarkAccessibleBoxesForSouthWest(chessBoard, position);
            AccessibleBoxesUtil.MarkAccessibleBoxesForNorthEast(chessBoard, position);
            AccessibleBoxesUtil.MarkAccessibleBoxesForNorthWest(chessBoard, position);
            AccessibleBoxesUtil.MarkAccessibleBoxesForSouthEast(chessBoard, position);
        }
    }
}
