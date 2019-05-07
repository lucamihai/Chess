using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackQueenCheckUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackQueenCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Point(1, 1);
            var blackQueenPosition = new Point(2, 1);
            var whiteQueenPosition = new Point(4, 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition, blackKingPosition);

            var numberOfMoves = Methods.GetNumberOfAvailableBoxes(ChessBoard);
            for (int row = blackQueenPosition.X + 1; row <= whiteQueenPosition.X; row++)
            {
                numberOfMoves--;
            }

            Assert.AreEqual(0, numberOfMoves);
        }

        [TestMethod]
        public void BlackQueenCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Point(1, 1);
            var blackQueenPosition = new Point(2, 1);
            var whiteQueenPosition = new Point(4, 1);
            var whitePawnPosition = new Point(2, 8);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
        }

        [TestMethod]
        public void BlackQueenCantMoveIfCantPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackQueenPosition = new Point(3, 2);
            var whiteQueenPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackQueenCantTakePieceIfCantPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackQueenPosition = new Point(8, 8);
            var whitePawnPosition = new Point(7, 8);
            var whiteQueenPosition = new Point(1, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackQueenCanMoveIfCanPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackQueenPosition = new Point(1, 7);
            var whiteQueenPosition = new Point(3, 6);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition, blackKingPosition);

            var defensePosition = new Point(whiteQueenPosition.X, whiteQueenPosition.Y - 1);
            Assert.IsTrue(ChessBoard[defensePosition.X, defensePosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackQueenCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackQueenPosition = new Point(2, 3);
            var whiteQueenPosition = new Point(3, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
