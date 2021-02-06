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
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.Row + 1, column = blackBishopPosition.Column + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastIfUnblocked()
        {
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.Row - 1, column = blackBishopPosition.Column + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestIfUnblocked()
        {
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.Row - 1, column = blackBishopPosition.Column - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestIfUnblocked()
        {
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.Row + 1, column = blackBishopPosition.Column - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsTrue(Chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(1, 1);
            var whitePawnPosition = new Position(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.Row + 1, column = blackBishopPosition.Column + 1; row < whitePawnPosition.Row && column < whitePawnPosition.Column; row++, column++)
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
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(8, 1);
            var whitePawnPosition = new Position(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.Row - 1, column = blackBishopPosition.Column + 1; row > whitePawnPosition.Row && column < whitePawnPosition.Column; row--, column++)
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
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(8, 8);
            var whitePawnPosition = new Position(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.Row - 1, column = blackBishopPosition.Column - 1; row > whitePawnPosition.Row && column > whitePawnPosition.Column; row--, column--)
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
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(1, 8);
            var whitePawnPosition = new Position(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.Row + 1, column = blackBishopPosition.Column - 1; row < whitePawnPosition.Row && column > whitePawnPosition.Column; row++, column--)
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
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(1, 1);
            var blackPawnPosition = new Position(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.Row + 1, column = blackBishopPosition.Column + 1; row < blackPawnPosition.Row && column < blackPawnPosition.Column; row++, column++)
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
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(8, 1);
            var blackPawnPosition = new Position(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.Row - 1, column = blackBishopPosition.Column + 1; row > blackPawnPosition.Row && column < blackPawnPosition.Column; row--, column++)
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
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(8, 8);
            var blackPawnPosition = new Position(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.Row - 1, column = blackBishopPosition.Column - 1; row > blackPawnPosition.Row && column > blackPawnPosition.Column; row--, column--)
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
            var blackKingPosition = new Position(1, 2);
            var blackBishopPosition = new Position(1, 8);
            var blackPawnPosition = new Position(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            for (int row = blackBishopPosition.Row + 1, column = blackBishopPosition.Column - 1; row < blackPawnPosition.Row && column > blackPawnPosition.Column; row++, column--)
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
