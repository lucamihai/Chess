﻿using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackPawnMovementUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackPawnCanMove1BoxForwardIfIsInInitialPosition()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            var positionToBeTested = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackPawnCanMove2BoxesForwardIfIsInInitialPosition()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            var positionToBeTested = new Point(blackPawnPosition.X - 2, blackPawnPosition.Y);
            Assert.IsTrue(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackPawnHas2AvailableMovesForInitialPosition()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(2, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMoveIfThereIsAWhitePieceInFrontOfIt()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);
            var whitePawnPosition = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMoveIfThereIsABlackPieceInFrontOfIt()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);
            var blackPawnPosition2 = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard[blackPawnPosition2].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            var availableMoves = Methods.GetNumberOfAvailableBoxes(ChessBoard);
            Assert.AreEqual(0, availableMoves);
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfThatLocationIsOccupiedByAWhitePiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);
            var positionToBeTested = new Point(blackPawnPosition.X - 2, blackPawnPosition.Y);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard[positionToBeTested].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            Assert.IsFalse(ChessBoard[positionToBeTested].Available);
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfThatLocationIsOccupiedByABlackPiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 1);
            var positionToBeTested = new Point(blackPawnPosition.X - 2, blackPawnPosition.Y);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard[positionToBeTested].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            Assert.IsFalse(ChessBoard[positionToBeTested].Available);
        }
    }
}