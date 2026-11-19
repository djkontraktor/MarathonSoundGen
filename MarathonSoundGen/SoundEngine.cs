using MarathonFileUtils.Sounds;

namespace MarathonSoundGen
{
    public static class SoundEngine
    {

        #region Public Properties

        public static SoundScape SoundScape = new SoundScape();
        public static M2SoundsFile SoundsFile;
        public static bool SoundsFileLoaded = false;

        #endregion

        #region Private Properties



        #endregion

        #region Public Members

        public static void LoadSoundsFile(string filePath)
        {
            SoundsFile = new M2SoundsFile(filePath);
            SoundsFileLoaded = true;
        }

        public static void StartAllSources()
        {
            if (SoundsFileLoaded)
            {
                foreach (SoundSource source in SoundScape.Sources)
                {
                    source.Start();
                }
            }            
        }

        public static void StopAllSources()
        {
            if (SoundsFileLoaded)
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

            SoundsFileLoaded = false;
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



        #endregion

    }
}
