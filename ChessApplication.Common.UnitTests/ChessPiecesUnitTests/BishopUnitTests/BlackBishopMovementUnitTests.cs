using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackBishopMovementUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackBishopCanMoveNorthEastIfUnblocked()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.X + 1, column = blackBishopPosition.Y + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastIfUnblocked()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.X - 1, column = blackBishopPosition.Y + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestIfUnblocked()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.X - 1, column = blackBishopPosition.Y - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestIfUnblocked()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.X + 1, column = blackBishopPosition.Y - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(1, 1);
            var whitePawnPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.X + 1, column = blackBishopPosition.Y + 1; row < whitePawnPosition.X && column < whitePawnPosition.Y; row++, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.X + 1, column = whitePawnPosition.Y + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(8, 1);
            var whitePawnPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.X - 1, column = blackBishopPosition.Y + 1; row > whitePawnPosition.X && column < whitePawnPosition.Y; row--, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.X - 1, column = whitePawnPosition.Y + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(8, 8);
            var whitePawnPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.X - 1, column = blackBishopPosition.Y - 1; row > whitePawnPosition.X && column > whitePawnPosition.Y; row--, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.X - 1, column = whitePawnPosition.Y - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(1, 8);
            var whitePawnPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.X + 1, column = blackBishopPosition.Y - 1; row < whitePawnPosition.X && column > whitePawnPosition.Y; row++, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.X + 1, column = whitePawnPosition.Y - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(1, 1);
            var blackPawnPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.X + 1, column = blackBishopPosition.Y + 1; row < blackPawnPosition.X && column < blackPawnPosition.Y; row++, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.X + 1, column = blackPawnPosition.Y + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(8, 1);
            var blackPawnPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.X - 1, column = blackBishopPosition.Y + 1; row > blackPawnPosition.X && column < blackPawnPosition.Y; row--, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.X - 1, column = blackPawnPosition.Y + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(8, 8);
            var blackPawnPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.X - 1, column = blackBishopPosition.Y - 1; row > blackPawnPosition.X && column > blackPawnPosition.Y; row--, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.X - 1, column = blackPawnPosition.Y - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Point(1, 2);
            var blackBishopPosition = new Point(1, 8);
            var blackPawnPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.X + 1, column = blackBishopPosition.Y - 1; row < blackPawnPosition.X && column > blackPawnPosition.Y; row++, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.X + 1, column = blackPawnPosition.Y - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }
    }
}
