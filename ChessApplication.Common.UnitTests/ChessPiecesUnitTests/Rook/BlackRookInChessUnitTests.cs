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
    public class BlackRookInChessUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackRookCantMoveIfCantPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackRookPosition = new Point(3, 2);
            var whiteQueenPosition = new Point(1, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            Assert.AreEqual(0, UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackRookCantTakePieceIfCantPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackRookPosition = new Point(8, 8);
            var whitePawnPosition = new Point(7, 8);
            var whiteQueenPosition = new Point(1, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            Assert.AreEqual(0, UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackRookCanMoveIfCanPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackRookPosition = new Point(1, 7);
            var whiteQueenPosition = new Point(3, 8);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            var defensePosition = new Point(whiteQueenPosition.X, blackRookPosition.Y);
            Assert.IsTrue(ChessBoard[defensePosition.X, defensePosition.Y].Available);
            Assert.AreEqual(1, UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteRookCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackRookPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(1, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new ChessPieces.Rook(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Available);
            Assert.AreEqual(1, UnitTestsUtilities.Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
