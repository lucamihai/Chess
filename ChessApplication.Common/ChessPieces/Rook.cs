using ChessApplication.Common.Enums;
using ChessApplication.Common.Helpers;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Common.ChessPieces
{
    public class Rook : ChessPiece
    {
        public Rook()
        {
            Color = PieceColor.Undefined;
        }

        public Rook(PieceColor pieceColor)
        {
            Color = pieceColor;
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(IChessboard chessBoard, Position position)
        {
            AccessibleBoxesUtil.MarkAccessibleBoxesForWest(chessBoard, position);
            AccessibleBoxesUtil.MarkAccessibleBoxesForEast(chessBoard, position);
            AccessibleBoxesUtil.MarkAccessibleBoxesForSouth(chessBoard, position);
            AccessibleBoxesUtil.MarkAccessibleBoxesForNorth(chessBoard, position);
        }
    }
}
