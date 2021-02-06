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
    public class BlackKnightMovementUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackKnightCanMoveNorthNorthEastIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row + 2, blackKnightPosition.Column + 1);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackKnightCanMoveNorthEastEastIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row + 1, blackKnightPosition.Column + 2);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackKnightCanMoveSouthEastEastIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column + 2);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthEastIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column + 1);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthWestIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column - 1);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthWestWestIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column - 2);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthWestWestIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row + 1, blackKnightPosition.Column - 2);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthNorthWestIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row + 2, blackKnightPosition.Column - 1);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 2, blackKnightPosition.Column + 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthEastEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 1, blackKnightPosition.Column + 2);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthEastEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column + 2);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column + 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column - 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthWestWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column - 2);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthWestWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 1, blackKnightPosition.Column - 2);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 2, blackKnightPosition.Column - 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }
    }
}