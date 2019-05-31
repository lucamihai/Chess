using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.PawnUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackPawnPieceTakingUnitTests
    {
        private ChessboardClassic ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = ChessboardProvider.GetChessboardWithNoPieces();
        }

        [TestMethod]
        public void BlackPawnCanTakeWhitePieceOnlyFromSouthWestAndSouthEast()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(3, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.White, blackPawnPosition, ChessBoard);
            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            var positionSouthWest = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);
            var positionSouthEast = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y + 1);

            Assert.IsTrue(ChessBoard[positionSouthWest].Available);
            Assert.IsTrue(ChessBoard[positionSouthEast].Available);
            Assert.AreEqual(2, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCantTakeAnyBlackPiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(3, 3);

            ChessBoard[blackKingPosition].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            ChessBoard.PositionBlackKing = blackKingPosition;

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackPawnPosition, ChessBoard);
            ChessBoard[blackPawnPosition].Piece
                .CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}