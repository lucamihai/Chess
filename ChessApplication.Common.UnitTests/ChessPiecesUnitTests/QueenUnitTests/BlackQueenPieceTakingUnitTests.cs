using System.Diagnostics.CodeAnalysis;
using System.Drawing;
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
            var blackKingPosition = new Point(8, 8);
            var blackQueenPosition = new Point(5, 5);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackQueenPosition, Chessboard);
            Chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackQueenPosition);

            var positionNorth = new Point(blackQueenPosition.X + 1, blackQueenPosition.Y);
            var positionSouth = new Point(blackQueenPosition.X - 1, blackQueenPosition.Y);
            var positionEast = new Point(blackQueenPosition.X, blackQueenPosition.Y + 1);
            var positionWest = new Point(blackQueenPosition.X, blackQueenPosition.Y - 1);

            var positionNorthEast = new Point(blackQueenPosition.X + 1, blackQueenPosition.Y + 1);
            var positionSouthEast = new Point(blackQueenPosition.X - 1, blackQueenPosition.Y + 1);
            var positionSouthWest = new Point(blackQueenPosition.X - 1, blackQueenPosition.Y - 1);
            var positionNorthWest = new Point(blackQueenPosition.X + 1, blackQueenPosition.Y - 1);

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
            var blackKingPosition = new Point(8, 8);
            var blackQueenPosition = new Point(5, 5);

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
