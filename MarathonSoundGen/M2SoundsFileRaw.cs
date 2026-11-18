using MacFileUtils;
using System.Collections.Generic;
using System.IO;

namespace MarathonSoundGen
{
    public class M2SoundsFileRaw : SoundsFileRaw
    {

        #region Public Properties

        public override int SourceCount
        {
            get
            {
                return mSourceCount;
            }
        }

        #endregion

        #region Private Properties

        private const int mHeaderSize = 260;
        private const int mV1Unused = 124;
        private int mVersion;
        private uint mTag;
        private short mSourceCount;
        private short mSoundCount;
        private readonly List<List<SoundDefinitionRaw>> mDefinitions = new List<List<SoundDefinitionRaw>>();
        private MacFile mFile;

        #endregion

        #region Public Members

        public override bool Open(MacFileSpecifier spec)
        {
            Close();
            MacFile f = new MacFile();

            if (!spec.Open(f))
            {
                return false;
            }

            byte[] b = new byte[mHeaderSize];

            if (!f.Read(b.Length, b))
            {
                f.Dispose();
                return false;
            }

            using (MemoryStream ms = new MemoryStream(b, false))
            using (BigEndianBinaryReader r = new BigEndianBinaryReader(ms))
            {
                mVersion = r.ReadInt32();
                mTag = r.ReadUInt32();
                mSourceCount = r.ReadInt16();
                mSoundCount = r.ReadInt16();
                r.Skip(mV1Unused * 2L);
            }

            if ((mVersion != 0 && mVersion != 1) || mTag != MacTypes.FourCC('s', 'n', 'd', '2') || mSoundCount < 0 || mSourceCount < 0)
            {
                f.Dispose();
                return false;
            }

            if (mSoundCount == 0)
            {
                mSoundCount = mSourceCount;
                mSourceCount = 1;
            }

            for (int s = 0; s < mSourceCount; s++)
            {
                List<SoundDefinitionRaw> list = new List<SoundDefinitionRaw>();

                for (int i = 0; i < mSoundCount; i++)
                {
                    SoundDefinitionRaw d = new SoundDefinitionRaw();

                    if (!d.Unpack(f))
                    {
                        f.Dispose();
                        Close();
                        return false;
                    }

                    list.Add(d);
                }

                mDefinitions.Add(list);
            }
            
            foreach (List<SoundDefinitionRaw> list in mDefinitions)
            {
                foreach (SoundDefinitionRaw d in list)
                {
                    if (!d.Load(f, true))
                    {
                        f.Dispose();
                        Close();
                        return false;
                    }
                }
            }

            mFile = f;
            return true;
        }

        public override void Close()
        {
            mDefinitions.Clear();

            if (mFile != null)
            {
                mFile.Dispose();
            }

            mFile = null;
            mSourceCount = 0;
            mSoundCount = 0;
        }

        public override SoundDefinitionRaw GetSoundDefinition(int source, int index)
        {
            return source >= 0 && source < mDefinitions.Count && index >= 0 && index < mDefinitions[source].Count ? mDefinitions[source][index] : null;
        }

        public override SoundsFileHeader GetSoundHeader(SoundDefinitionRaw d, int p)
        {
            return d != null && p >= 0 && p < d.Sounds.Count ? d.Sounds[p] : null;
        }

        public override byte[] GetSoundData(SoundDefinitionRaw d, int p)
        {
            return d == null || mFile == null ? null : d.LoadData(mFile, (short)p);
        }

        public override IEnumerable<int> GetSoundIndices(int source)
        {
            if (source < 0 || source >= mDefinitions.Count)
            {
                yield break;
            }

            for (int soundIndex = 0; soundIndex < mDefinitions[source].Count; soundIndex++)
            {
                yield return soundIndex;
            }
        }

        #endregion

    }
}
