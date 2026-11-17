using System;

namespace MarathonSoundGen
{
    public abstract class SoundsFile : IDisposable
    {

        #region Abstract Members

        public abstract bool Open(MacFileSpecifier file);
        public abstract void Close();
        public abstract SoundDefinition GetSoundDefinition(int source, int soundIndex);
        public abstract SoundsFileHeader GetSoundHeader(SoundDefinition definition, int permutation);
        public abstract byte[] GetSoundData(SoundDefinition definition, int permutation);

        #endregion

        #region Public Members

        public virtual int SourceCount
        {
            get
            {
                return 1;
            }
        }

        public void Dispose()
        {
            Close();
        }

        #endregion

    }
}
