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
    public class BlackKingPieceTakingUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicFilledWithBlackPawns();
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromNorthWest()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row + 1, blackKingPosition.Column - 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromNorth()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row + 1, blackKingPosition.Column);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromNorthEast()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row + 1, blackKingPosition.Column + 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromEast()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row, blackKingPosition.Column + 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromSouthEast()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column + 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromSouth()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromSouthWest()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column - 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromWest()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row, blackKingPosition.Column - 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKingCantTakeAnyBlackPiece()
        {
            var blackKingPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;
            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}
