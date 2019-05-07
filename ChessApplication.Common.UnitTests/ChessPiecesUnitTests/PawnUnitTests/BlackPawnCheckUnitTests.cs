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
    public class BlackPawnCheckUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackPawnCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 7);
            var whiteQueenPosition = new Point(5, 5);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(4, 8);
            var whiteQueenPosition = new Point(1, 8);
            var whitePawnPosition = new Point(3, 7);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
        }

        [TestMethod]
        public void BlackPawnCantMove1BoxForwardIfCantPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(4, 4);
            var whiteQueenPosition = new Point(8, 6);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfCantPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 4);
            var whiteQueenPosition = new Point(8, 6);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCantTakePiecesIfCantPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var whiteQueenPosition = new Point(blackKingPosition.X, blackKingPosition.Y - 1);
            var blackPawnPosition = new Point(3, 3);
            var whitePawnPositionSouthWest = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);
            var whitePawnPositionSouthEast = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y + 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whitePawnPositionSouthWest.X, whitePawnPositionSouthWest.Y].Piece = new Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionSouthEast.X, whitePawnPositionSouthEast.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCanMove1BoxForwardIfCanPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(8, 7);
            var whiteQueenPosition = new Point(6, 6);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X - 1, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCanMove2BoxesForwardIfCanPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 5);
            var whiteQueenPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X - 2, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var whiteQueenPosition = new Point(4, 4);
            var blackPawnPosition = new Point(5, 5);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}