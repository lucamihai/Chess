﻿using ChessApplication.Common.ChessPieces.Helpers;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Common.ChessPieces
{
    public class Rook : ChessPiece
    {
        public Rook(PieceColor pieceColor)
        {
            Color = pieceColor;
            Image = pieceColor == PieceColor.White ? Properties.Resources.WhiteRook : Properties.Resources.BlackRook;
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
