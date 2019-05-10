using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KingUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackKingThreatUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackKingCantMoveIfWillCauseACheck()
        {
            var blackKingPosition = new Point(1, 1);
            var whiteQueenPosition = new Point(2, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCantTakePieceIfWillCauseACheck()
        {
            var blackKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y);
            var whiteBishopPosition = new Point(whitePawnPosition.X - 1, whitePawnPosition.Y - 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            Assert.IsFalse(ChessBoard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackKingCanMoveAwayIfWillRemoveCheck()
        {
            var blackKingPosition = new Point(8, 2);
            var whiteQueenPosition = new Point(7, 1);
            var whitePawnPosition = new Point(6, 2);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            var availablePosition = new Point(8, 3);
            Assert.IsTrue(ChessBoard[availablePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackKingCanTakePieceIfWillRemoveCheck()
        {
            var blackKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(2, 1);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionBlackKing = blackKingPosition;

            ChessBoard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackKingPosition);

            Assert.IsTrue(ChessBoard[whiteQueenPosition].Available);
        }
    }
}
