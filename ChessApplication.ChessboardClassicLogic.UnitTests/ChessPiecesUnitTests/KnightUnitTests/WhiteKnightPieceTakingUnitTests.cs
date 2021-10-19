using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.KnightUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKnightPieceTakingUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicFilledWithPawns(PieceColor.White);
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromNorthNorthEast()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row + 2, whiteKnightPosition.Column + 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromNorthEastEast()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row + 1, whiteKnightPosition.Column + 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromSouthEastEast()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column + 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromSouthSouthEast()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column + 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromSouthSouthWest()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column - 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromSouthWestWest()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column - 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromNorthWestWest()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row + 1, whiteKnightPosition.Column - 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromNorthNorthWest()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKnightPosition.Row + 2, whiteKnightPosition.Column - 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKnightCantTakeAnyWhitePiece()
        {
            var whiteKingPosition = new Position(7, 7);
            var whiteKnightPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}