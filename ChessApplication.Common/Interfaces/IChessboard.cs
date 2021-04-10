using System;
using ChessApplication.Common.Enums;

namespace ChessApplication.Common.Interfaces
{
    public interface IChessboard
    {
        Box this[Position position] { get; }
        Box this[int row, int column] { get; }
        Position PositionWhiteKing { get; set; }
        Position PositionBlackKing { get; set; }
        CapturedPieceCollection CapturedPieceCollection { get; set; }
        PieceColor CurrentTurn { get; }
        bool RetakingIsActive { get; }
        Position RetakingPosition { get; }
        void Move(Position origin, Position destination);
        void RetakePiece(Position position, Type pieceType, PieceColor pieceColor);
        void NewGame();
        void SetChessboardBoxesAsUnavailable();
        bool IsCheckmateForProvidedColor(PieceColor providedColor);
        bool MoveTriggersCheck(Position origin, Position destination);
        bool PieceIsThreatened(Position location);
    }
}
