using MacFileUtils;
using System;
using System.Collections.Generic;
using System.IO;

namespace MarathonSoundGen
{
    public class SoundDefinitionRaw
    {

        #region Public Properties

        public const int MaximumPermutationsPerSound = 5;
        public short SoundCode;
        public short BehaviorIndex;
        public ushort Flags;
        public ushort Chance;
        public int LowPitch;
        public int HighPitch;
        public short Permutations;
        public ushort PermutationsPlayed;
        public int GroupOffset;
        public int SingleLength;
        public int TotalLength;
        public List<int> SoundOffsets { get; private set; }
        public List<SoundsFileHeader> Sounds { get; private set; }

        #endregion

        #region Private Properties

        private const int mHeaderSize = 64;

        #endregion

        #region Constructor

        public SoundDefinitionRaw()
        {
            BehaviorIndex = 1;
            Permutations = 1;
            SoundOffsets = new List<int>(MaximumPermutationsPerSound);
            Sounds = new List<SoundsFileHeader>(); 
        }

        #endregion

        #region Public Members

        public bool Unpack(MacFile file)
        {
            byte[] b = new byte[mHeaderSize];

            if (!file.Read(b.Length, b))
            {
                return false;
            }

            using (MemoryStream ms = new MemoryStream(b, false))
            using (BigEndianBinaryReader r = new BigEndianBinaryReader(ms))
            {
                return Unpack(r);
            }
        }

        public bool Unpack(BigEndianBinaryReader r)
        {
            try
            {
                SoundCode = r.ReadInt16();
                BehaviorIndex = r.ReadInt16();
                Flags = r.ReadUInt16();
                Chance = r.ReadUInt16();
                LowPitch = r.ReadInt32();
                HighPitch = r.ReadInt32();
                Permutations = r.ReadInt16();
                PermutationsPlayed = r.ReadUInt16();
                GroupOffset = r.ReadInt32();
                SingleLength = r.ReadInt32();
                TotalLength = r.ReadInt32();
                SoundOffsets.Clear();

                for (int i = 0; i < MaximumPermutationsPerSound; i++)
                {
                    SoundOffsets.Add(r.ReadInt32());
                }

                r.Skip(12);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Load(MacFile file, bool loadPermutations)
        {
            int count = loadPermutations ? Permutations : Math.Min(Permutations, (short)1);

            if (count < 0 || count > SoundOffsets.Count)
            {
                return false;
            }

            Sounds.Clear();

            for (int i = 0; i < count; i++)
            {
                if (!file.SetPosition(checked(GroupOffset + SoundOffsets[i])))
                {
                    Sounds.Clear();
                    return false;
                }

                SoundsFileHeader h = new SoundsFileHeader();

                if (!h.Load(file))
                {
                    Sounds.Clear();
                    return false;
                }

                Sounds.Add(h);
            }

            return true;
        }

        public byte[] LoadData(MacFile file, short permutation)
        {
            if (permutation < 0 || permutation >= Sounds.Count || permutation >= SoundOffsets.Count)
            {
                return null;
            }

            if (!file.SetPosition(checked(GroupOffset + SoundOffsets[permutation])))
            {
                return null;
            }

            return Sounds[permutation].LoadData(file);
        }

        #endregion

    }
}
