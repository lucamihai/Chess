using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KnightUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKnightCheckUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteKnightCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(7, 8);
            var blackQueenPosition = new Point(1, 8);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(7, 8);
            var blackQueenPosition = new Point(1, 8);
            var blackPawnPosition = new Point(whiteKnightPosition.X - 1, whiteKnightPosition.Y - 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.IsFalse(ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveIfNotPreventsCheck()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackQueenPosition = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCantTakePieceIfNotPreventsCheck()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackQueenPosition = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y);
            var blackPawnPosition = new Point(whiteKnightPosition.X - 2, whiteKnightPosition.Y - 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.IsFalse(ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveIfPreventsCheck()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(whiteKingPosition.X - 2, whiteKingPosition.Y);
            var blackQueenPosition = new Point(whiteKingPosition.X, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            var defensePosition = new Point(whiteKingPosition.X, whiteKingPosition.Y - 1);
            Assert.IsTrue(ChessBoard[defensePosition.X, defensePosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCanTakePieceIfPreventsCheck()
        {
            var whiteKingPosition = new Point(8, 8);
            var blackQueenPosition = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y);
            var whiteKnightPosition = new Point(blackQueenPosition.X - 2, blackQueenPosition.Y - 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}