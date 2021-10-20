using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.RookUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteRookCheckUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteRookCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteRookPosition = new Position(4, 4);
            var blackQueenPosition = new Position(5, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteRookCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteRookPosition = new Position(4, 4);
            var blackQueenPosition = new Position(5, 5);
            var blackPawnPosition = new Position(4, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            Assert.IsFalse(chessboard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteRookCantMoveIfCantPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteRookPosition = new Position(3, 2);
            var blackQueenPosition = new Position(1, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteRookCantTakePieceIfCantPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteRookPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 8);
            var blackQueenPosition = new Position(1, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteRookCanMoveIfCanPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteRookPosition = new Position(1, 7);
            var blackQueenPosition = new Position(3, 8);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            var defensePosition = new Position(blackQueenPosition.Row, whiteRookPosition.Column);
            Assert.IsTrue(chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteRookCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteRookPosition = new Position(1, 2);
            var blackQueenPosition = new Position(1, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            Assert.IsTrue(chessboard[blackQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}