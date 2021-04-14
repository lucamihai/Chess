using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhitePawnMovementUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhitePawnCanMove1BoxForwardIfIsInInitialPosition()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            var positionToBeTested = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhitePawnCanMove2BoxesForwardIfIsInInitialPosition()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            var positionToBeTested = new Position(whitePawnPosition.Row + 2, whitePawnPosition.Column);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhitePawnHas2AvailableMovesForInitialPosition()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(chessboard);
            Assert.AreEqual(2, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMoveIfThereIsAWhitePieceInFrontOfIt()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);
            var whitePawnPosition2 = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[whitePawnPosition2].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(chessboard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMoveIfThereIsABlackPieceInFrontOfIt()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);
            var blackPawnPosition = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(chessboard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfThatLocationIsOccupiedByAWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);
            var positionToBeTested = new Position(whitePawnPosition.Row + 2, whitePawnPosition.Column);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[positionToBeTested].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            Assert.IsFalse(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfThatLocationIsOccupiedByABlackPiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(2, 1);
            var positionToBeTested = new Position(whitePawnPosition.Row + 2, whitePawnPosition.Column);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[positionToBeTested].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionWhiteKing = whiteKingPosition;

            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            Assert.IsFalse(chessboard[positionToBeTested].Available);
        }
    }
}