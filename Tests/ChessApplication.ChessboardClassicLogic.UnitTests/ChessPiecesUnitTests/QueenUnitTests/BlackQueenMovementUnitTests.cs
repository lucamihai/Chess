using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackQueenMovementUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackQueenCanMoveNorthEastIfUnblocked()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (int row = blackQueenPosition.Row + 1, column = blackQueenPosition.Column + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsTrue(chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastIfUnblocked()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (int row = blackQueenPosition.Row - 1, column = blackQueenPosition.Column + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsTrue(chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestIfUnblocked()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (int row = blackQueenPosition.Row - 1, column = blackQueenPosition.Column - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsTrue(chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestIfUnblocked()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (int row = blackQueenPosition.Row + 1, column = blackQueenPosition.Column - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsTrue(chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(1, 1);
            var whitePawnPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (int row = blackQueenPosition.Row + 1, column = blackQueenPosition.Column + 1; row < whitePawnPosition.Row && column < whitePawnPosition.Column; row++, column++)
            {
                Assert.IsTrue(chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.Row + 1, column = whitePawnPosition.Column + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsFalse(chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(8, 1);
            var whitePawnPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (int row = blackQueenPosition.Row - 1, column = blackQueenPosition.Column + 1; row > whitePawnPosition.Row && column < whitePawnPosition.Column; row--, column++)
            {
                Assert.IsTrue(chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.Row - 1, column = whitePawnPosition.Column + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsFalse(chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(8, 8);
            var whitePawnPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (int row = blackQueenPosition.Row - 1, column = blackQueenPosition.Column - 1; row > whitePawnPosition.Row && column > whitePawnPosition.Column; row--, column--)
            {
                Assert.IsTrue(chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.Row - 1, column = whitePawnPosition.Column - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsFalse(chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(1, 8);
            var whitePawnPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (int row = blackQueenPosition.Row + 1, column = blackQueenPosition.Column - 1; row < whitePawnPosition.Row && column > whitePawnPosition.Column; row++, column--)
            {
                Assert.IsTrue(chessboard[row, column].Available);
            }

            for (int row = whitePawnPosition.Row + 1, column = whitePawnPosition.Column - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsFalse(chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(1, 1);
            var blackPawnPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (int row = blackQueenPosition.Row + 1, column = blackQueenPosition.Column + 1; row < blackPawnPosition.Row && column < blackPawnPosition.Column; row++, column++)
            {
                Assert.IsTrue(chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.Row + 1, column = blackPawnPosition.Column + 1; row < 9 && column < 9; row++, column++)
            {
                Assert.IsFalse(chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(8, 1);
            var blackPawnPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (int row = blackQueenPosition.Row - 1, column = blackQueenPosition.Column + 1; row > blackPawnPosition.Row && column < blackPawnPosition.Column; row--, column++)
            {
                Assert.IsTrue(chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.Row - 1, column = blackPawnPosition.Column + 1; row > 0 && column < 9; row--, column++)
            {
                Assert.IsFalse(chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveSouthWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(8, 8);
            var blackPawnPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (int row = blackQueenPosition.Row - 1, column = blackQueenPosition.Column - 1; row > blackPawnPosition.Row && column > blackPawnPosition.Column; row--, column--)
            {
                Assert.IsTrue(chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.Row - 1, column = blackPawnPosition.Column - 1; row > 0 && column > 0; row--, column--)
            {
                Assert.IsFalse(chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void WhiteBishopCanMoveNorthWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(1, 8);
            var blackPawnPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (int row = blackQueenPosition.Row + 1, column = blackQueenPosition.Column - 1; row < blackPawnPosition.Row && column > blackPawnPosition.Column; row++, column--)
            {
                Assert.IsTrue(chessboard[row, column].Available);
            }

            for (int row = blackPawnPosition.Row + 1, column = blackPawnPosition.Column - 1; row < 9 && column > 0; row++, column--)
            {
                Assert.IsFalse(chessboard[row, column].Available);
            }
        }

        [TestMethod]
        public void BlackQueenCanMoveEastIfUnblocked()
        {
            var blackKingPosition = new Position(1, 1);
            var blackQueenPosition = new Position(1, 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (var column = blackQueenPosition.Column + 1; column < 9; column++)
            {
                Assert.IsTrue(chessboard[blackQueenPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void BlackQueenCanMoveWestIfUnblocked()
        {
            var blackKingPosition = new Position(1, 1);
            var blackQueenPosition = new Position(2, 8);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (var column = blackQueenPosition.Column - 1; column > 0; column--)
            {
                Assert.IsTrue(chessboard[blackQueenPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void BlackQueenCanMoveNorthIfUnblocked()
        {
            var blackKingPosition = new Position(1, 1);
            var blackQueenPosition = new Position(1, 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (var row = blackQueenPosition.Row + 1; row < 9; row++)
            {
                Assert.IsTrue(chessboard[row, blackQueenPosition.Column].Available);
            }
        }

        [TestMethod]
        public void BlackQueenCanMoveSouthIfUnblocked()
        {
            var blackKingPosition = new Position(1, 1);
            var blackQueenPosition = new Position(8, 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (var row = blackQueenPosition.Row - 1; row > 0; row--)
            {
                Assert.IsTrue(chessboard[row, blackQueenPosition.Column].Available);
            }
        }

        [TestMethod]
        public void BlackQueenCanMoveEastAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 1);
            var blackQueenPosition = new Position(1, 2);
            var whitePawnPosition = new Position(1, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (var column = blackQueenPosition.Column + 1; column < whitePawnPosition.Column; column++)
            {
                Assert.IsTrue(chessboard[blackQueenPosition.Row, column].Available);
            }

            for (var column = whitePawnPosition.Column + 1; column < 9; column++)
            {
                Assert.IsFalse(chessboard[blackQueenPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void BlackQueenCanMoveWestAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(2, 1);
            var blackQueenPosition = new Position(1, 8);
            var whitePawnPosition = new Position(1, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (var column = blackQueenPosition.Column - 1; column > whitePawnPosition.Column; column--)
            {
                Assert.IsTrue(chessboard[blackQueenPosition.Row, column].Available);
            }

            for (var column = whitePawnPosition.Column - 1; column > 0; column--)
            {
                Assert.IsFalse(chessboard[blackQueenPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void BlackQueenCanMoveNorthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(1, 1);
            var whitePawnPosition = new Position(5, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (var row = blackQueenPosition.Row + 1; row < whitePawnPosition.Row; row++)
            {
                Assert.IsTrue(chessboard[row, blackQueenPosition.Column].Available);
            }

            for (var row = whitePawnPosition.Row + 1; row < 9; row++)
            {
                Assert.IsFalse(chessboard[row, blackQueenPosition.Column].Available);
            }
        }

        [TestMethod]
        public void BlackQueenCanMoveSouthAllTheWayToAWhitePieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(8, 1);
            var whitePawnPosition = new Position(5, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (var row = blackQueenPosition.Row - 1; row > whitePawnPosition.Row; row--)
            {
                Assert.IsTrue(chessboard[row, blackQueenPosition.Column].Available);
            }

            for (var row = whitePawnPosition.Row - 1; row > 0; row--)
            {
                Assert.IsFalse(chessboard[row, blackQueenPosition.Column].Available);
            }
        }

        [TestMethod]
        public void BlackQueenCanMoveEastAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 1);
            var blackQueenPosition = new Position(1, 2);
            var blackPawnPosition = new Position(1, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (var column = blackQueenPosition.Column + 1; column < blackPawnPosition.Column; column++)
            {
                Assert.IsTrue(chessboard[blackQueenPosition.Row, column].Available);
            }

            for (var column = blackPawnPosition.Column + 1; column < 9; column++)
            {
                Assert.IsFalse(chessboard[blackQueenPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void BlackQueenCanMoveWestAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(2, 1);
            var blackQueenPosition = new Position(1, 8);
            var blackPawnPosition = new Position(1, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (var column = blackQueenPosition.Column - 1; column > blackPawnPosition.Column; column--)
            {
                Assert.IsTrue(chessboard[blackQueenPosition.Row, column].Available);
            }

            for (var column = blackPawnPosition.Column - 1; column > 0; column--)
            {
                Assert.IsFalse(chessboard[blackQueenPosition.Row, column].Available);
            }
        }

        [TestMethod]
        public void BlackQueenCanMoveNorthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(1, 1);
            var blackPawnPosition = new Position(5, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (var row = blackQueenPosition.Row + 1; row < blackPawnPosition.Row; row++)
            {
                Assert.IsTrue(chessboard[row, blackQueenPosition.Column].Available);
            }

            for (var row = blackPawnPosition.Row + 1; row < 9; row++)
            {
                Assert.IsFalse(chessboard[row, blackQueenPosition.Column].Available);
            }
        }

        [TestMethod]
        public void BlackQueenCanMoveSouthAllTheWayToABlackPieceButNotBeyondIt()
        {
            var blackKingPosition = new Position(1, 2);
            var blackQueenPosition = new Position(8, 1);
            var blackPawnPosition = new Position(5, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            for (var row = blackQueenPosition.Row - 1; row > blackPawnPosition.Row; row--)
            {
                Assert.IsTrue(chessboard[row, blackQueenPosition.Column].Available);
            }

            for (var row = blackPawnPosition.Row - 1; row > 0; row--)
            {
                Assert.IsFalse(chessboard[row, blackQueenPosition.Column].Available);
            }
        }
    }
    
}
