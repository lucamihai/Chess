﻿using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Helpers;

namespace ChessApplication.ChessboardClassicLogic.ChessPieces
{
    public class Knight : ChessPiece
    {
        public Knight()
        {
            Color = PieceColor.Undefined;
        }

        public Knight(PieceColor pieceColor)
        {
            Color = pieceColor;
        }

        public override void CheckPossibilitiesForProvidedLocationAndMarkThem(IChessboard chessBoard, Position position)
        {
            var row = position.Row;
            var column = position.Column;

            var destinationNorthNorthEast = new Position(row + 2, column + 1);
            var destinationSouthSouthEast = new Position(row - 2, column + 1);
            var destinationNorthEastEast = new Position(row + 1, column + 2);
            var destinationSouthEastEast = new Position(row - 1, column + 2);

            var destinationNorthNorthWest = new Position(row + 2, column - 1);
            var destinationSouthSouthWest = new Position(row - 2, column - 1);
            var destinationNorthWestWest = new Position(row + 1, column - 2);
            var destinationSouthWestWest = new Position(row - 1, column - 2);

            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, destinationNorthNorthEast);
            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, destinationSouthSouthEast);
            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, destinationNorthEastEast);
            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, destinationSouthEastEast);

            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, destinationNorthNorthWest);
            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, destinationSouthSouthWest);
            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, destinationNorthWestWest);
            AccessibleBoxesUtil.MarkIfAccessible(chessBoard, position, destinationSouthWestWest);
        }
    }
}
