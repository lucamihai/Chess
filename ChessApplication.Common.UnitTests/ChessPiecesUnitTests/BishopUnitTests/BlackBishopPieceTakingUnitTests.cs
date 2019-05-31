using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackBishopPieceTakingUnitTests
    {
        private ChessboardClassic ChessBoard;

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

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackBishopPosition, ChessBoard);
            ChessBoard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition);

            var positionNorthEast = new Point(blackBishopPosition.X + 1, blackBishopPosition.Y + 1);
            var positionSouthEast = new Point(blackBishopPosition.X - 1, blackBishopPosition.Y + 1);
            var positionSouthWest = new Point(blackBishopPosition.X - 1, blackBishopPosition.Y - 1);
            var positionNorthWest = new Point(blackBishopPosition.X + 1, blackBishopPosition.Y - 1);

            Assert.IsTrue(ChessBoard[positionNorthEast].Available);
            Assert.IsTrue(ChessBoard[positionSouthEast].Available);
            Assert.IsTrue(ChessBoard[positionSouthWest].Available);
            Assert.IsTrue(ChessBoard[positionNorthWest].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackBishopCantTakeAnyBlackPieces()
        {
            var blackKingPosition = new Point(8, 8);
            var blackBishopPosition = new Point(5, 5);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackBishopPosition, ChessBoard);
            ChessBoard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

    }
}
