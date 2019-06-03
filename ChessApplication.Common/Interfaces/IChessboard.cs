using System.Drawing;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;

namespace ChessApplication.Common.Interfaces
{
    public interface IChessboard
    {
        Point PositionLowerLimit { get; }
        Point PositionHigherLimit { get; }
        Box this[Point point] { get; }
        Box this[int row, int column] { get; }
        Point PositionWhiteKing { get; set; }
        Point PositionBlackKing { get; set; }
        bool BeginnersMode { get; set; }
        bool IsCheckmateForProvidedColor(PieceColor providedColor);
        bool MoveTriggersCheck(Point origin, Point destination);
        bool PieceIsThreatened(Point location);
    }
}
