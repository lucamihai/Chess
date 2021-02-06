using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackQueenPieceTakingUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackQueenCanTakeWhitePiecesFromAnyDirection()
        {
            var blackKingPosition = new Position(8, 8);
            var blackQueenPosition = new Position(5, 5);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackQueenPosition, Chessboard);
            Chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackQueenPosition);

            var positionNorth = new Position(blackQueenPosition.Row + 1, blackQueenPosition.Column);
            var positionSouth = new Position(blackQueenPosition.Row - 1, blackQueenPosition.Column);
            var positionEast = new Position(blackQueenPosition.Row, blackQueenPosition.Column + 1);
            var positionWest = new Position(blackQueenPosition.Row, blackQueenPosition.Column - 1);

            var positionNorthEast = new Position(blackQueenPosition.Row + 1, blackQueenPosition.Column + 1);
            var positionSouthEast = new Position(blackQueenPosition.Row - 1, blackQueenPosition.Column + 1);
            var positionSouthWest = new Position(blackQueenPosition.Row - 1, blackQueenPosition.Column - 1);
            var positionNorthWest = new Position(blackQueenPosition.Row + 1, blackQueenPosition.Column - 1);

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
        public void BlackQueenCantTakeAnyBlackPieces()
        {
            var blackKingPosition = new Position(8, 8);
            var blackQueenPosition = new Position(5, 5);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackQueenPosition, Chessboard);
            Chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}
