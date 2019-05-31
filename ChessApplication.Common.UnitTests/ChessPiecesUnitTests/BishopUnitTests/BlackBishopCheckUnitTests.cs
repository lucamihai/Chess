using System.Diagnostics.CodeAnalysis;
using System.Drawing;
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
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(2, 2);
            var whiteQueenPosition = new Point(8, 2);

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
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(2, 2);
            var whiteQueenPosition = new Point(8, 2);
            var whitePawnPosition = new Point(blackBishopPosition.X + 1, blackBishopPosition.Y + 1);

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
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(3, 2);
            var whiteQueenPosition = new Point(1, 3);

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
            var blackKingPosition = new Point(3, 3);
            var blackBishopPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 7);
            var whiteQueenPosition = new Point(1, 3);

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
            var blackKingPosition = new Point(3, 3);
            var blackBishopPosition = new Point(4, 3);
            var whiteQueenPosition = new Point(3, 8);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            var defensePosition = new Point(whiteQueenPosition.X, blackBishopPosition.Y + 1);
            Assert.IsTrue(Chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackBishopCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackBishopPosition = new Point(2, 4);
            var whiteQueenPosition = new Point(1, 3);

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
