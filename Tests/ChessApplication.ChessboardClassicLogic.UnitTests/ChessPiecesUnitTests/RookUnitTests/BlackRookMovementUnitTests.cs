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
    public class BlackRookMovementUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackRookCanMoveEastIfUnblocked()
        {
            var blackKingPosition = new Position(1, 1);
            var blackRookPosition = new Position(1, 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            for (var column = blackRookPosition.Column + 1; column < 9; column++)
            {
                Assert.IsTrue(chessboard[blackRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveWestIfUnblocked()
        {
            var blackKingPosition = new Position(1, 1);
            var blackRookPosition = new Position(2, 8);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            for (var column = blackRookPosition.Column - 1; column > 0; column--)
            {
                Assert.IsTrue(chessboard[blackRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveNorthIfUnblocked()
        {
            var blackKingPosition = new Position(1, 1);
            var blackRookPosition = new Position(1, 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            for (var row = blackRookPosition.Row + 1; row < 9; row++)
            {
                Assert.IsTrue(chessboard[row, blackRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveSouthIfUnblocked()
        {
            var blackKingPosition = new Position(1, 1);
            var blackRookPosition = new Position(8, 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            for (var row = blackRookPosition.Row - 1; row > 0; row--)
            {
                Assert.IsTrue(chessboard[row, blackRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 1);
            var blackRookPosition = new Position(1, 2);
            var whitePawnPosition = new Position(1, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            for (var column = blackRookPosition.Column + 1; column < whitePawnPosition.Column; column++)
            {
                Assert.IsTrue(chessboard[blackRookPosition.Row, column].Available);
            }

            for (var column = whitePawnPosition.Column + 1; column < 9; column++)
            {
                Assert.IsFalse(chessboard[blackRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(2, 1);
            var blackRookPosition = new Position(1, 8);
            var whitePawnPosition = new Position(1, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            for (var column = blackRookPosition.Column - 1; column > whitePawnPosition.Column; column--)
            {
                Assert.IsTrue(chessboard[blackRookPosition.Row, column].Available);
            }

            for (var column = whitePawnPosition.Column - 1; column > 0; column--)
            {
                Assert.IsFalse(chessboard[blackRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveNorthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackRookPosition = new Position(1, 1);
            var whitePawnPosition = new Position(5, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            for (var row = blackRookPosition.Row + 1; row < whitePawnPosition.Row; row++)
            {
                Assert.IsTrue(chessboard[row, blackRookPosition.Column].Available);
            }

            for (var row = whitePawnPosition.Row + 1; row < 9; row++)
            {
                Assert.IsFalse(chessboard[row, blackRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveSouthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackRookPosition = new Position(8, 1);
            var whitePawnPosition = new Position(5, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            for (var row = blackRookPosition.Row - 1; row > whitePawnPosition.Row; row--)
            {
                Assert.IsTrue(chessboard[row, blackRookPosition.Column].Available);
            }

            for (var row = whitePawnPosition.Row - 1; row > 0; row--)
            {
                Assert.IsFalse(chessboard[row, blackRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 1);
            var blackRookPosition = new Position(1, 2);
            var blackPawnPosition = new Position(1, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            for (var column = blackRookPosition.Column + 1; column < blackPawnPosition.Column; column++)
            {
                Assert.IsTrue(chessboard[blackRookPosition.Row, column].Available);
            }

            for (var column = blackPawnPosition.Column + 1; column < 9; column++)
            {
                Assert.IsFalse(chessboard[blackRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(2, 1);
            var blackRookPosition = new Position(1, 8);
            var blackPawnPosition = new Position(1, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            for (var column = blackRookPosition.Column - 1; column > blackPawnPosition.Column; column--)
            {
                Assert.IsTrue(chessboard[blackRookPosition.Row, column].Available);
            }

            for (var column = blackPawnPosition.Column - 1; column > 0; column--)
            {
                Assert.IsFalse(chessboard[blackRookPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveNorthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackRookPosition = new Position(1, 1);
            var blackPawnPosition = new Position(5, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            for (var row = blackRookPosition.Row + 1; row < blackPawnPosition.Row; row++)
            {
                Assert.IsTrue(chessboard[row, blackRookPosition.Column].Available);
            }

            for (var row = blackPawnPosition.Row + 1; row < 9; row++)
            {
                Assert.IsFalse(chessboard[row, blackRookPosition.Column].Available);
            }
        }

        [TestMethod]
        public void BlackRookCanMoveSouthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackRookPosition = new Position(8, 1);
            var blackPawnPosition = new Position(5, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            for (var row = blackRookPosition.Row - 1; row > blackPawnPosition.Row; row--)
            {
                Assert.IsTrue(chessboard[row, blackRookPosition.Column].Available);
            }

            for (var row = blackPawnPosition.Row - 1; row > 0; row--)
            {
                Assert.IsFalse(chessboard[row, blackRookPosition.Column].Available);
            }
        }
    }
}