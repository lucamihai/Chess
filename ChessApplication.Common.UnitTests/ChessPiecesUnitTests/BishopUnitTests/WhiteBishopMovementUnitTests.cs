using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteBishopMovementUnitTests
    {
        private ChessboardClassic ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthEastIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            for (int row = whiteBishopPosition.X + 1, column = whiteBishopPosition.Y + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            for (int row = whiteBishopPosition.X - 1, column = whiteBishopPosition.Y + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            for (int row = whiteBishopPosition.X - 1, column = whiteBishopPosition.Y - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestIfUnblocked()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            for (int row = whiteBishopPosition.X + 1, column = whiteBishopPosition.Y - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsTrue(ChessBoard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(1, 1);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            for (int row = whiteBishopPosition.X + 1, column = whiteBishopPosition.Y + 1; row < whitePawnPosition.X && column < whitePawnPosition.Y; row++, column++)
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
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(8, 1);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            for (int row = whiteBishopPosition.X - 1, column = whiteBishopPosition.Y + 1; row > whitePawnPosition.X && column < whitePawnPosition.Y; row--, column++)
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
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(8, 8);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            for (int row = whiteBishopPosition.X - 1, column = whiteBishopPosition.Y - 1; row > whitePawnPosition.X && column > whitePawnPosition.Y; row--, column--)
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
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(1, 8);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            for (int row = whiteBishopPosition.X + 1, column = whiteBishopPosition.Y - 1; row < whitePawnPosition.X && column > whitePawnPosition.Y; row++, column--)
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
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(1, 1);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            for (int row = whiteBishopPosition.X + 1, column = whiteBishopPosition.Y + 1; row < blackPawnPosition.X && column < blackPawnPosition.Y; row++, column++)
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
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(8, 1);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            for (int row = whiteBishopPosition.X - 1, column = whiteBishopPosition.Y + 1; row > blackPawnPosition.X && column < blackPawnPosition.Y; row--, column++)
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
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(8, 8);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            for (int row = whiteBishopPosition.X - 1, column = whiteBishopPosition.Y - 1; row > blackPawnPosition.X && column > blackPawnPosition.Y; row--, column--)
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
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(1, 8);
            var blackPawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            for (int row = whiteBishopPosition.X + 1, column = whiteBishopPosition.Y - 1; row < blackPawnPosition.X && column > blackPawnPosition.Y; row++, column--)
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
