using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KnightUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackKnightCheckUnitTests
    {
        private ChessboardClassic ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackKnightCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(7, 8);
            var whiteQueenPosition = new Point(1, 8);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKnightCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(7, 8);
            var whiteQueenPosition = new Point(1, 8);
            var whitePawnPosition = new Point(blackKnightPosition.X - 1, blackKnightPosition.Y - 2);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackKnightCantMoveIfNotPreventsCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whiteQueenPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKnightCantTakePieceIfNotPreventsCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whiteQueenPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y);
            var whitePawnPosition = new Point(blackKnightPosition.X - 2, blackKnightPosition.Y - 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackKnightCanMoveIfPreventsCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(blackKingPosition.X - 2, blackKingPosition.Y);
            var whiteQueenPosition = new Point(blackKingPosition.X, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            var defensePosition = new Point(blackKingPosition.X, blackKingPosition.Y - 1);
            Assert.IsTrue(ChessBoard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKnightCanTakePieceIfPreventsCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var whiteQueenPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y);
            var blackKnightPosition = new Point(whiteQueenPosition.X - 2, whiteQueenPosition.Y - 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard[blackKnightPosition].Piece = new Knight(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKnightPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition);

            Assert.IsTrue(ChessBoard[whiteQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}