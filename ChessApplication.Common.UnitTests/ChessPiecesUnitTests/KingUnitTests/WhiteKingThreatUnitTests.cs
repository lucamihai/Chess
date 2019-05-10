﻿using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KingUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKingThreatUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteKingCantMoveIfWillCauseACheck()
        {
            var whiteKingPosition = new Point(1, 1);
            var blackQueenPosition = new Point(2, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKingPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKingCantTakePieceIfWillCauseACheck()
        {
            var whiteKingPosition = new Point(1, 1);
            var blackPawnPosition = new Point(whiteKingPosition.X + 1, whiteKingPosition.Y);
            var blackBishopPosition = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y + 1);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            ChessBoard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKingPosition, whiteKingPosition);

            Assert.IsFalse(ChessBoard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteKingCanMoveAwayIfWillRemoveCheck()
        {
            var whiteKingPosition = new Point(1, 2);
            var blackQueenPosition = new Point(2, 1);
            var blackPawnPosition = new Point(3, 2);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKingPosition, whiteKingPosition);

            var availablePosition = new Point(1, 3);
            Assert.IsTrue(ChessBoard[availablePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKingCanTakePieceIfWillRemoveCheck()
        {
            var whiteKingPosition = new Point(1, 2);
            var blackQueenPosition = new Point(2, 1);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKingPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackQueenPosition].Available);
        }
    }
}
