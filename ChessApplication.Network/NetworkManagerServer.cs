using System.IO;
using System.Net.Sockets;
using System.Threading;
using ChessApplication.Network.Entities;
using Newtonsoft.Json;

namespace ChessApplication.Network
{
    public class NetworkManagerServer : NetworkManager
    {
        private TcpListener ServerTcpListener { get; }

        public NetworkManagerServer()
        {
            ServerTcpListener = new TcpListener(System.Net.IPAddress.Any, Constants.DefaultPortNumber);
            ServerTcpListener.Start();
            
            NetworkThreadRunning = true;
            NetworkThread = new Thread(ServerListen);
            NetworkThread.Start();
            
        }

        protected override void SendMessage(Message message)
        {
            var stringMessage = JsonConvert.SerializeObject(message);
            var writer = new StreamWriter(NetworkStream) { AutoFlush = true };
            writer.WriteLine(stringMessage);
        }

        public override void Stop()
        {
            NetworkThreadRunning = false;
            NetworkStream?.Close();

            ServerTcpListener.Stop();
        }

        private void ServerListen()
        {
            var socketServer = ServerTcpListener.AcceptSocket();
            NetworkStream = new NetworkStream(socketServer);
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
    }
}
