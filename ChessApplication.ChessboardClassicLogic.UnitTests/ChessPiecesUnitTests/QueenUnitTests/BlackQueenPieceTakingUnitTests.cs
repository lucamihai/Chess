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
    public class BlackQueenPieceTakingUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackQueenCanTakeWhitePiecesFromAnyDirection()
        {
            var blackKingPosition = new Position(8, 8);
            var blackQueenPosition = new Position(5, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackQueenPosition, chessboard);
            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            var positionNorth = new Position(blackQueenPosition.Row + 1, blackQueenPosition.Column);
            var positionSouth = new Position(blackQueenPosition.Row - 1, blackQueenPosition.Column);
            var positionEast = new Position(blackQueenPosition.Row, blackQueenPosition.Column + 1);
            var positionWest = new Position(blackQueenPosition.Row, blackQueenPosition.Column - 1);

            var positionNorthEast = new Position(blackQueenPosition.Row + 1, blackQueenPosition.Column + 1);
            var positionSouthEast = new Position(blackQueenPosition.Row - 1, blackQueenPosition.Column + 1);
            var positionSouthWest = new Position(blackQueenPosition.Row - 1, blackQueenPosition.Column - 1);
            var positionNorthWest = new Position(blackQueenPosition.Row + 1, blackQueenPosition.Column - 1);

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
        public void BlackQueenCantTakeAnyBlackPieces()
        {
            var blackKingPosition = new Position(8, 8);
            var blackQueenPosition = new Position(5, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackQueenPosition, chessboard);
            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}
