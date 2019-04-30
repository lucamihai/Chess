using System.Diagnostics.CodeAnalysis;
using ChessApplication.Common.UserControls;

namespace UnitTestsUtilities
{
    [ExcludeFromCodeCoverage]
    public static class Methods
    {
        public static int GetNumberOfAvailableBoxes(Box[,] boxes)
        {
            int counter = 0;

            for (int row = 1; row < 9; row++)
            {
                for (int column = 1; column < 9; column++)
                {
                    if (boxes[row, column].Available)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }
    }
}
