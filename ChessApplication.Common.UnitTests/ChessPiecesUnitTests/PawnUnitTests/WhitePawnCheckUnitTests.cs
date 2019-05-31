using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhitePawnCheckUnitTests
    {
        private ChessboardClassic ChessBoard;

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

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(1, 1);
            var whitePawnPosition = new Point(2, 1);
            var blackQueenPosition = new Point(5, 1);
            var blackPawnPosition = new Point(3, 2);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            Assert.IsFalse(ChessBoard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhitePawnCantMove1BoxForwardIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(2, 2);
            var blackQueenPosition = new Point(2, 3);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(2, 2);
            var whitePawnPosition = new Point(2, 4);
            var blackQueenPosition = new Point(2, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

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

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackPawnPositionNorthWest].Piece = new Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionNorthEast].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCanMove1BoxForwardIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(2, 2);
            var whitePawnPosition = new Point(3, 4);
            var blackQueenPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X + 1, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCanMove2BoxesForwardIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(2, 4);
            var blackQueenPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X + 2, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(2, 1);
            var blackQueenPosition = new Point(3, 2);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            Assert.IsTrue(ChessBoard[blackQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}