using System;
using System.Diagnostics.CodeAnalysis;

namespace ChessApplication.ChatBox
{
    [ExcludeFromCodeCoverage]
    public static class Strings
    {
        public static string Chat => "SentChat";

        // {0} = time; {1} = username; {2} = message; {3} = separator
        public static string ChatPattern => "{0} {1}: {2}{3}";
        public static string Separator => Environment.NewLine;
    }
}
