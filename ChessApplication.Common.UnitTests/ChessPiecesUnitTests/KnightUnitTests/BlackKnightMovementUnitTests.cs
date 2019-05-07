using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KnightUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackKnightMovementUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackKnightCanMoveNorthNorthEastIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            var positionToBeTested = new Point(blackKnightPosition.X + 2, blackKnightPosition.Y + 1);
            Assert.IsTrue(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void BlackKnightCanMoveNorthEastEastIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            var positionToBeTested = new Point(blackKnightPosition.X + 1, blackKnightPosition.Y + 2);
            Assert.IsTrue(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void BlackKnightCanMoveSouthEastEastIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            var positionToBeTested = new Point(blackKnightPosition.X - 1, blackKnightPosition.Y + 2);
            Assert.IsTrue(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthEastIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            var positionToBeTested = new Point(blackKnightPosition.X - 2, blackKnightPosition.Y + 1);
            Assert.IsTrue(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthWestIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            var positionToBeTested = new Point(blackKnightPosition.X - 2, blackKnightPosition.Y - 1);
            Assert.IsTrue(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthWestWestIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            var positionToBeTested = new Point(blackKnightPosition.X - 1, blackKnightPosition.Y - 2);
            Assert.IsTrue(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthWestWestIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            var positionToBeTested = new Point(blackKnightPosition.X + 1, blackKnightPosition.Y - 2);
            Assert.IsTrue(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthNorthWestIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            var positionToBeTested = new Point(blackKnightPosition.X + 2, blackKnightPosition.Y - 1);
            Assert.IsTrue(ChessBoard[positionToBeTested.X, positionToBeTested.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X + 2, blackKnightPosition.Y + 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthEastEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X + 1, blackKnightPosition.Y + 2);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthEastEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X - 1, blackKnightPosition.Y + 2);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X - 2, blackKnightPosition.Y + 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X - 2, blackKnightPosition.Y - 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthWestWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X - 1, blackKnightPosition.Y - 2);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthWestWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X + 1, blackKnightPosition.Y - 2);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X + 2, blackKnightPosition.Y - 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
        }
    }
}