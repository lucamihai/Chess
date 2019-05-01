using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.Pawn
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackPawnNormalMovementUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = new Box[10, 10];
        }

        [TestMethod]
        public void BlackPawnCanMove1BoxForwardIfIsInInitialPosition()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnPosition = new Point(7, 1);

            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            var locationToBeTested = new Point(6, 1);
            Assert.IsTrue(ChessBoard[locationToBeTested.X, locationToBeTested.Y].Available);
        }

        [TestMethod]
        public void BlackPawnCanMove2BoxesForwardIfIsInInitialPosition()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnPosition = new Point(7, 1);

            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            var locationToBeTested = new Point(5, 1);
            Assert.IsTrue(ChessBoard[locationToBeTested.X, locationToBeTested.Y].Available);
        }

        [TestMethod]
        public void BlackPawnHas2AvailableMovesForInitialPosition()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnPosition = new Point(7, 1);

            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            var availableMoves = UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(2, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMoveIfThereIsAWhitePieceInFrontOfIt()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnPosition = new Point(7, 1);

            ChessBoard[pawnPosition.X - 1, pawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            var availableMoves = UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMoveIfThereIsABlackPieceInFrontOfIt()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnPosition = new Point(7, 1);

            ChessBoard[pawnPosition.X - 1, pawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            var availableMoves = UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfThatLocationIsOccupiedByAWhitePiece()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnPosition = new Point(7, 1);
            var positionToBeTested = new Point(5, 1);

            ChessBoard[positionToBeTested.X, positionToBeTested.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            Assert.IsFalse(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfThatLocationIsOccupiedByABlackPiece()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var pawnPosition = new Point(7, 1);
            var positionToBeTested = new Point(5, 1);

            ChessBoard[positionToBeTested.X, positionToBeTested.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[pawnPosition.X, pawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, pawnPosition, whiteKingPosition);

            Assert.IsFalse(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }
    }
}
