using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var blackKingPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;
            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            var positionNorth = new Position(blackKingPosition.Row + 1, blackKingPosition.Column);
            var positionSouth = new Position(blackKingPosition.Row - 1, blackKingPosition.Column);
            var positionEast = new Position(blackKingPosition.Row, blackKingPosition.Column + 1);
            var positionWest = new Position(blackKingPosition.Row, blackKingPosition.Column - 1);

            var positionNorthEast = new Position(blackKingPosition.Row + 1, blackKingPosition.Column + 1);
            var positionSouthEast = new Position(blackKingPosition.Row - 1, blackKingPosition.Column + 1);
            var positionSouthWest = new Position(blackKingPosition.Row - 1, blackKingPosition.Column - 1);
            var positionNorthWest = new Position(blackKingPosition.Row + 1, blackKingPosition.Column - 1);

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
            var blackKingPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;
            Methods.SurroundBoxWithPawns(PieceColor.Black, blackKingPosition, Chessboard);
            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}
