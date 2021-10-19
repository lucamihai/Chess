using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Helpers;

namespace ChessApplication.ChessboardClassicLogic.ChessPieces
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
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForWest(chessBoard, position);
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForEast(chessBoard, position);
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForSouth(chessBoard, position);
            ChessboardAccessibleBoxesHelper.MarkAccessibleBoxesForNorth(chessBoard, position);
        }
    }
}
