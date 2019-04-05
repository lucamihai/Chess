using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace ChessApplication.Network
{
    public class NetworkManagerServer : NetworkManager
    {
        private TcpListener ServerTcpListener { get; set; }

        public NetworkManagerServer()
        {
            ServerTcpListener = new TcpListener(System.Net.IPAddress.Any, Constants.PortNumber);
            ServerTcpListener.Start();

            NetworkThread = new Thread(new ThreadStart(ServerListen));
            NetworkThread.Start();
            networkThreadRunning = true;
        }

        public override void Stop()
        {
            try
            {
                networkThreadRunning = false;
                NetworkStream.Close();
            }

            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }

            ServerTcpListener.Stop();
        }

        private void ServerListen()
        {
            while (networkThreadRunning)
            {
                try
                {
                    var socketServer = ServerTcpListener.AcceptSocket();
                    NetworkStream = new NetworkStream(socketServer);

                    var streamReader = new StreamReader(NetworkStream);

                    while (networkThreadRunning)
                    {
                        var receivedData = streamReader.ReadLine();

                        if (receivedData == null)
                        {
                            break;
                        }

                        InterpretReceivedData(receivedData);
                    }

                    NetworkStream.Close();
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
