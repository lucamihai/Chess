namespace ChessApplication.Common
{
    public class CapturedPieceBox
    {
        public CapturedPieceBox(ChessPiece chessPiece)
        {
            ChessPiece = chessPiece;
        }

        public ChessPiece ChessPiece { get; set; }
        public int Count { get; set; }
    }
}