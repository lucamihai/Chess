using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace ChessApplication.Network
{
    public class NetworkManagerClient : NetworkManager
    {
        private TcpClient TcpClient { get; }

        public NetworkManagerClient(string hostname)
        {
            TcpClient = new TcpClient(hostname, Constants.PortNumber);
            NetworkStream = TcpClient.GetStream();

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
        }

        private void ServerListen()
        {
            while (networkThreadRunning)
            {
                try
                {
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
