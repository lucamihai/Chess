using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.Pawn
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhitePawnInChessUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = new Box[10, 10];
        }

        [TestMethod]
        public void WhitePawnCantMove1BoxForwardIfCantPreventCheck()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
            var whiteKingPosition = new Point(2, 2);
            var blackQueenPosition = new Point(2, 3);
            var whitePawnPosition = new Point(4, 4);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCantMove2BoxesForwardIfCantPreventCheck()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
            var whiteKingPosition = new Point(2, 2);
            var whitePawnPosition = new Point(2, 4);
            var blackQueenPosition = new Point(2, 3);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCantTakePiecesIfCantPreventCheck()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();

            var whiteKingPosition = new Point(8, 8);
            var blackQueenLocation = new Point(whiteKingPosition.X, whiteKingPosition.Y - 1);
            var whitePawnPosition = new Point(3, 3);
            var blackPawnLocationNorthWest = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y - 1);
            var blackPawnLocationNorthEast = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 1);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[blackQueenLocation.X, blackQueenLocation.Y].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[blackPawnLocationNorthWest.X, blackPawnLocationNorthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationNorthEast.X, blackPawnLocationNorthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCanMove1BoxForwardIfCanPreventCheck()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
            var whiteKingPosition = new Point(2, 2);
            var whitePawnPosition = new Point(3, 4);
            var blackQueenPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X + 1, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCanMove2BoxesForwardIfCanPreventCheck()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
            var whiteKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(2, 4);
            var blackQueenPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPosition.X + 2, whitePawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCanTakePieceIfCanPreventCheck()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
            var whiteKingPosition = new Point(3, 3);
            var whitePawnPosition = new Point(2, 1);
            var blackQueenPosition = new Point(3, 2);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
