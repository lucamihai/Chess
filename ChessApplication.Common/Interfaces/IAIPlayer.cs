using ChessApplication.Common.Enums;

namespace ChessApplication.Common.Interfaces
{
    public interface IAIPlayer
    {
        PieceColor Turn { get; set; }
        AIResponse PerformMove(IChessboard chessboard);
    }
}