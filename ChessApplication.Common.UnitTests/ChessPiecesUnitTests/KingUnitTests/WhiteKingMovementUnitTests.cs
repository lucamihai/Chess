using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KingUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKingMovementUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteKingCanMove1BoxInAnyDirectionIfNotOccupied()
        {
            var whiteKingPosition = new Point(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;
            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            var positionNorth = new Point(whiteKingPosition.X + 1, whiteKingPosition.Y);
            var positionSouth = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y);
            var positionEast = new Point(whiteKingPosition.X, whiteKingPosition.Y + 1);
            var positionWest = new Point(whiteKingPosition.X, whiteKingPosition.Y - 1);

            var positionNorthEast = new Point(whiteKingPosition.X + 1, whiteKingPosition.Y + 1);
            var positionSouthEast = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y + 1);
            var positionSouthWest = new Point(whiteKingPosition.X - 1, whiteKingPosition.Y - 1);
            var positionNorthWest = new Point(whiteKingPosition.X + 1, whiteKingPosition.Y - 1);

            Assert.IsTrue(Chessboard[positionNorth].Available);
            Assert.IsTrue(Chessboard[positionSouth].Available);
            Assert.IsTrue(Chessboard[positionEast].Available);
            Assert.IsTrue(Chessboard[positionWest].Available);

            Assert.IsTrue(Chessboard[positionNorthEast].Available);
            Assert.IsTrue(Chessboard[positionSouthEast].Available);
            Assert.IsTrue(Chessboard[positionSouthWest].Available);
            Assert.IsTrue(Chessboard[positionNorthWest].Available);

            Assert.AreEqual(8, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteKingCantMoveOverOccupiedBoxesByWhitePiecesInAnyDirection()
        {
            var whiteKingPosition = new Point(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;
            Methods.SurroundBoxWithPawns(PieceColor.White, whiteKingPosition, Chessboard);
            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}
