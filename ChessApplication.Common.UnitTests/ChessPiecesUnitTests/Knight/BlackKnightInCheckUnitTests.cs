using System.Diagnostics.CodeAnalysis;
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
    public class BlackKnightInCheckUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackKnightCantMoveIfNotPreventsCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whiteQueenPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new ChessPieces.Knight(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKnightCantTakePieceIfNotPreventsCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(3, 3);
            var whiteQueenPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y);
            var whitePawnPosition = new Point(blackKnightPosition.X - 2, blackKnightPosition.Y - 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new ChessPieces.Knight(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Available);
        }

        [TestMethod]
        public void BlackKnightCanMoveIfPreventsCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var blackKnightPosition = new Point(blackKingPosition.X - 2, blackKingPosition.Y);
            var whiteQueenPosition = new Point(blackKingPosition.X, 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new ChessPieces.Knight(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            var defensePosition = new Point(blackKingPosition.X, blackKingPosition.Y - 1);
            Assert.IsTrue(ChessBoard[defensePosition.X, defensePosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKnightCanTakePieceIfPreventsCheck()
        {
            var blackKingPosition = new Point(8, 8);
            var whiteQueenPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y);
            var blackKnightPosition = new Point(whiteQueenPosition.X - 2, whiteQueenPosition.Y - 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece = new ChessPieces.Knight(PieceColor.Black);

            ChessBoard[blackKnightPosition.X, blackKnightPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKnightPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
