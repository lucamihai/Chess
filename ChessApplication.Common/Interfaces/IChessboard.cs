using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Common.Interfaces
{
    public interface IChessboard
    {
        Box this[Position point] { get; }
        Box this[int row, int column] { get; }
        Position PositionWhiteKing { get; set; }
        Position PositionBlackKing { get; set; }
        bool BeginnersMode { get; set; }
        void ResetChessBoardBoxesColors();
        void SetChessBoardBoxesAsUnavailable();
        bool IsCheckmateForProvidedColor(PieceColor providedColor);
        bool MoveTriggersCheck(Position origin, Position destination);
        bool PieceIsThreatened(Position location);
    }
}
