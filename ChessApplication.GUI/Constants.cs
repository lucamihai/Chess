using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace ChessApplication.GUI
{
    [ExcludeFromCodeCoverage]
    public static class Constants
    {
        public const string DefaultUsernameServer = "Server";
        public const string DefaultUsernameClient = "Client";

        public static Color BoxColorLight { get; } = Color.Silver;
        public static Color BoxColorDark { get; } = Color.FromArgb(132, 107, 86);
        public static Color BoxColorAvailable { get; } = Color.Green;
    }
}
