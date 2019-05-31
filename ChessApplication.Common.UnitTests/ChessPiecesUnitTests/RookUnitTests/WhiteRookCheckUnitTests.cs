using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.RookUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteRookCheckUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteRookCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteRookPosition = new Point(4, 4);
            var blackQueenPosition = new Point(5, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteRookCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteRookPosition = new Point(4, 4);
            var blackQueenPosition = new Point(5, 5);
            var blackPawnPosition = new Point(4, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            Assert.IsFalse(Chessboard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteRookCantMoveIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteRookPosition = new Point(3, 2);
            var blackQueenPosition = new Point(1, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteRookCantTakePieceIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteRookPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 8);
            var blackQueenPosition = new Point(1, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteRookCanMoveIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteRookPosition = new Point(1, 7);
            var blackQueenPosition = new Point(3, 8);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            var defensePosition = new Point(blackQueenPosition.X, whiteRookPosition.Y);
            Assert.IsTrue(Chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteRookCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteRookPosition = new Point(1, 2);
            var blackQueenPosition = new Point(1, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            Assert.IsTrue(Chessboard[blackQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}