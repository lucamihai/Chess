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
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var blackKingPosition = UnitTestsUtilities.ChessboardProvider.GetBlackKingPositionForChessboardInitialState();
            var blackPawnLocation = new Point(3, 3);
            var whitePawnLocationWest = new Point(blackPawnLocation.X, blackPawnLocation.Y - 1);
            var whitePawnLocationNorthWest = new Point(blackPawnLocation.X + 1, blackPawnLocation.Y - 1);
            var whitePawnLocationNorth = new Point(blackPawnLocation.X + 1, blackPawnLocation.Y);
            var whitePawnLocationNorthEast = new Point(blackPawnLocation.X + 1, blackPawnLocation.Y + 1);
            var whitePawnLocationEast = new Point(blackPawnLocation.X, blackPawnLocation.Y + 1);
            var whitePawnLocationSouthEast = new Point(blackPawnLocation.X - 1, blackPawnLocation.Y - 1);
            var whitePawnLocationSouth = new Point(blackPawnLocation.X - 1, blackPawnLocation.Y);
            var whitePawnLocationSouthWest = new Point(blackPawnLocation.X - 1, blackPawnLocation.Y - 1);

            ChessBoard[whitePawnLocationWest.X, whitePawnLocationWest.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationNorthWest.X, whitePawnLocationNorthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationNorth.X, whitePawnLocationNorth.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationNorthEast.X, whitePawnLocationNorthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationEast.X, whitePawnLocationEast.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationSouthEast.X, whitePawnLocationSouthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationSouth.X, whitePawnLocationSouth.Y].Piece = new ChessPieces.Pawn(PieceColor.White);
            ChessBoard[whitePawnLocationSouthWest.X, whitePawnLocationSouthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.White);

            ChessBoard[blackPawnLocation.X, blackPawnLocation.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocation.X, blackPawnLocation.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnLocation, blackKingPosition);

            Assert.IsTrue(ChessBoard[whitePawnLocationSouthWest.X, whitePawnLocationNorthWest.Y].Available);
            Assert.IsTrue(ChessBoard[whitePawnLocationSouthEast.X, whitePawnLocationNorthEast.Y].Available);
            Assert.AreEqual(2, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }

        [TestMethod]
        public void BlackPawnCantTakeAnyBlackPiece()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var blackKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var blackPawnLocation = new Point(3, 3);
            var blackPawnLocationWest = new Point(blackPawnLocation.X, blackPawnLocation.Y - 1);
            var blackPawnLocationNorthWest = new Point(blackPawnLocation.X + 1, blackPawnLocation.Y - 1);
            var blackPawnLocationNorth = new Point(blackPawnLocation.X + 1, blackPawnLocation.Y);
            var blackPawnLocationNorthEast = new Point(blackPawnLocation.X + 1, blackPawnLocation.Y + 1);
            var blackPawnLocationEast = new Point(blackPawnLocation.X, blackPawnLocation.Y + 1);
            var blackPawnLocationSouthEast = new Point(blackPawnLocation.X - 1, blackPawnLocation.Y - 1);
            var blackPawnLocationSouth = new Point(blackPawnLocation.X - 1, blackPawnLocation.Y);
            var blackPawnLocationSouthWest = new Point(blackPawnLocation.X - 1, blackPawnLocation.Y - 1);

            ChessBoard[blackPawnLocationWest.X, blackPawnLocationWest.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationNorthWest.X, blackPawnLocationNorthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationNorth.X, blackPawnLocationNorth.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationNorthEast.X, blackPawnLocationNorthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationEast.X, blackPawnLocationEast.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationSouthEast.X, blackPawnLocationSouthEast.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationSouth.X, blackPawnLocationSouth.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocationSouthWest.X, blackPawnLocationSouthWest.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);

            ChessBoard[blackPawnLocation.X, blackPawnLocation.Y].Piece = new ChessPieces.Pawn(PieceColor.Black);
            ChessBoard[blackPawnLocation.X, blackPawnLocation.Y].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, blackPawnLocation, blackKingPosition);

            Assert.AreEqual(0, Methods.GetNumberOfAvailableBoxes(ChessBoard));
        }
    }
}
