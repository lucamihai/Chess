using System;
using System.Collections.Generic;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Common.UserControls;

namespace ChessApplication.AI
{
    public static class DecisionMaker
    {
        public static Box ChooseOrigin(IChessboard chessboard, Turn AITurn)
        {
            var AIOpponentPieceColor = (PieceColor)AITurn;
            var boxes = chessboard.GetAllBoxesContainingPiecesOfColor(AIOpponentPieceColor);

            var boxesWithPieceThatHaveAvailableMoves = new List<Box>();
            foreach (var box in boxes)
            {
                box.Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, box.Position);
                var possibleMoves = chessboard.GetAvailableBoxes();

                if (possibleMoves.Count > 0)
                    boxesWithPieceThatHaveAvailableMoves.Add(box);

                chessboard.ResetChessBoardBoxesColors();
                chessboard.SetChessBoardBoxesAsUnavailable();
            }

            if (boxesWithPieceThatHaveAvailableMoves.Count == 0)
            {
                throw new InvalidOperationException($"There are no pieces with available moves for Turn = {AITurn}");
            }

            var originIndex = new Random().Next(0, boxesWithPieceThatHaveAvailableMoves.Count - 1);

            return boxesWithPieceThatHaveAvailableMoves[originIndex];
        }

        public static Box ChooseDestination(IChessboard chessboard, Box origin)
        {
            if (origin.Piece == null)
            {
                throw new InvalidOperationException($"{nameof(origin)} must have a {nameof(origin.Piece)}");
            }

            origin.Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, origin.Position);

            var possibleDestinations = chessboard.GetAvailableBoxes();

            if (possibleDestinations.Count == 0)
            {
                throw new InvalidOperationException($"{nameof(origin)} must have at least 1 possible move");
            }

            var destinationIndex = new Random().Next(0, possibleDestinations.Count - 1);

            chessboard.ResetChessBoardBoxesColors();
            chessboard.SetChessBoardBoxesAsUnavailable();

            return possibleDestinations[destinationIndex];
        }
    }
}
