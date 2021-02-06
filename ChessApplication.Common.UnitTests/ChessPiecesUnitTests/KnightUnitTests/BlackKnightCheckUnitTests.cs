using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KnightUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackKnightCheckUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackKnightCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(7, 8);
            var whiteQueenPosition = new Position(1, 8);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKnightCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(7, 8);
            var whiteQueenPosition = new Position(1, 8);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column - 2);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackKnightCantMoveIfNotPreventsCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whiteQueenPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKnightCantTakePieceIfNotPreventsCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whiteQueenPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column - 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackKnightCanMoveIfPreventsCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(blackKingPosition.Row - 2, blackKingPosition.Column);
            var whiteQueenPosition = new Position(blackKingPosition.Row, 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            var defensePosition = new Position(blackKingPosition.Row, blackKingPosition.Column - 1);
            Assert.IsTrue(Chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakePieceIfPreventsCheck()
        {
            var blackKingPosition = new Position(8, 8);
            var whiteQueenPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column);
            var blackKnightPosition = new Position(whiteQueenPosition.Row - 2, whiteQueenPosition.Column - 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsTrue(Chessboard[whiteQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}