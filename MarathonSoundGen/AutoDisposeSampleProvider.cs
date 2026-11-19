using NAudio.Wave;
using System;
using System.Threading;

namespace MarathonSoundGen
{
    public class AutoDisposeSampleProvider : ISampleProvider
    {

        #region Public Properties

        public WaveFormat WaveFormat
        {
            get
            {
                return mSource.WaveFormat;
            }
        }

        #endregion

        #region Private Properties

        private readonly ISampleProvider mSource;
        private readonly Action mFinishedCallback;
        private int mFinished;

        #endregion

        #region Constructor

        public AutoDisposeSampleProvider(ISampleProvider source, Action finishedCallback)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            mSource = source;
            mFinishedCallback = finishedCallback;
        }

        #endregion

        #region Public Members

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

        #endregion

    }
}
