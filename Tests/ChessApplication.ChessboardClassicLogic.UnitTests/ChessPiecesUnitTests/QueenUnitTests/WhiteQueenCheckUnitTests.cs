using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteQueenCheckUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteQueenCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteQueenPosition = new Position(2, 1);
            var blackQueenPosition = new Position(4, 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteQueenPosition);

            var numberOfMoves = Methods.GetNumberOfAvailableBoxes(chessboard);
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

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteQueenPosition);

            Assert.IsFalse(chessboard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteQueenCantMoveIfCantPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteQueenPosition = new Position(3, 2);
            var blackQueenPosition = new Position(4, 4);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteQueenCantTakePieceIfCantPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteQueenPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 8);
            var blackQueenPosition = new Position(1, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteQueenCanMoveIfCanPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteQueenPosition = new Position(1, 7);
            var blackQueenPosition = new Position(3, 6);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteQueenPosition);

            var defensePosition = new Position(blackQueenPosition.Row, blackQueenPosition.Column - 1);
            Assert.IsTrue(chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteQueenCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteQueenPosition = new Position(2, 3);
            var blackQueenPosition = new Position(3, 4);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteQueenPosition);

            Assert.IsTrue(chessboard[blackQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

    }
}
