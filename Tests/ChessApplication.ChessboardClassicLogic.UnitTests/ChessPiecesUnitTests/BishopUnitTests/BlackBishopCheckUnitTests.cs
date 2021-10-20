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
    public class BlackBishopCheckUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackBishopCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(2, 2);
            var whiteQueenPosition = new Position(8, 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackBishopCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(2, 2);
            var whiteQueenPosition = new Position(8, 2);
            var whitePawnPosition = new Position(blackBishopPosition.Row + 1, blackBishopPosition.Column + 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackBishopPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackBishopCantMoveIfCantPreventCheck()
        {
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(3, 2);
            var whiteQueenPosition = new Position(1, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackBishopCantTakePieceIfCantPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackBishopPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 7);
            var whiteQueenPosition = new Position(1, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackBishopCanMoveIfCanPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackBishopPosition = new Position(4, 3);
            var whiteQueenPosition = new Position(3, 8);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackBishopPosition);

            var defensePosition = new Position(whiteQueenPosition.Row, blackBishopPosition.Column + 1);
            Assert.IsTrue(chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackBishopCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackBishopPosition = new Position(2, 4);
            var whiteQueenPosition = new Position(1, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackBishopPosition);

            Assert.IsTrue(chessboard[whiteQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}
