using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(3, 3);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, whitePawnPosition, Chessboard);
            Chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whitePawnPosition);

            var positionNorthWest = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column - 1);
            var positionNorthEast = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column + 1);

            Assert.IsTrue(Chessboard[positionNorthWest].Available);
            Assert.IsTrue(Chessboard[positionNorthEast].Available);
            Assert.AreEqual(2, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhitePawnCantTakeAnyWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(3, 3);

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