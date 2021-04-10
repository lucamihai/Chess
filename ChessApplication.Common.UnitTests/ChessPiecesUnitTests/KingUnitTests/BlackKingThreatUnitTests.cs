using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var blackKingPosition = new Position(1, 1);
            var whiteQueenPosition = new Position(2, 3);

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
            var blackKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column);
            var whiteBishopPosition = new Position(whitePawnPosition.Row - 1, whitePawnPosition.Column - 1);

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
            var blackKingPosition = new Position(8, 2);
            var whiteQueenPosition = new Position(7, 1);
            var whitePawnPosition = new Position(6, 2);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            var availablePosition = new Position(8, 3);
            Assert.IsTrue(Chessboard[availablePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakePieceIfWillRemoveCheck()
        {
            var blackKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(2, 1);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionBlackKing = blackKingPosition;

            Chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackKingPosition);

            Assert.IsTrue(Chessboard[whiteQueenPosition].Available);
        }
    }
}
