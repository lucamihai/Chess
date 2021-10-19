using System;
using ChessApplication.Common;
using ChessApplication.Common.Enums;

namespace ChessApplication.ChessboardClassicLogic.ChessPieces
{
    public static class ChessPieceProvider
    {
        public static ChessPiece GetChessPiece(Type chessPieceType, PieceColor pieceColor)
        {
            switch (chessPieceType.Name)
            {
                case nameof(Pawn):
                {
                    return new Pawn(pieceColor);
                }

                case nameof(Rook):
                {
                    return new Rook(pieceColor);
                }

                case nameof(Knight):
                {
                    return new Knight(pieceColor);
                }

                case nameof(Bishop):
                {
                    return new Bishop(pieceColor);
                }

                case nameof(Queen):
                {
                    return new Queen(pieceColor);
                }

                default:
                {
                    throw new InvalidOperationException($"Type {chessPieceType.Name} is not supported");
                }
            }
        }
    }
}