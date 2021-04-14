using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.KingUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackKingMovementUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackKingCanMove1BoxInAnyDirectionIfNotOccupied()
        {
            var blackKingPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;
            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            var positionNorth = new Position(blackKingPosition.Row + 1, blackKingPosition.Column);
            var positionSouth = new Position(blackKingPosition.Row - 1, blackKingPosition.Column);
            var positionEast = new Position(blackKingPosition.Row, blackKingPosition.Column + 1);
            var positionWest = new Position(blackKingPosition.Row, blackKingPosition.Column - 1);

            var positionNorthEast = new Position(blackKingPosition.Row + 1, blackKingPosition.Column + 1);
            var positionSouthEast = new Position(blackKingPosition.Row - 1, blackKingPosition.Column + 1);
            var positionSouthWest = new Position(blackKingPosition.Row - 1, blackKingPosition.Column - 1);
            var positionNorthWest = new Position(blackKingPosition.Row + 1, blackKingPosition.Column - 1);

            Assert.IsTrue(chessboard[positionNorth].Available);
            Assert.IsTrue(chessboard[positionSouth].Available);
            Assert.IsTrue(chessboard[positionEast].Available);
            Assert.IsTrue(chessboard[positionWest].Available);

            Assert.IsTrue(chessboard[positionNorthEast].Available);
            Assert.IsTrue(chessboard[positionSouthEast].Available);
            Assert.IsTrue(chessboard[positionSouthWest].Available);
            Assert.IsTrue(chessboard[positionNorthWest].Available);

            Assert.AreEqual(8, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKingCantMoveOverOccupiedBoxesByBlackPiecesInAnyDirection()
        {
            var blackKingPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;
            Methods.SurroundBoxWithPawns(PieceColor.Black, blackKingPosition, chessboard);
            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}
