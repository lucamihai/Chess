using System.Diagnostics.CodeAnalysis;
using System.Drawing;
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
            ChessBoard = new Box[10, 10];
        }

        [TestMethod]
        public void BlackPawnCanTakeWhitePieceOnlyFromSouthWestAndSouthEast()
        {
            ChessBoard = ChessboardProvider.GetChessboardInitialState();
            var blackKingPosition = ChessboardProvider.GetBlackKingPositionForChessboardInitialState();
            var blackPawnPosition = new Point(3, 3);
            var whitePawnPositionWest = new Point(blackPawnPosition.X, blackPawnPosition.Y - 1);
            var whitePawnPositionNorthWest = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y - 1);
            var whitePawnPositionNorth = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y);
            var whitePawnPositionNorthEast = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y + 1);
            var whitePawnPositionEast = new Point(blackPawnPosition.X, blackPawnPosition.Y + 1);
            var whitePawnPositionSouthEast = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);
            var whitePawnPositionSouth = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y);
            var whitePawnPositionSouthWest = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);

            ChessBoard[whitePawnPositionWest.X, whitePawnPositionWest.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionNorthWest.X, whitePawnPositionNorthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionNorth.X, whitePawnPositionNorth.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionNorthEast.X, whitePawnPositionNorthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionEast.X, whitePawnPositionEast.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionSouthEast.X, whitePawnPositionSouthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionSouth.X, whitePawnPositionSouth.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionSouthWest.X, whitePawnPositionSouthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnPositionSouthWest.X, whitePawnPositionNorthWest.Y].Available);
            Assert.IsTrue(ChessBoard[whitePawnPositionSouthEast.X, whitePawnPositionNorthEast.Y].Available);
            Assert.AreEqual(2, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCantTakeAnyBlackPiece()
        {
            ChessBoard = ChessboardProvider.GetChessboardInitialState();
            var blackKingPosition = ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var blackPawnPosition = new Point(3, 3);
            var blackPawnPositionWest = new Point(blackPawnPosition.X, blackPawnPosition.Y - 1);
            var blackPawnPositionNorthWest = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y - 1);
            var blackPawnPositionNorth = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y);
            var blackPawnPositionNorthEast = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y + 1);
            var blackPawnPositionEast = new Point(blackPawnPosition.X, blackPawnPosition.Y + 1);
            var blackPawnPositionSouthEast = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);
            var blackPawnPositionSouth = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y);
            var blackPawnPositionSouthWest = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);

            ChessBoard[blackPawnPositionWest.X, blackPawnPositionWest.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionNorthWest.X, blackPawnPositionNorthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionNorth.X, blackPawnPositionNorth.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionNorthEast.X, blackPawnPositionNorthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionEast.X, blackPawnPositionEast.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionSouthEast.X, blackPawnPositionSouthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionSouth.X, blackPawnPositionSouth.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionSouthWest.X, blackPawnPositionSouthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);

            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPosition.X, blackPawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnPosition, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
