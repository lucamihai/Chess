using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackQueenCheckUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackQueenCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Point(1, 1);
            var blackQueenPosition = new Point(2, 1);
            var whiteQueenPosition = new Point(4, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            var numberOfMoves = Methods.GetNumberOfAvailableBoxes(ChessBoard);
            for (int row = blackQueenPosition.X + 1; row <= whiteQueenPosition.X; row++)
            {
                numberOfMoves--;
            }

            Assert.AreEqual(0, numberOfMoves);
        }

        [TestMethod]
        public void BlackQueenCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Point(1, 1);
            var blackQueenPosition = new Point(2, 1);
            var whiteQueenPosition = new Point(4, 1);
            var whitePawnPosition = new Point(2, 8);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackQueenCantMoveIfCantPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackQueenPosition = new Point(3, 2);
            var whiteQueenPosition = new Point(4, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackQueenCantTakePieceIfCantPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackQueenPosition = new Point(8, 8);
            var whitePawnPosition = new Point(7, 8);
            var whiteQueenPosition = new Point(1, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackQueenCanMoveIfCanPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackQueenPosition = new Point(1, 7);
            var whiteQueenPosition = new Point(3, 6);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            var defensePosition = new Point(whiteQueenPosition.X, whiteQueenPosition.Y - 1);
            Assert.IsTrue(ChessBoard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackQueenCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackQueenPosition = new Point(2, 3);
            var whiteQueenPosition = new Point(3, 4);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition);

            Assert.IsTrue(ChessBoard[whiteQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
