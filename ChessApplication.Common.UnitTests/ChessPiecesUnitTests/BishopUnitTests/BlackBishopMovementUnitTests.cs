using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackBishopMovementUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackBishopCanMoveNorthEastIfUnblocked()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            for (int row = blackBishopPosition.X + 1, column = blackBishopPosition.Y + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastIfUnblocked()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            for (int row = blackBishopPosition.X - 1, column = blackBishopPosition.Y + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestIfUnblocked()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            for (int row = blackBishopPosition.X - 1, column = blackBishopPosition.Y - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestIfUnblocked()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            for (int row = blackBishopPosition.X + 1, column = blackBishopPosition.Y - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(1, 1);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            for (int row = blackBishopPosition.X + 1, column = blackBishopPosition.Y + 1; row < whitePawnPosition.X && column < whitePawnPosition.Y; row++, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = whitePawnPosition.X + 1, column = whitePawnPosition.Y + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(8, 1);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            for (int row = blackBishopPosition.X - 1, column = blackBishopPosition.Y + 1; row > whitePawnPosition.X && column < whitePawnPosition.Y; row--, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = whitePawnPosition.X - 1, column = whitePawnPosition.Y + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(8, 8);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            for (int row = blackBishopPosition.X - 1, column = blackBishopPosition.Y - 1; row > whitePawnPosition.X && column > whitePawnPosition.Y; row--, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = whitePawnPosition.X - 1, column = whitePawnPosition.Y - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(1, 8);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            for (int row = blackBishopPosition.X + 1, column = blackBishopPosition.Y - 1; row < whitePawnPosition.X && column > whitePawnPosition.Y; row++, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = whitePawnPosition.X + 1, column = whitePawnPosition.Y - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(1, 1);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            for (int row = blackBishopPosition.X + 1, column = blackBishopPosition.Y + 1; row < blackPawnPosition.X && column < blackPawnPosition.Y; row++, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = blackPawnPosition.X + 1, column = blackPawnPosition.Y + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(8, 1);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            for (int row = blackBishopPosition.X - 1, column = blackBishopPosition.Y + 1; row > blackPawnPosition.X && column < blackPawnPosition.Y; row--, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = blackPawnPosition.X - 1, column = blackPawnPosition.Y + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(8, 8);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            for (int row = blackBishopPosition.X - 1, column = blackBishopPosition.Y - 1; row > blackPawnPosition.X && column > blackPawnPosition.Y; row--, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = blackPawnPosition.X - 1, column = blackPawnPosition.Y - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(1, 8);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            for (int row = blackBishopPosition.X + 1, column = blackBishopPosition.Y - 1; row < blackPawnPosition.X && column > blackPawnPosition.Y; row++, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = blackPawnPosition.X + 1, column = blackPawnPosition.Y - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }
    }
}
