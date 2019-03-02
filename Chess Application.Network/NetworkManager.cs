using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chess_Application.Common;
using Chess_Application.Common.ChessPieces;
using Chess_Application.Common.Enums;

namespace Chess_Application.Network
{
    public class NetworkManager
    {
        private TcpListener ServerTcpListener { get; set; }
        private Thread NetworkThread { get; set; }
        private NetworkStream StreamServer { get; set; }
        private bool _isNetworkThreadRunning;

        public NetworkManager()
        {
            ServerTcpListener = new TcpListener(System.Net.IPAddress.Any, 3000);
            ServerTcpListener.Start();
            NetworkThread = new Thread(new ThreadStart(ServerListen));
            _isNetworkThreadRunning = true;
            NetworkThread.Start();
        }

        public void SendMessage(string message)
        {
            var writer = new StreamWriter(StreamServer) { AutoFlush = true };

            writer.WriteLine(message);
        }

        public void Stop()
        {
            try
            {
                _isNetworkThreadRunning = false;
                StreamServer.Close();
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }

            ServerTcpListener.Stop();
        }

        public delegate void MadeMove(Point origin, Point destination);
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

        public delegate void Selection(Point selectionPoint, Type chessPieceType, PieceColor chessPieceColor);
        public Selection OnSelection { get; set; }

        public delegate void ChatMessage(string message);
        public ChatMessage OnChatMessage { get; set; }

        private void ServerListen()
        {
            while (_isNetworkThreadRunning)
            {
                try
                {
                    var socketServer = ServerTcpListener.AcceptSocket();
                    StreamServer = new NetworkStream(socketServer);

                    var streamReader = new StreamReader(StreamServer);

                    while (_isNetworkThreadRunning)
                    {
                        var receivedData = streamReader.ReadLine();

                        if (receivedData == null)
                        {
                            break;
                        }

                        if (MessageIsACommand(receivedData))
                        {
                            var command = GetCommandFromMessage(receivedData);

                            if (command == NetworkCommandStrings.Disconnect)
                            {
                                _isNetworkThreadRunning = false;
                            }

                            // Client has made a move, receiving origin and destination coordinates, then proceeding to replicate the move
                            // e.g. "#B1 B2"
                            if (receivedData.Length == 6)
                            {
                                var coordinates = receivedData.Substring(1).Split();

                                var originRow = Convert.ToInt32(coordinates[0][0]) - 64;
                                var originColumn = Convert.ToInt32(coordinates[0][1]) - 48;
                                var destinationRow = Convert.ToInt32(coordinates[1][0]) - 64;
                                var destinationColumn = Convert.ToInt32(coordinates[1][1]) - 48;

                                var origin = new Point(originRow, originColumn);
                                var destination = new Point(destinationRow, destinationColumn);

                                OnMadeMove(origin, destination);
                            }

                            // e.g. "#usernameNewCoolUsername"
                            if (command.StartsWith(NetworkCommandStrings.ChangedUsername))
                            {
                                var username = receivedData.Substring(9);
                                OnChangedUsername(username);
                            }

                            // e.g. "#culori 1 2"
                            if (command.StartsWith(NetworkCommandStrings.ChangedColors))
                            {
                                var colorsString = receivedData.Substring(8);
                                var colors = colorsString.Split(' ');

                                var currentPlayersTurn = (Turn)Convert.ToInt32(colors[0]);
                                var opponentsTurn = (Turn)Convert.ToInt32(colors[1]);

                                OnChangedColors(currentPlayersTurn, opponentsTurn);

                                //isCurrentPlayersTurnToMove = (CurrentPlayersTurn == Turn.White) ? true : false;
                            }

                            if (command == NetworkCommandStrings.RequestNewGame)
                            {
                                OnRequestNewGame();
                            }

                            if (command == NetworkCommandStrings.NewGame)
                            {
                                OnNewGame();
                            }

                            if (command == NetworkCommandStrings.BeginSelection)
                            {
                                OnBeginSelection();
                            }

                            // e.g. "#selectat 2 3 AC"
                            if (command.StartsWith(NetworkCommandStrings.Selection))
                            {
                                var retakeDetails = receivedData.Substring(10).Split();

                                var row = Convert.ToInt32(retakeDetails[0]);
                                var column = Convert.ToInt32(retakeDetails[1]);
                                var selectionPoint = new Point(row, column);

                                var retakenPieceColor = (retakeDetails[2][1] == 'A') ? PieceColor.White : PieceColor.Black;
                                var retakenPieceType = retakeDetails[2][0];

                                
                                var chessPieceType = typeof(ChessPiece);


                                if (retakenPieceType == 'T')
                                {
                                    chessPieceType = typeof(Rook);
                                }

                                if (retakenPieceType == 'C')
                                {
                                    chessPieceType = typeof(Knight);
                                }

                                if (retakenPieceType == 'N')
                                {
                                    chessPieceType = typeof(Bishop);
                                }

                                if (retakenPieceType == 'R')
                                {
                                    chessPieceType = typeof(Queen);
                                }

                                OnSelection(selectionPoint, chessPieceType, retakenPieceColor);
                                
                            }
                        }

                        else
                        {
                            OnChatMessage(receivedData);
                        }
                    }

                    StreamServer.Close();
                }
                catch (Exception)
                {

                }
            }
        }

        private bool MessageIsACommand(string message)
        {
            return message.StartsWith("#");
        }

        private string GetCommandFromMessage(string message)
        {
            return message.Substring(1);
        }
    }
}
