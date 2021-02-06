using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteBishopMovementUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthEastIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            for (int row = whiteBishopPosition.Row + 1, column = whiteBishopPosition.Column + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            for (int row = whiteBishopPosition.Row - 1, column = whiteBishopPosition.Column + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            for (int row = whiteBishopPosition.Row - 1, column = whiteBishopPosition.Column - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            for (int row = whiteBishopPosition.Row + 1, column = whiteBishopPosition.Column - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(1, 1);
            var whitePawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            for (int row = whiteBishopPosition.Row + 1, column = whiteBishopPosition.Column + 1; row < whitePawnPosition.Row && column < whitePawnPosition.Column; row++, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.Row + 1, column = whitePawnPosition.Column + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(8, 1);
            var whitePawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            for (int row = whiteBishopPosition.Row - 1, column = whiteBishopPosition.Column + 1; row > whitePawnPosition.Row && column < whitePawnPosition.Column; row--, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.Row - 1, column = whitePawnPosition.Column + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(8, 8);
            var whitePawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            for (int row = whiteBishopPosition.Row - 1, column = whiteBishopPosition.Column - 1; row > whitePawnPosition.Row && column > whitePawnPosition.Column; row--, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.Row - 1, column = whitePawnPosition.Column - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(1, 8);
            var whitePawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            for (int row = whiteBishopPosition.Row + 1, column = whiteBishopPosition.Column - 1; row < whitePawnPosition.Row && column > whitePawnPosition.Column; row++, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.Row + 1, column = whitePawnPosition.Column - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(1, 1);
            var blackPawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            for (int row = whiteBishopPosition.Row + 1, column = whiteBishopPosition.Column + 1; row < blackPawnPosition.Row && column < blackPawnPosition.Column; row++, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.Row + 1, column = blackPawnPosition.Column + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(8, 1);
            var blackPawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            for (int row = whiteBishopPosition.Row - 1, column = whiteBishopPosition.Column + 1; row > blackPawnPosition.Row && column < blackPawnPosition.Column; row--, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.Row - 1, column = blackPawnPosition.Column + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(8, 8);
            var blackPawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            for (int row = whiteBishopPosition.Row - 1, column = whiteBishopPosition.Column - 1; row > blackPawnPosition.Row && column > blackPawnPosition.Column; row--, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.Row - 1, column = blackPawnPosition.Column - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteBishopPosition = new Position(1, 8);
            var blackPawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            for (int row = whiteBishopPosition.Row + 1, column = whiteBishopPosition.Column - 1; row < blackPawnPosition.Row && column > blackPawnPosition.Column; row++, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.Row + 1, column = blackPawnPosition.Column - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

    }
}
