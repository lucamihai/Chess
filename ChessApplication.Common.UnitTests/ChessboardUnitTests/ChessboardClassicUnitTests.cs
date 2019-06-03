using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests.ChessboardUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ChessboardClassicUnitTests
    {
        private ChessboardClassic Chessboard;

        [TestInitialize]
        public void Setup()
        {
            Chessboard = new ChessboardClassic();
        }

        [TestMethod]
        public void BoxesHaveCorrectNamesSet()
        {
            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    char rowLetter = (char)('A' + row - 1);
                    var expectedName = $"{rowLetter}{column}";

                    Assert.AreEqual(expectedName, Chessboard[row, column].BoxName);
                }
            }
        }

        [TestMethod]
        public void WhitePiecesAreAdded()
        {
            var whitePawnsAreAdded = WhitePawnsAreAdded();
            var whiteRooksAreAdded =
                Chessboard[1, 1].Piece is Rook && Chessboard[1, 1].Piece.Color == PieceColor.White
                && Chessboard[1, 8].Piece is Rook && Chessboard[1, 8].Piece.Color == PieceColor.White;

            var whiteKnightsAreAdded =
                Chessboard[1, 2].Piece is Knight && Chessboard[1, 2].Piece.Color == PieceColor.White
                && Chessboard[1, 7].Piece is Knight && Chessboard[1, 7].Piece.Color == PieceColor.White;

            var whiteBishopsAreAdded =
                Chessboard[1, 3].Piece is Bishop && Chessboard[1, 3].Piece.Color == PieceColor.White
                && Chessboard[1, 6].Piece is Bishop && Chessboard[1, 6].Piece.Color == PieceColor.White;

            var whiteQueenIsAdded = Chessboard[1, 4].Piece is Queen && Chessboard[1, 4].Piece.Color == PieceColor.White;
            var whiteKingIsAdded = Chessboard[1, 5].Piece is King && Chessboard[1, 5].Piece.Color == PieceColor.White;

            Assert.IsTrue(whitePawnsAreAdded);
            Assert.IsTrue(whiteRooksAreAdded);
            Assert.IsTrue(whiteKnightsAreAdded);
            Assert.IsTrue(whiteBishopsAreAdded);
            Assert.IsTrue(whiteKingIsAdded);
            Assert.IsTrue(whiteQueenIsAdded);
        }

        [TestMethod]
        public void BlackPiecesAreAdded()
        {
            var blackPawnsAreAdded = BlackPawnsAreAdded();
            var blackRooksAreAdded =
                Chessboard[8, 1].Piece is Rook && Chessboard[8, 1].Piece.Color == PieceColor.Black
                && Chessboard[8, 8].Piece is Rook && Chessboard[8, 8].Piece.Color == PieceColor.Black;

            var blackKnightsAreAdded =
                Chessboard[8, 2].Piece is Knight && Chessboard[8, 2].Piece.Color == PieceColor.Black
                && Chessboard[8, 7].Piece is Knight && Chessboard[8, 7].Piece.Color == PieceColor.Black;

            var blackBishopsAreAdded =
                Chessboard[8, 3].Piece is Bishop && Chessboard[8, 3].Piece.Color == PieceColor.Black
                && Chessboard[8, 6].Piece is Bishop && Chessboard[8, 6].Piece.Color == PieceColor.Black;

            var blackQueenIsAdded = Chessboard[8, 5].Piece is Queen && Chessboard[8, 5].Piece.Color == PieceColor.Black;
            var blackKingIsAdded = Chessboard[8, 4].Piece is King && Chessboard[8, 4].Piece.Color == PieceColor.Black;

            Assert.IsTrue(blackPawnsAreAdded);
            Assert.IsTrue(blackRooksAreAdded);
            Assert.IsTrue(blackKnightsAreAdded);
            Assert.IsTrue(blackBishopsAreAdded);
            Assert.IsTrue(blackKingIsAdded);
            Assert.IsTrue(blackQueenIsAdded);
        }

        [TestMethod]
        public void BoxesThatShouldNotHaveAPieceDoNotHaveAPiece()
        {
            for (int row = 3; row <= 6; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    Assert.IsTrue(Chessboard[row, column].Piece == null);
                }
            }
        }

        [TestMethod]
        public void SettingBeginnersModeSetsBeginnersModeForEachBox()
        {
            Chessboard.BeginnersMode = true;

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    Assert.IsTrue(Chessboard[row, column].BeginnersMode);
                }
            }
        }

        [TestMethod]
        public void ResettingBeginnersModeResetsBeginnersModeForEachBox()
        {
            Chessboard.BeginnersMode = false;

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    Assert.IsFalse(Chessboard[row, column].BeginnersMode);
                }
            }
        }

        [TestMethod]
        public void IsCheckmateForProvidedColorReturnsTrueForWhiteIfWhiteIsInCheckmate()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithProvidedColorInCheckmate(PieceColor.White);

            Assert.IsTrue(Chessboard.IsCheckmateForProvidedColor(PieceColor.White));
        }

        [TestMethod]
        public void IsCheckmateForProvidedColorReturnsFalseForWhiteIfWhiteIsNotInCheckmate()
        {
            Assert.IsFalse(Chessboard.IsCheckmateForProvidedColor(PieceColor.White));
        }

        [TestMethod]
        public void IsCheckmateForProvidedColorReturnsTrueForBlackIfBlackIsInCheckmate()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithProvidedColorInCheckmate(PieceColor.Black);

            Assert.IsTrue(Chessboard.IsCheckmateForProvidedColor(PieceColor.Black));
        }

        [TestMethod]
        public void IsCheckmateForProvidedColorReturnsFalseForBlackIfBlackIsNotInCheckmate()
        {
            Assert.IsFalse(Chessboard.IsCheckmateForProvidedColor(PieceColor.Black));
        }

        [TestMethod]
        public void PieceIsThreatenedByPawnsReturnsTrueIfBlackPawnIntersectsWhitePiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var blackPawnPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y - 1);

            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);

            var threatened = Chessboard.PieceIsThreatenedByPawns(whitePawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByPawnsReturnsFalseIfWhitePawnIntersectsWhitePiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var whitePawnPosition2 = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y - 1);

            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[whitePawnPosition2].Piece = new Pawn(PieceColor.White);

            var threatened = Chessboard.PieceIsThreatenedByPawns(whitePawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByRooksReturnsTrueIfBlackRookIntersectsWhitePiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var blackRookPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y);

            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);

            var threatened = Chessboard.PieceIsThreatenedByRooks(whitePawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByRooksReturnsFalseIfWhiteRookIntersectsWhitePiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var whiteRookPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y);

            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);

            var threatened = Chessboard.PieceIsThreatenedByRooks(whitePawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKnightsReturnsTrueIfBlackKnightIntersectsWhitePiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var blackKnightPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 2);

            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);

            var threatened = Chessboard.PieceIsThreatenedByKnights(whitePawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKnightsReturnsFalseIfWhiteKnightIntersectsWhitePiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var whiteKnightPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 2);

            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);

            var threatened = Chessboard.PieceIsThreatenedByKnights(whitePawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByBishopsReturnsTrueIfBlackBishopIntersectsWhitePiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var blackBishopPosition = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y + 2);

            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            var threatened = Chessboard.PieceIsThreatenedByBishops(whitePawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByBishopsReturnsFalseIfWhiteBishopIntersectsWhitePiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var whiteBishopPosition = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y + 2);

            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);

            var threatened = Chessboard.PieceIsThreatenedByBishops(whitePawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByQueenReturnsTrueIfBlackQueenIntersectsWhitePiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var blackQueenPosition = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y + 2);

            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);

            var threatened = Chessboard.PieceIsThreatenedByQueen(whitePawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByQueenReturnsFalseIfWhiteQueenIntersectsWhitePiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var whiteQueenPosition = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y + 2);

            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);

            var threatened = Chessboard.PieceIsThreatenedByQueen(whitePawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKingReturnsTrueIfBlackKingIntersectsWhitePiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var blackKingPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 1);

            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);

            var threatened = Chessboard.PieceIsThreatenedByKing(whitePawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKingReturnsFalseIfWhiteKingIntersectsWhitePiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var whiteKingPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 1);

            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);

            var threatened = Chessboard.PieceIsThreatenedByKing(whitePawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByPawnsReturnsTrueIfWhitePawnIntersectsBlackPiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var whitePawnPosition = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);

            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            var threatened = Chessboard.PieceIsThreatenedByPawns(blackPawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByPawnsReturnsFalseIfBlackPawnIntersectsBlackPiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var blackPawnPosition2 = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);

            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[blackPawnPosition2].Piece = new Pawn(PieceColor.Black);

            var threatened = Chessboard.PieceIsThreatenedByPawns(blackPawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByRooksReturnsTrueIfWhiteRookIntersectsBlackPiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var whiteRookPosition = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y);

            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);

            var threatened = Chessboard.PieceIsThreatenedByRooks(blackPawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByRooksReturnsFalseIfBlackRookIntersectsBlackPiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var blackRookPosition = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y);

            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);

            var threatened = Chessboard.PieceIsThreatenedByRooks(blackPawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKnightsReturnsTrueIfWhiteKnightIntersectsBlackPiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var whiteKnightPosition = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y + 2);

            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);

            var threatened = Chessboard.PieceIsThreatenedByKnights(blackPawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKnightsReturnsFalseIfBlackKnightIntersectsBlackPiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var blackKnightPosition = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y + 2);

            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);

            var threatened = Chessboard.PieceIsThreatenedByKnights(blackPawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByBishopsReturnsTrueIfWhiteBishopIntersectsBlackPiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var whiteBishopPosition = new Point(blackPawnPosition.X + 2, blackPawnPosition.Y + 2);

            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);

            var threatened = Chessboard.PieceIsThreatenedByBishops(blackPawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByBishopsReturnsFalseIfBlackBishopIntersectsBlackPiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var blackBishopPosition = new Point(blackPawnPosition.X + 2, blackPawnPosition.Y + 2);

            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            var threatened = Chessboard.PieceIsThreatenedByBishops(blackPawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByQueenReturnsTrueIfWhiteQueenIntersectsBlackPiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var whiteQueenPosition = new Point(blackPawnPosition.X + 2, blackPawnPosition.Y + 2);

            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);

            var threatened = Chessboard.PieceIsThreatenedByQueen(blackPawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByQueenReturnsFalseIfBlackQueenIntersectsBlackPiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var blackQueenPosition = new Point(blackPawnPosition.X + 2, blackPawnPosition.Y + 2);

            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);

            var threatened = Chessboard.PieceIsThreatenedByQueen(blackPawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKingReturnsTrueIfWhiteKingIntersectsBlackPiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var whiteKingPosition = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y + 1);

            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[whiteKingPosition].Piece = new King(PieceColor.White);

            var threatened = Chessboard.PieceIsThreatenedByKing(blackPawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKingReturnsFalseIfBlackKingIntersectsBlackPiece()
        {
            Chessboard = ChessboardProvider.GetChessboardClassicWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var blackKingPosition = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y + 1);

            Chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            Chessboard[blackKingPosition].Piece = new King(PieceColor.Black);

            var threatened = Chessboard.PieceIsThreatenedByKing(blackPawnPosition);
            Assert.IsFalse(threatened);
        }

        private bool WhitePawnsAreAdded()
        {
            for (int column = 1; column < 9; column++)
            {
                var currentPiece = Chessboard[2, column].Piece;

                if (!(currentPiece is Pawn) && currentPiece.Color != PieceColor.White)
                {
                    return false;
                }
            }

            return true;
        }

        private bool BlackPawnsAreAdded()
        {
            for (int column = 1; column < 9; column++)
            {
                var currentPiece = Chessboard[7, column].Piece;

                if (!(currentPiece is Pawn) && currentPiece.Color != PieceColor.Black)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
