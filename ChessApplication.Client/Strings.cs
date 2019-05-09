using System.Diagnostics.CodeAnalysis;

namespace ChessApplication.Client
{
    [ExcludeFromCodeCoverage]
    public static class Strings
    {
        public static string Connect => "Connect";
        public static string Disconnect => "Disconnect";

        public static string IpMustBeSpecified => "You must specify an IP address";
    }
}
