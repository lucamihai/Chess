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
    public class BlackKingPieceTakingUnitTests
    {
        private ChessboardClassic ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardFilledWithBlackPawns();
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromNorthWest()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X + 1, blackKingPosition.Y - 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromNorth()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X + 1, blackKingPosition.Y);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromNorthEast()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X + 1, blackKingPosition.Y + 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromEast()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X, blackKingPosition.Y + 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromSouthEast()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y + 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromSouth()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromSouthWest()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y - 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromWest()
        {
            var blackKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKingPosition.X, blackKingPosition.Y - 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCantTakeAnyBlackPiece()
        {
            var blackKingPosition = new Point(3, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;
            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
