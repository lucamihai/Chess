using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.KingUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackKingThreatUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackKingCantMoveIfWillCauseACheck()
        {
            var blackKingPosition = new Position(1, 1);
            var whiteQueenPosition = new Position(2, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKingCantTakePieceIfWillCauseACheck()
        {
            var blackKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(blackKingPosition.Row - 1, blackKingPosition.Column);
            var whiteBishopPosition = new Position(whitePawnPosition.Row - 1, whitePawnPosition.Column - 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackKingCanMoveAwayIfWillRemoveCheck()
        {
            var blackKingPosition = new Position(8, 2);
            var whiteQueenPosition = new Position(7, 1);
            var whitePawnPosition = new Position(6, 2);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            var availablePosition = new Position(8, 3);
            Assert.IsTrue(chessboard[availablePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackKingCanTakePieceIfWillRemoveCheck()
        {
            var blackKingPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(2, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackKingPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackKingPosition);

            Assert.IsTrue(chessboard[whiteQueenPosition].Available);
        }
    }
}
