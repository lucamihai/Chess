using System.Drawing;

namespace ChessApplication.Main
{
    public class Constants
    {
        public const string DefaultUsernameServer = "Server";
        public const string DefaultUsernameClient = "Client";

        public static Color BoxColorLight { get; } = Color.Silver;
        public static Color BoxColorDark { get; } = Color.FromArgb(132, 107, 86);
    }
}
