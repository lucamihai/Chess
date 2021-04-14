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
    public class BlackKnightMovementUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackKnightCanMoveNorthNorthEastIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row + 2, blackKnightPosition.Column + 1);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackKnightCanMoveNorthEastEastIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row + 1, blackKnightPosition.Column + 2);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackKnightCanMoveSouthEastEastIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column + 2);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthEastIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column + 1);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthWestIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column - 1);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthWestWestIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column - 2);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthWestWestIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row + 1, blackKnightPosition.Column - 2);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthNorthWestIfEmpty()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            var positionToBeTested = new Position(blackKnightPosition.Row + 2, blackKnightPosition.Column - 1);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 2, blackKnightPosition.Column + 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthEastEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 1, blackKnightPosition.Column + 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthEastEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column + 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column + 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column - 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthWestWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column - 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthWestWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 1, blackKnightPosition.Column - 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 2, blackKnightPosition.Column - 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }
    }
}