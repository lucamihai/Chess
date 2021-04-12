using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Media;

namespace ChessApplication.GUI.Helpers
{
    [ExcludeFromCodeCoverage]
    public class SoundManager
    {
        private readonly List<SoundPlayer> moveSounds;
        private int moveSoundIndex;

        public SoundManager()
        {
            moveSounds = new List<SoundPlayer>
            {
                new SoundPlayer(Properties.Resources.movesound1),
                new SoundPlayer(Properties.Resources.movesound2)
            };

            moveSoundIndex = 0;
        }

        public void PlayMoveSound()
        {
            moveSounds[moveSoundIndex].Play();

            moveSoundIndex++;

            if (moveSoundIndex > moveSounds.Count - 1)
            {
                moveSoundIndex = 0;
            }
        }
    }
}