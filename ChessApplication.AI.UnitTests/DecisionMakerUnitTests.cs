using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.AI.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DecisionMakerUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ChooseOriginThrowsInvalidOperationExceptionIfThereAreNoPiecesWithAvailableMoves()
        {
            var chessboard = ChessboardProvider.GetChessboardClassicWithProvidedColorInCheckmate(PieceColor.White);
            var origin = DecisionMaker.ChooseOrigin(chessboard, Turn.White);
        }

        [TestMethod]
        public void ChooseOriginReturnsBoxThatBelongsToChessboard()
        {
            var chessboard = new ChessboardClassic();
            var origin = DecisionMaker.ChooseOrigin(chessboard, Turn.White);

            Assert.AreEqual(chessboard[origin.Position], origin);
        }

        [TestMethod]
        public void ChooseOriginReturnsBoxWithPiece()
        {
            var chessboard = new ChessboardClassic();
            var origin = DecisionMaker.ChooseOrigin(chessboard, Turn.White);

            Assert.IsNotNull(origin.Piece);
        }

        [TestMethod]
        public void ChooseOriginReturnsBoxWithWhitePiece()
        {
            var chessboard = new ChessboardClassic();
            var origin = DecisionMaker.ChooseOrigin(chessboard, Turn.White);

            Assert.AreEqual(PieceColor.White, origin.Piece.Color);
        }

        [TestMethod]
        public void ChooseOriginReturnsBoxWithPieceThatHasAtLeast1PossibleMove()
        {
            var chessboard = new ChessboardClassic();
            var origin = DecisionMaker.ChooseOrigin(chessboard, Turn.White);

            origin.Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, origin.Position);
            var numberOfAvailableMoves = Methods.GetNumberOfAvailableBoxes(chessboard);

            Assert.IsTrue(numberOfAvailableMoves > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ChooseDestinationThrowsInvalidOperationExceptionForOriginWithoutAPiece()
        {
            var chessboard = new ChessboardClassic();
            var origin = chessboard[3, 3];
            var destination = DecisionMaker.ChooseDestination(chessboard, origin);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ChooseDestinationThrowsInvalidOperationExceptionForOriginWithPieceThatHasNoAvailableMove()
        {
            var chessboard = new ChessboardClassic();
            var rookBox = chessboard[1, 1];
            var destination = DecisionMaker.ChooseDestination(chessboard, rookBox);
        }

        [TestMethod]
        public void ChooseDestinationReturnsBoxThatBelongsToChessboard()
        {
            var chessboard = new ChessboardClassic();
            var pawnBox = chessboard[2, 1];
            var destination = DecisionMaker.ChooseDestination(chessboard, pawnBox);

            Assert.AreEqual(chessboard[destination.Position], destination);
        }

        [TestMethod]
        public void ChooseDestinationReturnsBoxThatIsReachableByOriginPiece()
        {
            var chessboard = new ChessboardClassic();
            var whitePawnPosition = new Point(2, 1);
            var destination = DecisionMaker.ChooseDestination(chessboard, chessboard[whitePawnPosition]);

            chessboard[whitePawnPosition].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);
            var reachableBoxes = Methods.GetAvailableBoxes(chessboard);

            Assert.IsTrue(reachableBoxes.Contains(destination));
        }
    }
}
