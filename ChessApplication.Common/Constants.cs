using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace ChessApplication.Common
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public static Color BoxColorLight { get; } = Color.Silver;
        public static Color BoxColorDark { get; } = Color.FromArgb(132, 107, 86);
        public static Color BoxColorAvailable { get; } = Color.Green;
    }
}
