using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackBishopCheckUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackBishopCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(2, 2);
            var whiteQueenPosition = new Position(8, 2);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackBishopCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(2, 2);
            var whiteQueenPosition = new Position(8, 2);
            var whitePawnPosition = new Position(blackBishopPosition.Row + 1, blackBishopPosition.Column + 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackBishopCantMoveIfCantPreventCheck()
        {
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(3, 2);
            var whiteQueenPosition = new Position(1, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackBishopCantTakePieceIfCantPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackBishopPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 7);
            var whiteQueenPosition = new Position(1, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackBishopCanMoveIfCanPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackBishopPosition = new Position(4, 3);
            var whiteQueenPosition = new Position(3, 8);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            var defensePosition = new Position(whiteQueenPosition.Row, blackBishopPosition.Column + 1);
            Assert.IsTrue(Chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackBishopCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackBishopPosition = new Position(2, 4);
            var whiteQueenPosition = new Position(1, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            Assert.IsTrue(Chessboard[whiteQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}
