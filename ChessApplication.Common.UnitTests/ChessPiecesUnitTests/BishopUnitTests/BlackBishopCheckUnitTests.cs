using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackBishopCheckUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackBishopCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(2, 2);
            var whiteQueenPosition = new Point(8, 2);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackBishopCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(2, 2);
            var whiteQueenPosition = new Point(8, 2);
            var whitePawnPosition = new Point(blackBishopPosition.X + 1, blackBishopPosition.Y + 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
        }

        [TestMethod]
        public void BlackBishopCantMoveIfCantPreventCheck()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(3, 2);
            var whiteQueenPosition = new Point(1, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackBishopCantTakePieceIfCantPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackBishopPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 7);
            var whiteQueenPosition = new Point(1, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackBishopCanMoveIfCanPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackBishopPosition = new Point(4, 3);
            var whiteQueenPosition = new Point(3, 8);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            var defensePosition = new Point(whiteQueenPosition.X, blackBishopPosition.Y + 1);
            Assert.IsTrue(ChessBoard[defensePosition.X, defensePosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackBishopCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackBishopPosition = new Point(2, 4);
            var whiteQueenPosition = new Point(1, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
