using System.Drawing;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Common.Interfaces
{
    public interface IChessboard
    {
        Box this[Point point] { get; }
        Box this[int row, int column] { get; }
        Point PositionWhiteKing { get; set; }
        Point PositionBlackKing { get; set; }
        bool BeginnersMode { get; set; }
        void ResetChessBoardBoxesColors();
        void SetChessBoardBoxesAsUnavailable();
        bool IsCheckmateForProvidedColor(PieceColor providedColor);
        bool MoveTriggersCheck(Point origin, Point destination);
        bool PieceIsThreatened(Point location);
    }
}
