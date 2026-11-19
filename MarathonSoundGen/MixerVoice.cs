using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.IO;

namespace MarathonSoundGen
{
    public class MixerVoice : IDisposable
    {

        #region Public Properties

        public MemoryStream MemoryStream { get; private set; }
        public WaveFileReader WaveReader { get; private set; }

        public SmbPitchShiftingSampleProvider PitchProvider
        {
            get;
            private set;
        }

        public VolumePanSampleProvider VolumePanProvider
        {
            get;
            private set;
        }

        public AutoDisposeSampleProvider Provider
        {
            get;
            private set;
        }

        public PlaybackParameters Parameters
        {
            get;
            private set;
        }

        #endregion

        #region Private Properties

        private bool mDisposed;

        #endregion

        #region Constructor

        public MixerVoice(MemoryStream memoryStream, WaveFileReader waveReader, SmbPitchShiftingSampleProvider pitchProvider, VolumePanSampleProvider volumePanProvider, AutoDisposeSampleProvider provider, PlaybackParameters parameters)
        {
            MemoryStream = memoryStream;
            WaveReader = waveReader;
            PitchProvider = pitchProvider;
            VolumePanProvider = volumePanProvider;
            Provider = provider;
            Parameters = parameters;
        }

        #endregion

        #region Public Members

        public void Dispose()
        {
            if (mDisposed)
            {
                return;
            }

            mDisposed = true;

            /*
             * Provider does not dispose its source. The voice owns the reader
             * and MemoryStream and disposes them here.
             */
            Provider = null;
            PitchProvider = null;
            VolumePanProvider = null;
            Parameters = null;

            if (WaveReader != null)
            {
                WaveReader.Dispose();
                WaveReader = null;
            }

            if (MemoryStream != null)
            {
                MemoryStream.Dispose();
                MemoryStream = null;
            }
        }

        #endregion

    }
}
