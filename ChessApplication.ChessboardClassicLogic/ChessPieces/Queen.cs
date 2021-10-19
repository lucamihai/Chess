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
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForWest(chessBoard, position);
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForEast(chessBoard, position);
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForSouth(chessBoard, position);
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForNorth(chessBoard, position);

            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForSouthWest(chessBoard, position);
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForNorthEast(chessBoard, position);
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForNorthWest(chessBoard, position);
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForSouthEast(chessBoard, position);
        }
    }
}
