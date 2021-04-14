using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.BishopUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackBishopPieceTakingUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackBishopCanOnlyTakeWhitePiecesFromNorthEastAndSouthEastAndSouthWestAndNorthWest()
        {
            var blackKingPosition = new Position(8, 8);
            var blackBishopPosition = new Position(5, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackBishopPosition, chessboard);
            chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackBishopPosition);

            var positionNorthEast = new Position(blackBishopPosition.Row + 1, blackBishopPosition.Column + 1);
            var positionSouthEast = new Position(blackBishopPosition.Row - 1, blackBishopPosition.Column + 1);
            var positionSouthWest = new Position(blackBishopPosition.Row - 1, blackBishopPosition.Column - 1);
            var positionNorthWest = new Position(blackBishopPosition.Row + 1, blackBishopPosition.Column - 1);

            Assert.IsTrue(chessboard[positionNorthEast].Available);
            Assert.IsTrue(chessboard[positionSouthEast].Available);
            Assert.IsTrue(chessboard[positionSouthWest].Available);
            Assert.IsTrue(chessboard[positionNorthWest].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackBishopCantTakeAnyBlackPieces()
        {
            var blackKingPosition = new Position(8, 8);
            var blackBishopPosition = new Position(5, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackBishopPosition, chessboard);
            chessboard[blackBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

    }
}
