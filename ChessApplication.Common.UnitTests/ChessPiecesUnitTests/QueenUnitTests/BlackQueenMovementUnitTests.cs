using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackQueenMovementUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackQueenCanMoveNorthEastIfUnblocked()
        {
            var blackKingPosition = new Point(1, 2);
            var blackQueenPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (int row = blackQueenPosition.X + 1, column = blackQueenPosition.Y + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastIfUnblocked()
        {
            var blackKingPosition = new Point(1, 2);
            var blackQueenPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (int row = blackQueenPosition.X - 1, column = blackQueenPosition.Y + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestIfUnblocked()
        {
            var blackKingPosition = new Point(1, 2);
            var blackQueenPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (int row = blackQueenPosition.X - 1, column = blackQueenPosition.Y - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestIfUnblocked()
        {
            var blackKingPosition = new Point(1, 2);
            var blackQueenPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (int row = blackQueenPosition.X + 1, column = blackQueenPosition.Y - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackQueenPosition = new Point(1, 1);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (int row = blackQueenPosition.X + 1, column = blackQueenPosition.Y + 1; row < whitePawnPosition.X && column < whitePawnPosition.Y; row++, column++)
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
            var blackQueenPosition = new Point(8, 1);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (int row = blackQueenPosition.X - 1, column = blackQueenPosition.Y + 1; row > whitePawnPosition.X && column < whitePawnPosition.Y; row--, column++)
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
            var blackQueenPosition = new Point(8, 8);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (int row = blackQueenPosition.X - 1, column = blackQueenPosition.Y - 1; row > whitePawnPosition.X && column > whitePawnPosition.Y; row--, column--)
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
            var blackQueenPosition = new Point(1, 8);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (int row = blackQueenPosition.X + 1, column = blackQueenPosition.Y - 1; row < whitePawnPosition.X && column > whitePawnPosition.Y; row++, column--)
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
            var blackQueenPosition = new Point(1, 1);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (int row = blackQueenPosition.X + 1, column = blackQueenPosition.Y + 1; row < blackPawnPosition.X && column < blackPawnPosition.Y; row++, column++)
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
            var blackQueenPosition = new Point(8, 1);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (int row = blackQueenPosition.X - 1, column = blackQueenPosition.Y + 1; row > blackPawnPosition.X && column < blackPawnPosition.Y; row--, column++)
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
            var blackQueenPosition = new Point(8, 8);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (int row = blackQueenPosition.X - 1, column = blackQueenPosition.Y - 1; row > blackPawnPosition.X && column > blackPawnPosition.Y; row--, column--)
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
            var blackQueenPosition = new Point(1, 8);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (int row = blackQueenPosition.X + 1, column = blackQueenPosition.Y - 1; row < blackPawnPosition.X && column > blackPawnPosition.Y; row++, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }

            for (int row = blackPawnPosition.X + 1, column = blackPawnPosition.Y - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsFalse(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void BlackQueenCanMoveEastIfUnblocked()
        {
            var blackKingPosition = new Point(1, 1);
            var blackQueenPosition = new Point(1, 2);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (var column = blackQueenPosition.Y + 1; column < 9; column++)
                Assert.IsTrue(ChessBoard[blackQueenPosition.X, column].Available);
        }

        [TestMethod]
        public void BlackQueenCanMoveWestIfUnblocked()
        {
            var blackKingPosition = new Point(1, 1);
            var blackQueenPosition = new Point(2, 8);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (var column = blackQueenPosition.Y - 1; column > 0; column--)
                Assert.IsTrue(ChessBoard[blackQueenPosition.X, column].Available);
        }

        [TestMethod]
        public void BlackQueenCanMoveNorthIfUnblocked()
        {
            var blackKingPosition = new Point(1, 1);
            var blackQueenPosition = new Point(1, 2);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (var row = blackQueenPosition.X + 1; row < 9; row++)
                Assert.IsTrue(ChessBoard[row, blackQueenPosition.Y].Available);
        }

        [TestMethod]
        public void BlackQueenCanMoveSouthIfUnblocked()
        {
            var blackKingPosition = new Point(1, 1);
            var blackQueenPosition = new Point(8, 2);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (var row = blackQueenPosition.X - 1; row > 0; row--)
                Assert.IsTrue(ChessBoard[row, blackQueenPosition.Y].Available);
        }

        [TestMethod]
        public void BlackQueenCanMoveEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 1);
            var blackQueenPosition = new Point(1, 2);
            var whitePawnPosition = new Point(1, 5);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (var column = blackQueenPosition.Y + 1; column < whitePawnPosition.Y; column++)
                Assert.IsTrue(ChessBoard[blackQueenPosition.X, column].Available);

            for (var column = whitePawnPosition.Y + 1; column < 9; column++)
                Assert.IsFalse(ChessBoard[blackQueenPosition.X, column].Available);
        }

        [TestMethod]
        public void BlackQueenCanMoveWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(2, 1);
            var blackQueenPosition = new Point(1, 8);
            var whitePawnPosition = new Point(1, 5);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (var column = blackQueenPosition.Y - 1; column > whitePawnPosition.Y; column--)
                Assert.IsTrue(ChessBoard[blackQueenPosition.X, column].Available);

            for (var column = whitePawnPosition.Y - 1; column > 0; column--)
                Assert.IsFalse(ChessBoard[blackQueenPosition.X, column].Available);
        }

        [TestMethod]
        public void BlackQueenCanMoveNorthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackQueenPosition = new Point(1, 1);
            var whitePawnPosition = new Point(5, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (var row = blackQueenPosition.X + 1; row < whitePawnPosition.X; row++)
                Assert.IsTrue(ChessBoard[row, blackQueenPosition.Y].Available);

            for (var row = whitePawnPosition.X + 1; row < 9; row++)
                Assert.IsFalse(ChessBoard[row, blackQueenPosition.Y].Available);
        }

        [TestMethod]
        public void BlackQueenCanMoveSouthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackQueenPosition = new Point(8, 1);
            var whitePawnPosition = new Point(5, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (var row = blackQueenPosition.X - 1; row > whitePawnPosition.X; row--)
                Assert.IsTrue(ChessBoard[row, blackQueenPosition.Y].Available);

            for (var row = whitePawnPosition.X - 1; row > 0; row--)
                Assert.IsFalse(ChessBoard[row, blackQueenPosition.Y].Available);
        }

        [TestMethod]
        public void BlackQueenCanMoveEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 1);
            var blackQueenPosition = new Point(1, 2);
            var blackPawnPosition = new Point(1, 5);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (var column = blackQueenPosition.Y + 1; column < blackPawnPosition.Y; column++)
                Assert.IsTrue(ChessBoard[blackQueenPosition.X, column].Available);

            for (var column = blackPawnPosition.Y + 1; column < 9; column++)
                Assert.IsFalse(ChessBoard[blackQueenPosition.X, column].Available);
        }

        [TestMethod]
        public void BlackQueenCanMoveWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(2, 1);
            var blackQueenPosition = new Point(1, 8);
            var blackPawnPosition = new Point(1, 5);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (var column = blackQueenPosition.Y - 1; column > blackPawnPosition.Y; column--)
                Assert.IsTrue(ChessBoard[blackQueenPosition.X, column].Available);

            for (var column = blackPawnPosition.Y - 1; column > 0; column--)
                Assert.IsFalse(ChessBoard[blackQueenPosition.X, column].Available);
        }

        [TestMethod]
        public void BlackQueenCanMoveNorthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackQueenPosition = new Point(1, 1);
            var blackPawnPosition = new Point(5, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (var row = blackQueenPosition.X + 1; row < blackPawnPosition.X; row++)
                Assert.IsTrue(ChessBoard[row, blackQueenPosition.Y].Available);

            for (var row = blackPawnPosition.X + 1; row < 9; row++)
                Assert.IsFalse(ChessBoard[row, blackQueenPosition.Y].Available);
        }

        [TestMethod]
        public void BlackQueenCanMoveSouthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackQueenPosition = new Point(8, 1);
            var blackPawnPosition = new Point(5, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            for (var row = blackQueenPosition.X - 1; row > blackPawnPosition.X; row--)
                Assert.IsTrue(ChessBoard[row, blackQueenPosition.Y].Available);

            for (var row = blackPawnPosition.X - 1; row > 0; row--)
                Assert.IsFalse(ChessBoard[row, blackQueenPosition.Y].Available);
        }
    }
    
}
