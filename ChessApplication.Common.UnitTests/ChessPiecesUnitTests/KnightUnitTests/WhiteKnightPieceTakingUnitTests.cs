using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KnightUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKnightPieceTakingUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicFilledWithWhitePawns();
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromNorthNorthEast()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X + 2, whiteKnightPosition.Y + 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromNorthEastEast()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X + 1, whiteKnightPosition.Y + 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromSouthEastEast()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X - 1, whiteKnightPosition.Y + 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromSouthSouthEast()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X - 2, whiteKnightPosition.Y + 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromSouthSouthWest()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X - 2, whiteKnightPosition.Y - 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromSouthWestWest()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X - 1, whiteKnightPosition.Y - 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromNorthWestWest()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X + 1, whiteKnightPosition.Y - 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromNorthNorthWest()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X + 2, whiteKnightPosition.Y - 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKnightCantTakeAnyWhitePiece()
        {
            var whiteKingPosition = new Point(7, 7);
            var whiteKnightPosition = new Point(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}