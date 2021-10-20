using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.RookUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackRookCheckUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackRookCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackRookPosition = new Position(4, 4);
            var whiteQueenPosition = new Position(5, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackRookCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackRookPosition = new Position(4, 4);
            var whiteQueenPosition = new Position(5, 5);
            var whitePawnPosition = new Position(4, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackRookCantMoveIfCantPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackRookPosition = new Position(3, 2);
            var whiteQueenPosition = new Position(1, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackRookCantTakePieceIfCantPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackRookPosition = new Position(8, 8);
            var whitePawnPosition = new Position(7, 8);
            var whiteQueenPosition = new Position(1, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackRookCanMoveIfCanPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackRookPosition = new Position(1, 7);
            var whiteQueenPosition = new Position(3, 8);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            var defensePosition = new Position(whiteQueenPosition.Row, blackRookPosition.Column);
            Assert.IsTrue(chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteRookCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackRookPosition = new Position(1, 2);
            var whiteQueenPosition = new Position(1, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            Assert.IsTrue(chessboard[whiteQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}