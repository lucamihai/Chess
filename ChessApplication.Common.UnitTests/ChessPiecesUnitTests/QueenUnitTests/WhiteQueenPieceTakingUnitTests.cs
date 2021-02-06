using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.QueenUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class WhiteQueenPieceTakingUnitTests
    {
        private IChessboard Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
        }

        [TestMethod]
        public void WhiteQueenCanTakeBlackPiecesFromAnyDirection()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteQueenPosition = new Position(5, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, whiteQueenPosition, Chessboard);
            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            var positionNorth = new Position(whiteQueenPosition.Row + 1, whiteQueenPosition.Column);
            var positionSouth = new Position(whiteQueenPosition.Row - 1, whiteQueenPosition.Column);
            var positionEast = new Position(whiteQueenPosition.Row, whiteQueenPosition.Column + 1);
            var positionWest = new Position(whiteQueenPosition.Row, whiteQueenPosition.Column - 1);

            var positionNorthEast = new Position(whiteQueenPosition.Row + 1, whiteQueenPosition.Column + 1);
            var positionSouthEast = new Position(whiteQueenPosition.Row - 1, whiteQueenPosition.Column + 1);
            var positionSouthWest = new Position(whiteQueenPosition.Row - 1, whiteQueenPosition.Column - 1);
            var positionNorthWest = new Position(whiteQueenPosition.Row + 1, whiteQueenPosition.Column - 1);

            Assert.IsTrue(Chessboard[positionNorth].Available);
            Assert.IsTrue(Chessboard[positionSouth].Available);
            Assert.IsTrue(Chessboard[positionEast].Available);
            Assert.IsTrue(Chessboard[positionWest].Available);

            Assert.IsTrue(Chessboard[positionNorthEast].Available);
            Assert.IsTrue(Chessboard[positionSouthEast].Available);
            Assert.IsTrue(Chessboard[positionSouthWest].Available);
            Assert.IsTrue(Chessboard[positionNorthWest].Available);

            Assert.AreEqual(8, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void WhiteQueenCantTakeAnyWhitePieces()
        {
            var whiteKingPosition = new Position(8, 8);
            var whiteQueenPosition = new Position(5, 5);

            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);
            Chessboard.PositionWhiteKing = whiteKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, whiteQueenPosition, Chessboard);
            Chessboard[whiteQueenPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, whiteQueenPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }
    }
}
