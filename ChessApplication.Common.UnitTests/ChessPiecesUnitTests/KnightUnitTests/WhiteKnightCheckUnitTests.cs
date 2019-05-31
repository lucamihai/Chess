using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KnightUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKnightCheckUnitTests
    {
        private ChessboardClassic ChessBoard;

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

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(7, 8);
            var blackQueenPosition = new Point(1, 8);
            var blackPawnPosition = new Point(whiteKnightPosition.X - 1, whiteKnightPosition.Y - 2);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            Assert.IsFalse(ChessBoard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveIfNotPreventsCheck()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackQueenPosition = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCantTakePieceIfNotPreventsCheck()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackQueenPosition = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y);
            var blackPawnPosition = new Point(whiteKnightPosition.X - 2, whiteKnightPosition.Y - 1);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            Assert.IsFalse(ChessBoard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveIfPreventsCheck()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(whiteKingPosition.X - 2, whiteKingPosition.Y);
            var blackQueenPosition = new Point(whiteKingPosition.X, 1);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            var defensePosition = new Point(whiteKingPosition.X, whiteKingPosition.Y - 1);
            Assert.IsTrue(ChessBoard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCanTakePieceIfPreventsCheck()
        {
            var whiteKingPosition = new Point(8, 8);
            var blackQueenPosition = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y);
            var whiteKnightPosition = new Point(blackQueenPosition.X - 2, blackQueenPosition.Y - 1);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            Assert.IsTrue(ChessBoard[blackQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}