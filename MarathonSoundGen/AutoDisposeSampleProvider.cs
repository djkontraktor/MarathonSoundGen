using NAudio.Wave;
using System;
using System.Threading;

namespace MarathonSoundGen
{
    public class AutoDisposeSampleProvider : ISampleProvider
    {
        private readonly ISampleProvider mSource;
        private readonly Action mFinishedCallback;

        private int mFinished;

        public WaveFormat WaveFormat
        {
            get
            {
                return mSource.WaveFormat;
            }
        }

        public AutoDisposeSampleProvider(
            ISampleProvider source,
            Action finishedCallback)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            mSource = source;
            mFinishedCallback = finishedCallback;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = mSource.Read(buffer, offset, count);

            if (samplesRead == 0)
            {
                SignalFinished();
            }

            return samplesRead;
        }

        public void SignalFinished()
        {
            if (Interlocked.Exchange(ref mFinished, 1) != 0)
            {
                return;
            }

            if (mFinishedCallback != null)
            {
                mFinishedCallback();
            }
        }

    }
}
