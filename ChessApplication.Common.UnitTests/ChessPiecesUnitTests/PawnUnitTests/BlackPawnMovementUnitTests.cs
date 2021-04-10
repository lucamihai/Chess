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
    public class BlackPawnMovementUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackPawnCanMove1BoxForwardIfIsInInitialPosition()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            var positionToBeTested = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackPawnCanMove2BoxesForwardIfIsInInitialPosition()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            var positionToBeTested = new Position(blackPawnPosition.Row - 2, blackPawnPosition.Column);
            Assert.IsTrue(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackPawnHas2AvailableMovesForInitialPosition()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(Chessboard);
            Assert.AreEqual(2, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMoveIfThereIsAWhitePieceInFrontOfIt()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);
            var whitePawnPosition = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(Chessboard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMoveIfThereIsABlackPieceInFrontOfIt()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);
            var blackPawnPosition2 = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[blackPawnPosition2].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(Chessboard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfThatLocationIsOccupiedByAWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);
            var positionToBeTested = new Position(blackPawnPosition.Row - 2, blackPawnPosition.Column);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[positionToBeTested].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            Assert.IsFalse(Chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfThatLocationIsOccupiedByABlackPiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);
            var positionToBeTested = new Position(blackPawnPosition.Row - 2, blackPawnPosition.Column);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[positionToBeTested].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            Assert.IsFalse(Chessboard[positionToBeTested].Available);
        }
    }
}