using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhitePawnMovementUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhitePawnCanMove1BoxForwardIfIsInInitialPosition()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            var positionToBeTested = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhitePawnCanMove2BoxesForwardIfIsInInitialPosition()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            var positionToBeTested = new Position(whitePawnPosition.Row + 2, whitePawnPosition.Column);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhitePawnHas2AvailableMovesForInitialPosition()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(Chessboard);
            Assert.AreEqual(2, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMoveIfThereIsAWhitePieceInFrontOfIt()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);
            var whitePawnPosition2 = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[whitePawnPosition2].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(Chessboard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMoveIfThereIsABlackPieceInFrontOfIt()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);
            var blackPawnPosition = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(Chessboard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfThatLocationIsOccupiedByAWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);
            var positionToBeTested = new Position(whitePawnPosition.Row + 2, whitePawnPosition.Column);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[positionToBeTested].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            Assert.IsFalse(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfThatLocationIsOccupiedByABlackPiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);
            var positionToBeTested = new Position(whitePawnPosition.Row + 2, whitePawnPosition.Column);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[positionToBeTested].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            Assert.IsFalse(Chessboard[positionToBeTested].Available);
        }
    }
}