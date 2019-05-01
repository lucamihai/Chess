using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.Rook
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteRookInChessUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteRookCantMoveIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteRookPosition = new Point(3, 2);
            var blackQueenPosition = new Point(1, 3);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            Assert.AreEqual(0, UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteRookCantTakePieceIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteRookPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 8);
            var blackQueenPosition = new Point(1, 3);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.White);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            Assert.AreEqual(0, UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteRookCanMoveIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteRookPosition = new Point(1, 7);
            var blackQueenPosition = new Point(3, 8);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            var defensePosition = new Point(blackQueenPosition.X, whiteRookPosition.Y);
            Assert.IsTrue(ChessBoard[defensePosition.X, defensePosition.Y].Available);
            Assert.AreEqual(1, UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteRookCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteRookPosition = new Point(1, 2);
            var blackQueenPosition = new Point(1, 3);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.White);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Available);
            Assert.AreEqual(1, UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
