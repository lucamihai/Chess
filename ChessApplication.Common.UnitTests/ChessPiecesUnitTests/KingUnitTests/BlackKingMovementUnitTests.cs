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
    public class BlackKingMovementUnitTests
    {
        private ChessboardClassic ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackKingCanMove1BoxInAnyDirectionIfNotOccupied()
        {
            var blackKingPosition = new Point(3, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;
            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            var positionNorth = new Point(blackKingPosition.X + 1, blackKingPosition.Y);
            var positionSouth = new Point(blackKingPosition.X - 1, blackKingPosition.Y);
            var positionEast = new Point(blackKingPosition.X, blackKingPosition.Y + 1);
            var positionWest = new Point(blackKingPosition.X, blackKingPosition.Y - 1);

            var positionNorthEast = new Point(blackKingPosition.X + 1, blackKingPosition.Y + 1);
            var positionSouthEast = new Point(blackKingPosition.X - 1, blackKingPosition.Y + 1);
            var positionSouthWest = new Point(blackKingPosition.X - 1, blackKingPosition.Y - 1);
            var positionNorthWest = new Point(blackKingPosition.X + 1, blackKingPosition.Y - 1);

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
        public void BlackKingCantMoveOverOccupiedBoxesByBlackPiecesInAnyDirection()
        {
            var blackKingPosition = new Point(3, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;
            Methods.SurroundBoxWithPawns(PieceColor.Black, blackKingPosition, ChessBoard);
            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
