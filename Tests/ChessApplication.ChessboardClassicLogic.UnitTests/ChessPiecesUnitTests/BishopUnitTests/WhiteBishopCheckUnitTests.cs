using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteBishopCheckUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteBishopCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(2, 2);
            var blackQueenPosition = new Position(8, 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteBishopCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(2, 2);
            var blackQueenPosition = new Position(8, 2);
            var blackPawnPosition = new Position(whiteBishopPosition.Row + 1, whiteBishopPosition.Column + 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteBishopPosition);

            Assert.IsFalse(chessboard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteBishopCantMoveIfCantPreventCheck()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(3, 2);
            var blackQueenPosition = new Position(1, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteBishopCantTakePieceIfCantPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteBishopPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 7);
            var blackQueenPosition = new Position(1, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteBishopCanMoveIfCanPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteBishopPosition = new Position(4, 3);
            var blackQueenPosition = new Position(3, 8);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteBishopPosition);

            var defensePosition = new Position(blackQueenPosition.Row, whiteBishopPosition.Column + 1);
            Assert.IsTrue(chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteBishopCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Position(3, 3);
            var whiteBishopPosition = new Position(2, 4);
            var blackQueenPosition = new Position(1, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteBishopPosition);

            Assert.IsTrue(chessboard[blackQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

    }
}
