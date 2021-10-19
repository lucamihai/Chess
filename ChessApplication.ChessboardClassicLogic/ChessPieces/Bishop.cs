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
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForSouthWest(chessBoard, position);
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForNorthEast(chessBoard, position);
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForNorthWest(chessBoard, position);
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForSouthEast(chessBoard, position);
        }
    }
}
