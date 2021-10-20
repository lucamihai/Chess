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
    public class BlackPawnPieceTakingUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackPawnCanTakeWhitePieceOnlyFromSouthWestAndSouthEast()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackPawnPosition, chessboard);
            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            var positionSouthWest = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column - 1);
            var positionSouthEast = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column + 1);

            Assert.IsTrue(chessboard[positionSouthWest].Available);
            Assert.IsTrue(chessboard[positionSouthEast].Available);
            Assert.AreEqual(2, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackPawnCantTakeAnyBlackPiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(3, 3);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackPawnPosition, chessboard);
            chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}