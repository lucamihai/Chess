using System.Diagnostics.CodeAnalysis;

namespace ChessApplication.Network.Entities
{
    [ExcludeFromCodeCoverage]
    public class Message
    {
        public Message()
        {
            CommandType = CommandType.Unrecognized;
            Arguments = new string[0];
        }

        public Message(CommandType commandType, params string[] arguments)
        {
            CommandType = commandType;
            Arguments = arguments;
        }

        public CommandType CommandType { get; set; }
        public string[] Arguments { get; set; }
    }
}