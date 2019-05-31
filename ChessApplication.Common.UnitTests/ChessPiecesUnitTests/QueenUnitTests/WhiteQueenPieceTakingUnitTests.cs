using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteQueenPieceTakingUnitTests
    {
        private ChessboardClassic ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteQueenCanTakeBlackPiecesFromAnyDirection()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteQueenPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, whiteQueenPosition, ChessBoard);
            ChessBoard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition);

            var positionNorth = new Point(whiteQueenPosition.X + 1, whiteQueenPosition.Y);
            var positionSouth = new Point(whiteQueenPosition.X - 1, whiteQueenPosition.Y);
            var positionEast = new Point(whiteQueenPosition.X, whiteQueenPosition.Y + 1);
            var positionWest = new Point(whiteQueenPosition.X, whiteQueenPosition.Y - 1);

            var positionNorthEast = new Point(whiteQueenPosition.X + 1, whiteQueenPosition.Y + 1);
            var positionSouthEast = new Point(whiteQueenPosition.X - 1, whiteQueenPosition.Y + 1);
            var positionSouthWest = new Point(whiteQueenPosition.X - 1, whiteQueenPosition.Y - 1);
            var positionNorthWest = new Point(whiteQueenPosition.X + 1, whiteQueenPosition.Y - 1);

            Assert.IsTrue(ChessBoard[positionNorth].Available);
            Assert.IsTrue(ChessBoard[positionSouth].Available);
            Assert.IsTrue(ChessBoard[positionEast].Available);
            Assert.IsTrue(ChessBoard[positionWest].Available);

            Assert.IsTrue(ChessBoard[positionNorthEast].Available);
            Assert.IsTrue(ChessBoard[positionSouthEast].Available);
            Assert.IsTrue(ChessBoard[positionSouthWest].Available);
            Assert.IsTrue(ChessBoard[positionNorthWest].Available);

            Assert.AreEqual(8, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteQueenCantTakeAnyWhitePieces()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteQueenPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, whiteQueenPosition, ChessBoard);
            ChessBoard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
