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
    public class WhiteKnightCheckUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteKnightCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(7, 8);
            var blackQueenPosition = new Position(1, 8);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKnightCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(7, 8);
            var blackQueenPosition = new Position(1, 8);
            var blackPawnPosition = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column - 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsFalse(chessboard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveIfNotPreventsCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackQueenPosition = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKnightCantTakePieceIfNotPreventsCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var blackQueenPosition = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column);
            var blackPawnPosition = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column - 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsFalse(chessboard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveIfPreventsCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(whiteKingPosition.Row - 2, whiteKingPosition.Column);
            var blackQueenPosition = new Position(whiteKingPosition.Row, 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            var defensePosition = new Position(whiteKingPosition.Row, whiteKingPosition.Column - 1);
            Assert.IsTrue(chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKnightCanTakePieceIfPreventsCheck()
        {
            var whiteKingPosition = new Position(8, 8);
            var blackQueenPosition = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column);
            var whiteKnightPosition = new Position(blackQueenPosition.Row - 2, blackQueenPosition.Column - 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsTrue(chessboard[blackQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}