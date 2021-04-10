using System;
using ChessApplication.Common.Enums;
using ChessApplication.Network;

namespace ChessApplication.GUI.Helpers
{
    public static class NetworkManagerProvider
    {
        public static NetworkManager GetNetworkManager(UserType userType, string hostname)
        {
            switch (userType)
            {
                case UserType.SinglePlayer:
                {
                    // TODO: Implement a SinglePlayer NetworkManager
                    throw new NotImplementedException();
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