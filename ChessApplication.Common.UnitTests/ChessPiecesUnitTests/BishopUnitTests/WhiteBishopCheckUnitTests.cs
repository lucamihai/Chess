using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteBishopCheckUnitTests
    {
        private ChessboardClassic ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteBishopCantMoveIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(2, 2);
            var blackQueenPosition = new Point(8, 2);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteBishopCantTakePieceIfWillCauseCheck()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(2, 2);
            var blackQueenPosition = new Point(8, 2);
            var blackPawnPosition = new Point(whiteBishopPosition.X + 1, whiteBishopPosition.Y + 1);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            Assert.IsFalse(ChessBoard[blackPawnPosition].Available);
        }

        [TestMethod]
        public void WhiteBishopCantMoveIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(1, 2);
            var whiteBishopPosition = new Point(3, 2);
            var blackQueenPosition = new Point(1, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteBishopCantTakePieceIfCantPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteBishopPosition = new Point(8, 8);
            var blackPawnPosition = new Point(7, 7);
            var blackQueenPosition = new Point(1, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteBishopCanMoveIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteBishopPosition = new Point(4, 3);
            var blackQueenPosition = new Point(3, 8);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            var defensePosition = new Point(blackQueenPosition.X, whiteBishopPosition.Y + 1);
            Assert.IsTrue(ChessBoard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteBishopCanTakePieceIfCanPreventCheck()
        {
            var whiteKingPosition = new Point(3, 3);
            var whiteBishopPosition = new Point(2, 4);
            var blackQueenPosition = new Point(1, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            Assert.IsTrue(ChessBoard[blackQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

    }
}
