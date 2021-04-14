using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Helpers;

namespace ChessApplication.ChessboardClassicLogic.ChessPieces
{
    public class Bishop : ChessPiece
    {
        public Bishop()
        {
            Color = PieceColor.Undefined;
        }

        public Bishop(PieceColor pieceColor)
        {
            Color = pieceColor;
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
