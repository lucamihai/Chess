using System;
using System.Diagnostics.CodeAnalysis;

namespace ChessApplication.Common
{
    public struct Position : IEquatable<Position>
    {
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; set; }
        public int Column { get; set; }

        public bool IsOutOfBounds()
        {
            return Row > 8
                   || Row < 1
                   || Column > 8
                   || Column < 1;
        }

        [ExcludeFromCodeCoverage]
        public bool Equals(Position other)
        {
            return Row == other.Row && Column == other.Column;
        }

        [ExcludeFromCodeCoverage]
        public override bool Equals(object obj)
        {
            return obj is Position other && Equals(other);
        }

        [ExcludeFromCodeCoverage]
        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Column;
            }
        }
    }
}