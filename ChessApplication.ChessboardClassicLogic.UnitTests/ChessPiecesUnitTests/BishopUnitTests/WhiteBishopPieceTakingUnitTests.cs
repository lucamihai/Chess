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
    public class WhiteBishopPieceTakingUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteBishopCanOnlyTakeBlackPiecesFromNorthEastAndSouthEastAndSouthWestAndNorthWest()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteBishopPosition = new Position(5, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, whiteBishopPosition, chessboard);
            chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteBishopPosition);

            var positionNorthEast = new Position(whiteBishopPosition.Row + 1, whiteBishopPosition.Column + 1);
            var positionSouthEast = new Position(whiteBishopPosition.Row - 1, whiteBishopPosition.Column + 1);
            var positionSouthWest = new Position(whiteBishopPosition.Row - 1, whiteBishopPosition.Column - 1);
            var positionNorthWest = new Position(whiteBishopPosition.Row + 1, whiteBishopPosition.Column - 1);

            Assert.IsTrue(chessboard[positionNorthEast].Available);
            Assert.IsTrue(chessboard[positionSouthEast].Available);
            Assert.IsTrue(chessboard[positionSouthWest].Available);
            Assert.IsTrue(chessboard[positionNorthWest].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteBishopCantTakeAnyWhitePieces()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteBishopPosition = new Position(5, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, whiteBishopPosition, chessboard);
            chessboard[whiteBishopPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteBishopPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

    }
}
