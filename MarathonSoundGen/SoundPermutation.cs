namespace MarathonSoundGen
{
    public class SoundPermutation
    {
        public int Source { get; set; }
        public int SoundIndex { get; set; }
        public int Permutation { get; set; }
        public SoundDefinitionRaw Definition { get; set; }
        public SoundsFileHeader Header { get; set; }
        public byte[] Data { get; set; }
    }
}
