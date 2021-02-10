namespace ChessApplication.Network.Entities
{
    public enum CommandType
    {
        Unrecognized,
        Disconnect,
        Move,
        UsernameChange,
        ColorsChange,
        RequestNewGame,
        NewGame,
        BeginRetakeSelection,
        RetakeSelection,
        Chat,

    }
}