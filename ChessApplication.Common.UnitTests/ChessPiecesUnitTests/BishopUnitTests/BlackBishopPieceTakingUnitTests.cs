using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackBishopPieceTakingUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackBishopCanOnlyTakeWhitePiecesFromNorthEastAndSouthEastAndSouthWestAndNorthWest()
        {
            var blackKingPosition = new Point(8, 8);
            var blackBishopPosition = new Point(5, 5);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);

            Methods.SurroundBoxWithPawns(PieceColor.White, blackBishopPosition, ChessBoard);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            var positionNorthEast = new Point(blackBishopPosition.X + 1, blackBishopPosition.Y + 1);
            var positionSouthEast = new Point(blackBishopPosition.X - 1, blackBishopPosition.Y + 1);
            var positionSouthWest = new Point(blackBishopPosition.X - 1, blackBishopPosition.Y - 1);
            var positionNorthWest = new Point(blackBishopPosition.X + 1, blackBishopPosition.Y - 1);

            Assert.IsTrue(ChessBoard[positionNorthEast.X, positionNorthEast.Y].Available);
            Assert.IsTrue(ChessBoard[positionSouthEast.X, positionSouthEast.Y].Available);
            Assert.IsTrue(ChessBoard[positionSouthWest.X, positionSouthWest.Y].Available);
            Assert.IsTrue(ChessBoard[positionNorthWest.X, positionNorthWest.Y].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackBishopCantTakeAnyBlackPieces()
        {
            var blackKingPosition = new Point(8, 8);
            var blackBishopPosition = new Point(5, 5);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece = new Bishop(PieceColor.Black);

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackBishopPosition, ChessBoard);
            ChessBoard[blackBishopPosition.X, blackBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

    }
}
