using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackQueenCheckUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackQueenCantMoveIfWillCauseCheck()
        {
            var blackKingPosition = new Position(1, 1);
            var blackQueenPosition = new Position(2, 1);
            var whiteQueenPosition = new Position(4, 1);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            var numberOfMoves = Methods.GetNumberOfAvailableBoxes(chessboard);
            for (int row = blackQueenPosition.Row + 1; row <= whiteQueenPosition.Row; row++)
            {
                numberOfMoves--;
            }

            Assert.AreEqual(0, numberOfMoves);
        }

        [TestMethod]
        public void BlackQueenCantTakePieceIfWillCauseCheck()
        {
            var blackKingPosition = new Position(1, 1);
            var blackQueenPosition = new Position(2, 1);
            var whiteQueenPosition = new Position(4, 1);
            var whitePawnPosition = new Position(2, 8);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            Assert.IsFalse(chessboard[whitePawnPosition].Available);
        }

        [TestMethod]
        public void BlackQueenCantMoveIfCantPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackQueenPosition = new Position(3, 2);
            var whiteQueenPosition = new Position(4, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackQueenCantTakePieceIfCantPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackQueenPosition = new Position(8, 8);
            var whitePawnPosition = new Position(7, 8);
            var whiteQueenPosition = new Position(1, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackQueenCanMoveIfCanPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackQueenPosition = new Position(1, 7);
            var whiteQueenPosition = new Position(3, 6);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            var defensePosition = new Position(whiteQueenPosition.Row, whiteQueenPosition.Column - 1);
            Assert.IsTrue(chessboard[defensePosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackQueenCanTakePieceIfCanPreventCheck()
        {
            var blackKingPosition = new Position(3, 3);
            var blackQueenPosition = new Position(2, 3);
            var whiteQueenPosition = new Position(3, 4);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionBlackKing = blackKingPosition;

            chessboard[blackQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackQueenPosition);

            Assert.IsTrue(chessboard[whiteQueenPosition].Available);
            Assert.AreEqual(1, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}
