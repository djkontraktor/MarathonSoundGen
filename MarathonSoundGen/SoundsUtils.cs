using MarathonFileUtils.Sounds;
using MarathonFileUtils.Sounds.LowLevel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;

namespace MarathonSoundGen
{
    public static class SoundsUtils
    {

        #region Private Properties

        private static readonly Random mRng = new Random();

        #endregion

        #region Public Members

        public static void PlaySound(SoundPermutation sound)
        {
            byte[] soundData = sound.Data;
            SoundsFileHeader header = sound.Header;

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

        public static void PlaySoundSlot(SoundSlot slot)
        {
            if (slot.Samples.Count > 0)
            {
                SoundPermutation chosenSound = GetRandomElement(slot.Samples);
                PlaySound(chosenSound);
            }
        }

        #endregion

        #region Private Members

        private static T GetRandomElement<T>(List<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (list.Count == 0)
            {
                throw new InvalidOperationException("Cannot select an element from an empty list.");
            }

            return list[mRng.Next(list.Count)];
        }

        #endregion

    }
}
