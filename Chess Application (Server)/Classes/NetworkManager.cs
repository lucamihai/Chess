using Chess_Application.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chess_Application.Enums;

namespace Chess_Application.Classes
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
            var writer = new StreamWriter(StreamServer) {AutoFlush = true};

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

                        // If a command was received
                        if (receivedData.StartsWith("#"))
                        {

                            // Client has disconnected
                            if (receivedData == "#Gata")
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

                            // Client changed the username, update this info
                            // e.g. "#usernameNewCoolUsername"
                            if (receivedData.StartsWith("#username"))
                            {
                                var username = receivedData.Substring(9);
                                OnChangedUsername(username);
                            }

                            // Client chose a color, update this info
                            // e.g. "#culori 1 2"
                            if (receivedData.StartsWith("#culori"))
                            {
                                var colorsString = receivedData.Substring(8);
                                var colors = colorsString.Split(' ');

                                var currentPlayersTurn = (Turn)Convert.ToInt32(colors[0]);
                                var opponentsTurn = (Turn)Convert.ToInt32(colors[1]);

                                OnChangedColors(currentPlayersTurn, opponentsTurn);

                                //isCurrentPlayersTurnToMove = (CurrentPlayersTurn == Turn.White) ? true : false;
                            }

                            // Client requested a new game
                            if (receivedData == "#request new game")
                            {
                                OnRequestNewGame();
                            }

                            // Client agreed to start a new game
                            if (receivedData == "#new game")
                            {
                                OnNewGame();
                            }

                            // Client must retake a captured piece
                            if (receivedData == "#selectie")
                            {
                                OnBeginSelection();

                                //opponentMustSelect = true;
                                //MethodInvoker notify = new MethodInvoker(
                                //    () => { textBox1.AppendText(usernameClient + " must retake a piece from Spoils o' war\r\n"); }
                                //);

                                //Invoke(notify);
                            }

                            // Client has retaken a captured piece, update this info
                            // e.g. "#selectat 2 3 AC"
                            if (receivedData.StartsWith("#selectat"))
                            {
                                var retakeDetails = receivedData.Substring(10).Split();

                                var row = Convert.ToInt32(retakeDetails[0]);
                                var column = Convert.ToInt32(retakeDetails[1]);
                                var selectionPoint = new Point(row, column);

                                var retakenPieceColor = (PieceColor)retakeDetails[2][1];
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

                                    //RetakeCapturedPiece(capturedWhiteQueen, ChessBoard[row, column]);

                                    //updateLabelCapturedPiece = new MethodInvoker(
                                    //    () => { capturedWhiteQueen.Count--; }
                                    //);
                                }

                                OnSelection(selectionPoint, chessPieceType, retakenPieceColor);

                                //Invoke(updateLabelCapturedPiece);
                            }
                        }

                        // If a normal message was received, create a new chat entry
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
    }
}
