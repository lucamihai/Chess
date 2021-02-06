using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.UserControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessApplication.Common.UnitTests.UserControlsUnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class BoxUnitTests
    {
        private Box box;

        [TestMethod]
        public void BoxPositionIsGeneratedCorrectlyFromBoxName1()
        {
            box = new Box("A1");
            var expectedPosition = new Position(1, 1);
            
            Assert.AreEqual(expectedPosition, box.Position);
        }

        [TestMethod]
        public void BoxPositionIsGeneratedCorrectlyFromBoxName2()
        {
            box = new Box("B3");
            var expectedPosition = new Position(2, 3);

            Assert.AreEqual(expectedPosition, box.Position);
        }

        [TestMethod]
        public void BoxPositionIsGeneratedCorrectlyFromBoxName3()
        {
            box = new Box("D4");
            var expectedPosition = new Position(4, 4);

            Assert.AreEqual(expectedPosition, box.Position);
        }

        [TestMethod]
        public void BoxPositionIsGeneratedCorrectlyFromBoxName4()
        {
            box = new Box("F5");
            var expectedPosition = new Position(6, 5);

            Assert.AreEqual(expectedPosition, box.Position);
        }

        [TestMethod]
        public void SettingAvailableToTrueChangesBoxColorToGreenIfBeginnersModeIsSetToTrue()
        {
            box = new Box("A1");
            box.BeginnersMode = true;

            box.Available = true;

            Assert.IsTrue(box.BoxBackgroundColor == Constants.BoxColorAvailable);
        }

        [TestMethod]
        public void SettingAvailableToTrueDoesNotChangeBoxColorToGreenIfBeginnersModeIsSetToFalse()
        {
            box = new Box("A1");
            box.BeginnersMode = false;

            box.Available = true;

            Assert.IsFalse(box.BoxBackgroundColor == Constants.BoxColorAvailable);
        }

        
    }
}
