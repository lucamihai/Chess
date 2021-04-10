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
            var whiteKingPosition = new Position(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;
            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            var positionNorth = new Position(whiteKingPosition.Row + 1, whiteKingPosition.Column);
            var positionSouth = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column);
            var positionEast = new Position(whiteKingPosition.Row, whiteKingPosition.Column + 1);
            var positionWest = new Position(whiteKingPosition.Row, whiteKingPosition.Column - 1);

            var positionNorthEast = new Position(whiteKingPosition.Row + 1, whiteKingPosition.Column + 1);
            var positionSouthEast = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column + 1);
            var positionSouthWest = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column - 1);
            var positionNorthWest = new Position(whiteKingPosition.Row + 1, whiteKingPosition.Column - 1);

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
            var whiteKingPosition = new Position(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;
            Methods.SurroundBoxWithPawns(PieceColor.White, whiteKingPosition, Chessboard);
            Chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}
