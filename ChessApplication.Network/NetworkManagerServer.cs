using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ChessApplication.Network
{
    public class NetworkManagerServer : NetworkManager
    {
        private TcpListener ServerTcpListener { get; }

        public NetworkManagerServer()
        {
            try
            {
                ServerTcpListener = new TcpListener(System.Net.IPAddress.Any, Constants.PortNumber);
                ServerTcpListener.Start();
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Environment.Exit(0);
            }

            NetworkThreadRunning = true;
            NetworkThread = new Thread(ServerListen);
            NetworkThread.Start();
            
        }

        public override void Stop()
        {
            try
            {
                NetworkThreadRunning = false;
                NetworkStream.Close();

                ServerTcpListener.Stop();
            }

            catch (Exception exception)
            {
                Application.Exit();
            }
        }

        private void ServerListen()
        {
            var socketServer = ServerTcpListener.AcceptSocket();
            NetworkStream = new NetworkStream(socketServer);
            var streamReader = new StreamReader(NetworkStream);

            while (NetworkThreadRunning)
            {
                //if (!NetworkStream.DataAvailable)
                //{
                //    continue;
                //}

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
