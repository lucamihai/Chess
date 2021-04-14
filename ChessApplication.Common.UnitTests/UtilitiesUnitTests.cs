using System.Diagnostics.CodeAnalysis;
using ChessApplication.ChessboardClassicLogic.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Tests.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.Common.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UtilitiesUnitTests
    {
        [TestMethod]
        public void LocationContainsPieceReturnsTrueForAppropriatePieceTypeWithoutProvidingColor1()
        {
            var chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
            var whitePawnPosition = new Position(1, 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            Assert.IsTrue(Utilities.LocationContainsPiece<Pawn>(chessboard[whitePawnPosition]));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsTrueForAppropriatePieceTypeWithoutProvidingColor2()
        {
            var chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
            var blackBishopPosition = new Position(3, 3);

            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            Assert.IsTrue(Utilities.LocationContainsPiece<Bishop>(chessboard[blackBishopPosition]));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForDifferentPieceTypeWithoutProvidingColor1()
        {
            var chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
            var whitePawnPosition = new Position(1, 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            Assert.IsFalse(Utilities.LocationContainsPiece<Queen>(chessboard[whitePawnPosition]));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForDifferentPieceTypeWithoutProvidingColor2()
        {
            var chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
            var blackBishopPosition = new Position(3, 3);

            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            Assert.IsFalse(Utilities.LocationContainsPiece<Rook>(chessboard[blackBishopPosition]));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsTrueForAppropriatePieceTypeAndAppropriateProvidedColor1()
        {
            var chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
            var whitePawnPosition = new Position(1, 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            Assert.IsTrue(Utilities.LocationContainsPiece<Pawn>(chessboard[whitePawnPosition], PieceColor.White));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsTrueForAppropriatePieceTypeAndAppropriateProvidedColor2()
        {
            var chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
            var blackBishopPosition = new Position(3, 3);

            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            Assert.IsTrue(Utilities.LocationContainsPiece<Bishop>(chessboard[blackBishopPosition], PieceColor.Black));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForAppropriatePieceTypeAndDifferentProvidedColor1()
        {
            var chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
            var whitePawnPosition = new Position(1, 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            Assert.IsFalse(Utilities.LocationContainsPiece<Pawn>(chessboard[whitePawnPosition], PieceColor.Black));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForAppropriatePieceTypeAndDifferentProvidedColor2()
        {
            var chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
            var blackBishopPosition = new Position(3, 3);

            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            Assert.IsFalse(Utilities.LocationContainsPiece<Bishop>(chessboard[blackBishopPosition], PieceColor.White));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForDifferentPieceTypeAndAppropriateProvidedColor1()
        {
            var chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
            var whitePawnPosition = new Position(1, 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            Assert.IsFalse(Utilities.LocationContainsPiece<Queen>(chessboard[whitePawnPosition], PieceColor.White));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForDifferentPieceTypeAndAppropriateProvidedColor2()
        {
            var chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
            var blackBishopPosition = new Position(3, 3);

            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            Assert.IsFalse(Utilities.LocationContainsPiece<Rook>(chessboard[blackBishopPosition], PieceColor.Black));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForDifferentPieceTypeAndDifferentProvidedColor1()
        {
            var chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
            var whiteKnightPosition = new Position(1, 1);

            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);

            Assert.IsFalse(Utilities.LocationContainsPiece<Queen>(chessboard[whiteKnightPosition], PieceColor.White));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForDifferentPieceTypeAndDifferentProvidedColor2()
        {
            var chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();
            var blackPawnPosition = new Position(3, 3);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);

            Assert.IsFalse(Utilities.LocationContainsPiece<Rook>(chessboard[blackPawnPosition], PieceColor.Black));
        }
    }
}
