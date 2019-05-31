using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.RookUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackRookMovementUnitTests
    {
        private ChessboardClassic ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackRookCanMoveEastIfUnblocked()
        {
            var blackKingPosition = new Point(1, 1);
            var blackRookPosition = new Point(1, 2);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            for (var column = blackRookPosition.Y + 1; column < 9; column++)
                Assert.IsTrue(ChessBoard[blackRookPosition.X, column].Available);
        }

        [TestMethod]
        public void BlackRookCanMoveWestIfUnblocked()
        {
            var blackKingPosition = new Point(1, 1);
            var blackRookPosition = new Point(2, 8);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            for (var column = blackRookPosition.Y - 1; column > 0; column--)
                Assert.IsTrue(ChessBoard[blackRookPosition.X, column].Available);
        }

        [TestMethod]
        public void BlackRookCanMoveNorthIfUnblocked()
        {
            var blackKingPosition = new Point(1, 1);
            var blackRookPosition = new Point(1, 2);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            for (var row = blackRookPosition.X + 1; row < 9; row++)
                Assert.IsTrue(ChessBoard[row, blackRookPosition.Y].Available);
        }

        [TestMethod]
        public void BlackRookCanMoveSouthIfUnblocked()
        {
            var blackKingPosition = new Point(1, 1);
            var blackRookPosition = new Point(8, 2);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            for (var row = blackRookPosition.X - 1; row > 0; row--)
                Assert.IsTrue(ChessBoard[row, blackRookPosition.Y].Available);
        }

        [TestMethod]
        public void BlackRookCanMoveEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 1);
            var blackRookPosition = new Point(1, 2);
            var whitePawnPosition = new Point(1, 5);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            for (var column = blackRookPosition.Y + 1; column < whitePawnPosition.Y; column++)
                Assert.IsTrue(ChessBoard[blackRookPosition.X, column].Available);

            for (var column = whitePawnPosition.Y + 1; column < 9; column++)
                Assert.IsFalse(ChessBoard[blackRookPosition.X, column].Available);
        }

        [TestMethod]
        public void BlackRookCanMoveWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(2, 1);
            var blackRookPosition = new Point(1, 8);
            var whitePawnPosition = new Point(1, 5);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            for (var column = blackRookPosition.Y - 1; column > whitePawnPosition.Y; column--)
                Assert.IsTrue(ChessBoard[blackRookPosition.X, column].Available);

            for (var column = whitePawnPosition.Y - 1; column > 0; column--)
                Assert.IsFalse(ChessBoard[blackRookPosition.X, column].Available);
        }

        [TestMethod]
        public void BlackRookCanMoveNorthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackRookPosition = new Point(1, 1);
            var whitePawnPosition = new Point(5, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            for (var row = blackRookPosition.X + 1; row < whitePawnPosition.X; row++)
                Assert.IsTrue(ChessBoard[row, blackRookPosition.Y].Available);

            for (var row = whitePawnPosition.X + 1; row < 9; row++)
                Assert.IsFalse(ChessBoard[row, blackRookPosition.Y].Available);
        }

        [TestMethod]
        public void BlackRookCanMoveSouthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackRookPosition = new Point(8, 1);
            var whitePawnPosition = new Point(5, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            for (var row = blackRookPosition.X - 1; row > whitePawnPosition.X; row--)
                Assert.IsTrue(ChessBoard[row, blackRookPosition.Y].Available);

            for (var row = whitePawnPosition.X - 1; row > 0; row--)
                Assert.IsFalse(ChessBoard[row, blackRookPosition.Y].Available);
        }

        [TestMethod]
        public void BlackRookCanMoveEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 1);
            var blackRookPosition = new Point(1, 2);
            var blackPawnPosition = new Point(1, 5);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            for (var column = blackRookPosition.Y + 1; column < blackPawnPosition.Y; column++)
                Assert.IsTrue(ChessBoard[blackRookPosition.X, column].Available);

            for (var column = blackPawnPosition.Y + 1; column < 9; column++)
                Assert.IsFalse(ChessBoard[blackRookPosition.X, column].Available);
        }

        [TestMethod]
        public void BlackRookCanMoveWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(2, 1);
            var blackRookPosition = new Point(1, 8);
            var blackPawnPosition = new Point(1, 5);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            for (var column = blackRookPosition.Y - 1; column > blackPawnPosition.Y; column--)
                Assert.IsTrue(ChessBoard[blackRookPosition.X, column].Available);

            for (var column = blackPawnPosition.Y - 1; column > 0; column--)
                Assert.IsFalse(ChessBoard[blackRookPosition.X, column].Available);
        }

        [TestMethod]
        public void BlackRookCanMoveNorthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackRookPosition = new Point(1, 1);
            var blackPawnPosition = new Point(5, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            for (var row = blackRookPosition.X + 1; row < blackPawnPosition.X; row++)
                Assert.IsTrue(ChessBoard[row, blackRookPosition.Y].Available);

            for (var row = blackPawnPosition.X + 1; row < 9; row++)
                Assert.IsFalse(ChessBoard[row, blackRookPosition.Y].Available);
        }

        [TestMethod]
        public void BlackRookCanMoveSouthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackRookPosition = new Point(8, 1);
            var blackPawnPosition = new Point(5, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            for (var row = blackRookPosition.X - 1; row > blackPawnPosition.X; row--)
                Assert.IsTrue(ChessBoard[row, blackRookPosition.Y].Available);

            for (var row = blackPawnPosition.X - 1; row > 0; row--)
                Assert.IsFalse(ChessBoard[row, blackRookPosition.Y].Available);
        }
    }
}