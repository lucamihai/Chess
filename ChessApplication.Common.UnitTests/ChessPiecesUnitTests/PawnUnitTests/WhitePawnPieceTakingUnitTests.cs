using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhitePawnPieceTakingUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhitePawnCanTakeBlackPieceOnlyFromNorthWestAndNorthEast()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, whitePawnPosition, Chessboard);
            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            var positionNorthWest = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y - 1);
            var positionNorthEast = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 1);

            Assert.IsTrue(Chessboard[positionNorthWest].Available);
            Assert.IsTrue(Chessboard[positionNorthEast].Available);
            Assert.AreEqual(2, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhitePawnCantTakeAnyWhitePiece()
        {
            var whiteKingPosition = new Point(8, 8);
            var whitePawnPosition = new Point(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, whitePawnPosition, Chessboard);
            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}