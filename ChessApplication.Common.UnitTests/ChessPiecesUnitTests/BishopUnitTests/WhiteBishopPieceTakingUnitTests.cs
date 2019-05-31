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
    public class WhiteBishopPieceTakingUnitTests
    {
        private ChessboardClassic ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhiteBishopCanOnlyTakeBlackPiecesFromNorthEastAndSouthEastAndSouthWestAndNorthWest()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteBishopPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, whiteBishopPosition, ChessBoard);
            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            var positionNorthEast = new Point(whiteBishopPosition.X + 1, whiteBishopPosition.Y + 1);
            var positionSouthEast = new Point(whiteBishopPosition.X - 1, whiteBishopPosition.Y + 1);
            var positionSouthWest = new Point(whiteBishopPosition.X - 1, whiteBishopPosition.Y - 1);
            var positionNorthWest = new Point(whiteBishopPosition.X + 1, whiteBishopPosition.Y - 1);

            Assert.IsTrue(ChessBoard[positionNorthEast].Available);
            Assert.IsTrue(ChessBoard[positionSouthEast].Available);
            Assert.IsTrue(ChessBoard[positionSouthWest].Available);
            Assert.IsTrue(ChessBoard[positionNorthWest].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteBishopCantTakeAnyWhitePieces()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteBishopPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, whiteBishopPosition, ChessBoard);
            ChessBoard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

    }
}
