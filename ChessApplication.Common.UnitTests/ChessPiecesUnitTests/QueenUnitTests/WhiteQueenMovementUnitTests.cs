using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteQueenMovementUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthEastIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (int row = whiteQueenPosition.Row + 1, column = whiteQueenPosition.Column + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthEastIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (int row = whiteQueenPosition.Row - 1, column = whiteQueenPosition.Column + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthWestIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (int row = whiteQueenPosition.Row - 1, column = whiteQueenPosition.Column - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthWestIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (int row = whiteQueenPosition.Row + 1, column = whiteQueenPosition.Column - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(1, 1);
            var whitePawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (int row = whiteQueenPosition.Row + 1, column = whiteQueenPosition.Column + 1; row < whitePawnPosition.Row && column < whitePawnPosition.Column; row++, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.Row + 1, column = whitePawnPosition.Column + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(8, 1);
            var whitePawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (int row = whiteQueenPosition.Row - 1, column = whiteQueenPosition.Column + 1; row > whitePawnPosition.Row && column < whitePawnPosition.Column; row--, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.Row - 1, column = whitePawnPosition.Column + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(8, 8);
            var whitePawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (int row = whiteQueenPosition.Row - 1, column = whiteQueenPosition.Column - 1; row > whitePawnPosition.Row && column > whitePawnPosition.Column; row--, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.Row - 1, column = whitePawnPosition.Column - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(1, 8);
            var whitePawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (int row = whiteQueenPosition.Row + 1, column = whiteQueenPosition.Column - 1; row < whitePawnPosition.Row && column > whitePawnPosition.Column; row++, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.Row + 1, column = whitePawnPosition.Column - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(1, 1);
            var blackPawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (int row = whiteQueenPosition.Row + 1, column = whiteQueenPosition.Column + 1; row < blackPawnPosition.Row && column < blackPawnPosition.Column; row++, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.Row + 1, column = blackPawnPosition.Column + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(8, 1);
            var blackPawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (int row = whiteQueenPosition.Row - 1, column = whiteQueenPosition.Column + 1; row > blackPawnPosition.Row && column < blackPawnPosition.Column; row--, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.Row - 1, column = blackPawnPosition.Column + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(8, 8);
            var blackPawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (int row = whiteQueenPosition.Row - 1, column = whiteQueenPosition.Column - 1; row > blackPawnPosition.Row && column > blackPawnPosition.Column; row--, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.Row - 1, column = blackPawnPosition.Column - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(1, 8);
            var blackPawnPosition = new Position(4, 4);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (int row = whiteQueenPosition.Row + 1, column = whiteQueenPosition.Column - 1; row < blackPawnPosition.Row && column > blackPawnPosition.Column; row++, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.Row + 1, column = blackPawnPosition.Column - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsFalse(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteQueenCanMoveEastIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteQueenPosition = new Position(1, 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (var column = whiteQueenPosition.Column + 1; column < 9; column++)
                Assert.IsTrue(Chessboard[whiteQueenPosition.Row, column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveWestIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteQueenPosition = new Position(2, 8);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (var column = whiteQueenPosition.Column - 1; column > 0; column--)
                Assert.IsTrue(Chessboard[whiteQueenPosition.Row, column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteQueenPosition = new Position(1, 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (var row = whiteQueenPosition.Row + 1; row < 9; row++)
                Assert.IsTrue(Chessboard[row, whiteQueenPosition.Column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteQueenPosition = new Position(8, 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (var row = whiteQueenPosition.Row - 1; row > 0; row--)
                Assert.IsTrue(Chessboard[row, whiteQueenPosition.Column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteQueenPosition = new Position(1, 2);
            var whitePawnPosition = new Position(1, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (var column = whiteQueenPosition.Column + 1; column < whitePawnPosition.Column; column++)
                Assert.IsTrue(Chessboard[whiteQueenPosition.Row, column].Available);

            for (var column = whitePawnPosition.Column + 1; column < 9; column++)
                Assert.IsFalse(Chessboard[whiteQueenPosition.Row, column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(2, 1);
            var whiteQueenPosition = new Position(1, 8);
            var whitePawnPosition = new Position(1, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (var column = whiteQueenPosition.Column - 1; column > whitePawnPosition.Column; column--)
                Assert.IsTrue(Chessboard[whiteQueenPosition.Row, column].Available);

            for (var column = whitePawnPosition.Column - 1; column > 0; column--)
                Assert.IsFalse(Chessboard[whiteQueenPosition.Row, column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(1, 1);
            var whitePawnPosition = new Position(5, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (var row = whiteQueenPosition.Row + 1; row < whitePawnPosition.Row; row++)
                Assert.IsTrue(Chessboard[row, whiteQueenPosition.Column].Available);

            for (var row = whitePawnPosition.Row + 1; row < 9; row++)
                Assert.IsFalse(Chessboard[row, whiteQueenPosition.Column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(8, 1);
            var whitePawnPosition = new Position(5, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (var row = whiteQueenPosition.Row - 1; row > whitePawnPosition.Row; row--)
                Assert.IsTrue(Chessboard[row, whiteQueenPosition.Column].Available);

            for (var row = whitePawnPosition.Row - 1; row > 0; row--)
                Assert.IsFalse(Chessboard[row, whiteQueenPosition.Column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteQueenPosition = new Position(1, 2);
            var blackPawnPosition = new Position(1, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (var column = whiteQueenPosition.Column + 1; column < blackPawnPosition.Column; column++)
                Assert.IsTrue(Chessboard[whiteQueenPosition.Row, column].Available);

            for (var column = blackPawnPosition.Column + 1; column < 9; column++)
                Assert.IsFalse(Chessboard[whiteQueenPosition.Row, column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(2, 1);
            var whiteQueenPosition = new Position(1, 8);
            var blackPawnPosition = new Position(1, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (var column = whiteQueenPosition.Column - 1; column > blackPawnPosition.Column; column--)
                Assert.IsTrue(Chessboard[whiteQueenPosition.Row, column].Available);

            for (var column = blackPawnPosition.Column - 1; column > 0; column--)
                Assert.IsFalse(Chessboard[whiteQueenPosition.Row, column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveNorthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(1, 1);
            var blackPawnPosition = new Position(5, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (var row = whiteQueenPosition.Row + 1; row < blackPawnPosition.Row; row++)
                Assert.IsTrue(Chessboard[row, whiteQueenPosition.Column].Available);

            for (var row = blackPawnPosition.Row + 1; row < 9; row++)
                Assert.IsFalse(Chessboard[row, whiteQueenPosition.Column].Available);
        }

        [TestMethod]
        public void WhiteQueenCanMoveSouthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(8, 1);
            var blackPawnPosition = new Position(5, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            for (var row = whiteQueenPosition.Row - 1; row > blackPawnPosition.Row; row--)
                Assert.IsTrue(Chessboard[row, whiteQueenPosition.Column].Available);

            for (var row = blackPawnPosition.Row - 1; row > 0; row--)
                Assert.IsFalse(Chessboard[row, whiteQueenPosition.Column].Available);
        }
    }
}
