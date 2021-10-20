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
    public class BlackPawnMovementUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackPawnCanMove1BoxForwardIfIsInInitialPosition()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            var positionToBeTested = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackPawnCanMove2BoxesForwardIfIsInInitialPosition()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            var positionToBeTested = new Position(blackPawnPosition.Row - 2, blackPawnPosition.Column);
            Assert.IsTrue(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackPawnHas2AvailableMovesForInitialPosition()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(chessboard);
            Assert.AreEqual(2, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMoveIfThereIsAWhitePieceInFrontOfIt()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);
            var whitePawnPosition = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(chessboard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMoveIfThereIsABlackPieceInFrontOfIt()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);
            var blackPawnPosition2 = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[blackPawnPosition2].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(chessboard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfThatLocationIsOccupiedByAWhitePiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);
            var positionToBeTested = new Position(blackPawnPosition.Row - 2, blackPawnPosition.Column);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[positionToBeTested].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            Assert.IsFalse(chessboard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfThatLocationIsOccupiedByABlackPiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(7, 1);
            var positionToBeTested = new Position(blackPawnPosition.Row - 2, blackPawnPosition.Column);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[positionToBeTested].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            Assert.IsFalse(chessboard[positionToBeTested].Available);
        }
    }
}