using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.RookUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackRookPieceTakingUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackRookCanOnlyTakeWhitePiecesFromNorthSouthEastAndWest()
        {
            var blackKingPosition = new Point(8, 8);
            var blackRookPosition = new Point(5, 5);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new Rook(PieceColor.Black);

            Methods.SurroundBoxWithPawns(PieceColor.White, blackRookPosition, ChessBoard);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            var positionNorth = new Point(blackRookPosition.X + 1, blackRookPosition.Y);
            var positionSouth = new Point(blackRookPosition.X - 1, blackRookPosition.Y);
            var positionEast = new Point(blackRookPosition.X, blackRookPosition.Y + 1);
            var positionWest = new Point(blackRookPosition.X, blackRookPosition.Y - 1);

            Assert.IsTrue(ChessBoard[positionNorth.X, positionNorth.Y].Available);
            Assert.IsTrue(ChessBoard[positionSouth.X, positionSouth.Y].Available);
            Assert.IsTrue(ChessBoard[positionEast.X, positionEast.Y].Available);
            Assert.IsTrue(ChessBoard[positionWest.X, positionWest.Y].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackRookCantTakeAnyBlackPieces()
        {
            var blackKingPosition = new Point(8, 8);
            var blackRookPosition = new Point(5, 5);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece = new Rook(PieceColor.Black);

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackRookPosition, ChessBoard);
            ChessBoard[blackRookPosition.X, blackRookPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}