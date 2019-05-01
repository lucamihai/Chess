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
    public class BlackPawnInChessUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = new Box[10, 10];
        }

        [TestMethod]
        public void BlackPawnCantMove1BoxForwardIfCantPreventCheck()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(4, 4);
            var whiteQueenPosition = new Point(8, 6);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCantMove2BoxesForwardIfCantPreventCheck()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 4);
            var whiteQueenPosition = new Point(8, 6);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCantTakePiecesIfCantPreventCheck()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();

            var blackKingPosition = new Point(8, 8);
            var whiteQueenPosition = new Point(blackKingPosition.X, blackKingPosition.Y - 1);
            var blackPawnPosition = new Point(3, 3);
            var whitePawnPositionSouthWest = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);
            var whitePawnPositionSouthEast = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y + 1);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[whitePawnPositionSouthWest.X, whitePawnPositionSouthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionSouthEast.X, whitePawnPositionSouthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCanMove1BoxForwardIfCanPreventCheck()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(8, 7);
            var whiteQueenPosition = new Point(6, 6);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X - 1, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCanMove2BoxesForwardIfCanPreventCheck()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 5);
            var whiteQueenPosition = new Point(4, 4);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnPosition.X - 2, blackPawnPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCanTakePieceIfCanPreventCheck()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
            var blackKingPosition = new Point(8, 8);
            var whiteQueenPosition = new Point(4, 4);
            var blackPawnPosition = new Point(5, 5);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
