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
    public class WhiteKnightMovementUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthNorthEastIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row + 2, whiteKnightPosition.Column + 1);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthEastEastIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row + 1, whiteKnightPosition.Column + 2);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthEastEastIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column + 2);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthEastIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column + 1);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthWestIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column - 1);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthWestWestIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column - 2);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthWestWestIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row + 1, whiteKnightPosition.Column - 2);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthNorthWestIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row + 2, whiteKnightPosition.Column - 1);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthEastIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row + 2, whiteKnightPosition.Column + 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthEastEastIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row + 1, whiteKnightPosition.Column + 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthEastEastIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column + 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthEastIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column + 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthWestIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column - 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthWestWestIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column - 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthWestWestIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row + 1, whiteKnightPosition.Column - 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthWestIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row + 2, whiteKnightPosition.Column - 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKnightPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }
    }
}