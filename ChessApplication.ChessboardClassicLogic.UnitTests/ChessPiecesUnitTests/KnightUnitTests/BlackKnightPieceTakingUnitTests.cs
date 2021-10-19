using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.KnightUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackKnightPieceTakingUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicFilledWithPawns(PieceColor.Black);
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromNorthNorthEast()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 2, blackKnightPosition.Column + 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromNorthEastEast()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 1, blackKnightPosition.Column + 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromSouthEastEast()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column + 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromSouthSouthEast()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column + 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromSouthSouthWest()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 2, blackKnightPosition.Column - 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromSouthWestWest()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row - 1, blackKnightPosition.Column - 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromNorthWestWest()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 1, blackKnightPosition.Column - 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromNorthNorthWest()
        {
            var blackKingPosition = new Position(8, 8);
            var blackKnightPosition = new Position(3, 3);
            var whitePawnPosition = new Position(blackKnightPosition.Row + 2, blackKnightPosition.Column - 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.IsTrue(chessboard[whitePawnPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKnightCantTakeAnyBlackPiece()
        {
            var blackKingPosition = new Position(7, 7);
            var blackKnightPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}