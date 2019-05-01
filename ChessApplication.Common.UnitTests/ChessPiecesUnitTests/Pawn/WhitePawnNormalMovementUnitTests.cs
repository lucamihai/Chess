using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

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
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhitePawnCanMove1BoxForwardIfIsInInitialPosition()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            var positionToBeTested = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y);
            Assert.IsTrue(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhitePawnCanMove2BoxesForwardIfIsInInitialPosition()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            var positionToBeTested = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y);
            Assert.IsTrue(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhitePawnHas2AvailableMovesForInitialPosition()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            var availableMoves = UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(2, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMoveIfThereIsAWhitePieceInFrontOfIt()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPosition.X + 1, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            var availableMoves = UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMoveIfThereIsABlackPieceInFrontOfIt()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPosition.X + 1, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            var availableMoves = UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfThatLocationIsOccupiedByAWhitePiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);
            var positionToBeTested = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[positionToBeTested.X, positionToBeTested.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.IsFalse(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfThatLocationIsOccupiedByABlackPiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);
            var positionToBeTested = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[positionToBeTested.X, positionToBeTested.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.IsFalse(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

    }
}
