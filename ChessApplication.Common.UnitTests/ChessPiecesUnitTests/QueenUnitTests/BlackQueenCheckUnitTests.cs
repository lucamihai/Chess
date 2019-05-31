using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackQueenCheckUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackQueenCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Point(1, 1);
            var blackQueenPosition = new Point(2, 1);
            var whiteQueenPosition = new Point(4, 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackQueenPosition);

            var numberOfMoves = Methods.GetNumberOfAvailableBoxes(Chessboard);
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

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackQueenPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackQueenCantMoveIfCantPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackQueenPosition = new Point(3, 2);
            var whiteQueenPosition = new Point(4, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackQueenCantTakePieceIfCantPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackQueenPosition = new Point(8, 8);
            var whitePawnPosition = new Point(7, 8);
            var whiteQueenPosition = new Point(1, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackQueenCanMoveIfCanPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackQueenPosition = new Point(1, 7);
            var whiteQueenPosition = new Point(3, 6);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackQueenPosition);

            var defensePosition = new Point(whiteQueenPosition.X, whiteQueenPosition.Y - 1);
            Assert.IsTrue(Chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackQueenCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Point(3, 3);
            var blackQueenPosition = new Point(2, 3);
            var whiteQueenPosition = new Point(3, 4);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackQueenPosition);

            Assert.IsTrue(Chessboard[whiteQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}
