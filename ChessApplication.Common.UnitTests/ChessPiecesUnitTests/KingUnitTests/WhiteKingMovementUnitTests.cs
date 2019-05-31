using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KingUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKingMovementUnitTests
    {
        private ChessboardClassic ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteKingCanMove1BoxInAnyDirectionIfNotOccupied()
        {
            var whiteKingPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;
            ChessBoard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKingPosition);

            var positionNorth = new Point(whiteKingPosition.X + 1, whiteKingPosition.Y);
            var positionSouth = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y);
            var positionEast = new Point(whiteKingPosition.X, whiteKingPosition.Y + 1);
            var positionWest = new Point(whiteKingPosition.X, whiteKingPosition.Y - 1);

            var positionNorthEast = new Point(whiteKingPosition.X + 1, whiteKingPosition.Y + 1);
            var positionSouthEast = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y + 1);
            var positionSouthWest = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y - 1);
            var positionNorthWest = new Point(whiteKingPosition.X + 1, whiteKingPosition.Y - 1);

            Assert.IsTrue(ChessBoard[positionNorth].Available);
            Assert.IsTrue(ChessBoard[positionSouth].Available);
            Assert.IsTrue(ChessBoard[positionEast].Available);
            Assert.IsTrue(ChessBoard[positionWest].Available);

            Assert.IsTrue(ChessBoard[positionNorthEast].Available);
            Assert.IsTrue(ChessBoard[positionSouthEast].Available);
            Assert.IsTrue(ChessBoard[positionSouthWest].Available);
            Assert.IsTrue(ChessBoard[positionNorthWest].Available);

            Assert.AreEqual(8, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKingCantMoveOverOccupiedBoxesByWhitePiecesInAnyDirection()
        {
            var whiteKingPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;
            Methods.SurroundBoxWithPawns(PieceColor.White, whiteKingPosition, ChessBoard);
            ChessBoard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
