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
    public class WhiteKingMovementUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteKingCanMove1BoxInAnyDirectionIfNotOccupied()
        {
            var whiteKingPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;
            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            var positionNorth = new Position(whiteKingPosition.Row + 1, whiteKingPosition.Column);
            var positionSouth = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column);
            var positionEast = new Position(whiteKingPosition.Row, whiteKingPosition.Column + 1);
            var positionWest = new Position(whiteKingPosition.Row, whiteKingPosition.Column - 1);

            var positionNorthEast = new Position(whiteKingPosition.Row + 1, whiteKingPosition.Column + 1);
            var positionSouthEast = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column + 1);
            var positionSouthWest = new Position(whiteKingPosition.Row - 1, whiteKingPosition.Column - 1);
            var positionNorthWest = new Position(whiteKingPosition.Row + 1, whiteKingPosition.Column - 1);

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
        public void WhiteKingCantMoveOverOccupiedBoxesByWhitePiecesInAnyDirection()
        {
            var whiteKingPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;
            Methods.SurroundBoxWithPawns(PieceColor.White, whiteKingPosition, chessboard);
            chessboard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}
