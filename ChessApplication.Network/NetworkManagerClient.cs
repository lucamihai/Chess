﻿using System.IO;
using System.Net.Sockets;
using System.Threading;
using ChessApplication.Network.Entities;
using Newtonsoft.Json;

namespace ChessApplication.Network
{
    public class NetworkManagerClient : NetworkManager
    {
        private TcpClient TcpClient { get; }

        public NetworkManagerClient(string hostname)
        {
            TcpClient = new TcpClient(hostname, Constants.DefaultPortNumber);

            NetworkStream = TcpClient.GetStream();

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

            TcpClient.Close();
            TcpClient.Dispose();
            
            NetworkStream.Close();
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
