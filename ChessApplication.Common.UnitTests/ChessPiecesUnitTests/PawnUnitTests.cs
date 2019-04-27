using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.Common.UnitTests.ChessPiecesUnitTests
{
    [TestClass]
    public class PawnUnitTests
    {
        private Box[,] ChessBoard;

        [TestInitialize]
        public void Setup()
        {
            ChessBoard = new Box[10, 10];
        }

        [TestMethod]
        public void WhitePawnCanMove2BoxesForwardIfIsInInitialPosition()
        {
            ChessBoard = UnitTestsUtilities.ChessboardProvider.GetChessboardInitialState();
            var whiteKingPosition = UnitTestsUtilities.ChessboardProvider.GetWhiteKingPositionForChessboardInitialState();
            var blackKingPosition = UnitTestsUtilities.ChessboardProvider.GetBlackKingPositionForChessboardInitialState();
            var box = new Point(2, 1);

            ChessBoard[2, 1].Piece.CheckPossibilitiesForProvidedLocationAndMarkThem(ChessBoard, box, whiteKingPosition);

            Assert.IsTrue(ChessBoard[4, 1].Available);
        }
    }
}
