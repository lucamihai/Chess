using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ChessApplication.ChessboardClassicLogic.AI;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.AIUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class RandomMovesAIPlayerUnitTests
    {
        private IChessboard chessboard;
        private RandomMovesAIPlayer randomMovesAiPlayer;

        [TestInitialize]
        public void Setup()
        {
            chessboard = new ChessboardClassic();
            randomMovesAiPlayer = new RandomMovesAIPlayer();
        }

        [TestMethod]
        public void TestThatWhenAiTurnIsNotEqualToCurrentTurnPerformMoveReturnsExpectedResponse()
        {
            randomMovesAiPlayer.Turn = PieceColor.Black;

            var aiResponse = randomMovesAiPlayer.PerformMove(chessboard);

            Assert.AreEqual(AIResponse.NotAIsTurn, aiResponse);
        }

        [TestMethod]
        public void TestThatWhenAiPlayerIsInCheckmatePerformMoveReturnsExpectedResponse()
        {
            randomMovesAiPlayer.Turn = PieceColor.White;
            chessboard = ChessboardProvider.GetChessboardClassicWithProvidedColorInCheckmate(PieceColor.White);

            var aiResponse = randomMovesAiPlayer.PerformMove(chessboard);

            Assert.AreEqual(AIResponse.NoMovesLeft, aiResponse);
        }

        [TestMethod]
        public void TestThatWhenMoveIsAvailableForAiPerformMovePerformsExpectedMoveReturnsExpectedResult()
        {
            randomMovesAiPlayer.Turn = PieceColor.White;
            chessboard = ChessboardProvider.GetChessboardClassicSingleMoveAvailableForProvidedColor(PieceColor.White);

            var aiResponse = randomMovesAiPlayer.PerformMove(chessboard);

            var expectedMovePosition = new Position(8, 8);
            Assert.AreEqual(AIResponse.SuccessfulMove, aiResponse);
            Assert.IsNotNull(chessboard[expectedMovePosition].Piece);
            Assert.IsTrue(chessboard[expectedMovePosition].Piece is Pawn);
            Assert.IsTrue(chessboard[expectedMovePosition].Piece.Color == PieceColor.White);
        }

        [TestMethod]
        public void TestThatWhenAiPlayerCanRetakePiecePerformMoveRetakesPieceAndReturnsExpectedResponse()
        {
            randomMovesAiPlayer.Turn = PieceColor.White;
            chessboard = ChessboardProvider.GetChessboardClassicWithProvidedColorAboutToRetakePiece(PieceColor.White, new Rook(PieceColor.White));
            var retakenPiecesCountBeforeMove = chessboard.CapturedPieceCollection.GetEntryCount(new Rook(PieceColor.White));

            var aiResponse = randomMovesAiPlayer.PerformMove(chessboard);

            var retakenPiecesCountAfterMove = chessboard.CapturedPieceCollection.GetEntryCount(new Rook(PieceColor.White));
            var expectedRetakePosition = new Position(8, 8);
            Assert.AreEqual(AIResponse.SuccessfulMove, aiResponse);
            Assert.IsNotNull(chessboard[expectedRetakePosition].Piece);
            Assert.IsTrue(chessboard[expectedRetakePosition].Piece is Rook);
            Assert.IsTrue(chessboard[expectedRetakePosition].Piece.Color == PieceColor.White);
            Assert.AreEqual(retakenPiecesCountAfterMove, retakenPiecesCountBeforeMove - 1);
        }

        [TestMethod]
        public void TestThatTwoAiPlayersCanPlayAgainstEachOther()
        {
            randomMovesAiPlayer.Turn = PieceColor.White;
            chessboard = new ChessboardClassic();
            var secondAiPlayer = new RandomMovesAIPlayer { Turn = PieceColor.Black };
            var firstAiPlayerMoveResponses = new List<AIResponse>();
            var secondAiPlayerMoveResponses = new List<AIResponse>();

            for (var i = 0; i < 3; i++)
            {
                var firstPlayerResponse = randomMovesAiPlayer.PerformMove(chessboard);
                var secondPlayerResponse = secondAiPlayer.PerformMove(chessboard);

                firstAiPlayerMoveResponses.Add(firstPlayerResponse);
                secondAiPlayerMoveResponses.Add(secondPlayerResponse);
            }

            Assert.IsTrue(firstAiPlayerMoveResponses.All(x => x == AIResponse.SuccessfulMove));
            Assert.IsTrue(secondAiPlayerMoveResponses.All(x => x == AIResponse.SuccessfulMove));
            // TODO: Also test that not all pieces are in their original positions
        }
    }
}