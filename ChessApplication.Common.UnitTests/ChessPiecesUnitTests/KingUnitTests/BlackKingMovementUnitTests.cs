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
    public class BlackKingMovementUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackKingCanMove1BoxInAnyDirectionIfNotOccupied()
        {
            var blackKingPosition = new Point(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;
            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            var positionNorth = new Point(blackKingPosition.X + 1, blackKingPosition.Y);
            var positionSouth = new Point(blackKingPosition.X - 1, blackKingPosition.Y);
            var positionEast = new Point(blackKingPosition.X, blackKingPosition.Y + 1);
            var positionWest = new Point(blackKingPosition.X, blackKingPosition.Y - 1);

            var positionNorthEast = new Point(blackKingPosition.X + 1, blackKingPosition.Y + 1);
            var positionSouthEast = new Point(blackKingPosition.X - 1, blackKingPosition.Y + 1);
            var positionSouthWest = new Point(blackKingPosition.X - 1, blackKingPosition.Y - 1);
            var positionNorthWest = new Point(blackKingPosition.X + 1, blackKingPosition.Y - 1);

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
        public void BlackKingCantMoveOverOccupiedBoxesByBlackPiecesInAnyDirection()
        {
            var blackKingPosition = new Point(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;
            Methods.SurroundBoxWithPawns(PieceColor.Black, blackKingPosition, Chessboard);
            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}
