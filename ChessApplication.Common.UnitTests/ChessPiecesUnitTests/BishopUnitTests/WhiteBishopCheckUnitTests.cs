using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteBishopCheckUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteBishopCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(2, 2);
            var blackQueenPosition = new Point(8, 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteBishopCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(2, 2);
            var blackQueenPosition = new Point(8, 2);
            var blackPawnPosition = new Point(whiteBishopPosition.X + 1, whiteBishopPosition.Y + 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition, whiteKingPosition);

            Assert.IsFalse(ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteBishopCantMoveIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(3, 2);
            var blackQueenPosition = new Point(1, 3);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteBishopCantTakePieceIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteBishopPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 7);
            var blackQueenPosition = new Point(1, 3);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteBishopCanMoveIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteBishopPosition = new Point(4, 3);
            var blackQueenPosition = new Point(3, 8);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition, whiteKingPosition);

            var defensePosition = new Point(blackQueenPosition.X, whiteBishopPosition.Y + 1);
            Assert.IsTrue(ChessBoard[defensePosition.X, defensePosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteBishopCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteBishopPosition = new Point(2, 4);
            var blackQueenPosition = new Point(1, 3);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

    }
}
