using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhitePawnPieceTakingUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhitePawnCanTakeBlackPieceOnlyFromNorthWestAndNorthEast()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, whitePawnPosition, chessboard);
            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            var positionNorthWest = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column - 1);
            var positionNorthEast = new Position(whitePawnPosition.Row + 1, whitePawnPosition.Column + 1);

            Assert.IsTrue(chessboard[positionNorthWest].Available);
            Assert.IsTrue(chessboard[positionNorthEast].Available);
            Assert.AreEqual(2, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhitePawnCantTakeAnyWhitePiece()
        {
            var whiteKingPosition = new Position(8, 8);
            var whitePawnPosition = new Position(3, 3);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, whitePawnPosition, chessboard);
            chessboard[whitePawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whitePawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}