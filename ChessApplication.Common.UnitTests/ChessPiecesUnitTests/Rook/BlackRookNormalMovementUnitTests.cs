using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.Rook
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackRookNormalMovementUnitTests
    {
        private Box[,] ChessBoard;

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

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            for (int column = blackRookPosition.Y + 1; column < 9; column++)
            {
                Assert.IsTrue(ChessBoard[blackRookPosition.X, column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveWestIfUnblocked()
        {
            var blackKingPosition = new Point(1, 1);
            var blackRookPosition = new Point(2, 8);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            for (int column = blackRookPosition.Y - 1; column > 0; column--)
            {
                Assert.IsTrue(ChessBoard[blackRookPosition.X, column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveNorthIfUnblocked()
        {
            var blackKingPosition = new Point(1, 1);
            var blackRookPosition = new Point(1, 2);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            for (int row = blackRookPosition.X + 1; row < 9; row++)
            {
                Assert.IsTrue(ChessBoard[row, blackRookPosition.Y].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveSouthIfUnblocked()
        {
            var blackKingPosition = new Point(1, 1);
            var blackRookPosition = new Point(8, 2);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            for (int row = blackRookPosition.X - 1; row > 0; row--)
            {
                Assert.IsTrue(ChessBoard[row, blackRookPosition.Y].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 1);
            var blackRookPosition = new Point(1, 2);
            var whitePawnPosition = new Point(1, 5);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            for (int column = blackRookPosition.Y + 1; column < whitePawnPosition.Y; column++)
            {
                Assert.IsTrue(ChessBoard[blackRookPosition.X, column].Available);
            }

            for (int column = whitePawnPosition.Y + 1; column < 9; column++)
            {
                Assert.IsFalse(ChessBoard[blackRookPosition.X, column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(2, 1);
            var blackRookPosition = new Point(1, 8);
            var whitePawnPosition = new Point(1, 5);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            for (int column = blackRookPosition.Y - 1; column > whitePawnPosition.Y; column--)
            {
                Assert.IsTrue(ChessBoard[blackRookPosition.X, column].Available);
            }

            for (int column = whitePawnPosition.Y - 1; column > 0; column--)
            {
                Assert.IsFalse(ChessBoard[blackRookPosition.X, column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveNorthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackRookPosition = new Point(1, 1);
            var whitePawnPosition = new Point(5, 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            for (int row = blackRookPosition.X + 1; row < whitePawnPosition.X; row++)
            {
                Assert.IsTrue(ChessBoard[row, blackRookPosition.Y].Available);
            }

            for (int row = whitePawnPosition.X + 1; row < 9; row++)
            {
                Assert.IsFalse(ChessBoard[row, blackRookPosition.Y].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveSouthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackRookPosition = new Point(8, 1);
            var whitePawnPosition = new Point(5, 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            for (int row = blackRookPosition.X - 1; row > whitePawnPosition.X; row--)
            {
                Assert.IsTrue(ChessBoard[row, blackRookPosition.Y].Available);
            }

            for (int row = whitePawnPosition.X - 1; row > 0; row--)
            {
                Assert.IsFalse(ChessBoard[row, blackRookPosition.Y].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 1);
            var blackRookPosition = new Point(1, 2);
            var blackPawnPosition = new Point(1, 5);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            for (int column = blackRookPosition.Y + 1; column < blackPawnPosition.Y; column++)
            {
                Assert.IsTrue(ChessBoard[blackRookPosition.X, column].Available);
            }

            for (int column = blackPawnPosition.Y + 1; column < 9; column++)
            {
                Assert.IsFalse(ChessBoard[blackRookPosition.X, column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(2, 1);
            var blackRookPosition = new Point(1, 8);
            var blackPawnPosition = new Point(1, 5);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            for (int column = blackRookPosition.Y - 1; column > blackPawnPosition.Y; column--)
            {
                Assert.IsTrue(ChessBoard[blackRookPosition.X, column].Available);
            }

            for (int column = blackPawnPosition.Y - 1; column > 0; column--)
            {
                Assert.IsFalse(ChessBoard[blackRookPosition.X, column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveNorthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackRookPosition = new Point(1, 1);
            var blackPawnPosition = new Point(5, 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            for (int row = blackRookPosition.X + 1; row < blackPawnPosition.X; row++)
            {
                Assert.IsTrue(ChessBoard[row, blackRookPosition.Y].Available);
            }

            for (int row = blackPawnPosition.X + 1; row < 9; row++)
            {
                Assert.IsFalse(ChessBoard[row, blackRookPosition.Y].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveSouthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackRookPosition = new Point(8, 1);
            var blackPawnPosition = new Point(5, 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            for (int row = blackRookPosition.X - 1; row > blackPawnPosition.X; row--)
            {
                Assert.IsTrue(ChessBoard[row, blackRookPosition.Y].Available);
            }

            for (int row = blackPawnPosition.X - 1; row > 0; row--)
            {
                Assert.IsFalse(ChessBoard[row, blackRookPosition.Y].Available);
            }
        }
    }
}
