using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row + 2, whiteKnightPosition.Column + 1);

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
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row + 1, whiteKnightPosition.Column + 2);

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
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column + 2);

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
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column + 1);

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
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column - 1);

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
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column - 2);

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
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row + 1, whiteKnightPosition.Column - 2);

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
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row + 2, whiteKnightPosition.Column - 1);

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
            var whiteKingPosition = new Position(7, 7);
            var whiteKnightPosition = new Position(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}