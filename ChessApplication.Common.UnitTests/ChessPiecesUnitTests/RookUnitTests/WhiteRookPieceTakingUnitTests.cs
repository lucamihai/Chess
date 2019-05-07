using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.RookUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteRookPieceTakingUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteRookCanOnlyTakeBlackPiecesFromNorthSouthEastAndWest()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteRookPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);

            Methods.SurroundBoxWithPawns(PieceColor.Black, whiteRookPosition, ChessBoard);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            var positionNorth = new Point(whiteRookPosition.X + 1, whiteRookPosition.Y);
            var positionSouth = new Point(whiteRookPosition.X - 1, whiteRookPosition.Y);
            var positionEast = new Point(whiteRookPosition.X, whiteRookPosition.Y + 1);
            var positionWest = new Point(whiteRookPosition.X, whiteRookPosition.Y - 1);

            Assert.IsTrue(ChessBoard[positionNorth.X, positionNorth.Y].Available);
            Assert.IsTrue(ChessBoard[positionSouth.X, positionSouth.Y].Available);
            Assert.IsTrue(ChessBoard[positionEast.X, positionEast.Y].Available);
            Assert.IsTrue(ChessBoard[positionWest.X, positionWest.Y].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteRookCantTakeAnyWhitePieces()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteRookPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece = new Rook(PieceColor.White);

            Methods.SurroundBoxWithPawns(PieceColor.White, whiteRookPosition, ChessBoard);
            ChessBoard[whiteRookPosition.X, whiteRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteRookPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}