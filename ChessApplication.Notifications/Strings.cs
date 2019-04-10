using System;

namespace ChessApplication.Notifications
{
    public static class Strings
    {
        public static string Notifications => "Notifications";

        // {0} = notification time; {1} = notification message; {2} = separator
        public static string NotificationPattern => "{0} -> {1}{2}";
        public static string NotificationSeparator => Environment.NewLine;
    }
}
