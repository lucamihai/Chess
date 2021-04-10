using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhitePawnCheckUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhitePawnCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(1, 1);
            var whitePawnPosition = new Position(2, 2);
            var blackQueenPosition = new Position(5, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhitePawnCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(1, 1);
            var whitePawnPosition = new Position(2, 1);
            var blackQueenPosition = new Position(5, 1);
            var blackPawnPosition = new Position(3, 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            Assert.IsFalse(Chessboard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhitePawnCantMove1BoxForwardIfCantPreventCheck()
        {
            var whiteKingPosition = new Position(2, 2);
            var blackQueenPosition = new Position(2, 3);
            var whitePawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfCantPreventCheck()
        {
            var whiteKingPosition = new Position(2, 2);
            var whitePawnPosition = new Position(2, 4);
            var blackQueenPosition = new Position(2, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhitePawnCantTakePiecesIfCantPreventCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var blackQueenPosition = new Position(whiteKingPosition.Row, whiteKingPosition.Column - 1);
            var whitePawnPosition = new Position(3, 3);
            var blackPawnPositionNorthWest = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column - 1);
            var blackPawnPositionNorthEast = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column + 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackPawnPositionNorthWest].Piece = new Pawn(PieceColor.Black);
            Chessboard[blackPawnPositionNorthEast].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhitePawnCanMove1BoxForwardIfCanPreventCheck()
        {
            var whiteKingPosition = new Position(2, 2);
            var whitePawnPosition = new Position(3, 4);
            var blackQueenPosition = new Position(5, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition.Row + 1, whitePawnPosition.Column].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhitePawnCanMove2BoxesForwardIfCanPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(2, 4);
            var blackQueenPosition = new Position(5, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition.Row + 2, whitePawnPosition.Column].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhitePawnCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(2, 1);
            var blackQueenPosition = new Position(3, 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            Assert.IsTrue(Chessboard[blackQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}