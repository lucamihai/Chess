using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var whiteKingPosition = new Position(1, 1);
            var whiteQueenPosition = new Position(2, 1);
            var blackQueenPosition = new Position(4, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            var numberOfMoves = Methods.GetNumberOfAvailableBoxes(Chessboard);
            for (int row = whiteQueenPosition.Row + 1; row <= blackQueenPosition.Row; row++)
            {
                numberOfMoves--;
            }

            Assert.AreEqual(0, numberOfMoves);
        }

        [TestMethod]
        public void WhiteQueenCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteQueenPosition = new Position(2, 1);
            var blackQueenPosition = new Position(4, 1);
            var blackPawnPosition = new Position(2, 8);

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
            var whiteKingPosition = new Position(3, 3);
            var whiteQueenPosition = new Position(3, 2);
            var blackQueenPosition = new Position(4, 4);

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
            var whiteKingPosition = new Position(3, 3);
            var whiteQueenPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 8);
            var blackQueenPosition = new Position(1, 3);

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
            var whiteKingPosition = new Position(3, 3);
            var whiteQueenPosition = new Position(1, 7);
            var blackQueenPosition = new Position(3, 6);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            var defensePosition = new Position(blackQueenPosition.Row, blackQueenPosition.Column - 1);
            Assert.IsTrue(Chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteQueenCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteQueenPosition = new Position(2, 3);
            var blackQueenPosition = new Position(3, 4);

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
