using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteQueenPieceTakingUnitTests
    {
        private Box[,] ChessBoard;

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

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            Methods.SurroundBoxWithPawns(PieceColor.Black, whiteQueenPosition, ChessBoard);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            var positionNorth = new Point(whiteQueenPosition.X + 1, whiteQueenPosition.Y);
            var positionSouth = new Point(whiteQueenPosition.X - 1, whiteQueenPosition.Y);
            var positionEast = new Point(whiteQueenPosition.X, whiteQueenPosition.Y + 1);
            var positionWest = new Point(whiteQueenPosition.X, whiteQueenPosition.Y - 1);

            var positionNorthEast = new Point(whiteQueenPosition.X + 1, whiteQueenPosition.Y + 1);
            var positionSouthEast = new Point(whiteQueenPosition.X - 1, whiteQueenPosition.Y + 1);
            var positionSouthWest = new Point(whiteQueenPosition.X - 1, whiteQueenPosition.Y - 1);
            var positionNorthWest = new Point(whiteQueenPosition.X + 1, whiteQueenPosition.Y - 1);

            Assert.IsTrue(ChessBoard[positionNorth.X, positionNorth.Y].Available);
            Assert.IsTrue(ChessBoard[positionSouth.X, positionSouth.Y].Available);
            Assert.IsTrue(ChessBoard[positionEast.X, positionEast.Y].Available);
            Assert.IsTrue(ChessBoard[positionWest.X, positionWest.Y].Available);

            Assert.IsTrue(ChessBoard[positionNorthEast.X, positionNorthEast.Y].Available);
            Assert.IsTrue(ChessBoard[positionSouthEast.X, positionSouthEast.Y].Available);
            Assert.IsTrue(ChessBoard[positionSouthWest.X, positionSouthWest.Y].Available);
            Assert.IsTrue(ChessBoard[positionNorthWest.X, positionNorthWest.Y].Available);

            Assert.AreEqual(8, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteQueenCantTakeAnyWhitePieces()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteQueenPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.White);

            Methods.SurroundBoxWithPawns(PieceColor.White, whiteQueenPosition, ChessBoard);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
