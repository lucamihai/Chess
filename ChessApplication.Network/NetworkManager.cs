using System;
using System.Net.Sockets;
using System.Threading;
using ChessApplication.Common;
using ChessApplication.Common.Enums;
using ChessApplication.Network.Entities;
using Newtonsoft.Json;

namespace ChessApplication.Network
{
    public abstract class NetworkManager : IDisposable
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        };

        protected Thread NetworkThread { get; set; }
        protected bool NetworkThreadRunning;
        protected NetworkStream NetworkStream { get; set; }

        public abstract void Stop();

        public delegate void MadeMove(Position origin, Position destination);
        public delegate void ChangedUsername(string username);
        public delegate void ChangedColor(PieceColor opponentsTurn);
        public delegate void RequestedNewGame();
        public delegate void IssuedNewGame();
        public delegate void BegunRetakeSelection();
        public delegate void MadeRetakeSelection(Position selectionPosition, ChessPiece chessPiece);
        public delegate void ChatMessage(string message);
        public delegate void Notification(string notificationMessage);

        public MadeMove OnMadeMove { get; set; }
        public ChangedUsername OnChangedUsername { get; set; }
        public ChangedColor OnChangedColor { get; set; }
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

        public void ChangeColor(PieceColor color)
        {
            var message = new Message(CommandType.ColorChange, color.ToString());
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
                JsonConvert.SerializeObject(selectedPiece, JsonSerializerSettings));

            SendMessage(message);
        }

        public void SendChatMessage(string chatMessage)
        {
            var message = new Message(CommandType.Chat, chatMessage);
            SendMessage(message);
        }

        protected abstract void SendMessage(Message message);

        protected void InterpretReceivedData(string receivedData)
        {
            var message = JsonConvert.DeserializeObject<Message>(receivedData);

            if (message == null)
            {
                throw new InvalidOperationException();
            }

            switch (message.CommandType)
            {
                case CommandType.Unrecognized:
                {
                    throw new InvalidOperationException();
                }

                case CommandType.Disconnect:
                {
                    HandleDisconnect();
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

                case CommandType.ColorChange:
                {
                    HandleColorsChange(message);
                    break;
                }

                case CommandType.RequestNewGame:
                {
                    HandleRequestNewGame();
                    break;
                }

                case CommandType.NewGame:
                {
                    HandleNewGame();
                    break;
                }

                case CommandType.BeginRetakeSelection:
                {
                    HandleBeginSelection();
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
                default:
                {
                    throw new InvalidOperationException();
                }
            }
        }

        private void HandleDisconnect()
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
            var opponentChosenColor = GetColorFromString(message.Arguments[0]);

            OnChangedColor(opponentChosenColor);
        }

        private void HandleRequestNewGame()
        {
            OnRequestedNewGame();
        }

        private void HandleNewGame()
        {
            OnIssuedNewGame();
            
        }

        private void HandleBeginSelection()
        {
            OnBegunRetakeSelection();
        }

        private void HandleSelection(Message message)
        {
            var row = Convert.ToInt32(message.Arguments[0]);
            var column = Convert.ToInt32(message.Arguments[1]);
            var selectionPosition = new Position(row, column);
            var chessPiece = JsonConvert.DeserializeObject<ChessPiece>(message.Arguments[2], JsonSerializerSettings);

            OnMadeRetakeSelection(selectionPosition, chessPiece);
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

        private static PieceColor GetColorFromString(string value)
        {
            return Enum.TryParse<PieceColor>(value, out var pieceColor)
                ? pieceColor
                : PieceColor.Undefined;
        }
    }
}
