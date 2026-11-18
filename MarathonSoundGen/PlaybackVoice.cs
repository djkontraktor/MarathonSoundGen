using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.IO;

namespace MarathonSoundGen
{
    public class PlaybackVoice : IDisposable
    {
        private bool mDisposed;

        public WaveOut Output { get; private set; }

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

        public PlaybackParameters Parameters
        {
            get;
            private set;
        }

        public PlaybackVoice(WaveOut output, MemoryStream memoryStream, WaveFileReader waveReader, SmbPitchShiftingSampleProvider pitchProvider, VolumePanSampleProvider volumePanProvider, PlaybackParameters parameters)
        {
            Output = output;
            MemoryStream = memoryStream;
            WaveReader = waveReader;
            PitchProvider = pitchProvider;
            VolumePanProvider = volumePanProvider;
            Parameters = parameters;

            parameters.BaseVolumeAtStart = parameters.Volume;
            parameters.BasePitchAtStart = parameters.Pitch;
            parameters.BasePanAtStart = parameters.Pan;
        }

        public void StopAndDispose()
        {
            if (mDisposed)
            {
                return;
            }

            /*
             * Detach all SoundSource event handlers before calling Stop().
             */
            if (Output != null)
            {
                try
                {
                    Output.Stop();
                }
                catch
                {
                    // Continue releasing the remaining resources.
                }
            }

            Dispose();
        }

        public void Dispose()
        {
            if (mDisposed)
            {
                return;
            }

            mDisposed = true;

            if (Output != null)
            {
                Output.Dispose();
                Output = null;
            }

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

            PitchProvider = null;
            VolumePanProvider = null;
            Parameters = null;
        }
    }
}
