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
    public class WhitePawnPieceTakingUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = new Box[10, 10];
        }

        [TestMethod]
        public void WhitePawnCanTakeBlackPieceOnlyFromNorthWestAndNorthEast()
        {
            ChessBoard = ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var whitePawnPosition = new Point(3, 3);
            var blackPawnPositionWest = new Point(whitePawnPosition.X, whitePawnPosition.Y - 1);
            var blackPawnPositionNorthWest = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y - 1);
            var blackPawnPositionNorth = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y);
            var blackPawnPositionNorthEast = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 1);
            var blackPawnPositionEast = new Point(whitePawnPosition.X, whitePawnPosition.Y + 1);
            var blackPawnPositionSouthEast = new Point(whitePawnPosition.X - 1, whitePawnPosition.Y - 1);
            var blackPawnPositionSouth = new Point(whitePawnPosition.X - 1, whitePawnPosition.Y);
            var blackPawnPositionSouthWest = new Point(whitePawnPosition.X - 1, whitePawnPosition.Y - 1);

            ChessBoard[blackPawnPositionWest.X, blackPawnPositionWest.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionNorthWest.X, blackPawnPositionNorthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionNorth.X, blackPawnPositionNorth.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionNorthEast.X, blackPawnPositionNorthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionEast.X, blackPawnPositionEast.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionSouthEast.X, blackPawnPositionSouthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionSouth.X, blackPawnPositionSouth.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnPositionSouthWest.X, blackPawnPositionSouthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnPositionNorthWest.X, blackPawnPositionNorthWest.Y].Available);
            Assert.IsTrue(ChessBoard[blackPawnPositionNorthEast.X, blackPawnPositionNorthEast.Y].Available);
            Assert.AreEqual(2, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCantTakeAnyWhitePiece()
        {
            ChessBoard = ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var whitePawnPosition = new Point(3, 3);
            var whitePawnPositionWest = new Point(whitePawnPosition.X, whitePawnPosition.Y - 1);
            var whitePawnPositionNorthWest = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y - 1);
            var whitePawnPositionNorth = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y);
            var whitePawnPositionNorthEast = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 1);
            var whitePawnPositionEast = new Point(whitePawnPosition.X, whitePawnPosition.Y + 1);
            var whitePawnPositionSouthEast = new Point(whitePawnPosition.X - 1, whitePawnPosition.Y - 1);
            var whitePawnPositionSouth = new Point(whitePawnPosition.X - 1, whitePawnPosition.Y);
            var whitePawnPositionSouthWest = new Point(whitePawnPosition.X - 1, whitePawnPosition.Y - 1);

            ChessBoard[whitePawnPositionWest.X, whitePawnPositionWest.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionNorthWest.X, whitePawnPositionNorthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionNorth.X, whitePawnPositionNorth.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionNorthEast.X, whitePawnPositionNorthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionEast.X, whitePawnPositionEast.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionSouthEast.X, whitePawnPositionSouthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionSouth.X, whitePawnPositionSouth.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPositionSouthWest.X, whitePawnPositionSouthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnPosition.X, whitePawnPosition.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnPosition, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
