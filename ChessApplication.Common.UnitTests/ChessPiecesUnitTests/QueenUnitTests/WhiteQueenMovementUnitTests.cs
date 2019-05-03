using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteQueenMovementUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthEastIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (int row = whiteQueenPosition.X + 1, column = whiteQueenPosition.Y + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthEastIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (int row = whiteQueenPosition.X - 1, column = whiteQueenPosition.Y + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthWestIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (int row = whiteQueenPosition.X - 1, column = whiteQueenPosition.Y - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthWestIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (int row = whiteQueenPosition.X + 1, column = whiteQueenPosition.Y - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(1, 1);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (int row = whiteQueenPosition.X + 1, column = whiteQueenPosition.Y + 1; row < whitePawnPosition.X && column < whitePawnPosition.Y; row++, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = whitePawnPosition.X + 1, column = whitePawnPosition.Y + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(8, 1);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (int row = whiteQueenPosition.X - 1, column = whiteQueenPosition.Y + 1; row > whitePawnPosition.X && column < whitePawnPosition.Y; row--, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = whitePawnPosition.X - 1, column = whitePawnPosition.Y + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(8, 8);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (int row = whiteQueenPosition.X - 1, column = whiteQueenPosition.Y - 1; row > whitePawnPosition.X && column > whitePawnPosition.Y; row--, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = whitePawnPosition.X - 1, column = whitePawnPosition.Y - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(1, 8);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (int row = whiteQueenPosition.X + 1, column = whiteQueenPosition.Y - 1; row < whitePawnPosition.X && column > whitePawnPosition.Y; row++, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = whitePawnPosition.X + 1, column = whitePawnPosition.Y - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(1, 1);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (int row = whiteQueenPosition.X + 1, column = whiteQueenPosition.Y + 1; row < blackPawnPosition.X && column < blackPawnPosition.Y; row++, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = blackPawnPosition.X + 1, column = blackPawnPosition.Y + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(8, 1);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (int row = whiteQueenPosition.X - 1, column = whiteQueenPosition.Y + 1; row > blackPawnPosition.X && column < blackPawnPosition.Y; row--, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = blackPawnPosition.X - 1, column = blackPawnPosition.Y + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(8, 8);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (int row = whiteQueenPosition.X - 1, column = whiteQueenPosition.Y - 1; row > blackPawnPosition.X && column > blackPawnPosition.Y; row--, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = blackPawnPosition.X - 1, column = blackPawnPosition.Y - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(1, 8);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (int row = whiteQueenPosition.X + 1, column = whiteQueenPosition.Y - 1; row < blackPawnPosition.X && column > blackPawnPosition.Y; row++, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = blackPawnPosition.X + 1, column = blackPawnPosition.Y - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveEastIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteQueenPosition = new Point(1, 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (var column = whiteQueenPosition.Y + 1; column < 9; column++)
                Assert.IsTrue(ChessBoard[whiteQueenPosition.X, column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveWestIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteQueenPosition = new Point(2, 8);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (var column = whiteQueenPosition.Y - 1; column > 0; column--)
                Assert.IsTrue(ChessBoard[whiteQueenPosition.X, column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteQueenPosition = new Point(1, 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (var row = whiteQueenPosition.X + 1; row < 9; row++)
                Assert.IsTrue(ChessBoard[row, whiteQueenPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteQueenPosition = new Point(8, 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (var row = whiteQueenPosition.X - 1; row > 0; row--)
                Assert.IsTrue(ChessBoard[row, whiteQueenPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteQueenPosition = new Point(1, 2);
            var whitePawnPosition = new Point(1, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (var column = whiteQueenPosition.Y + 1; column < whitePawnPosition.Y; column++)
                Assert.IsTrue(ChessBoard[whiteQueenPosition.X, column].Available);

            for (var column = whitePawnPosition.Y + 1; column < 9; column++)
                Assert.IsFalse(ChessBoard[whiteQueenPosition.X, column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(2, 1);
            var whiteQueenPosition = new Point(1, 8);
            var whitePawnPosition = new Point(1, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (var column = whiteQueenPosition.Y - 1; column > whitePawnPosition.Y; column--)
                Assert.IsTrue(ChessBoard[whiteQueenPosition.X, column].Available);

            for (var column = whitePawnPosition.Y - 1; column > 0; column--)
                Assert.IsFalse(ChessBoard[whiteQueenPosition.X, column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(1, 1);
            var whitePawnPosition = new Point(5, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (var row = whiteQueenPosition.X + 1; row < whitePawnPosition.X; row++)
                Assert.IsTrue(ChessBoard[row, whiteQueenPosition.Y].Available);

            for (var row = whitePawnPosition.X + 1; row < 9; row++)
                Assert.IsFalse(ChessBoard[row, whiteQueenPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(8, 1);
            var whitePawnPosition = new Point(5, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (var row = whiteQueenPosition.X - 1; row > whitePawnPosition.X; row--)
                Assert.IsTrue(ChessBoard[row, whiteQueenPosition.Y].Available);

            for (var row = whitePawnPosition.X - 1; row > 0; row--)
                Assert.IsFalse(ChessBoard[row, whiteQueenPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 1);
            var whiteQueenPosition = new Point(1, 2);
            var blackPawnPosition = new Point(1, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (var column = whiteQueenPosition.Y + 1; column < blackPawnPosition.Y; column++)
                Assert.IsTrue(ChessBoard[whiteQueenPosition.X, column].Available);

            for (var column = blackPawnPosition.Y + 1; column < 9; column++)
                Assert.IsFalse(ChessBoard[whiteQueenPosition.X, column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(2, 1);
            var whiteQueenPosition = new Point(1, 8);
            var blackPawnPosition = new Point(1, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (var column = whiteQueenPosition.Y - 1; column > blackPawnPosition.Y; column--)
                Assert.IsTrue(ChessBoard[whiteQueenPosition.X, column].Available);

            for (var column = blackPawnPosition.Y - 1; column > 0; column--)
                Assert.IsFalse(ChessBoard[whiteQueenPosition.X, column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(1, 1);
            var blackPawnPosition = new Point(5, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (var row = whiteQueenPosition.X + 1; row < blackPawnPosition.X; row++)
                Assert.IsTrue(ChessBoard[row, whiteQueenPosition.Y].Available);

            for (var row = blackPawnPosition.X + 1; row < 9; row++)
                Assert.IsFalse(ChessBoard[row, whiteQueenPosition.Y].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(8, 1);
            var blackPawnPosition = new Point(5, 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            for (var row = whiteQueenPosition.X - 1; row > blackPawnPosition.X; row--)
                Assert.IsTrue(ChessBoard[row, whiteQueenPosition.Y].Available);

            for (var row = blackPawnPosition.X - 1; row > 0; row--)
                Assert.IsFalse(ChessBoard[row, whiteQueenPosition.Y].Available);
        }
    }
}
