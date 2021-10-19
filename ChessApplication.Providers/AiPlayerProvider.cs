using ChessApplication.ChessboardClassicLogic.AI;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.Providers
{
    public static class AiPlayerProvider
    {
        public static IAIPlayer GetAiPlayer(ChessboardType chessboardType, UserType userType)
        {
            if (userType != UserType.SinglePlayerVersusAI)
            {
                return null;
            }

            switch (chessboardType)
            {
                // TODO: Maybe do a provider for each chessboard type
                case ChessboardType.Classic:
                {
                    return new RandomMovesAIPlayer();
                }
                default:
                {
                    return null;
                }
            }
        }
    }
}