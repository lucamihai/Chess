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
    public class WhiteKnightCheckUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteKnightCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(7, 8);
            var blackQueenPosition = new Position(1, 8);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKnightCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(7, 8);
            var blackQueenPosition = new Position(1, 8);
            var blackPawnPosition = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column - 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsFalse(Chessboard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveIfNotPreventsCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackQueenPosition = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKnightCantTakePieceIfNotPreventsCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackQueenPosition = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column);
            var blackPawnPosition = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column - 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsFalse(Chessboard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveIfPreventsCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(whiteKingPosition.Row - 2, whiteKingPosition.Column);
            var blackQueenPosition = new Position(whiteKingPosition.Row, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            var defensePosition = new Position(whiteKingPosition.Row, whiteKingPosition.Column - 1);
            Assert.IsTrue(Chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakePieceIfPreventsCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var blackQueenPosition = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column);
            var whiteKnightPosition = new Position(blackQueenPosition.Row - 2, blackQueenPosition.Column - 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsTrue(Chessboard[blackQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}