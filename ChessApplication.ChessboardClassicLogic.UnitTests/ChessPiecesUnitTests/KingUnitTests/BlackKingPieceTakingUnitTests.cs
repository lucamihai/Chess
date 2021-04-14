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
    public class BlackKingPieceTakingUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicFilledWithBlackPawns();
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromNorthWest()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row + 1, blackKingPosition.Column - 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromNorth()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row + 1, blackKingPosition.Column);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromNorthEast()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row + 1, blackKingPosition.Column + 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromEast()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row, blackKingPosition.Column + 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromSouthEast()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column + 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromSouth()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromSouthWest()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column - 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakeWhitePieceFromWest()
        {
            var blackKingPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKingPosition.Row, blackKingPosition.Column - 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKingCantTakeAnyBlackPiece()
        {
            var blackKingPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;
            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}
