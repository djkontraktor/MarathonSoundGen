using MarathonFileUtils.Sounds;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MarathonSoundGen
{
    public class RandomSoundSource : SoundSource
    {

        #region Public Properties

        public double Frequency_Hz
        {
            get
            {
                lock (mFrequencySyncRoot)
                {
                    return mFrequencyHz;
                }
            }
            set
            {
                ValidatePositiveFinite(value, nameof(value));

                lock (mFrequencySyncRoot)
                {
                    mFrequencyHz = value;
                }

                WakeScheduler();
            }
        }

        public double RandomFrequency_Hz
        {
            get
            {
                lock (mFrequencySyncRoot)
                {
                    return mRandomFrequencyHz;
                }
            }
            set
            {
                ValidateFinite(value, nameof(value));

                lock (mFrequencySyncRoot)
                {
                    mRandomFrequencyHz = Math.Max(0.0, value);
                }

                WakeScheduler();
            }
        }

        public double RandomFrequencyOffset_Hz
        {
            get
            {
                lock (mFrequencySyncRoot)
                {
                    return mRandomFrequencyOffsetHz;
                }
            }
            set
            {
                ValidateFinite(value, nameof(value));

                lock (mFrequencySyncRoot)
                {
                    mRandomFrequencyOffsetHz = value;
                }

                WakeScheduler();
            }
        }

        #endregion

        #region Private Properties

        private const double mMinimumEffectiveFrequencyHz = 0.001;
        private const double mMaximumEffectiveFrequencyHz = 1000.0;
        private readonly object mFrequencySyncRoot = new object();
        private double mFrequencyHz;
        private double mRandomFrequencyHz;
        private double mRandomFrequencyOffsetHz;
        private CancellationTokenSource mSchedulerCancellation;
        private Task mSchedulerTask;

        #endregion

        #region Constructor

        public RandomSoundSource(SoundEngine soundEngine, SoundSlot soundSlot, double volume, double randomVolume, double randomVolumeOffset, double pitch, double randomPitch, double randomPitchOffset,
            double pan, double randomPan, double randomPanOffset, double frequency_Hz, double randomFrequency_Hz, double randomFrequencyOffset_Hz)
        : base(soundEngine, soundSlot, volume, randomVolume, randomVolumeOffset, pitch, randomPitch, randomPitchOffset, pan, randomPan, randomPanOffset)
        {
            ValidatePositiveFinite(frequency_Hz, nameof(frequency_Hz));
            ValidateFinite(randomFrequency_Hz, nameof(randomFrequency_Hz));
            ValidateFinite(randomFrequencyOffset_Hz, nameof(randomFrequencyOffset_Hz));

            mFrequencyHz = frequency_Hz;
            mRandomFrequencyHz = Math.Max(0.0, randomFrequency_Hz);
            mRandomFrequencyOffsetHz = randomFrequencyOffset_Hz;
        }

        #endregion

        #region Public Members

        public override void Start()
        {
            lock (mFrequencySyncRoot)
            {
                if (mSchedulerTask != null && !mSchedulerTask.IsCompleted)
                {
                    return;
                }

                mSchedulerCancellation = new CancellationTokenSource();

                CancellationToken token = mSchedulerCancellation.Token;

                // Set the base started state and play the first trigger
                // immediately.
                base.Start();

                mSchedulerTask = Task.Run(() => RunSchedulerAsync(token), token);
            }
        }

        public override void Stop()
        {
            CancellationTokenSource cancellation;
            Task schedulerTask;

            lock (mFrequencySyncRoot)
            {
                cancellation = mSchedulerCancellation;
                schedulerTask = mSchedulerTask;

                mSchedulerCancellation = null;
                mSchedulerTask = null;
            }

            if (cancellation != null)
            {
                cancellation.Cancel();
            }

            // Do not synchronously wait on schedulerTask here. Stop() may be
            // called from a UI thread, and waiting is unnecessary because the
            // cancellation token ends the scheduler promptly.
            base.Stop();

            if (cancellation != null)
            {
                cancellation.Dispose();
            }
        }

        #endregion

        #region Private Members

        private async Task RunSchedulerAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested && Playing)
                {
                    TimeSpan delay = GetNextTriggerDelay();

                    await Task.Delay(delay, cancellationToken).ConfigureAwait(false);

                    if (cancellationToken.IsCancellationRequested || !Playing)
                    {
                        break;
                    }

                    // This starts a new voice without stopping any voice that is
                    // already running. Random volume, pitch, and pan are selected
                    // independently for this trigger.
                    PlaySoundSingle();
                }
            }
            catch (OperationCanceledException)
            {
                // Expected when Stop() is called.
            }
            catch (ObjectDisposedException)
            {
                // Expected if disposal races with the scheduler.
            }
            catch (Exception exception)
            {
                OnPlaybackError(exception);
            }
        }

        private TimeSpan GetNextTriggerDelay()
        {
            double baseFrequency;
            double randomFrequency;
            double frequencyOffset;

            lock (mFrequencySyncRoot)
            {
                baseFrequency = mFrequencyHz;
                randomFrequency = mRandomFrequencyHz;
                frequencyOffset = mRandomFrequencyOffsetHz;
            }

            double effectiveFrequency = baseFrequency + frequencyOffset + NextRandomSignedValue(randomFrequency);
            effectiveFrequency = Clamp(effectiveFrequency, mMinimumEffectiveFrequencyHz, mMaximumEffectiveFrequencyHz);

            double delaySeconds = 1.0 / effectiveFrequency;

            return TimeSpan.FromSeconds(delaySeconds);
        }

        private void WakeScheduler()
        {
            /*
             * Property changes affect the next scheduled period. The currently
             * active Task.Delay is not interrupted.
             *
             * If you want changes to reset the current delay immediately, use a
             * separate scheduler wake CancellationTokenSource.
             */
        }

        private static void ValidatePositiveFinite(double value, string parameterName)
        {
            ValidateFinite(value, parameterName);

            if (value <= 0.0)
            {
                throw new ArgumentOutOfRangeException(parameterName, "Frequency must be greater than zero.");
            }
        }

        #endregion

    }
}
