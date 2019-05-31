using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KnightUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackKnightMovementUnitTests
    {
        private ChessboardClassic ChessBoard;

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

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            var positionToBeTested = new Point(blackKnightPosition.X + 2, blackKnightPosition.Y + 1);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackKnightCanMoveNorthEastEastIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            var positionToBeTested = new Point(blackKnightPosition.X + 1, blackKnightPosition.Y + 2);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackKnightCanMoveSouthEastEastIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            var positionToBeTested = new Point(blackKnightPosition.X - 1, blackKnightPosition.Y + 2);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthEastIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            var positionToBeTested = new Point(blackKnightPosition.X - 2, blackKnightPosition.Y + 1);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthSouthWestIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            var positionToBeTested = new Point(blackKnightPosition.X - 2, blackKnightPosition.Y - 1);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveSouthWestWestIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            var positionToBeTested = new Point(blackKnightPosition.X - 1, blackKnightPosition.Y - 2);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthWestWestIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            var positionToBeTested = new Point(blackKnightPosition.X + 1, blackKnightPosition.Y - 2);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCanMoveNorthNorthWestIfEmpty()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            var positionToBeTested = new Point(blackKnightPosition.X + 2, blackKnightPosition.Y - 1);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X + 2, blackKnightPosition.Y + 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthEastEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X + 1, blackKnightPosition.Y + 2);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthEastEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X - 1, blackKnightPosition.Y + 2);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthEastIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X - 2, blackKnightPosition.Y + 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthSouthWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X - 2, blackKnightPosition.Y - 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveSouthWestWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X - 1, blackKnightPosition.Y - 2);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthWestWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X + 1, blackKnightPosition.Y - 2);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKnightCantMoveNorthNorthWestIfOccupiedByWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X + 2, blackKnightPosition.Y - 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }
    }
}