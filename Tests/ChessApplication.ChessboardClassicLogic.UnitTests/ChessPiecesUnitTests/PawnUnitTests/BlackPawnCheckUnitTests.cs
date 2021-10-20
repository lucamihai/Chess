using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackPawnCheckUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackPawnCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 7);
            var whiteQueenPosition = new Position(5, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackPawnCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(4, 8);
            var whiteQueenPosition = new Position(1, 8);
            var whitePawnPosition = new Position(3, 7);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackPawnCantMove1BoxForwardIfCantPreventCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(4, 4);
            var whiteQueenPosition = new Position(8, 6);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfCantPreventCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 4);
            var whiteQueenPosition = new Position(8, 6);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackPawnCantTakePiecesIfCantPreventCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var whiteQueenPosition = new Position(blackKingPosition.Row, blackKingPosition.Column - 1);
            var blackPawnPosition = new Position(3, 3);
            var whitePawnPositionSouthWest = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column - 1);
            var whitePawnPositionSouthEast = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column + 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whitePawnPositionSouthWest].Piece = new Pawn(PieceColor.White);
            chessboard[whitePawnPositionSouthEast].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackPawnCanMove1BoxForwardIfCanPreventCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(8, 7);
            var whiteQueenPosition = new Position(6, 6);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            Assert.IsTrue(chessboard[blackPawnPosition.Row - 1, blackPawnPosition.Column].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackPawnCanMove2BoxesForwardIfCanPreventCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 5);
            var whiteQueenPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            Assert.IsTrue(chessboard[blackPawnPosition.Row - 2, blackPawnPosition.Column].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackPawnCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var whiteQueenPosition = new Position(4, 4);
            var blackPawnPosition = new Position(5, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            Assert.IsTrue(chessboard[whiteQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}