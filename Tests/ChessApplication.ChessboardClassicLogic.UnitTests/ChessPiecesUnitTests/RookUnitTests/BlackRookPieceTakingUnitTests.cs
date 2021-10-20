using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.RookUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackRookPieceTakingUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void BlackRookCanOnlyTakeWhitePiecesFromNorthSouthEastAndWest()
        {
            var blackKingPosition = new Position(8, 8);
            var blackRookPosition = new Position(5, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackRookPosition, chessboard);
            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            var positionNorth = new Position(blackRookPosition.Row + 1, blackRookPosition.Column);
            var positionSouth = new Position(blackRookPosition.Row - 1, blackRookPosition.Column);
            var positionEast = new Position(blackRookPosition.Row, blackRookPosition.Column + 1);
            var positionWest = new Position(blackRookPosition.Row, blackRookPosition.Column - 1);

            Assert.IsTrue(chessboard[positionNorth].Available);
            Assert.IsTrue(chessboard[positionSouth].Available);
            Assert.IsTrue(chessboard[positionEast].Available);
            Assert.IsTrue(chessboard[positionWest].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void BlackRookCantTakeAnyBlackPieces()
        {
            var blackKingPosition = new Position(8, 8);
            var blackRookPosition = new Position(5, 5);

            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);
            chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackRookPosition, chessboard);
            chessboard[blackRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, blackRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}