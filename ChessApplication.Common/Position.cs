namespace ChessApplication.Common
{
    public struct Position
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
    }
}