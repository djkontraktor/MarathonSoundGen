using MarathonFileUtils.Sounds.LowLevel;
using System;
using System.IO;
using System.Media;

namespace MarathonSoundGen
{
    public static class SoundsUtils
    {

        #region Public Members

        public static void PlaySound(byte[] soundData, SoundsFileHeader header)
        {
            if (soundData == null)
            {
                throw new ArgumentNullException(nameof(soundData));
            }

            if (header == null)
            {
                throw new ArgumentNullException(nameof(header));
            }

            try
            {
                using (MemoryStream waveStream = MarathonFileUtils.Sounds.Utils.CreateWaveStream(soundData, header))
                using (SoundPlayer player = new SoundPlayer(waveStream))
                {
                    player.Load();
                    player.PlaySync();
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

    }
}
