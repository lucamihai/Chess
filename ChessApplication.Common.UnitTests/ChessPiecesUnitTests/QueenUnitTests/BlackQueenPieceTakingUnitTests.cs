using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackQueenPieceTakingUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackQueenCanTakeWhitePiecesFromAnyDirection()
        {
            var blackKingPosition = new Point(8, 8);
            var blackQueenPosition = new Point(5, 5);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            Methods.SurroundBoxWithPawns(PieceColor.White, blackQueenPosition, ChessBoard);
            ChessBoard[blackQueenPosition.X, blackQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackQueenPosition, blackKingPosition);

            var positionNorth = new Point(blackQueenPosition.X + 1, blackQueenPosition.Y);
            var positionSouth = new Point(blackQueenPosition.X - 1, blackQueenPosition.Y);
            var positionEast = new Point(blackQueenPosition.X, blackQueenPosition.Y + 1);
            var positionWest = new Point(blackQueenPosition.X, blackQueenPosition.Y - 1);

            var positionNorthEast = new Point(blackQueenPosition.X + 1, blackQueenPosition.Y + 1);
            var positionSouthEast = new Point(blackQueenPosition.X - 1, blackQueenPosition.Y + 1);
            var positionSouthWest = new Point(blackQueenPosition.X - 1, blackQueenPosition.Y - 1);
            var positionNorthWest = new Point(blackQueenPosition.X + 1, blackQueenPosition.Y - 1);

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
        public void BlackQueenCantTakeAnyBlackPieces()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteQueenPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece = new Queen(PieceColor.Black);

            Methods.SurroundBoxWithPawns(PieceColor.Black, whiteQueenPosition, ChessBoard);
            ChessBoard[whiteQueenPosition.X, whiteQueenPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteQueenPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
