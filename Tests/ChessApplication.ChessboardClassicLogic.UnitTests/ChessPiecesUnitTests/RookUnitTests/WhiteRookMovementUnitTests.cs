using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.RookUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteRookMovementUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteRookCanMoveEastIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteRookPosition = new Position(1, 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            for (var column = whiteRookPosition.Column + 1; column < 9; column++)
            {
                Assert.IsTrue(chessboard[whiteRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveWestIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteRookPosition = new Position(2, 8);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            for (var column = whiteRookPosition.Column - 1; column > 0; column--)
            {
                Assert.IsTrue(chessboard[whiteRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveNorthIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteRookPosition = new Position(1, 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            for (var row = whiteRookPosition.Row + 1; row < 9; row++)
            {
                Assert.IsTrue(chessboard[row, whiteRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveSouthIfUnblocked()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteRookPosition = new Position(8, 2);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            for (var row = whiteRookPosition.Row - 1; row > 0; row--)
            {
                Assert.IsTrue(chessboard[row, whiteRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteRookPosition = new Position(1, 2);
            var whitePawnPosition = new Position(1, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            for (var column = whiteRookPosition.Column + 1; column < whitePawnPosition.Column; column++)
            {
                Assert.IsTrue(chessboard[whiteRookPosition.Row, column].Available);
            }

            for (var column = whitePawnPosition.Column + 1; column < 9; column++)
            {
                Assert.IsFalse(chessboard[whiteRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(2, 1);
            var whiteRookPosition = new Position(1, 8);
            var whitePawnPosition = new Position(1, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            for (var column = whiteRookPosition.Column - 1; column > whitePawnPosition.Column; column--)
            {
                Assert.IsTrue(chessboard[whiteRookPosition.Row, column].Available);
            }

            for (var column = whitePawnPosition.Column - 1; column > 0; column--)
            {
                Assert.IsFalse(chessboard[whiteRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveNorthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteRookPosition = new Position(1, 1);
            var whitePawnPosition = new Position(5, 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            for (var row = whiteRookPosition.Row + 1; row < whitePawnPosition.Row; row++)
            {
                Assert.IsTrue(chessboard[row, whiteRookPosition.Column].Available);
            }

            for (var row = whitePawnPosition.Row + 1; row < 9; row++)
            {
                Assert.IsFalse(chessboard[row, whiteRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveSouthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteRookPosition = new Position(8, 1);
            var whitePawnPosition = new Position(5, 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            for (var row = whiteRookPosition.Row - 1; row > whitePawnPosition.Row; row--)
            {
                Assert.IsTrue(chessboard[row, whiteRookPosition.Column].Available);
            }

            for (var row = whitePawnPosition.Row - 1; row > 0; row--)
            {
                Assert.IsFalse(chessboard[row, whiteRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 1);
            var whiteRookPosition = new Position(1, 2);
            var blackPawnPosition = new Position(1, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            for (var column = whiteRookPosition.Column + 1; column < blackPawnPosition.Column; column++)
            {
                Assert.IsTrue(chessboard[whiteRookPosition.Row, column].Available);
            }

            for (var column = blackPawnPosition.Column + 1; column < 9; column++)
            {
                Assert.IsFalse(chessboard[whiteRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(2, 1);
            var whiteRookPosition = new Position(1, 8);
            var blackPawnPosition = new Position(1, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            for (var column = whiteRookPosition.Column - 1; column > blackPawnPosition.Column; column--)
            {
                Assert.IsTrue(chessboard[whiteRookPosition.Row, column].Available);
            }

            for (var column = blackPawnPosition.Column - 1; column > 0; column--)
            {
                Assert.IsFalse(chessboard[whiteRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveNorthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteRookPosition = new Position(1, 1);
            var blackPawnPosition = new Position(5, 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            for (var row = whiteRookPosition.Row + 1; row < blackPawnPosition.Row; row++)
            {
                Assert.IsTrue(chessboard[row, whiteRookPosition.Column].Available);
            }

            for (var row = blackPawnPosition.Row + 1; row < 9; row++)
            {
                Assert.IsFalse(chessboard[row, whiteRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void WhiteRookCanMoveSouthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var whiteKingPosition = new Position(1, 2);
            var whiteRookPosition = new Position(8, 1);
            var blackPawnPosition = new Position(5, 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            for (var row = whiteRookPosition.Row - 1; row > blackPawnPosition.Row; row--)
            {
                Assert.IsTrue(chessboard[row, whiteRookPosition.Column].Available);
            }

            for (var row = blackPawnPosition.Row - 1; row > 0; row--)
            {
                Assert.IsFalse(chessboard[row, whiteRookPosition.Column].Available);
            }
        }
    }
}