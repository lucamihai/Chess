using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Helpers;

namespace ChessApplication.ChessboardClassicLogic.ChessPieces
{
    public class Queen : ChessPiece
    {
        public Queen()
        {
            Color = PieceColor.Undefined;
        }

        public Queen(PieceColor pieceColor)
        {
            Color = pieceColor;
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(IChessboard chessBoard, Position position)
        {
            AccessibleBoxesUtil.MarkAccessibleBoxesForWest(chessBoard, position);
            AccessibleBoxesUtil.MarkAccessibleBoxesForEast(chessBoard, position);
            AccessibleBoxesUtil.MarkAccessibleBoxesForSouth(chessBoard, position);
            AccessibleBoxesUtil.MarkAccessibleBoxesForNorth(chessBoard, position);

            AccessibleBoxesUtil.MarkAccessibleBoxesForSouthWest(chessBoard, position);
            AccessibleBoxesUtil.MarkAccessibleBoxesForNorthEast(chessBoard, position);
            AccessibleBoxesUtil.MarkAccessibleBoxesForNorthWest(chessBoard, position);
            AccessibleBoxesUtil.MarkAccessibleBoxesForSouthEast(chessBoard, position);
        }
    }
}
