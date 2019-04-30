using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.Pawn
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhitePawnNormalMovementUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = new Box[10, 10];
        }

        [TestMethod]
        public void WhitePawnCanMove1BoxForwardIfIsInInitialPosition()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnLocation = new Point(2, 1);

            ChessBoard[pawnLocation.X, pawnLocation.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnLocation, whiteKingPosition);

            var locationToBeTested = new Point(3, 1);
            Assert.IsTrue(ChessBoard[locationToBeTested.X, locationToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhitePawnCanMove2BoxesForwardIfIsInInitialPosition()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnLocation = new Point(2, 1);

            ChessBoard[pawnLocation.X, pawnLocation.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnLocation, whiteKingPosition);

            var locationToBeTested = new Point(4, 1);
            Assert.IsTrue(ChessBoard[locationToBeTested.X, locationToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhitePawnHas2AvailableMovesForInitialPosition()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnLocation = new Point(2, 1);

            ChessBoard[pawnLocation.X, pawnLocation.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnLocation, whiteKingPosition);

            var availableMoves = UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(2, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMoveIfThereIsAWhitePieceInFrontOfIt()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnLocation = new Point(2, 1);

            ChessBoard[pawnLocation.X + 1, pawnLocation.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[pawnLocation.X, pawnLocation.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnLocation, whiteKingPosition);

            var availableMoves = UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMoveIfThereIsABlackPieceInFrontOfIt()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnLocation = new Point(2, 1);

            ChessBoard[pawnLocation.X + 1, pawnLocation.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[pawnLocation.X, pawnLocation.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnLocation, whiteKingPosition);

            var availableMoves = UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfThatLocationIsOccupiedByAWhitePiece()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnLocation = new Point(2, 1);
            var locationToBeTested = new Point(4, 1);

            ChessBoard[locationToBeTested.X, locationToBeTested.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[pawnLocation.X, pawnLocation.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnLocation, whiteKingPosition);

            Assert.IsFalse(ChessBoard[locationToBeTested.X, locationToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfThatLocationIsOccupiedByABlackPiece()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnLocation = new Point(2, 1);
            var locationToBeTested = new Point(4, 1);

            ChessBoard[locationToBeTested.X, locationToBeTested.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[pawnLocation.X, pawnLocation.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnLocation, whiteKingPosition);

            Assert.IsFalse(ChessBoard[locationToBeTested.X, locationToBeTested.Y].Available);
        }

    }
}
