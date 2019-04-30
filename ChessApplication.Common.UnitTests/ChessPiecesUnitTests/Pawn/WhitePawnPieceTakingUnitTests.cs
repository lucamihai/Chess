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
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var whitePawnLocation = new Point(3, 3);
            var blackPawnLocationWest = new Point(whitePawnLocation.X, whitePawnLocation.Y - 1);
            var blackPawnLocationNorthWest = new Point(whitePawnLocation.X + 1, whitePawnLocation.Y - 1);
            var blackPawnLocationNorth = new Point(whitePawnLocation.X + 1, whitePawnLocation.Y);
            var blackPawnLocationNorthEast = new Point(whitePawnLocation.X + 1, whitePawnLocation.Y + 1);
            var blackPawnLocationEast = new Point(whitePawnLocation.X, whitePawnLocation.Y + 1);
            var blackPawnLocationSouthEast = new Point(whitePawnLocation.X - 1, whitePawnLocation.Y - 1);
            var blackPawnLocationSouth = new Point(whitePawnLocation.X - 1, whitePawnLocation.Y);
            var blackPawnLocationSouthWest = new Point(whitePawnLocation.X - 1, whitePawnLocation.Y - 1);

            ChessBoard[blackPawnLocationWest.X, blackPawnLocationWest.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationNorthWest.X, blackPawnLocationNorthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationNorth.X, blackPawnLocationNorth.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationNorthEast.X, blackPawnLocationNorthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationEast.X, blackPawnLocationEast.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationSouthEast.X, blackPawnLocationSouthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationSouth.X, blackPawnLocationSouth.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationSouthWest.X, blackPawnLocationSouthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);

            ChessBoard[whitePawnLocation.X, whitePawnLocation.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocation.X, whitePawnLocation.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnLocation, whiteKingPosition);

            Assert.IsTrue(ChessBoard[blackPawnLocationNorthWest.X, blackPawnLocationNorthWest.Y].Available);
            Assert.IsTrue(ChessBoard[blackPawnLocationNorthEast.X, blackPawnLocationNorthEast.Y].Available);
            Assert.AreEqual(2, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void WhitePawnCantTakeAnyWhitePiece()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var whitePawnLocation = new Point(3, 3);
            var whitePawnLocationWest = new Point(whitePawnLocation.X, whitePawnLocation.Y - 1);
            var whitePawnLocationNorthWest = new Point(whitePawnLocation.X + 1, whitePawnLocation.Y - 1);
            var whitePawnLocationNorth = new Point(whitePawnLocation.X + 1, whitePawnLocation.Y);
            var whitePawnLocationNorthEast = new Point(whitePawnLocation.X + 1, whitePawnLocation.Y + 1);
            var whitePawnLocationEast = new Point(whitePawnLocation.X, whitePawnLocation.Y + 1);
            var whitePawnLocationSouthEast = new Point(whitePawnLocation.X - 1, whitePawnLocation.Y - 1);
            var whitePawnLocationSouth = new Point(whitePawnLocation.X - 1, whitePawnLocation.Y);
            var whitePawnLocationSouthWest = new Point(whitePawnLocation.X - 1, whitePawnLocation.Y - 1);

            ChessBoard[whitePawnLocationWest.X, whitePawnLocationWest.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationNorthWest.X, whitePawnLocationNorthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationNorth.X, whitePawnLocationNorth.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationNorthEast.X, whitePawnLocationNorthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationEast.X, whitePawnLocationEast.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationSouthEast.X, whitePawnLocationSouthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationSouth.X, whitePawnLocationSouth.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationSouthWest.X, whitePawnLocationSouthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[whitePawnLocation.X, whitePawnLocation.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocation.X, whitePawnLocation.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, whitePawnLocation, whiteKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
