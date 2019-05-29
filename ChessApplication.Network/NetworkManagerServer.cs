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
                Application.Exit();
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
