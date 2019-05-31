using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteQueenCheckUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteQueenCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteQueenPosition = new Point(2, 1);
            var blackQueenPosition = new Point(4, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            var numberOfMoves = Methods.GetNumberOfAvailableBoxes(Chessboard);
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

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            Assert.IsFalse(Chessboard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteQueenCantMoveIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteQueenPosition = new Point(3, 2);
            var blackQueenPosition = new Point(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteQueenCantTakePieceIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteQueenPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 8);
            var blackQueenPosition = new Point(1, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteQueenCanMoveIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteQueenPosition = new Point(1, 7);
            var blackQueenPosition = new Point(3, 6);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            var defensePosition = new Point(blackQueenPosition.X, blackQueenPosition.Y - 1);
            Assert.IsTrue(Chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteQueenCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteQueenPosition = new Point(2, 3);
            var blackQueenPosition = new Point(3, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            Assert.IsTrue(Chessboard[blackQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

    }
}
