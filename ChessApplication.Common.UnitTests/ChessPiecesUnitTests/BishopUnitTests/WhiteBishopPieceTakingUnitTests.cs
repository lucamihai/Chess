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
    public class WhiteBishopPieceTakingUnitTests
    {
        private Box[,] ChessBoard;

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

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece = new Bishop(PieceColor.White);

            Methods.SurroundBoxWithPawns(PieceColor.Black, whiteBishopPosition, ChessBoard);
            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition, whiteKingPosition);

            var positionNorthEast = new Point(whiteBishopPosition.X + 1, whiteBishopPosition.Y + 1);
            var positionSouthEast = new Point(whiteBishopPosition.X - 1, whiteBishopPosition.Y + 1);
            var positionSouthWest = new Point(whiteBishopPosition.X - 1, whiteBishopPosition.Y - 1);
            var positionNorthWest = new Point(whiteBishopPosition.X + 1, whiteBishopPosition.Y - 1);

            Assert.IsTrue(ChessBoard[positionNorthEast.X, positionNorthEast.Y].Available);
            Assert.IsTrue(ChessBoard[positionSouthEast.X, positionSouthEast.Y].Available);
            Assert.IsTrue(ChessBoard[positionSouthWest.X, positionSouthWest.Y].Available);
            Assert.IsTrue(ChessBoard[positionNorthWest.X, positionNorthWest.Y].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhiteBishopCantTakeAnyWhitePieces()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteBishopPosition = new Point(5, 5);

            ChessBoard[whiteKingPosition.X, whiteKingPosition.Y].Piece = new King(PieceColor.White);
            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece = new Bishop(PieceColor.White);

            Methods.SurroundBoxWithPawns(PieceColor.White, whiteBishopPosition, ChessBoard);
            ChessBoard[whiteBishopPosition.X, whiteBishopPosition.Y].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whiteBishopPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

    }
}
