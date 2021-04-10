using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;

namespace ChessApplication.Common
{
    [ExcludeFromCodeCoverage]
    public class Box
    {
        public bool Available { get; set; }

        public ChessPiece Piece { get; set; }

        // TODO: Maybe extract this to BoxUserControl
        public bool HighlightAvailableMove { get; set; } = true;

        public Position Position { get; set; }

        public Box(Position position, ChessPiece chessPiece = null)
        {
            Position = position;
            Piece = chessPiece;
        }
    }
}