using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        public override string ToString()
        {
            return $"#{CommandType} {string.Join(" ", Arguments)}";
        }

        public static Message FromString(string messageString)
        {
            if (string.IsNullOrEmpty(messageString))
            {
                return new Message();
            }

            if (messageString[0] != '#')
            {
                return new Message();
            }
            
            var tokens = messageString.Substring(1).Split();

            if (tokens.Length < 1)
            {
                return new Message();
            }

            return new Message
            {
                CommandType = GetCommandTypeFromString(tokens[0]),
                Arguments = tokens.Skip(1).ToArray()
            };
        }

        private static CommandType GetCommandTypeFromString(string stringCommandType)
        {
            return Enum.TryParse<CommandType>(stringCommandType, out var command)
                ? command
                : CommandType.Unrecognized;
        }
    }
}