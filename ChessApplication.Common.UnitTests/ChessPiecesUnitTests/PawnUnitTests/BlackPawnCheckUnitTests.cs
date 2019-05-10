using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
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

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(4, 8);
            var whiteQueenPosition = new Point(1, 8);
            var whitePawnPosition = new Point(3, 7);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackPawnCantMove1BoxForwardIfCantPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(4, 4);
            var whiteQueenPosition = new Point(8, 6);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfCantPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 4);
            var whiteQueenPosition = new Point(8, 6);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

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

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whitePawnPositionSouthWest].Piece = new Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionSouthEast].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCanMove1BoxForwardIfCanPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(8, 7);
            var whiteQueenPosition = new Point(6, 6);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X - 1, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCanMove2BoxesForwardIfCanPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 5);
            var whiteQueenPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X - 2, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var whiteQueenPosition = new Point(4, 4);
            var blackPawnPosition = new Point(5, 5);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            Assert.IsTrue(ChessBoard[whiteQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}