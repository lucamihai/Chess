﻿using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.Knight
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackKnightPieceTakingUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardFilledWithBlackPawns();
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromNorthNorthEast()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X + 2, blackKnightPosition.Y + 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new ChessPieces.Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromNorthEastEast()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X + 1, blackKnightPosition.Y + 2);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new ChessPieces.Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromSouthEastEast()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X - 1, blackKnightPosition.Y + 2);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new ChessPieces.Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromSouthSouthEast()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X - 2, blackKnightPosition.Y + 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new ChessPieces.Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromSouthSouthWest()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X - 2, blackKnightPosition.Y - 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new ChessPieces.Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromSouthWestWest()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X - 1, blackKnightPosition.Y - 2);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new ChessPieces.Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromNorthWestWest()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X + 1, blackKnightPosition.Y - 2);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new ChessPieces.Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKnightCanTakeWhitePieceFromNorthNorthWest()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whitePawnPosition = new Point(blackKnightPosition.X + 2, blackKnightPosition.Y - 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new ChessPieces.Knight(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKnightCantTakeAnyBlackPiece()
        {
            var blackKingPosition = new Point(7, 7);
            var blackKnightPosition = new Point(3, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new ChessPieces.Knight(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}