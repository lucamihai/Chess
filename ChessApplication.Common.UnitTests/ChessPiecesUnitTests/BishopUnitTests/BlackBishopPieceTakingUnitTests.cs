using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackBishopPieceTakingUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackBishopCanOnlyTakeWhitePiecesFromNorthEastAndSouthEastAndSouthWestAndNorthWest()
        {
            var blackKingPosition = new Position(8, 8);
            var blackBishopPosition = new Position(5, 5);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackBishopPosition, Chessboard);
            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            var positionNorthEast = new Position(blackBishopPosition.Row + 1, blackBishopPosition.Column + 1);
            var positionSouthEast = new Position(blackBishopPosition.Row - 1, blackBishopPosition.Column + 1);
            var positionSouthWest = new Position(blackBishopPosition.Row - 1, blackBishopPosition.Column - 1);
            var positionNorthWest = new Position(blackBishopPosition.Row + 1, blackBishopPosition.Column - 1);

            Assert.IsTrue(Chessboard[positionNorthEast].Available);
            Assert.IsTrue(Chessboard[positionSouthEast].Available);
            Assert.IsTrue(Chessboard[positionSouthWest].Available);
            Assert.IsTrue(Chessboard[positionNorthWest].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackBishopCantTakeAnyBlackPieces()
        {
            var blackKingPosition = new Position(8, 8);
            var blackBishopPosition = new Position(5, 5);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackBishopPosition, Chessboard);
            Chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

    }
}
