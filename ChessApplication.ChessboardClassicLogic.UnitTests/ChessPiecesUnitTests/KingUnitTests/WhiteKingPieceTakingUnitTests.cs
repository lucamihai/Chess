using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.KingUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKingPieceTakingUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicFilledWithWhitePawns();
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromNorthWest()
        {
            var whiteKingPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKingPosition.Row + 1, whiteKingPosition.Column - 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromNorth()
        {
            var whiteKingPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKingPosition.Row + 1, whiteKingPosition.Column);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromNorthEast()
        {
            var whiteKingPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKingPosition.Row + 1, whiteKingPosition.Column + 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromEast()
        {
            var whiteKingPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKingPosition.Row, whiteKingPosition.Column + 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromSouthEast()
        {
            var whiteKingPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column + 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromSouth()
        {
            var whiteKingPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromSouthWest()
        {
            var whiteKingPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column - 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakeBlackPieceFromWest()
        {
            var whiteKingPosition = new Position(3, 3);
            var blackPawnPosition = new Position(whiteKingPosition.Row, whiteKingPosition.Column - 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            Assert.IsTrue(chessboard[blackPawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKingCantTakeAnyWhitePiece()
        {
            var whiteKingPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;
            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}
