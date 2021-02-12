using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.Enums;

namespace ChessApplication.Common.ChessPieces.Helpers
{
    [ExcludeFromCodeCoverage]
    public static class ChessPieceInfoProvider
    {
        private static readonly Dictionary<string, Type> Types;

        static ChessPieceInfoProvider()
        {
            Types = new Dictionary<string, Type>
            {
                {nameof(Pawn), typeof(Pawn)},
                {nameof(Rook), typeof(Rook)},
                {nameof(Knight), typeof(Knight)},
                {nameof(Bishop), typeof(Bishop)},
                {nameof(Queen), typeof(Queen)},
                {nameof(King), typeof(King)},
            };
        }

        public static Type GetChessPieceTypeFromString(string typeName)
        {
            return Types.TryGetValue(typeName, out var type)
                ? type
                : typeof(ChessPiece);
        }

        public static PieceColor GetPieceColorFromString(string value)
        {
            return Enum.TryParse<PieceColor>(value, out var pieceColor)
                ? pieceColor
                : PieceColor.Undefined;
        }

        public static Turn GetColorFromString(string value)
        {
            return Enum.TryParse<Turn>(value, out var pieceColor)
                ? pieceColor
                : Turn.Undefined;
        }
    }
}