using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.RookUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteRookMovementUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteRookCanMoveEastIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteRookPosition = new Point(1, 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            for (var column = whiteRookPosition.Y + 1; column < 9; column++)
                Assert.IsTrue(ChessBoard[whiteRookPosition.X, column].Available);
        }

        [TestMethod]
        public void WhiteRookCanMoveWestIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteRookPosition = new Point(2, 8);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            for (var column = whiteRookPosition.Y - 1; column > 0; column--)
                Assert.IsTrue(ChessBoard[whiteRookPosition.X, column].Available);
        }

        [TestMethod]
        public void WhiteRookCanMoveNorthIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteRookPosition = new Point(1, 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            for (var row = whiteRookPosition.X + 1; row < 9; row++)
                Assert.IsTrue(ChessBoard[row, whiteRookPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteRookCanMoveSouthIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteRookPosition = new Point(8, 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            for (var row = whiteRookPosition.X - 1; row > 0; row--)
                Assert.IsTrue(ChessBoard[row, whiteRookPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteRookCanMoveEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteRookPosition = new Point(1, 2);
            var whitePawnPosition = new Point(1, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            for (var column = whiteRookPosition.Y + 1; column < whitePawnPosition.Y; column++)
                Assert.IsTrue(ChessBoard[whiteRookPosition.X, column].Available);

            for (var column = whitePawnPosition.Y + 1; column < 9; column++)
                Assert.IsFalse(ChessBoard[whiteRookPosition.X, column].Available);
        }

        [TestMethod]
        public void WhiteRookCanMoveWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(2, 1);
            var whiteRookPosition = new Point(1, 8);
            var whitePawnPosition = new Point(1, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            for (var column = whiteRookPosition.Y - 1; column > whitePawnPosition.Y; column--)
                Assert.IsTrue(ChessBoard[whiteRookPosition.X, column].Available);

            for (var column = whitePawnPosition.Y - 1; column > 0; column--)
                Assert.IsFalse(ChessBoard[whiteRookPosition.X, column].Available);
        }

        [TestMethod]
        public void WhiteRookCanMoveNorthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteRookPosition = new Point(1, 1);
            var whitePawnPosition = new Point(5, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            for (var row = whiteRookPosition.X + 1; row < whitePawnPosition.X; row++)
                Assert.IsTrue(ChessBoard[row, whiteRookPosition.Y].Available);

            for (var row = whitePawnPosition.X + 1; row < 9; row++)
                Assert.IsFalse(ChessBoard[row, whiteRookPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteRookCanMoveSouthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteRookPosition = new Point(8, 1);
            var whitePawnPosition = new Point(5, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            for (var row = whiteRookPosition.X - 1; row > whitePawnPosition.X; row--)
                Assert.IsTrue(ChessBoard[row, whiteRookPosition.Y].Available);

            for (var row = whitePawnPosition.X - 1; row > 0; row--)
                Assert.IsFalse(ChessBoard[row, whiteRookPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteRookCanMoveEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteRookPosition = new Point(1, 2);
            var blackPawnPosition = new Point(1, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            for (var column = whiteRookPosition.Y + 1; column < blackPawnPosition.Y; column++)
                Assert.IsTrue(ChessBoard[whiteRookPosition.X, column].Available);

            for (var column = blackPawnPosition.Y + 1; column < 9; column++)
                Assert.IsFalse(ChessBoard[whiteRookPosition.X, column].Available);
        }

        [TestMethod]
        public void WhiteRookCanMoveWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(2, 1);
            var whiteRookPosition = new Point(1, 8);
            var blackPawnPosition = new Point(1, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            for (var column = whiteRookPosition.Y - 1; column > blackPawnPosition.Y; column--)
                Assert.IsTrue(ChessBoard[whiteRookPosition.X, column].Available);

            for (var column = blackPawnPosition.Y - 1; column > 0; column--)
                Assert.IsFalse(ChessBoard[whiteRookPosition.X, column].Available);
        }

        [TestMethod]
        public void WhiteRookCanMoveNorthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteRookPosition = new Point(1, 1);
            var blackPawnPosition = new Point(5, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            for (var row = whiteRookPosition.X + 1; row < blackPawnPosition.X; row++)
                Assert.IsTrue(ChessBoard[row, whiteRookPosition.Y].Available);

            for (var row = blackPawnPosition.X + 1; row < 9; row++)
                Assert.IsFalse(ChessBoard[row, whiteRookPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteRookCanMoveSouthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteRookPosition = new Point(8, 1);
            var blackPawnPosition = new Point(5, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            for (var row = whiteRookPosition.X - 1; row > blackPawnPosition.X; row--)
                Assert.IsTrue(ChessBoard[row, whiteRookPosition.Y].Available);

            for (var row = blackPawnPosition.X - 1; row > 0; row--)
                Assert.IsFalse(ChessBoard[row, whiteRookPosition.Y].Available);
        }
    }
}