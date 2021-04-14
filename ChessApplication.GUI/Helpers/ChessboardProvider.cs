using System;
using ChessApplication.ChessboardClassicLogic;
using ChessApplication.Common.Enums;
using ChessApplication.Common.Interfaces;

namespace ChessApplication.GUI.Helpers
{
    public static class ChessboardProvider
    {
        public static IChessboard GetChessboard(ChessboardType chessboardType)
        {
            switch (chessboardType)
            {
                case ChessboardType.Classic:
                {
                    return new ChessboardClassic();
                }
                case ChessboardType.Shatranj:
                {
                    throw new NotImplementedException();
                }
                default:
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}