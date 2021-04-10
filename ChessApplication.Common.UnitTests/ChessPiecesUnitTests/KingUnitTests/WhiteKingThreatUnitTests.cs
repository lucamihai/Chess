using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KingUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKingThreatUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteKingCantMoveIfWillCauseACheck()
        {
            var whiteKingPosition = new Position(1, 1);
            var blackQueenPosition = new Position(2, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKingCantTakePieceIfWillCauseACheck()
        {
            var whiteKingPosition = new Position(1, 1);
            var blackPawnPosition = new Position(whiteKingPosition.Row + 1, whiteKingPosition.Column);
            var blackBishopPosition = new Position(blackPawnPosition.Row + 1, blackPawnPosition.Column + 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.IsFalse(Chessboard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKingCanMoveAwayIfWillRemoveCheck()
        {
            var whiteKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(2, 1);
            var blackPawnPosition = new Position(3, 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            var availablePosition = new Position(1, 3);
            Assert.IsTrue(Chessboard[availablePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakePieceIfWillRemoveCheck()
        {
            var whiteKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(2, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.IsTrue(Chessboard[blackQueenPosition].Available);
        }
    }
}
