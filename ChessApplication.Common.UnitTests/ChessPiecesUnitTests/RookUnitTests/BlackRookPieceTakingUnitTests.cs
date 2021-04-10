using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.RookUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackRookPieceTakingUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackRookCanOnlyTakeWhitePiecesFromNorthSouthEastAndWest()
        {
            var blackKingPosition = new Position(8, 8);
            var blackRookPosition = new Position(5, 5);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackRookPosition, Chessboard);
            Chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackRookPosition);

            var positionNorth = new Position(blackRookPosition.Row + 1, blackRookPosition.Column);
            var positionSouth = new Position(blackRookPosition.Row - 1, blackRookPosition.Column);
            var positionEast = new Position(blackRookPosition.Row, blackRookPosition.Column + 1);
            var positionWest = new Position(blackRookPosition.Row, blackRookPosition.Column - 1);

            Assert.IsTrue(Chessboard[positionNorth].Available);
            Assert.IsTrue(Chessboard[positionSouth].Available);
            Assert.IsTrue(Chessboard[positionEast].Available);
            Assert.IsTrue(Chessboard[positionWest].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackRookCantTakeAnyBlackPieces()
        {
            var blackKingPosition = new Position(8, 8);
            var blackRookPosition = new Position(5, 5);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackRookPosition, Chessboard);
            Chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}