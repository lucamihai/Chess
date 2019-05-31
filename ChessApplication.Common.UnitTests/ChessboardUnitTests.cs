using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using ChessApplication.Common.Chessboards;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestsUtilities;

namespace ChessApplication.Common.UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class ChessboardUnitTests
    {
        private ChessboardClassic chessboard;

        [TestInitialize]
        public void Setup()
        {
            chessboard = new ChessboardClassic();
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

                    Assert.AreEqual(expectedName, chessboard[row, column].BoxName);
                }
            }
        }

        [TestMethod]
        public void WhitePiecesAreAdded()
        {
            var whitePawnsAreAdded = WhitePawnsAreAdded();
            var whiteRooksAreAdded =
                chessboard[1, 1].Piece is Rook && chessboard[1, 1].Piece.Color == PieceColor.White
                && chessboard[1, 8].Piece is Rook && chessboard[1, 8].Piece.Color == PieceColor.White;

            var whiteKnightsAreAdded =
                chessboard[1, 2].Piece is Knight && chessboard[1, 2].Piece.Color == PieceColor.White
                && chessboard[1, 7].Piece is Knight && chessboard[1, 7].Piece.Color == PieceColor.White;

            var whiteBishopsAreAdded =
                chessboard[1, 3].Piece is Bishop && chessboard[1, 3].Piece.Color == PieceColor.White
                && chessboard[1, 6].Piece is Bishop && chessboard[1, 6].Piece.Color == PieceColor.White;

            var whiteQueenIsAdded = chessboard[1, 4].Piece is Queen && chessboard[1, 4].Piece.Color == PieceColor.White;
            var whiteKingIsAdded = chessboard[1, 5].Piece is King && chessboard[1, 5].Piece.Color == PieceColor.White;

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
                chessboard[8, 1].Piece is Rook && chessboard[8, 1].Piece.Color == PieceColor.Black
                && chessboard[8, 8].Piece is Rook && chessboard[8, 8].Piece.Color == PieceColor.Black;

            var blackKnightsAreAdded =
                chessboard[8, 2].Piece is Knight && chessboard[8, 2].Piece.Color == PieceColor.Black
                && chessboard[8, 7].Piece is Knight && chessboard[8, 7].Piece.Color == PieceColor.Black;

            var blackBishopsAreAdded =
                chessboard[8, 3].Piece is Bishop && chessboard[8, 3].Piece.Color == PieceColor.Black
                && chessboard[8, 6].Piece is Bishop && chessboard[8, 6].Piece.Color == PieceColor.Black;

            var blackQueenIsAdded = chessboard[8, 5].Piece is Queen && chessboard[8, 5].Piece.Color == PieceColor.Black;
            var blackKingIsAdded = chessboard[8, 4].Piece is King && chessboard[8, 4].Piece.Color == PieceColor.Black;

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
                    Assert.IsTrue(chessboard[row, column].Piece == null);
                }
            }
        }

        [TestMethod]
        public void SettingBeginnersModeSetsBeginnersModeForEachBox()
        {
            chessboard.BeginnersMode = true;

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    Assert.IsTrue(chessboard[row, column].BeginnersMode);
                }
            }
        }

        [TestMethod]
        public void ResettingBeginnersModeResetsBeginnersModeForEachBox()
        {
            chessboard.BeginnersMode = false;

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    Assert.IsFalse(chessboard[row, column].BeginnersMode);
                }
            }
        }

        [TestMethod]
        public void SetAllBoxesAsUnavailableSetsAllBoxesAvailableToFalse()
        {
            chessboard.SetChessBoardBoxesAsUnavailable();

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    Assert.IsFalse(chessboard[row, column].Available);
                }
            }
        }

        [TestMethod]
        public void ResetBoxesColorsMakesBoxesHaveTheCorrectColors()
        {
            chessboard.ResetChessBoardBoxesColors();

            Assert.IsTrue(BoxesHaveTheCorrectColors());
        }

        [TestMethod]
        public void IsCheckmateForProvidedColorReturnsTrueForWhiteIfWhiteIsInCheckmate()
        {
            chessboard = ChessboardProvider.GetChessboardWithProvidedColorInCheckmate(PieceColor.White);

            Assert.IsTrue(chessboard.IsCheckmateForProvidedColor(PieceColor.White));
        }

        [TestMethod]
        public void IsCheckmateForProvidedColorReturnsFalseForWhiteIfWhiteIsNotInCheckmate()
        {
            Assert.IsFalse(chessboard.IsCheckmateForProvidedColor(PieceColor.White));
        }

        [TestMethod]
        public void IsCheckmateForProvidedColorReturnsTrueForBlackIfBlackIsInCheckmate()
        {
            chessboard = ChessboardProvider.GetChessboardWithProvidedColorInCheckmate(PieceColor.Black);

            Assert.IsTrue(chessboard.IsCheckmateForProvidedColor(PieceColor.Black));
        }

        [TestMethod]
        public void IsCheckmateForProvidedColorReturnsFalseForBlackIfBlackIsNotInCheckmate()
        {
            Assert.IsFalse(chessboard.IsCheckmateForProvidedColor(PieceColor.Black));
        }

        [TestMethod]
        public void PieceIsThreatenedByPawnsReturnsTrueIfBlackPawnIntersectsWhitePiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var blackPawnPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y - 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);

            var threatened = chessboard.PieceIsThreatenedByPawns(whitePawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByPawnsReturnsFalseIfWhitePawnIntersectsWhitePiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var whitePawnPosition2 = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y - 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[whitePawnPosition2].Piece = new Pawn(PieceColor.White);

            var threatened = chessboard.PieceIsThreatenedByPawns(whitePawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByRooksReturnsTrueIfBlackRookIntersectsWhitePiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var blackRookPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);

            var threatened = chessboard.PieceIsThreatenedByRooks(whitePawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByRooksReturnsFalseIfWhiteRookIntersectsWhitePiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var whiteRookPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);

            var threatened = chessboard.PieceIsThreatenedByRooks(whitePawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKnightsReturnsTrueIfBlackKnightIntersectsWhitePiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var blackKnightPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 2);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);

            var threatened = chessboard.PieceIsThreatenedByKnights(whitePawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKnightsReturnsFalseIfWhiteKnightIntersectsWhitePiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var whiteKnightPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 2);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);

            var threatened = chessboard.PieceIsThreatenedByKnights(whitePawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByBishopsReturnsTrueIfBlackBishopIntersectsWhitePiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var blackBishopPosition = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y + 2);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            var threatened = chessboard.PieceIsThreatenedByBishops(whitePawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByBishopsReturnsFalseIfWhiteBishopIntersectsWhitePiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var whiteBishopPosition = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y + 2);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);

            var threatened = chessboard.PieceIsThreatenedByBishops(whitePawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByQueenReturnsTrueIfBlackQueenIntersectsWhitePiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var blackQueenPosition = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y + 2);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);

            var threatened = chessboard.PieceIsThreatenedByQueen(whitePawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByQueenReturnsFalseIfWhiteQueenIntersectsWhitePiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var whiteQueenPosition = new Point(whitePawnPosition.X + 2, whitePawnPosition.Y + 2);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);

            var threatened = chessboard.PieceIsThreatenedByQueen(whitePawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKingReturnsTrueIfBlackKingIntersectsWhitePiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var blackKingPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);

            var threatened = chessboard.PieceIsThreatenedByKing(whitePawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKingReturnsFalseIfWhiteKingIntersectsWhitePiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var whitePawnPosition = new Point(2, 2);
            var whiteKingPosition = new Point(whitePawnPosition.X + 1, whitePawnPosition.Y + 1);

            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);
            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);

            var threatened = chessboard.PieceIsThreatenedByKing(whitePawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByPawnsReturnsTrueIfWhitePawnIntersectsBlackPiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var whitePawnPosition = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whitePawnPosition].Piece = new Pawn(PieceColor.White);

            var threatened = chessboard.PieceIsThreatenedByPawns(blackPawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByPawnsReturnsFalseIfBlackPawnIntersectsBlackPiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var blackPawnPosition2 = new Point(blackPawnPosition.X - 1, blackPawnPosition.Y - 1);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[blackPawnPosition2].Piece = new Pawn(PieceColor.Black);

            var threatened = chessboard.PieceIsThreatenedByPawns(blackPawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByRooksReturnsTrueIfWhiteRookIntersectsBlackPiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var whiteRookPosition = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whiteRookPosition].Piece = new Rook(PieceColor.White);

            var threatened = chessboard.PieceIsThreatenedByRooks(blackPawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByRooksReturnsFalseIfBlackRookIntersectsBlackPiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var blackRookPosition = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[blackRookPosition].Piece = new Rook(PieceColor.Black);

            var threatened = chessboard.PieceIsThreatenedByRooks(blackPawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKnightsReturnsTrueIfWhiteKnightIntersectsBlackPiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var whiteKnightPosition = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y + 2);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whiteKnightPosition].Piece = new Knight(PieceColor.White);

            var threatened = chessboard.PieceIsThreatenedByKnights(blackPawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKnightsReturnsFalseIfBlackKnightIntersectsBlackPiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var blackKnightPosition = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y + 2);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[blackKnightPosition].Piece = new Knight(PieceColor.Black);

            var threatened = chessboard.PieceIsThreatenedByKnights(blackPawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByBishopsReturnsTrueIfWhiteBishopIntersectsBlackPiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var whiteBishopPosition = new Point(blackPawnPosition.X + 2, blackPawnPosition.Y + 2);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whiteBishopPosition].Piece = new Bishop(PieceColor.White);

            var threatened = chessboard.PieceIsThreatenedByBishops(blackPawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByBishopsReturnsFalseIfBlackBishopIntersectsBlackPiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var blackBishopPosition = new Point(blackPawnPosition.X + 2, blackPawnPosition.Y + 2);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[blackBishopPosition].Piece = new Bishop(PieceColor.Black);

            var threatened = chessboard.PieceIsThreatenedByBishops(blackPawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByQueenReturnsTrueIfWhiteQueenIntersectsBlackPiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var whiteQueenPosition = new Point(blackPawnPosition.X + 2, blackPawnPosition.Y + 2);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whiteQueenPosition].Piece = new Queen(PieceColor.White);

            var threatened = chessboard.PieceIsThreatenedByQueen(blackPawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByQueenReturnsFalseIfBlackQueenIntersectsBlackPiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var blackQueenPosition = new Point(blackPawnPosition.X + 2, blackPawnPosition.Y + 2);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[blackQueenPosition].Piece = new Queen(PieceColor.Black);

            var threatened = chessboard.PieceIsThreatenedByQueen(blackPawnPosition);
            Assert.IsFalse(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKingReturnsTrueIfWhiteKingIntersectsBlackPiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var whiteKingPosition = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y + 1);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[whiteKingPosition].Piece = new King(PieceColor.White);

            var threatened = chessboard.PieceIsThreatenedByKing(blackPawnPosition);
            Assert.IsTrue(threatened);
        }

        [TestMethod]
        public void PieceIsThreatenedByKingReturnsFalseIfBlackKingIntersectsBlackPiece()
        {
            chessboard = ChessboardProvider.GetChessboardWithNoPieces();

            var blackPawnPosition = new Point(2, 2);
            var blackKingPosition = new Point(blackPawnPosition.X + 1, blackPawnPosition.Y + 1);

            chessboard[blackPawnPosition].Piece = new Pawn(PieceColor.Black);
            chessboard[blackKingPosition].Piece = new King(PieceColor.Black);

            var threatened = chessboard.PieceIsThreatenedByKing(blackPawnPosition);
            Assert.IsFalse(threatened);
        }

        private bool WhitePawnsAreAdded()
        {
            for (int column = 1; column < 9; column++)
            {
                var currentPiece = chessboard[2, column].Piece;

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
                var currentPiece = chessboard[7, column].Piece;

                if (!(currentPiece is Pawn) && currentPiece.Color != PieceColor.Black)
                {
                    return false;
                }
            }

            return true;
        }

        private bool BoxesHaveTheCorrectColors()
        {
            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    if ((row % 2 == 0 && column % 2 == 0) || (row % 2 == 1 && column % 2 == 1))
                    {
                        if (chessboard[row, column].BoxBackgroundColor != Constants.BoxColorDark)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (chessboard[row, column].BoxBackgroundColor != Constants.BoxColorLight)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
