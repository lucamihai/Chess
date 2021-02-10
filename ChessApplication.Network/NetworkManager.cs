using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using ChessApplication.Common;
using ChessApplication.Common.ChessPieces;
using ChessApplication.Common.Enums;
using ChessApplication.Network.Entities;

namespace ChessApplication.Network
{
    public abstract class NetworkManager : IDisposable
    {
        protected Thread NetworkThread { get; set; }
        protected bool NetworkThreadRunning;
        protected NetworkStream NetworkStream { get; set; }

        public abstract void Stop();

        public delegate void MadeMove(Position origin, Position destination);
        public delegate void ChangedUsername(string username);
        public delegate void ChangedColors(Turn currentPlayersTurn, Turn opponentsTurn);
        public delegate void RequestedNewGame();
        public delegate void IssuedNewGame();
        public delegate void BegunRetakeSelection();
        public delegate void MadeRetakeSelection(Position selectionPosition, Type chessPieceType, PieceColor chessPieceColor);
        public delegate void ChatMessage(string message);
        public delegate void Notification(string notificationMessage);

        public MadeMove OnMadeMove { get; set; }
        public ChangedUsername OnChangedUsername { get; set; }
        public ChangedColors OnChangedColors { get; set; }
        public RequestedNewGame OnRequestedNewGame { get; set; }
        public IssuedNewGame OnIssuedNewGame { get; set; }
        public BegunRetakeSelection OnBegunRetakeSelection { get; set; }
        public MadeRetakeSelection OnMadeRetakeSelection { get; set; }
        public ChatMessage OnChatMessage { get; set; }
        public Notification OnNotification { get; set; }

        public void ChangeUsername(string newUsername)
        {
            var message = new Message(CommandType.UsernameChange, newUsername);
            SendMessage(message);
        }

        [Obsolete("Method signature left for compatibility. Will be changed.")]
        public void ChangeColors(string colorsString1, string colorsString2)
        {
            var message = new Message(CommandType.ColorsChange, colorsString1, colorsString2);
            SendMessage(message);
        }

        public void RequestNewGame()
        {
            var message = new Message(CommandType.RequestNewGame);
            SendMessage(message);
        }

        public void IssueNewGame()
        {
            var message = new Message(CommandType.NewGame);
            SendMessage(message);
        }

        public void NotifyOfMove(Position origin, Position destination)
        {
            var message = new Message(
                CommandType.Move,
                origin.Row.ToString(), origin.Column.ToString(),
                destination.Row.ToString(), destination.Column.ToString());

            SendMessage(message);
        }

        public void BeginRetakeSelection()
        {
            var message = new Message(CommandType.BeginRetakeSelection);
            SendMessage(message);
        }

        public void NotifyOfRetakeSelection(Position position, ChessPiece selectedPiece)
        {
            var message = new Message(CommandType.RetakeSelection,
                position.Row.ToString(), position.Column.ToString(),
                selectedPiece.Color == PieceColor.White ? Abbreviations.White.ToString() : Abbreviations.Black.ToString(),
                selectedPiece.Abbreviation);

            SendMessage(message);
        }

        public void SendChatMessage(string chatMessage)
        {
            var message = new Message(CommandType.Chat, chatMessage);
            SendMessage(message);
        }

        private void SendMessage(Message message)
        {
            var stringMessage = message.ToString();
            var writer = new StreamWriter(NetworkStream) {AutoFlush = true};
            writer.WriteLine(stringMessage);
        }

        protected void InterpretReceivedData(string receivedData)
        {
            var message = Message.FromString(receivedData);

            switch (message.CommandType)
            {
                case CommandType.Unrecognized:
                {
                    throw new InvalidOperationException();
                }

                case CommandType.Disconnect:
                {
                    HandleDisconnect(message);
                    break;
                }

                case CommandType.Move:
                {
                    HandleMove(message);
                    break;
                }

                case CommandType.UsernameChange:
                {
                    HandleUsernameChange(message);
                    break;
                }

                case CommandType.ColorsChange:
                {
                    HandleColorsChange(message);
                    break;
                }

                case CommandType.RequestNewGame:
                {
                    HandleRequestNewGame(message);
                    break;
                }

                case CommandType.NewGame:
                {
                    HandleNewGame(message);
                    break;
                }

                case CommandType.BeginRetakeSelection:
                {
                    HandleBeginSelection(message);
                    break;
                }

                case CommandType.RetakeSelection:
                {
                    HandleSelection(message);
                    break;
                }

                case CommandType.Chat:
                {
                    HandleChat(message);
                    break;
                }
            }
        }

        private void HandleDisconnect(Message message)
        {
            NetworkThreadRunning = false;
        }

        private void HandleMove(Message message)
        {
            var originRow = Convert.ToInt32(message.Arguments[0]);
            var originColumn = Convert.ToInt32(message.Arguments[1]);
            var origin = new Position(originRow, originColumn);

            var destinationRow = Convert.ToInt32(message.Arguments[2]);
            var destinationColumn = Convert.ToInt32(message.Arguments[3]);
            var destination = new Position(destinationRow, destinationColumn);

            OnMadeMove(origin, destination);
        }

        private void HandleUsernameChange(Message message)
        {
            var username = string.Join(" ", message.Arguments);
            OnChangedUsername(username);
        }

        private void HandleColorsChange(Message message)
        {
            var currentPlayersTurn = (Turn)Convert.ToInt32(message.Arguments[0]);
            var opponentsTurn = (Turn)Convert.ToInt32(message.Arguments[1]);

            OnChangedColors(currentPlayersTurn, opponentsTurn);
        }

        private void HandleRequestNewGame(Message message)
        {
            OnRequestedNewGame();
        }

        private void HandleNewGame(Message message)
        {
            OnIssuedNewGame();
        }

        private void HandleBeginSelection(Message message)
        {
            OnBegunRetakeSelection();
        }

        private void HandleSelection(Message message)
        {
            var row = Convert.ToInt32(message.Arguments[0]);
            var column = Convert.ToInt32(message.Arguments[1]);
            var selectionPosition = new Position(row, column);

            var retakenPieceColor = message.Arguments[2][0] == Abbreviations.White ? PieceColor.White : PieceColor.Black;
            var retakenPieceType = message.Arguments[3][0];

            var chessPieceType = typeof(ChessPiece);
            switch (retakenPieceType)
            {
                case Abbreviations.Rook:
                    chessPieceType = typeof(Rook);
                    break;
                case Abbreviations.Knight:
                    chessPieceType = typeof(Knight);
                    break;
                case Abbreviations.Bishop:
                    chessPieceType = typeof(Bishop);
                    break;
                case Abbreviations.Queen:
                    chessPieceType = typeof(Queen);
                    break;
            }

            OnMadeRetakeSelection(selectionPosition, chessPieceType, retakenPieceColor);
        }

        private void HandleChat(Message message)
        {
            OnChatMessage(string.Join(" ", message.Arguments));
        }

        public virtual void Dispose()
        {
            Stop();
            NetworkStream?.Close();
            NetworkStream?.Dispose();
        }
    }
}
