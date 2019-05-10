using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhitePawnMovementUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhitePawnCanMove1BoxForwardIfIsInInitialPosition()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            var positionToBeTested = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhitePawnCanMove2BoxesForwardIfIsInInitialPosition()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            var positionToBeTested = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhitePawnHas2AvailableMovesForInitialPosition()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(2, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMoveIfThereIsAWhitePieceInFrontOfIt()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);
            var whitePawnPosition2 = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard[whitePawnPosition2].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMoveIfThereIsABlackPieceInFrontOfIt()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);
            var blackPawnPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfThatLocationIsOccupiedByAWhitePiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);
            var positionToBeTested = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard[positionToBeTested].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            Assert.IsFalse(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfThatLocationIsOccupiedByABlackPiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(2, 1);
            var positionToBeTested = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard[positionToBeTested].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            Assert.IsFalse(ChessBoard[positionToBeTested].Available);
        }
    }
}