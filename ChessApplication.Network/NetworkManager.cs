using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using ChessApplication.Common;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;

namespace ChessApplication.Network
{
    public abstract class NetworkManager
    {
        protected Thread NetworkThread { get; set; }
        protected bool networkThreadRunning;
        protected NetworkStream NetworkStream { get; set; }

        public abstract void Stop();

        public delegate void MadeMove(Position origin, Position destination);
        public MadeMove OnMadeMove { get; set; }

        public delegate void ChangedUsername(string username);
        public ChangedUsername OnChangedUsername { get; set; }

        public delegate void ChangedColors(Turn currentPlayersTurn, Turn opponentsTurn);
        public ChangedColors OnChangedColors { get; set; }

        public delegate void RequestNewGame();
        public RequestNewGame OnRequestNewGame { get; set; }

        public delegate void NewGame();
        public NewGame OnNewGame { get; set; }

        public delegate void BeginSelection();
        public BeginSelection OnBeginSelection { get; set; }

        public delegate void Selection(Position selectionPosition, Type chessPieceType, PieceColor chessPieceColor);
        public Selection OnSelection { get; set; }

        public delegate void ChatMessage(string message);
        public ChatMessage OnChatMessage { get; set; }

        public delegate void Notification(string notificationMessage);
        public Notification OnNotification { get; set; }

        public void SendMessage(string message)
        {
            var writer = new StreamWriter(NetworkStream) {AutoFlush = true};
            writer.WriteLine(message);
        }

        protected void InterpretReceivedData(string receivedData)
        {
            if (MessageIsACommand(receivedData))
            {
                var command = GetCommandFromMessage(receivedData);

                if (command == CommandStrings.Disconnect)
                {
                    networkThreadRunning = false;
                }

                // Client has made a move, receiving origin and destination coordinates
                // e.g. "#B1 B2"
                if (receivedData.Length == 6)
                {
                    var coordinates = receivedData.Substring(1).Split();

                    var originRow = Convert.ToInt32(coordinates[0][0]) - 64;
                    var originColumn = Convert.ToInt32(coordinates[0][1]) - 48;
                    var destinationRow = Convert.ToInt32(coordinates[1][0]) - 64;
                    var destinationColumn = Convert.ToInt32(coordinates[1][1]) - 48;

                    var origin = new Position(originRow, originColumn);
                    var destination = new Position(destinationRow, destinationColumn);

                    OnMadeMove(origin, destination);
                }

                // e.g. "#usernameNewCoolUsername"
                if (command.StartsWith(CommandStrings.ChangedUsername))
                {
                    var username = receivedData.Substring(9);
                    OnChangedUsername(username);
                }

                // e.g. "#culori 1 2"
                if (command.StartsWith(CommandStrings.ChangedColors))
                {
                    var colorsString = receivedData.Substring(8);
                    var colors = colorsString.Split(' ');

                    var currentPlayersTurn = (Turn)Convert.ToInt32(colors[0]);
                    var opponentsTurn = (Turn)Convert.ToInt32(colors[1]);

                    OnChangedColors(currentPlayersTurn, opponentsTurn);
                }

                if (command == CommandStrings.RequestNewGame)
                {
                    OnRequestNewGame();
                }

                if (command == CommandStrings.NewGame)
                {
                    OnNewGame();
                }

                if (command == CommandStrings.BeginSelection)
                {
                    OnBeginSelection();
                }

                // e.g. "#selectat 2 3 AC"
                if (command.StartsWith(CommandStrings.Selection))
                {
                    var retakeDetails = receivedData.Substring(10).Split();

                    var row = Convert.ToInt32(retakeDetails[0]);
                    var column = Convert.ToInt32(retakeDetails[1]);
                    var selectionPosition = new Position(row, column);

                    var retakenPieceColor = retakeDetails[2][1] == Abbreviations.White ? PieceColor.White : PieceColor.Black;
                    var retakenPieceType = retakeDetails[2][0];

                    var chessPieceType = typeof(ChessPiece);
                    if (retakenPieceType == Abbreviations.Rook)
                    {
                        chessPieceType = typeof(Rook);
                    }

                    if (retakenPieceType == Abbreviations.Knight)
                    {
                        chessPieceType = typeof(Knight);
                    }

                    if (retakenPieceType == Abbreviations.Bishop)
                    {
                        chessPieceType = typeof(Bishop);
                    }

                    if (retakenPieceType == Abbreviations.Queen)
                    {
                        chessPieceType = typeof(Queen);
                    }

                    OnSelection(selectionPosition, chessPieceType, retakenPieceColor);
                }
            }

            else
            {
                OnChatMessage(receivedData);
            }
        }

        private bool MessageIsACommand(string message)
        {
            return message.StartsWith(Constants.CommandMarker);
        }

        private string GetCommandFromMessage(string message)
        {
            return message.Substring(1);
        }
    }
}
