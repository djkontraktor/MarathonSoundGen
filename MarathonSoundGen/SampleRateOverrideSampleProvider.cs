using NAudio.Wave;

namespace MarathonSoundGen
{
    public class SampleRateOverrideSampleProvider : ISampleProvider
    {

        #region Public Properties

        public WaveFormat WaveFormat
        {
            get
            {
                return mWaveFormat;
            }
        }

        #endregion

        #region Private Properties

        private readonly ISampleProvider mSource;
        private readonly WaveFormat mWaveFormat;

        #endregion

        #region Constructor

        public SampleRateOverrideSampleProvider(ISampleProvider source, int sampleRate)
        {
            mSource = source;
            mWaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, source.WaveFormat.Channels);
        }

        #endregion

        #region Public Members

        public int Read(float[] buffer, int offset, int count)
        {
            // The samples are intentionally passed through unchanged.
            // Only their interpreted sample rate is different.
            return mSource.Read(buffer, offset, count);
        }

        #endregion

    }
}
