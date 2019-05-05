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
    public class WhitePawnCheckUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhitePawnCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(1, 1);
            var whitePawnPosition = new Point(2, 2);
            var blackQueenPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(1, 1);
            var whitePawnPosition = new Point(2, 1);
            var blackQueenPosition = new Point(5, 1);
            var blackPawnPosition = new Point(3, 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.IsFalse(ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Available);
        }

        [TestMethod]
        public void WhitePawnCantMove1BoxForwardIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(2, 2);
            var blackQueenPosition = new Point(2, 3);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(2, 2);
            var whitePawnPosition = new Point(2, 4);
            var blackQueenPosition = new Point(2, 3);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCantTakePiecesIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(8, 8);
            var blackQueenPosition = new Point(whiteKingPosition.X, whiteKingPosition.Y - 1);
            var whitePawnPosition = new Point(3, 3);
            var blackPawnPositionNorthWest = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y - 1);
            var blackPawnPositionNorthEast = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackPawnPositionNorthWest.X, blackPawnPositionNorthWest.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionNorthEast.X, blackPawnPositionNorthEast.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCanMove1BoxForwardIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(2, 2);
            var whitePawnPosition = new Point(3, 4);
            var blackQueenPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X + 1, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCanMove2BoxesForwardIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(2, 4);
            var blackQueenPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X + 2, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(2, 1);
            var blackQueenPosition = new Point(3, 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}