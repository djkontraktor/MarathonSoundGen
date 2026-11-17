using System;
using System.Collections.Generic;

namespace MarathonSoundGen
{
    public class M1SoundsFile : SoundsFile
    {

        #region Private Properties

        private const int MaximumPermutations = 5;
        private readonly MacResourceFile mResources = new MacResourceFile();
        private readonly MacResource mCached = new MacResource();
        private short mCachedCode = -1;
        private readonly Dictionary<short, SoundDefinition> mDefinitions = new Dictionary<short, SoundDefinition>();
        private readonly Dictionary<short, SoundsFileHeader> mHeaders = new Dictionary<short, SoundsFileHeader>();
        private static readonly uint SndType = MacTypes.FourCC('s', 'n', 'd', ' ');

        #endregion

        #region Public Members

        public override bool Open(MacFileSpecifier f)
        {
            Close();
            return f.Open(mResources);
        }

        public override void Close()
        {
            mHeaders.Clear();
            mDefinitions.Clear();
            mCachedCode = -1;
            mCached.Unload();
            mResources.Close();
        }

        public override SoundDefinition GetSoundDefinition(int source, int index)
        {
            if (index < short.MinValue || index > short.MaxValue || !mResources.Check(SndType, (short)index))
            {
                return null;
            }

            SoundDefinition d;
            
            if (!mDefinitions.TryGetValue((short)index, out d))
            {
                d = new SoundDefinition
                {
                    BehaviorIndex = 2,
                    SoundCode = (short)index,
                    Permutations = 1
                };

                while (d.Permutations < MaximumPermutations && mResources.Check(SndType, (short)(index + d.Permutations)))
                {
                    d.Permutations++;
                }

                mDefinitions[(short)index] = d;
            }

            return d;
        }

        private int GetIndex(SoundDefinition d, int permutation)
        {
            return d.SoundCode + Math.Min(permutation, MaximumPermutations);
        }

        public override SoundsFileHeader GetSoundHeader(SoundDefinition d, int permutation)
        {
            if (d == null)
            {
                return null;
            }

            int index = GetIndex(d, permutation);

            if (index < short.MinValue || index > short.MaxValue)
            {
                return null;
            }

            SoundsFileHeader h;

            if (!mHeaders.TryGetValue((short)index, out h))
            {
                if (mCachedCode != (short)index)
                {
                    if (!mResources.Get(SndType, (short)index, mCached))
                    {
                        return null;
                    }

                    mCachedCode = (short)index;
                }

                h = new SoundsFileHeader();

                if (!h.Load(mCached))
                {
                    return null;
                }

                mHeaders[(short)index] = h;
            }

            return h;
        }

        public override byte[] GetSoundData(SoundDefinition d, int permutation)
        {
            if (d == null)
            {
                return null;
            }

            int index = GetIndex(d, permutation);

            if (index < short.MinValue || index > short.MaxValue)
            {
                return null;
            }

            if (mCachedCode != (short)index)
            {
                if (!mResources.Get(SndType, (short)index, mCached))
                {
                    return null;
                }

                mCachedCode = (short)index;
            }

            SoundsFileHeader h = GetSoundHeader(d, permutation);
            return h == null ? null : h.LoadData(mCached);
        }

        #endregion

    }

}
