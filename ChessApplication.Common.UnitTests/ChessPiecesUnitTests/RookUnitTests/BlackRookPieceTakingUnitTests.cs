using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.RookUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackRookPieceTakingUnitTests
    {
        private ChessboardClassic ChessBoard;

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

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackRookPosition, ChessBoard);
            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            var positionNorth = new Point(blackRookPosition.X + 1, blackRookPosition.Y);
            var positionSouth = new Point(blackRookPosition.X - 1, blackRookPosition.Y);
            var positionEast = new Point(blackRookPosition.X, blackRookPosition.Y + 1);
            var positionWest = new Point(blackRookPosition.X, blackRookPosition.Y - 1);

            Assert.IsTrue(ChessBoard[positionNorth].Available);
            Assert.IsTrue(ChessBoard[positionSouth].Available);
            Assert.IsTrue(ChessBoard[positionEast].Available);
            Assert.IsTrue(ChessBoard[positionWest].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackRookCantTakeAnyBlackPieces()
        {
            var blackKingPosition = new Point(8, 8);
            var blackRookPosition = new Point(5, 5);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackRookPosition, ChessBoard);
            ChessBoard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}