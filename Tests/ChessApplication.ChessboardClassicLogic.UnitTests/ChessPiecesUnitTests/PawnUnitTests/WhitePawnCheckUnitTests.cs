using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhitePawnCheckUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhitePawnCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(1, 1);
            var whitePawnPosition = new Position(2, 2);
            var blackQueenPosition = new Position(5, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhitePawnCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(1, 1);
            var whitePawnPosition = new Position(2, 1);
            var blackQueenPosition = new Position(5, 1);
            var blackPawnPosition = new Position(3, 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            Assert.IsFalse(chessboard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhitePawnCantMove1BoxForwardIfCantPreventCheck()
        {
            var whiteKingPosition = new Position(2, 2);
            var blackQueenPosition = new Position(2, 3);
            var whitePawnPosition = new Position(4, 4);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfCantPreventCheck()
        {
            var whiteKingPosition = new Position(2, 2);
            var whitePawnPosition = new Position(2, 4);
            var blackQueenPosition = new Position(2, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhitePawnCantTakePiecesIfCantPreventCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var blackQueenPosition = new Position(whiteKingPosition.Row, whiteKingPosition.Column - 1);
            var whitePawnPosition = new Position(3, 3);
            var blackPawnPositionNorthWest = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column - 1);
            var blackPawnPositionNorthEast = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column + 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackPawnPositionNorthWest].Piece = new Pawn(PieceColor.Black);
            chessboard[blackPawnPositionNorthEast].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhitePawnCanMove1BoxForwardIfCanPreventCheck()
        {
            var whiteKingPosition = new Position(2, 2);
            var whitePawnPosition = new Position(3, 4);
            var blackQueenPosition = new Position(5, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            Assert.IsTrue(chessboard[whitePawnPosition.Row + 1, whitePawnPosition.Column].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhitePawnCanMove2BoxesForwardIfCanPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(2, 4);
            var blackQueenPosition = new Position(5, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            Assert.IsTrue(chessboard[whitePawnPosition.Row + 2, whitePawnPosition.Column].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhitePawnCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(2, 1);
            var blackQueenPosition = new Position(3, 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            Assert.IsTrue(chessboard[blackQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}