using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests.Pawn
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BlackPawnPieceTakingUnitTests
    {
        private Box[,] ChessBoard;

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

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);

            Methods.SurroundBoxWithPawns(PieceColor.White, blackPawnPosition, ChessBoard);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            var positionSouthWest = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);
            var positionSouthEast = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y + 1);

            Assert.IsTrue(ChessBoard[positionSouthWest.X, positionSouthWest.Y].Available);
            Assert.IsTrue(ChessBoard[positionSouthEast.X, positionSouthEast.Y].Available);
            Assert.AreEqual(2, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCantTakeAnyBlackPiece()
        {
            var blackKingPosition = new Point(8, 8);
            var blackPawnPosition = new Point(3, 3);

            ChessBoard[blackKingPosition.X, blackKingPosition.Y].Piece = new King(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);

            Methods.SurroundBoxWithPawns(PieceColor.Black, blackPawnPosition, ChessBoard);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
