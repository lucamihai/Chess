using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.ChessboardClassicLogic.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteQueenPieceTakingUnitTests
    {
        private IChessboard chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteQueenCanTakeBlackPiecesFromAnyDirection()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteQueenPosition = new Position(5, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, whiteQueenPosition, chessboard);
            chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteQueenPosition);

            var positionNorth = new Position(whiteQueenPosition.Row + 1, whiteQueenPosition.Column);
            var positionSouth = new Position(whiteQueenPosition.Row - 1, whiteQueenPosition.Column);
            var positionEast = new Position(whiteQueenPosition.Row, whiteQueenPosition.Column + 1);
            var positionWest = new Position(whiteQueenPosition.Row, whiteQueenPosition.Column - 1);

            var positionNorthEast = new Position(whiteQueenPosition.Row + 1, whiteQueenPosition.Column + 1);
            var positionSouthEast = new Position(whiteQueenPosition.Row - 1, whiteQueenPosition.Column + 1);
            var positionSouthWest = new Position(whiteQueenPosition.Row - 1, whiteQueenPosition.Column - 1);
            var positionNorthWest = new Position(whiteQueenPosition.Row + 1, whiteQueenPosition.Column - 1);

            Assert.IsTrue(chessboard[positionNorth].Available);
            Assert.IsTrue(chessboard[positionSouth].Available);
            Assert.IsTrue(chessboard[positionEast].Available);
            Assert.IsTrue(chessboard[positionWest].Available);

            Assert.IsTrue(chessboard[positionNorthEast].Available);
            Assert.IsTrue(chessboard[positionSouthEast].Available);
            Assert.IsTrue(chessboard[positionSouthWest].Available);
            Assert.IsTrue(chessboard[positionNorthWest].Available);

            Assert.AreEqual(8, Methods.GetNumberOfAvailableBoxes(chessboard));
        }

        [TestMethod]
        public void WhiteQueenCantTakeAnyWhitePieces()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteQueenPosition = new Position(5, 5);

            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, whiteQueenPosition, chessboard);
            chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(chessboard, whiteQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(chessboard));
        }
    }
}
