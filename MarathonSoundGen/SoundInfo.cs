namespace MarathonSoundGen
{
    public class SoundInfo
    {

        #region Public Properties

        public AudioFormat AudioFormat { get; protected set; }
        public bool Stereo { get; protected set; }
        public bool LittleEndian { get; protected set; }
        public int BytesPerFrame { get; protected set; }
        public int LoopStart { get; protected set; }
        public int LoopEnd { get; protected set; }
        public uint Rate { get; protected set; }
        public int Length { get; protected set; }

        #endregion

        #region Constructor

        public SoundInfo()
        {
            AudioFormat = AudioFormat._8_bit;
            BytesPerFrame = 1;
        }

        #endregion

    }
}
