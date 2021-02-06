using System.Diagnostics.CodeAnalysis;
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
            var whiteKingPosition = new Position(8, 8);
            var whiteRookPosition = new Position(5, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, whiteRookPosition, Chessboard);
            Chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteRookPosition);

            var positionNorth = new Position(whiteRookPosition.Row + 1, whiteRookPosition.Column);
            var positionSouth = new Position(whiteRookPosition.Row - 1, whiteRookPosition.Column);
            var positionEast = new Position(whiteRookPosition.Row, whiteRookPosition.Column + 1);
            var positionWest = new Position(whiteRookPosition.Row, whiteRookPosition.Column - 1);

            Assert.IsTrue(Chessboard[positionNorth].Available);
            Assert.IsTrue(Chessboard[positionSouth].Available);
            Assert.IsTrue(Chessboard[positionEast].Available);
            Assert.IsTrue(Chessboard[positionWest].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteRookCantTakeAnyWhitePieces()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteRookPosition = new Position(5, 5);

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