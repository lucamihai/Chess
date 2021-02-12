namespace ChessApplication.Network.Entities
{
    public enum CommandType
    {
        Unrecognized,
        Disconnect,
        Move,
        UsernameChange,
        ColorChange,
        RequestNewGame,
        NewGame,
        BeginRetakeSelection,
        RetakeSelection,
        Chat
    }
}