using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackPawnMovementUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackPawnCanMove1BoxForwardIfIsInInitialPosition()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            var locationToBeTested = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y);
            Assert.IsTrue(ChessBoard[locationToBeTested.X, locationToBeTested.Y].Available);
        }

        [TestMethod]
        public void BlackPawnCanMove2BoxesForwardIfIsInInitialPosition()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            var locationToBeTested = new Point(blackPawnPosition.X - 2, blackPawnPosition.Y);
            Assert.IsTrue(ChessBoard[locationToBeTested.X, locationToBeTested.Y].Available);
        }

        [TestMethod]
        public void BlackPawnHas2AvailableMovesForInitialPosition()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(2, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMoveIfThereIsAWhitePieceInFrontOfIt()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[blackPawnPosition.X - 1, blackPawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMoveIfThereIsABlackPieceInFrontOfIt()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[blackPawnPosition.X - 1, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfThatLocationIsOccupiedByAWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);
            var positionToBeTested = new Point(blackPawnPosition.X - 2, blackPawnPosition.Y);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[positionToBeTested.X, positionToBeTested.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfThatLocationIsOccupiedByABlackPiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);
            var positionToBeTested = new Point(blackPawnPosition.X - 2, blackPawnPosition.Y);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[positionToBeTested.X, positionToBeTested.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }
    }
}