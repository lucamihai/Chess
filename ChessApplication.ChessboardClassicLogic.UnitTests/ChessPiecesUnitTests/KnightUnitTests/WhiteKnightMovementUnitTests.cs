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
    public class WhiteKnightMovementUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthNorthEastIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row + 2, whiteKnightPosition.Column + 1);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthEastEastIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row + 1, whiteKnightPosition.Column + 2);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthEastEastIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column + 2);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthEastIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column + 1);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthWestIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column - 1);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthWestWestIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column - 2);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthWestWestIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row + 1, whiteKnightPosition.Column - 2);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthNorthWestIfEmpty()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            var positionToBeTested = new Position(whiteKnightPosition.Row + 2, whiteKnightPosition.Column - 1);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthEastIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row + 2, whiteKnightPosition.Column + 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthEastEastIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row + 1, whiteKnightPosition.Column + 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthEastEastIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column + 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthEastIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column + 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthWestIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row - 2, whiteKnightPosition.Column - 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthWestWestIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row - 1, whiteKnightPosition.Column - 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthWestWestIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row + 1, whiteKnightPosition.Column - 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthWestIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(whiteKnightPosition.Row + 2, whiteKnightPosition.Column - 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKnightPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }
    }
}