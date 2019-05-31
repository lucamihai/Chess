using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KingUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKingPieceTakingUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicFilledWithWhitePawns();
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromNorthWest()
        {
            var whiteKingPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKingPosition.X + 1, whiteKingPosition.Y - 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromNorth()
        {
            var whiteKingPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKingPosition.X + 1, whiteKingPosition.Y);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromNorthEast()
        {
            var whiteKingPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKingPosition.X + 1, whiteKingPosition.Y + 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromEast()
        {
            var whiteKingPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKingPosition.X, whiteKingPosition.Y + 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromSouthEast()
        {
            var whiteKingPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y + 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromSouth()
        {
            var whiteKingPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromSouthWest()
        {
            var whiteKingPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y - 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromWest()
        {
            var whiteKingPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKingPosition.X, whiteKingPosition.Y - 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKingCantTakeAnyWhitePiece()
        {
            var whiteKingPosition = new Point(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;
            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}
