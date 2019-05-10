using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KnightUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKnightMovementUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthNorthEastIfEmpty()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            var positionToBeTested = new Point(whiteKnightPosition.X + 2, whiteKnightPosition.Y + 1);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthEastEastIfEmpty()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            var positionToBeTested = new Point(whiteKnightPosition.X + 1, whiteKnightPosition.Y + 2);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthEastEastIfEmpty()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            var positionToBeTested = new Point(whiteKnightPosition.X - 1, whiteKnightPosition.Y + 2);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthEastIfEmpty()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            var positionToBeTested = new Point(whiteKnightPosition.X - 2, whiteKnightPosition.Y + 1);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthWestIfEmpty()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            var positionToBeTested = new Point(whiteKnightPosition.X - 2, whiteKnightPosition.Y - 1);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthWestWestIfEmpty()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            var positionToBeTested = new Point(whiteKnightPosition.X - 1, whiteKnightPosition.Y - 2);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthWestWestIfEmpty()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            var positionToBeTested = new Point(whiteKnightPosition.X + 1, whiteKnightPosition.Y - 2);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthNorthWestIfEmpty()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            var positionToBeTested = new Point(whiteKnightPosition.X + 2, whiteKnightPosition.Y - 1);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthEastIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(whiteKnightPosition.X + 2, whiteKnightPosition.Y + 1);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthEastEastIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(whiteKnightPosition.X + 1, whiteKnightPosition.Y + 2);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthEastEastIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(whiteKnightPosition.X - 1, whiteKnightPosition.Y + 2);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthEastIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(whiteKnightPosition.X - 2, whiteKnightPosition.Y + 1);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthWestIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(whiteKnightPosition.X - 2, whiteKnightPosition.Y - 1);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthWestWestIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(whiteKnightPosition.X - 1, whiteKnightPosition.Y - 2);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthWestWestIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(whiteKnightPosition.X + 1, whiteKnightPosition.Y - 2);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthWestIfOccupiedByWhitePiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(whiteKnightPosition.X + 2, whiteKnightPosition.Y - 1);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition].Piece = new Knight(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }
    }
}