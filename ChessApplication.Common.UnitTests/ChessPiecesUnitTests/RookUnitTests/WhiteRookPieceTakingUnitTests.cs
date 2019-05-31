using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.RookUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteRookPieceTakingUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteRookCanOnlyTakeBlackPiecesFromNorthSouthEastAndWest()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteRookPosition = new Point(5, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, whiteRookPosition, Chessboard);
            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            var positionNorth = new Point(whiteRookPosition.X + 1, whiteRookPosition.Y);
            var positionSouth = new Point(whiteRookPosition.X - 1, whiteRookPosition.Y);
            var positionEast = new Point(whiteRookPosition.X, whiteRookPosition.Y + 1);
            var positionWest = new Point(whiteRookPosition.X, whiteRookPosition.Y - 1);

            Assert.IsTrue(Chessboard[positionNorth].Available);
            Assert.IsTrue(Chessboard[positionSouth].Available);
            Assert.IsTrue(Chessboard[positionEast].Available);
            Assert.IsTrue(Chessboard[positionWest].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteRookCantTakeAnyWhitePieces()
        {
            var whiteKingPosition = new Point(8, 8);
            var whiteRookPosition = new Point(5, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, whiteRookPosition, Chessboard);
            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}