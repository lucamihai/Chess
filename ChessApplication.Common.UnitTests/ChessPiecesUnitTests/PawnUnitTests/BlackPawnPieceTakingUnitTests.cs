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
    public class BlackPawnPieceTakingUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackPawnCanTakeWhitePieceOnlyFromSouthWestAndSouthEast()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackPawnPosition, Chessboard);
            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            var positionSouthWest = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column - 1);
            var positionSouthEast = new Position(blackPawnPosition.Row - 1, blackPawnPosition.Column + 1);

            Assert.IsTrue(Chessboard[positionSouthWest].Available);
            Assert.IsTrue(Chessboard[positionSouthEast].Available);
            Assert.AreEqual(2, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackPawnCantTakeAnyBlackPiece()
        {
            var blackKingPosition = new Position(8, 8);
            var blackPawnPosition = new Position(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackPawnPosition, Chessboard);
            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}