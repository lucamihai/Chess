using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KnightUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackKnightPieceTakingUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicFilledWithBlackPawns();
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromNorthNorthEast()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 2, blackKnightPosition.Column + 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromNorthEastEast()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 1, blackKnightPosition.Column + 2);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromSouthEastEast()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column + 2);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromSouthSouthEast()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column + 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromSouthSouthWest()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column - 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromSouthWestWest()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column - 2);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromNorthWestWest()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 1, blackKnightPosition.Column - 2);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromNorthNorthWest()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 2, blackKnightPosition.Column - 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.IsTrue(Chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKnightCantTakeAnyBlackPiece()
        {
            var blackKingPosition = new Position(7, 7);
            var blackKnightPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}