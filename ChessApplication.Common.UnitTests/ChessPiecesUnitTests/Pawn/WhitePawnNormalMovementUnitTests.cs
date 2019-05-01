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
            var pawnPosition = new Point(2, 1);

            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            var positionToBeTested = new Point(3, 1);
            Assert.IsTrue(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhitePawnCanMove2BoxesForwardIfIsInInitialPosition()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnPosition = new Point(2, 1);

            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            var positionToBeTested = new Point(4, 1);
            Assert.IsTrue(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhitePawnHas2AvailableMovesForInitialPosition()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnPosition = new Point(2, 1);

            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            var availableMoves = UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(2, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMoveIfThereIsAWhitePieceInFrontOfIt()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnPosition = new Point(2, 1);

            ChessBoard[pawnPosition.X + 1, pawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            var availableMoves = UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMoveIfThereIsABlackPieceInFrontOfIt()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnPosition = new Point(2, 1);

            ChessBoard[pawnPosition.X + 1, pawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            var availableMoves = UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfThatLocationIsOccupiedByAWhitePiece()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnPosition = new Point(2, 1);
            var positionToBeTested = new Point(4, 1);

            ChessBoard[positionToBeTested.X, positionToBeTested.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            Assert.IsFalse(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfThatLocationIsOccupiedByABlackPiece()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnPosition = new Point(2, 1);
            var positionToBeTested = new Point(4, 1);

            ChessBoard[positionToBeTested.X, positionToBeTested.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            Assert.IsFalse(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

    }
}
