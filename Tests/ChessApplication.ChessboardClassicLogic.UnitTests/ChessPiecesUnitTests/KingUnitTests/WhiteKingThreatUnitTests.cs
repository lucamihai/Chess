using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.KingUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKingThreatUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteKingCantMoveIfWillCauseACheck()
        {
            var whiteKingPosition = new Position(1, 1);
            var blackQueenPosition = new Position(2, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKingCantTakePieceIfWillCauseACheck()
        {
            var whiteKingPosition = new Position(1, 1);
            var blackPawnPosition = new Position(whiteKingPosition.Row + 1, whiteKingPosition.Column);
            var blackBishopPosition = new Position(blackPawnPosition.Row + 1, blackPawnPosition.Column + 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            Assert.IsFalse(chessboard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKingCanMoveAwayIfWillRemoveCheck()
        {
            var whiteKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(2, 1);
            var blackPawnPosition = new Position(3, 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            var availablePosition = new Position(1, 3);
            Assert.IsTrue(chessboard[availablePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteKingCanTakePieceIfWillRemoveCheck()
        {
            var whiteKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(2, 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            Assert.IsTrue(chessboard[blackQueenPosition].Available);
        }
    }
}
