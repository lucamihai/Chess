﻿using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KnightUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteKnightPieceTakingUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardFilledWithWhitePawns();
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromNorthNorthEast()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X + 2, whiteKnightPosition.Y + 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromNorthEastEast()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X + 1, whiteKnightPosition.Y + 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromSouthEastEast()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X - 1, whiteKnightPosition.Y + 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromSouthSouthEast()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X - 2, whiteKnightPosition.Y + 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromSouthSouthWest()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X - 2, whiteKnightPosition.Y - 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromSouthWestWest()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X - 1, whiteKnightPosition.Y - 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromNorthWestWest()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X + 1, whiteKnightPosition.Y - 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCanTakeBlackPieceFromNorthNorthWest()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteKnightPosition = new Point(3, 3);
            var blackPawnPosition = new Point(whiteKnightPosition.X + 2, whiteKnightPosition.Y - 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new Pawn(PieceColor.Black);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteKnightCantTakeAnyWhitePiece()
        {
            var whiteKingPosition = new Point(7, 7);
            var whiteKnightPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece = new Knight(PieceColor.White);

            ChessBoard[whiteKnightPosition.X, whiteKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteKnightPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}