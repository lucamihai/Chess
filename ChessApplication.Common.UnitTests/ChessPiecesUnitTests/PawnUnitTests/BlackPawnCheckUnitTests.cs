using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackPawnCheckUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackPawnCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 7);
            var whiteQueenPosition = new Point(5, 5);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackPawnCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(4, 8);
            var whiteQueenPosition = new Point(1, 8);
            var whitePawnPosition = new Point(3, 7);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackPawnCantMove1BoxForwardIfCantPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(4, 4);
            var whiteQueenPosition = new Point(8, 6);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfCantPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 4);
            var whiteQueenPosition = new Point(8, 6);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackPawnCantTakePiecesIfCantPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var whiteQueenPosition = new Point(blackKingPosition.X, blackKingPosition.Y - 1);
            var blackPawnPosition = new Point(3, 3);
            var whitePawnPositionSouthWest = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);
            var whitePawnPositionSouthEast = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y + 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whitePawnPositionSouthWest].Piece = new Pawn(PieceColor.White);
            Chessboard[whitePawnPositionSouthEast].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackPawnCanMove1BoxForwardIfCanPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(8, 7);
            var whiteQueenPosition = new Point(6, 6);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition.X - 1, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackPawnCanMove2BoxesForwardIfCanPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 5);
            var whiteQueenPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition.X - 2, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackPawnCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var whiteQueenPosition = new Point(4, 4);
            var blackPawnPosition = new Point(5, 5);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            Assert.IsTrue(Chessboard[whiteQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}