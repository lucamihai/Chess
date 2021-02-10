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

            NetworkThreadRunning = true;
            NetworkThread = new Thread(ServerListen);
            NetworkThread.Start();
        }

        public override void Stop()
        {
            try
            {
                NetworkThreadRunning = false;

                TcpClient.Close();
                TcpClient.Dispose();
                
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
            var streamReader = new StreamReader(NetworkStream);

            while (NetworkThreadRunning)
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

        public override void Dispose()
        {
            Stop();
            base.Dispose();
            TcpClient?.Dispose();
        }
    }
}
