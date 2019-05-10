using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhitePawnPieceTakingUnitTests
    {
        private Chessboard ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void WhitePawnCanTakeBlackPieceOnlyFromNorthWestAndNorthEast()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, whitePawnPosition, ChessBoard);
            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            var positionNorthWest = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y - 1);
            var positionNorthEast = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 1);

            Assert.IsTrue(ChessBoard[positionNorthWest].Available);
            Assert.IsTrue(ChessBoard[positionNorthEast].Available);
            Assert.AreEqual(2, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCantTakeAnyWhitePiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(3, 3);

            ChessBoard[whiteKingPosition].Piece = new King(PieceColor.White);
            ChessBoard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            ChessBoard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, whitePawnPosition, ChessBoard);
            ChessBoard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}