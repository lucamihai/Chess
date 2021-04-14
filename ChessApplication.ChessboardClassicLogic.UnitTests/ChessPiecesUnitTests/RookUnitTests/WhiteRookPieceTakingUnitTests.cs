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
    public class WhiteRookPieceTakingUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteRookCanOnlyTakeBlackPiecesFromNorthSouthEastAndWest()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteRookPosition = new Position(5, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, whiteRookPosition, chessboard);
            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            var positionNorth = new Position(whiteRookPosition.Row + 1, whiteRookPosition.Column);
            var positionSouth = new Position(whiteRookPosition.Row - 1, whiteRookPosition.Column);
            var positionEast = new Position(whiteRookPosition.Row, whiteRookPosition.Column + 1);
            var positionWest = new Position(whiteRookPosition.Row, whiteRookPosition.Column - 1);

            Assert.IsTrue(chessboard[positionNorth].Available);
            Assert.IsTrue(chessboard[positionSouth].Available);
            Assert.IsTrue(chessboard[positionEast].Available);
            Assert.IsTrue(chessboard[positionWest].Available);
            Assert.AreEqual(4, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteRookCantTakeAnyWhitePieces()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteRookPosition = new Position(5, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, whiteRookPosition, chessboard);
            chessboard[whiteRookPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteRookPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}