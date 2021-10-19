using System;
using ChessApplication.Common.Enums;
using ChessApplication.Network;

namespace ChessApplication.Providers
{
    public static class NetworkManagerProvider
    {
        public static NetworkManager GetNetworkManager(UserType userType, string hostname)
        {
            switch (userType)
            {
                case UserType.SinglePlayer:
                {
                    return new NetworkManagerSinglePlayer();
                }
                case UserType.SinglePlayerVersusAI:
                {
                    return new NetworkManagerSinglePlayer();
                }
                case UserType.Server:
                {
                    return new NetworkManagerServer();
                }
                case UserType.Client:
                {
                    return new NetworkManagerClient(hostname);
                }
                default:
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}