using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Chess_Application.Network
{
    public class NetworkManagerClient : NetworkManager
    {
        private TcpClient TcpClient { get; set; }

        public NetworkManagerClient(string hostname)
        {
            TcpClient = new TcpClient(hostname, 3000);
            NetworkStream = TcpClient.GetStream();

            NetworkThread = new Thread(new ThreadStart(ServerListen));
            NetworkThread.Start();
            networkThreadRunning = true;
        }

        public override void SendMessage(string message)
        {
            var writer = new StreamWriter(NetworkStream) { AutoFlush = true };

            writer.WriteLine(message);
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
