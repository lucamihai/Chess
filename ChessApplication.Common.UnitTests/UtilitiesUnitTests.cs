using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class UtilitiesUnitTests
    {
        [TestMethod]
        public void LocationContainsPieceReturnsTrueForAppropriatePieceTypeWithoutProvidingColor1()
        {
            var chessboard = ChessboardProvider.GetChessboardWithNoPieces();
            var whitePawnPosition = new Point(1, 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            Assert.IsTrue(Utilities.LocationContainsPiece<Pawn>(chessboard[whitePawnPosition]));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsTrueForAppropriatePieceTypeWithoutProvidingColor2()
        {
            var chessboard = ChessboardProvider.GetChessboardWithNoPieces();
            var blackBishopPosition = new Point(3, 3);

            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            Assert.IsTrue(Utilities.LocationContainsPiece<Bishop>(chessboard[blackBishopPosition]));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForDifferentPieceTypeWithoutProvidingColor1()
        {
            var chessboard = ChessboardProvider.GetChessboardWithNoPieces();
            var whitePawnPosition = new Point(1, 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            Assert.IsFalse(Utilities.LocationContainsPiece<Queen>(chessboard[whitePawnPosition]));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForDifferentPieceTypeWithoutProvidingColor2()
        {
            var chessboard = ChessboardProvider.GetChessboardWithNoPieces();
            var blackBishopPosition = new Point(3, 3);

            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            Assert.IsFalse(Utilities.LocationContainsPiece<Rook>(chessboard[blackBishopPosition]));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsTrueForAppropriatePieceTypeAndAppropriateProvidedColor1()
        {
            var chessboard = ChessboardProvider.GetChessboardWithNoPieces();
            var whitePawnPosition = new Point(1, 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            Assert.IsTrue(Utilities.LocationContainsPiece<Pawn>(chessboard[whitePawnPosition], PieceColor.White));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsTrueForAppropriatePieceTypeAndAppropriateProvidedColor2()
        {
            var chessboard = ChessboardProvider.GetChessboardWithNoPieces();
            var blackBishopPosition = new Point(3, 3);

            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            Assert.IsTrue(Utilities.LocationContainsPiece<Bishop>(chessboard[blackBishopPosition], PieceColor.Black));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForAppropriatePieceTypeAndDifferentProvidedColor1()
        {
            var chessboard = ChessboardProvider.GetChessboardWithNoPieces();
            var whitePawnPosition = new Point(1, 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            Assert.IsFalse(Utilities.LocationContainsPiece<Pawn>(chessboard[whitePawnPosition], PieceColor.Black));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForAppropriatePieceTypeAndDifferentProvidedColor2()
        {
            var chessboard = ChessboardProvider.GetChessboardWithNoPieces();
            var blackBishopPosition = new Point(3, 3);

            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            Assert.IsFalse(Utilities.LocationContainsPiece<Bishop>(chessboard[blackBishopPosition], PieceColor.White));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForDifferentPieceTypeAndAppropriateProvidedColor1()
        {
            var chessboard = ChessboardProvider.GetChessboardWithNoPieces();
            var whitePawnPosition = new Point(1, 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            Assert.IsFalse(Utilities.LocationContainsPiece<Queen>(chessboard[whitePawnPosition], PieceColor.White));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForDifferentPieceTypeAndAppropriateProvidedColor2()
        {
            var chessboard = ChessboardProvider.GetChessboardWithNoPieces();
            var blackBishopPosition = new Point(3, 3);

            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            Assert.IsFalse(Utilities.LocationContainsPiece<Rook>(chessboard[blackBishopPosition], PieceColor.Black));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForDifferentPieceTypeAndDifferentProvidedColor1()
        {
            var chessboard = ChessboardProvider.GetChessboardWithNoPieces();
            var whiteKnightPosition = new Point(1, 1);

            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);

            Assert.IsFalse(Utilities.LocationContainsPiece<Queen>(chessboard[whiteKnightPosition], PieceColor.White));
        }

        [TestMethod]
        public void LocationContainsPieceReturnsFalseForDifferentPieceTypeAndDifferentProvidedColor2()
        {
            var chessboard = ChessboardProvider.GetChessboardWithNoPieces();
            var blackPawnPosition = new Point(3, 3);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);

            Assert.IsFalse(Utilities.LocationContainsPiece<Rook>(chessboard[blackPawnPosition], PieceColor.Black));
        }

        [TestMethod]
        public void RetakeCapturedPieceDecrementCapturedPieceBoxCount()
        {
            var box = new Box("H1");
            var capturedPieceBox = new CapturedPieceBox(new Bishop(PieceColor.White)) {Count = 2};
            var countBeforeRetaking = capturedPieceBox.Count;

            Utilities.RetakeCapturedPiece(capturedPieceBox, box);
            var countAfterRetaking = capturedPieceBox.Count;

            Assert.IsTrue(countAfterRetaking == countBeforeRetaking - 1);
        }

        [TestMethod]
        public void RetakeCapturedPieceCreatesNewWhiteRookForBoxIfCapturedPieceBoxHasWhiteRook()
        {
            var box = new Box("H1");
            var capturedPieceBox = new CapturedPieceBox(new Rook(PieceColor.White)) { Count = 2 };

            Utilities.RetakeCapturedPiece(capturedPieceBox, box);

            Assert.IsTrue(Utilities.LocationContainsPiece<Rook>(box, capturedPieceBox.ChessPiece.Color));
        }

        [TestMethod]
        public void RetakeCapturedPieceCreatesNewWhiteKnightForBoxIfCapturedPieceBoxHasWhiteKnight()
        {
            var box = new Box("H1");
            var capturedPieceBox = new CapturedPieceBox(new Knight(PieceColor.White)) { Count = 2 };

            Utilities.RetakeCapturedPiece(capturedPieceBox, box);

            Assert.IsTrue(Utilities.LocationContainsPiece<Knight>(box, capturedPieceBox.ChessPiece.Color));
        }

        [TestMethod]
        public void RetakeCapturedPieceCreatesNewWhiteBishopForBoxIfCapturedPieceBoxHasWhiteBishop()
        {
            var box = new Box("H1");
            var capturedPieceBox = new CapturedPieceBox(new Bishop(PieceColor.White)) { Count = 2 };

            Utilities.RetakeCapturedPiece(capturedPieceBox, box);

            Assert.IsTrue(Utilities.LocationContainsPiece<Bishop>(box, capturedPieceBox.ChessPiece.Color));
        }

        [TestMethod]
        public void RetakeCapturedPieceCreatesNewWhiteQueenForBoxIfCapturedPieceBoxHasWhiteQueen()
        {
            var box = new Box("H1");
            var capturedPieceBox = new CapturedPieceBox(new Queen(PieceColor.White)) { Count = 2 };

            Utilities.RetakeCapturedPiece(capturedPieceBox, box);

            Assert.IsTrue(Utilities.LocationContainsPiece<Queen>(box, capturedPieceBox.ChessPiece.Color));
        }

        [TestMethod]
        public void RetakeCapturedPieceCreatesNewBlackRookForBoxIfCapturedPieceBoxHasBlackRook()
        {
            var box = new Box("H1");
            var capturedPieceBox = new CapturedPieceBox(new Rook(PieceColor.Black)) { Count = 2 };

            Utilities.RetakeCapturedPiece(capturedPieceBox, box);

            Assert.IsTrue(Utilities.LocationContainsPiece<Rook>(box, capturedPieceBox.ChessPiece.Color));
        }

        [TestMethod]
        public void RetakeCapturedPieceCreatesNewBlackKnightForBoxIfCapturedPieceBoxHasBlackKnight()
        {
            var box = new Box("H1");
            var capturedPieceBox = new CapturedPieceBox(new Knight(PieceColor.Black)) { Count = 2 };

            Utilities.RetakeCapturedPiece(capturedPieceBox, box);

            Assert.IsTrue(Utilities.LocationContainsPiece<Knight>(box, capturedPieceBox.ChessPiece.Color));
        }

        [TestMethod]
        public void RetakeCapturedPieceCreatesNewBlackBishopForBoxIfCapturedPieceBoxHasBlackBishop()
        {
            var box = new Box("H1");
            var capturedPieceBox = new CapturedPieceBox(new Bishop(PieceColor.Black)) { Count = 2 };

            Utilities.RetakeCapturedPiece(capturedPieceBox, box);

            Assert.IsTrue(Utilities.LocationContainsPiece<Bishop>(box, capturedPieceBox.ChessPiece.Color));
        }

        [TestMethod]
        public void RetakeCapturedPieceCreatesNewBlackQueenForBoxIfCapturedPieceBoxHasBlackQueen()
        {
            var box = new Box("H1");
            var capturedPieceBox = new CapturedPieceBox(new Queen(PieceColor.Black)) { Count = 2 };

            Utilities.RetakeCapturedPiece(capturedPieceBox, box);

            Assert.IsTrue(Utilities.LocationContainsPiece<Queen>(box, capturedPieceBox.ChessPiece.Color));
        }

        [TestMethod]
        public void ResizeImageReturnsImageWithDesiredSize()
        {
            var originalWidth = 100;
            var originalHeight = 100;
            var imageBeforeResizing = new Bitmap(originalWidth, originalHeight);

            var desiredWidth = 75;
            var desiredHeight = 75;
            var imageAfterResizing = Utilities.ResizeImage(imageBeforeResizing, desiredWidth, desiredHeight);

            Assert.AreEqual(desiredWidth, imageAfterResizing.Width);
            Assert.AreEqual(desiredHeight, imageAfterResizing.Height);
        }

    }
}
