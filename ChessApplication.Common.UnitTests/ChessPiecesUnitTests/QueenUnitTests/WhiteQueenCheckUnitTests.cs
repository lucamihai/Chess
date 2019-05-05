using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteQueenCheckUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteQueenCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteQueenPosition = new Point(2, 1);
            var blackQueenPosition = new Point(4, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            var numberOfMoves = Methods.GetNumberOfAvailableBoxes(ChessBoard);
            for (int row = whiteQueenPosition.X + 1; row <= blackQueenPosition.X; row++)
            {
                numberOfMoves--;
            }

            Assert.AreEqual(0, numberOfMoves);
        }

        [TestMethod]
        public void WhiteQueenCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteQueenPosition = new Point(2, 1);
            var blackQueenPosition = new Point(4, 1);
            var blackPawnPosition = new Point(2, 8);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            Assert.IsFalse(ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteQueenCantMoveIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteQueenPosition = new Point(3, 2);
            var blackQueenPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteQueenCantTakePieceIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteQueenPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 8);
            var blackQueenPosition = new Point(1, 3);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteQueenCanMoveIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteQueenPosition = new Point(1, 7);
            var blackQueenPosition = new Point(3, 6);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            var defensePosition = new Point(blackQueenPosition.X, blackQueenPosition.Y - 1);
            Assert.IsTrue(ChessBoard[defensePosition.X, defensePosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteQueenCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteQueenPosition = new Point(2, 3);
            var blackQueenPosition = new Point(3, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

    }
}
