using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackQueenPieceTakingUnitTests
    {
        private ChessboardClassic ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackQueenCanTakeWhitePiecesFromAnyDirection()
        {
            var blackKingPosition = new Point(8, 8);
            var blackQueenPosition = new Point(5, 5);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackQueenPosition, ChessBoard);
            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            var positionNorth = new Point(blackQueenPosition.X + 1, blackQueenPosition.Y);
            var positionSouth = new Point(blackQueenPosition.X - 1, blackQueenPosition.Y);
            var positionEast = new Point(blackQueenPosition.X, blackQueenPosition.Y + 1);
            var positionWest = new Point(blackQueenPosition.X, blackQueenPosition.Y - 1);

            var positionNorthEast = new Point(blackQueenPosition.X + 1, blackQueenPosition.Y + 1);
            var positionSouthEast = new Point(blackQueenPosition.X - 1, blackQueenPosition.Y + 1);
            var positionSouthWest = new Point(blackQueenPosition.X - 1, blackQueenPosition.Y - 1);
            var positionNorthWest = new Point(blackQueenPosition.X + 1, blackQueenPosition.Y - 1);

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
        public void BlackQueenCantTakeAnyBlackPieces()
        {
            var blackKingPosition = new Point(8, 8);
            var blackQueenPosition = new Point(5, 5);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackQueenPosition, ChessBoard);
            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
