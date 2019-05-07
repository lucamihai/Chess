using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KingUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKingMovementUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteKingCanMove1BoxInAnyDirectionIfNotOccupied()
        {
            var whiteKingPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKingPosition, whiteKingPosition);

            var positionNorth = new Point(whiteKingPosition.X + 1, whiteKingPosition.Y);
            var positionSouth = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y);
            var positionEast = new Point(whiteKingPosition.X, whiteKingPosition.Y + 1);
            var positionWest = new Point(whiteKingPosition.X, whiteKingPosition.Y - 1);

            var positionNorthEast = new Point(whiteKingPosition.X + 1, whiteKingPosition.Y + 1);
            var positionSouthEast = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y + 1);
            var positionSouthWest = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y - 1);
            var positionNorthWest = new Point(whiteKingPosition.X + 1, whiteKingPosition.Y - 1);

            Assert.IsTrue(ChessBoard[positionNorth.X, positionNorth.Y].Available);
            Assert.IsTrue(ChessBoard[positionSouth.X, positionSouth.Y].Available);
            Assert.IsTrue(ChessBoard[positionEast.X, positionEast.Y].Available);
            Assert.IsTrue(ChessBoard[positionWest.X, positionWest.Y].Available);

            Assert.IsTrue(ChessBoard[positionNorthEast.X, positionNorthEast.Y].Available);
            Assert.IsTrue(ChessBoard[positionSouthEast.X, positionSouthEast.Y].Available);
            Assert.IsTrue(ChessBoard[positionSouthWest.X, positionSouthWest.Y].Available);
            Assert.IsTrue(ChessBoard[positionNorthWest.X, positionNorthWest.Y].Available);

            Assert.AreEqual(8, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKingCantMoveOverOccupiedBoxesByWhitePiecesInAnyDirection()
        {
            var whiteKingPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            Methods.SurroundBoxWithPawns(PieceColor.White, whiteKingPosition, ChessBoard);
            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKingPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
