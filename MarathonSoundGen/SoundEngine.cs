using MarathonFileUtils.Sounds;

namespace MarathonSoundGen
{
    public static class SoundEngine
    {

        #region Public Properties

        public static SoundScape SoundScape = new SoundScape();
        public static M2SoundsFile SoundsFile;

        #endregion

        #region Private Properties


        private static bool mInitialized = false;

        #endregion

        #region Public Members

        public static void LoadSoundsFile(string filePath)
        {
            SoundsFile = new M2SoundsFile(filePath);
            Init();
        }

        public static void StartAllSources()
        {
            if (mInitialized)
            {
                foreach (SoundSource source in SoundScape.Sources)
                {
                    source.Start();
                }
            }            
        }

        public static void StopAllSources()
        {
            if (mInitialized)
            {
                foreach (SoundSource source in SoundScape.Sources)
                {
                    source.Stop();
                }
            }
        }

        public static void DisposeAllSources()
        {
            foreach (SoundSource source in SoundScape.Sources)
            {
                source.Dispose();
            }

            mInitialized = false;
        }

        public static void AddAmbientSoundSource(AmbientSoundSource source)
        {
            SoundScape.Sources.Add(source);
        }

        public static void RemoveAmbientSoundSource(AmbientSoundSource source)
        {
            SoundScape.Sources.Remove(source);
        }

        #endregion

        #region Private Members

        private static void Init()
        {
            mInitialized = true;
        }

        #endregion

    }
}
