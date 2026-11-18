using System;
using System.Collections.Generic;

namespace MarathonSoundGen
{
    public class M1SoundsFileRaw : SoundsFileRaw
    {

        #region Private Properties

        private const int mMaximumPermutations = 5;
        private readonly MacResourceFile mResources = new MacResourceFile();
        private readonly MacResource mCached = new MacResource();
        private short mCachedCode = -1;
        private readonly Dictionary<short, SoundDefinitionRaw> mDefinitions = new Dictionary<short, SoundDefinitionRaw>();
        private readonly Dictionary<short, SoundsFileHeader> mHeaders = new Dictionary<short, SoundsFileHeader>();
        private static readonly uint mSndType = MacTypes.FourCC('s', 'n', 'd', ' ');

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

        public override SoundDefinitionRaw GetSoundDefinition(int source, int index)
        {
            if (index < short.MinValue || index > short.MaxValue || !mResources.Check(mSndType, (short)index))
            {
                return null;
            }

            SoundDefinitionRaw d;
            
            if (!mDefinitions.TryGetValue((short)index, out d))
            {
                d = new SoundDefinitionRaw
                {
                    BehaviorIndex = 2,
                    SoundCode = (short)index,
                    Permutations = 1
                };

                while (d.Permutations < mMaximumPermutations && mResources.Check(mSndType, (short)(index + d.Permutations)))
                {
                    d.Permutations++;
                }

                mDefinitions[(short)index] = d;
            }

            return d;
        }

        private int GetIndex(SoundDefinitionRaw d, int permutation)
        {
            return d.SoundCode + Math.Min(permutation, mMaximumPermutations);
        }

        public override SoundsFileHeader GetSoundHeader(SoundDefinitionRaw d, int permutation)
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
                    if (!mResources.Get(mSndType, (short)index, mCached))
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

        public override byte[] GetSoundData(SoundDefinitionRaw d, int permutation)
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
                if (!mResources.Get(mSndType, (short)index, mCached))
                {
                    return null;
                }

                mCachedCode = (short)index;
            }

            SoundsFileHeader h = GetSoundHeader(d, permutation);
            return h == null ? null : h.LoadData(mCached);
        }

        public override IEnumerable<int> GetSoundIndices(int source)
        {
            if (source != 0)
            {
                yield break;
            }

            List<short> resourceIds = mResources.GetResourceIds(mSndType);
            HashSet<short> idSet = new HashSet<short>(resourceIds);

            int position = 0;

            while (position < resourceIds.Count)
            {
                short baseId = resourceIds[position];

                yield return baseId;

                int permutationCount = 1;

                while (permutationCount < mMaximumPermutations && baseId + permutationCount <= short.MaxValue && idSet.Contains((short)(baseId + permutationCount)))
                {
                    permutationCount++;
                }

                // Skip the resource IDs treated as permutations.
                position += permutationCount;
            }
        }

        #endregion

    }

}
