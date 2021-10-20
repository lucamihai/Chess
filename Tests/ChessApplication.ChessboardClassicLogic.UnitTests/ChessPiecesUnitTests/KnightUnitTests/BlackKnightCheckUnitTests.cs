using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.KnightUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackKnightCheckUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackKnightCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(7, 8);
            var whiteQueenPosition = new Position(1, 8);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKnightCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(7, 8);
            var whiteQueenPosition = new Position(1, 8);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column - 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackKnightCantMoveIfNotPreventsCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whiteQueenPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKnightCantTakePieceIfNotPreventsCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whiteQueenPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column - 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackKnightCanMoveIfPreventsCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(blackKingPosition.Row - 2, blackKingPosition.Column);
            var whiteQueenPosition = new Position(blackKingPosition.Row, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            var defensePosition = new Position(blackKingPosition.Row, blackKingPosition.Column - 1);
            Assert.IsTrue(chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakePieceIfPreventsCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var whiteQueenPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column);
            var blackKnightPosition = new Position(whiteQueenPosition.Row - 2, whiteQueenPosition.Column - 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsTrue(chessboard[whiteQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}