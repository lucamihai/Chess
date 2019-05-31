using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteBishopPieceTakingUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteBishopCanOnlyTakeBlackPiecesFromNorthEastAndSouthEastAndSouthWestAndNorthWest()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteBishopPosition = new Point(5, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, whiteBishopPosition, Chessboard);
            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            var positionNorthEast = new Point(whiteBishopPosition.X + 1, whiteBishopPosition.Y + 1);
            var positionSouthEast = new Point(whiteBishopPosition.X - 1, whiteBishopPosition.Y + 1);
            var positionSouthWest = new Point(whiteBishopPosition.X - 1, whiteBishopPosition.Y - 1);
            var positionNorthWest = new Point(whiteBishopPosition.X + 1, whiteBishopPosition.Y - 1);

            Assert.IsTrue(Chessboard[positionNorthEast].Available);
            Assert.IsTrue(Chessboard[positionSouthEast].Available);
            Assert.IsTrue(Chessboard[positionSouthWest].Available);
            Assert.IsTrue(Chessboard[positionNorthWest].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteBishopCantTakeAnyWhitePieces()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteBishopPosition = new Point(5, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, whiteBishopPosition, Chessboard);
            Chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

    }
}
