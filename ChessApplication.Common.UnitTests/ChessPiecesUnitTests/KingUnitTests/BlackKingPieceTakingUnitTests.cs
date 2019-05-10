using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KingUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackKingPieceTakingUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardFilledWithBlackPawns();
        }

        [TestMethod]
        public void BlackKingCanTakeBlackPieceFromNorthWest()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X + 1, blackKingPosition.Y - 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeBlackPieceFromNorth()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X + 1, blackKingPosition.Y);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeBlackPieceFromNorthEast()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X + 1, blackKingPosition.Y + 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeBlackPieceFromEast()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X, blackKingPosition.Y + 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeBlackPieceFromSouthEast()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y + 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeBlackPieceFromSouth()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeBlackPieceFromSouthWest()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y - 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeBlackPieceFromWest()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X, blackKingPosition.Y - 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCantTakeAnyWhitePiece()
        {
            var blackKingPosition = new Point(3, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
