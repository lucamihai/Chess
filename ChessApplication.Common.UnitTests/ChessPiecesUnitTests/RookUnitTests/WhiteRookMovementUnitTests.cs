using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.RookUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteRookMovementUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteRookCanMoveEastIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteRookPosition = new Position(1, 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            for (var column = whiteRookPosition.Column + 1; column < 9; column++)
            {
                Assert.IsTrue(Chessboard[whiteRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveWestIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteRookPosition = new Position(2, 8);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            for (var column = whiteRookPosition.Column - 1; column > 0; column--)
            {
                Assert.IsTrue(Chessboard[whiteRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveNorthIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteRookPosition = new Position(1, 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            for (var row = whiteRookPosition.Row + 1; row < 9; row++)
            {
                Assert.IsTrue(Chessboard[row, whiteRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveSouthIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteRookPosition = new Position(8, 2);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            for (var row = whiteRookPosition.Row - 1; row > 0; row--)
            {
                Assert.IsTrue(Chessboard[row, whiteRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteRookPosition = new Position(1, 2);
            var whitePawnPosition = new Position(1, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            for (var column = whiteRookPosition.Column + 1; column < whitePawnPosition.Column; column++)
            {
                Assert.IsTrue(Chessboard[whiteRookPosition.Row, column].Available);
            }

            for (var column = whitePawnPosition.Column + 1; column < 9; column++)
            {
                Assert.IsFalse(Chessboard[whiteRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(2, 1);
            var whiteRookPosition = new Position(1, 8);
            var whitePawnPosition = new Position(1, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            for (var column = whiteRookPosition.Column - 1; column > whitePawnPosition.Column; column--)
            {
                Assert.IsTrue(Chessboard[whiteRookPosition.Row, column].Available);
            }

            for (var column = whitePawnPosition.Column - 1; column > 0; column--)
            {
                Assert.IsFalse(Chessboard[whiteRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveNorthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteRookPosition = new Position(1, 1);
            var whitePawnPosition = new Position(5, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            for (var row = whiteRookPosition.Row + 1; row < whitePawnPosition.Row; row++)
            {
                Assert.IsTrue(Chessboard[row, whiteRookPosition.Column].Available);
            }

            for (var row = whitePawnPosition.Row + 1; row < 9; row++)
            {
                Assert.IsFalse(Chessboard[row, whiteRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveSouthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteRookPosition = new Position(8, 1);
            var whitePawnPosition = new Position(5, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            for (var row = whiteRookPosition.Row - 1; row > whitePawnPosition.Row; row--)
            {
                Assert.IsTrue(Chessboard[row, whiteRookPosition.Column].Available);
            }

            for (var row = whitePawnPosition.Row - 1; row > 0; row--)
            {
                Assert.IsFalse(Chessboard[row, whiteRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteRookPosition = new Position(1, 2);
            var blackPawnPosition = new Position(1, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            for (var column = whiteRookPosition.Column + 1; column < blackPawnPosition.Column; column++)
            {
                Assert.IsTrue(Chessboard[whiteRookPosition.Row, column].Available);
            }

            for (var column = blackPawnPosition.Column + 1; column < 9; column++)
            {
                Assert.IsFalse(Chessboard[whiteRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(2, 1);
            var whiteRookPosition = new Position(1, 8);
            var blackPawnPosition = new Position(1, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            for (var column = whiteRookPosition.Column - 1; column > blackPawnPosition.Column; column--)
            {
                Assert.IsTrue(Chessboard[whiteRookPosition.Row, column].Available);
            }

            for (var column = blackPawnPosition.Column - 1; column > 0; column--)
            {
                Assert.IsFalse(Chessboard[whiteRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveNorthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteRookPosition = new Position(1, 1);
            var blackPawnPosition = new Position(5, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            for (var row = whiteRookPosition.Row + 1; row < blackPawnPosition.Row; row++)
            {
                Assert.IsTrue(Chessboard[row, whiteRookPosition.Column].Available);
            }

            for (var row = blackPawnPosition.Row + 1; row < 9; row++)
            {
                Assert.IsFalse(Chessboard[row, whiteRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveSouthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteRookPosition = new Position(8, 1);
            var blackPawnPosition = new Position(5, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            for (var row = whiteRookPosition.Row - 1; row > blackPawnPosition.Row; row--)
            {
                Assert.IsTrue(Chessboard[row, whiteRookPosition.Column].Available);
            }

            for (var row = blackPawnPosition.Row - 1; row > 0; row--)
            {
                Assert.IsFalse(Chessboard[row, whiteRookPosition.Column].Available);
            }
        }
    }
}