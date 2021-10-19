using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Helpers;

namespace ChessApplication.ChessboardClassicLogic.AI
{
    public class RandomMovesAIPlayer : IAIPlayer
    {
        private readonly Random rng;
        private const int BaseWaitTimeInMilliseconds = 500;

        public PieceColor Turn { get; set; }

        public RandomMovesAIPlayer()
        {
            rng = new Random();
        }

        public AIResponse PerformMove(IChessboard chessboard)
        {
            if (chessboard.CurrentTurn != Turn)
            {
                return AIResponse.NotAIsTurn;
            }

            Thread.Sleep(BaseWaitTimeInMilliseconds);

            var statusAfterRegularMove = HandleRegularMove(chessboard);

            if (chessboard.RetakingIsActive)
            {
                var statusAfterRetaking = HandleRetaking(chessboard);

                return statusAfterRetaking;
            }

            return statusAfterRegularMove;
        }

        private AIResponse HandleRegularMove(IChessboard chessboard)
        {
            var boxesWithPieces = ChessboardBoxesHelper.GetBoxesThatHavePieces(chessboard, Turn);

            if (boxesWithPieces.Count == 0)
            {
                return AIResponse.NoPiecesLeft;
            }

            var allAvailableMoves = new List<Tuple<Box, Box>>();

            foreach (var boxWithPiece in boxesWithPieces)
            {
                var availableMoves = GetAvailableMovesFromBox(chessboard, boxWithPiece);
                allAvailableMoves.AddRange(availableMoves);
            }

            if (allAvailableMoves.Count == 0)
            {
                return AIResponse.NoMovesLeft;
            }

            var move = ChooseMove(allAvailableMoves);
            chessboard.Move(move.Item1.Position, move.Item2.Position);

            return AIResponse.SuccessfulMove;
        }

        private AIResponse HandleRetaking(IChessboard chessboard)
        {
            var canRetakePieces = chessboard.CapturedPieceCollection.GetCountTotalCapturedPieces(Turn, typeof(Pawn)) > 0;

            if (!canRetakePieces)
            {
                return AIResponse.SuccessfulMove;
            }

            var capturedTypes = chessboard.CapturedPieceCollection.GetIndividualCountsForCapturedPieces(Turn, typeof(Pawn))
                .Where(x => x.Value > 0)
                .ToList();

            var choice = rng.Next(0, capturedTypes.Count);
            var pieceType = capturedTypes[choice].Key;
            var pieceToRetake = ChessPieceProvider.GetChessPiece(pieceType, Turn);

            chessboard.RetakePiece(chessboard.RetakingPosition, pieceToRetake);

            return AIResponse.SuccessfulMove;
        }

        private Tuple<Box, Box> ChooseMove(List<Tuple<Box, Box>> moves)
        {
            var randomIndex = rng.Next(0, moves.Count - 1);

            return moves[randomIndex];
        }

        private static List<Tuple<Box, Box>> GetAvailableMovesFromBox(IChessboard chessboard, Box origin)
        {
            var moves = new List<Tuple<Box, Box>>();

            origin.Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, origin.Position);

            var availableBoxes = ChessboardBoxesHelper.GetAvailableBoxes(chessboard);

            foreach (var availableBox in availableBoxes)
            {
                moves.Add(new Tuple<Box, Box>(origin, availableBox));
            }

            chessboard.SetChessboardBoxesAsUnavailable();

            return moves;
        }
    }
}