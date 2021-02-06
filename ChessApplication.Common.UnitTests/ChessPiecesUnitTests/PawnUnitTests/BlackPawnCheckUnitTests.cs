using System.Diagnostics.CodeAnalysis;
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
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 7);
            var whiteQueenPosition = new Position(5, 5);

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
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(4, 8);
            var whiteQueenPosition = new Position(1, 8);
            var whitePawnPosition = new Position(3, 7);

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
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(4, 4);
            var whiteQueenPosition = new Position(8, 6);

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
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 4);
            var whiteQueenPosition = new Position(8, 6);

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
            var blackKingPosition = new Position(8, 8);
            var whiteQueenPosition = new Position(blackKingPosition.Row, blackKingPosition.Column - 1);
            var blackPawnPosition = new Position(3, 3);
            var whitePawnPositionSouthWest = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column - 1);
            var whitePawnPositionSouthEast = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column + 1);

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
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(8, 7);
            var whiteQueenPosition = new Position(6, 6);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition.Row - 1, blackPawnPosition.Column].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackPawnCanMove2BoxesForwardIfCanPreventCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 5);
            var whiteQueenPosition = new Position(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            Assert.IsTrue(Chessboard[blackPawnPosition.Row - 2, blackPawnPosition.Column].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackPawnCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var whiteQueenPosition = new Position(4, 4);
            var blackPawnPosition = new Position(5, 5);

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