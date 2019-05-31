using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.KingUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackKingThreatUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackKingCantMoveIfWillCauseACheck()
        {
            var blackKingPosition = new Point(1, 1);
            var whiteQueenPosition = new Point(2, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKingCantTakePieceIfWillCauseACheck()
        {
            var blackKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(blackKingPosition.X - 1, blackKingPosition.Y);
            var whiteBishopPosition = new Point(whitePawnPosition.X - 1, whitePawnPosition.Y - 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.IsFalse(Chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackKingCanMoveAwayIfWillRemoveCheck()
        {
            var blackKingPosition = new Point(8, 2);
            var whiteQueenPosition = new Point(7, 1);
            var whitePawnPosition = new Point(6, 2);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            var availablePosition = new Point(8, 3);
            Assert.IsTrue(Chessboard[availablePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakePieceIfWillRemoveCheck()
        {
            var blackKingPosition = new Point(1, 2);
            var whiteQueenPosition = new Point(2, 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.IsTrue(Chessboard[whiteQueenPosition].Available);
        }
    }
}
