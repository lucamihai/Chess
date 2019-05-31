using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

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
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(3, 3);

            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackPawnPosition, Chessboard);
            Chessboard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(Chessboard, blackPawnPosition);

            var positionSouthWest = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);
            var positionSouthEast = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y + 1);

            Assert.IsTrue(Chessboard[positionSouthWest].Available);
            Assert.IsTrue(Chessboard[positionSouthEast].Available);
            Assert.AreEqual(2, Methods.GetNumberOfAvailableBoxes(Chessboard));
        }

        [TestMethod]
        public void BlackPawnCantTakeAnyBlackPiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(3, 3);

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