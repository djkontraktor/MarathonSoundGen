using MacFileUtils;
using System;
using System.Collections.Generic;

namespace MarathonSoundGen
{
    public abstract class SoundsFileRaw : IDisposable
    {

        #region Abstract Members

        public abstract bool Open(MacFileSpecifier file);
        public abstract void Close();
        public abstract SoundDefinitionRaw GetSoundDefinition(int source, int soundIndex);
        public abstract SoundsFileHeader GetSoundHeader(SoundDefinitionRaw definition, int permutation);
        public abstract byte[] GetSoundData(SoundDefinitionRaw definition, int permutation);
        public abstract IEnumerable<int> GetSoundIndices(int source);

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
