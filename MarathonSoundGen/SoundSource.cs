using MarathonFileUtils.Sounds;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MarathonSoundGen
{
    public class SoundSource : IDisposable
    {

        #region Public Properties

        public SoundSlot SoundSlot
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mSoundSlot;
                }
            }
            set
            {
                lock (mSyncRoot)
                {
                    ThrowIfDisposed();
                    mSoundSlot = value;
                }
            }
        }

        public double Volume
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mVolume;
                }
            }
            set
            {
                lock (mSyncRoot)
                {
                    ThrowIfDisposed();
                    mVolume = ClampFinite(value, 0.0, 1.0, nameof(value));
                    UpdateActiveVoice();
                }
            }
        }

        public double RandomVolume
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mRandomVolume;
                }
            }
            set
            {
                lock (mSyncRoot)
                {
                    ThrowIfDisposed();
                    ValidateFinite(value, nameof(value));
                    mRandomVolume = Math.Max(0.0, value);
                }
            }
        }

        public double RandomVolumeOffset
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mRandomVolumeOffset;
                }
            }
            set
            {
                lock (mSyncRoot)
                {
                    ThrowIfDisposed();
                    ValidateFinite(value, nameof(value));
                    mRandomVolumeOffset = value;
                }
            }
        }

        public double Pitch
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mPitch;
                }
            }
            set
            {
                lock (mSyncRoot)
                {
                    ThrowIfDisposed();
                    mPitch = ClampFinite(value, mMinimumPitch, mMaximumPitch, nameof(value));
                    UpdateActiveVoice();
                }
            }
        }

        public double RandomPitch
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mRandomPitch;
                }
            }
            set
            {
                lock (mSyncRoot)
                {
                    ThrowIfDisposed();
                    ValidateFinite(value, nameof(value));
                    mRandomPitch = Math.Max(0.0, value);
                }
            }
        }

        public double RandomPitchOffset
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mRandomPitchOffset;
                }
            }
            set
            {
                lock (mSyncRoot)
                {
                    ThrowIfDisposed();
                    ValidateFinite(value, nameof(value));
                    mRandomPitchOffset = value;
                }
            }
        }

        public double Pan
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mPan;
                }
            }
            set
            {
                lock (mSyncRoot)
                {
                    ThrowIfDisposed();
                    mPan = ClampFinite(value, -1.0, 1.0, nameof(value));
                    UpdateActiveVoice();
                }
            }
        }

        public double RandomPan
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mRandomPan;
                }
            }
            set
            {
                lock (mSyncRoot)
                {
                    ThrowIfDisposed();
                    ValidateFinite(value, nameof(value));
                    mRandomPan = Math.Max(0.0, value);
                }
            }
        }

        public double RandomPanOffset
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mRandomPanOffset;
                }
            }
            set
            {
                lock (mSyncRoot)
                {
                    ThrowIfDisposed();
                    ValidateFinite(value, nameof(value));
                    mRandomPanOffset = value;
                }
            }
        }

        public bool IsStarted
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mStarted && !mDisposed;
                }
            }
        }

        // Maybe effects here later?

        #endregion

        #region Private/Protected Properties

        protected const double mMinimumPitch = 0.5;
        protected const double mMaximumPitch = 2.0;
        protected bool IsDisposed
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mDisposed;
                }
            }
        }
        protected SoundEngine SoundEngine
        {
            get
            {
                return mSoundEngine;
            }
        }
        private readonly object mSyncRoot = new object();
        private readonly Random mRng = new Random();
        private SoundSlot mSoundSlot;
        private SoundEngine mSoundEngine;
        private MixerVoice mActiveVoice;
        private double mVolume;
        private double mRandomVolume;
        private double mRandomVolumeOffset;
        private double mPitch;
        private double mRandomPitch;
        private double mRandomPitchOffset;
        private double mPan;
        private double mRandomPan;
        private double mRandomPanOffset;
        private bool mDisposed;
        private bool mStarted;

        #endregion

        #region Constructor

        public SoundSource(SoundEngine soundEngine, SoundSlot soundSlot, double volume, double randomVolume, double randomVolumeOffset, double pitch, double randomPitch, double randomPitchOffset, double pan, double randomPan, double randomPanOffset)
        {
            if (soundEngine == null)
            {
                throw new ArgumentNullException(nameof(soundEngine));
            }

            if (soundSlot == null)
            {
                throw new ArgumentNullException(nameof(soundSlot));
            }

            ValidateFinite(randomVolume, nameof(randomVolume));
            ValidateFinite(randomVolumeOffset, nameof(randomVolumeOffset));
            ValidateFinite(randomPitch, nameof(randomPitch));
            ValidateFinite(randomPitchOffset, nameof(randomPitchOffset));
            ValidateFinite(randomPan, nameof(randomPan));
            ValidateFinite(randomPanOffset, nameof(randomPanOffset));

            mSoundEngine = soundEngine;
            mSoundSlot = soundSlot;

            mVolume = ClampFinite(volume, 0.0, 1.0, nameof(volume));
            mRandomVolume = Math.Max(0.0, randomVolume);
            mRandomVolumeOffset = randomVolumeOffset;

            mPitch = ClampFinite(pitch, mMinimumPitch, mMaximumPitch, nameof(pitch));
            mRandomPitch = Math.Max(0.0, randomPitch);
            mRandomPitchOffset = randomPitchOffset;

            mPan = ClampFinite(pan, -1.0, 1.0, nameof(pan));
            mRandomPan = Math.Max(0.0, randomPan);
            mRandomPanOffset = randomPanOffset;
        }

        #endregion

        #region Public Members

        public virtual void Start()
        {
            lock (mSyncRoot)
            {
                ThrowIfDisposed();

                if (mStarted)
                {
                    return;
                }

                ValidateSoundSlot();
                mStarted = true;
            }

            try
            {
                mSoundEngine.ActivateSource(this);
                PlayRandomSound();
            }
            catch
            {
                lock (mSyncRoot)
                {
                    mStarted = false;
                }

                mSoundEngine.DeactivateSource(this);

                throw;
            }
        }

        public virtual void Stop()
        {
            MixerVoice voice;

            lock (mSyncRoot)
            {
                ThrowIfDisposed();

                mStarted = false;

                voice = mActiveVoice;
                mActiveVoice = null;
            }

            if (voice != null)
            {
                mSoundEngine.RemoveInput(voice.Provider);
                voice.Dispose();
            }

            mSoundEngine.DeactivateSource(this);
        }

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!disposing)
        //    {
        //        return;
        //    }

        //    MixerVoice voice;

        //    lock (mSyncRoot)
        //    {
        //        if (mDisposed)
        //        {
        //            return;
        //        }

        //        mStarted = false;
        //        mDisposed = true;

        //        voice = mActiveVoice;
        //        mActiveVoice = null;
        //    }

        //    if (voice != null)
        //    {
        //        voice.Output.PlaybackStopped -= Voice_PlaybackStopped;

        //        voice.StopAndDispose();
        //    }
        //}

        public virtual void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Protected/Private Members

        protected OwnedSampleProvider CreateRandomOwnedProvider()
        {
            SoundPermutation selectedSound;
            PlaybackParameters parameters;

            lock (mSyncRoot)
            {
                ThrowIfDisposed();
                ValidateSoundSlot();

                selectedSound =
                    GetRandomElement(mSoundSlot.Samples);

                /*
                 * A new randomized volume, pitch, and pan are generated every time
                 * this method is called.
                 */
                parameters =
                    CreateRandomPlaybackParameters();
            }

            return CreateOwnedProvider(
                selectedSound,
                parameters);
        }

        private OwnedSampleProvider CreateOwnedProvider(
    SoundPermutation sound,
    PlaybackParameters parameters)
        {
            if (sound == null)
            {
                throw new ArgumentNullException(nameof(sound));
            }

            if (sound.Data == null)
            {
                throw new ArgumentNullException(nameof(sound.Data));
            }

            if (sound.Header == null)
            {
                throw new ArgumentNullException(nameof(sound.Header));
            }

            MemoryStream memoryStream = null;
            WaveFileReader waveReader = null;

            try
            {
                memoryStream =
                    MarathonFileUtils.Sounds.Utils.CreateWaveStream(
                        sound.Data,
                        sound.Header);

                if (memoryStream == null)
                {
                    throw new InvalidOperationException(
                        "CreateWaveStream returned null.");
                }

                memoryStream.Position = 0;

                waveReader = new WaveFileReader(memoryStream);

                ISampleProvider sampleProvider =
                    waveReader.ToSampleProvider();

                SmbPitchShiftingSampleProvider pitchProvider =
                    new SmbPitchShiftingSampleProvider(sampleProvider);

                pitchProvider.PitchFactor =
                    (float)parameters.Pitch;

                VolumePanSampleProvider volumePanProvider =
                    new VolumePanSampleProvider(pitchProvider);

                volumePanProvider.Volume =
                    (float)parameters.Volume;

                volumePanProvider.Pan =
                    (float)parameters.Pan;

                ISampleProvider engineFormatProvider =
                    ConvertToEngineFormat(volumePanProvider);

                return new OwnedSampleProvider(
                    engineFormatProvider,
                    waveReader,
                    memoryStream);
            }
            catch
            {
                if (waveReader != null)
                {
                    waveReader.Dispose();

                    /*
                     * WaveFileReader normally disposes its underlying stream.
                     */
                    memoryStream = null;
                }

                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                }

                throw;
            }
        }

        protected void PlayRandomSound()
        {
            MixerVoice previousVoice;
            MixerVoice newVoice;

            lock (mSyncRoot)
            {
                ThrowIfDisposed();

                if (!mStarted)
                {
                    return;
                }

                ValidateSoundSlot();

                SoundPermutation selectedSound =
                    GetRandomElement(mSoundSlot.Samples);

                PlaybackParameters parameters =
                    CreateRandomPlaybackParameters();

                /*
                 * Construct the replacement before removing the current input.
                 * This minimizes the replacement interval.
                 */
                newVoice = CreateVoice(
                    selectedSound,
                    parameters);

                previousVoice = mActiveVoice;
                mActiveVoice = newVoice;
            }

            if (previousVoice != null)
            {
                mSoundEngine.RemoveInput(previousVoice.Provider);
                previousVoice.Dispose();
            }

            try
            {
                mSoundEngine.AddInput(newVoice.Provider);
            }
            catch
            {
                lock (mSyncRoot)
                {
                    if (ReferenceEquals(mActiveVoice, newVoice))
                    {
                        mActiveVoice = null;
                    }
                }

                newVoice.Dispose();
                throw;
            }
        }

        private void VoiceFinished(MixerVoice finishedVoice)
        {
            if (finishedVoice == null)
            {
                return;
            }

            /*
             * AutoDisposeSampleProvider calls this from inside the audio mixer's
             * Read() operation. Do not dispose the current provider or add a new
             * mixer input until that Read() has returned.
             */
            ThreadPool.QueueUserWorkItem(
                delegate
                {
                    FinishVoiceOutsideMixerRead(finishedVoice);
                });
        }

        /// <summary>
        /// Called after a voice finishes naturally or stops with an error.
        /// </summary>
        protected virtual void OnVoiceFinished(Exception exception)
        {
            if (exception != null)
            {
                OnPlaybackError(exception);
            }
        }

        protected virtual void OnPlaybackError(Exception exception)
        {
            // Add application logging here if desired.
            // Debug.WriteLine(exception);
        }

        protected double NextRandomSignedValue(double amount)
        {
            lock (mSyncRoot)
            {
                ValidateFinite(amount, nameof(amount));

                if (amount <= 0.0)
                {
                    return 0.0;
                }

                return ((mRng.NextDouble() * 2.0) - 1.0) * amount;
            }
        }

        protected static double Clamp(double value, double minimum, double maximum)
        {
            if (value < minimum)
            {
                return minimum;
            }

            if (value > maximum)
            {
                return maximum;
            }

            return value;
        }

        protected static void ValidateFinite(double value, string parameterName)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
            {
                throw new ArgumentOutOfRangeException(parameterName, "The value must be a finite number.");
            }
        }

        private PlaybackParameters CreateRandomPlaybackParameters()
        {
            double randomizedVolume = Clamp(mVolume + mRandomVolumeOffset + GetRandomSignedValueUnsafe(mRandomVolume), 0.0, 1.0);
            double randomizedPitch = Clamp(mPitch + mRandomPitchOffset + GetRandomSignedValueUnsafe(mRandomPitch), mMinimumPitch, mMaximumPitch);
            double randomizedPan = Clamp(mPan + mRandomPanOffset + GetRandomSignedValueUnsafe(mRandomPan), -1.0, 1.0);

            return new PlaybackParameters
            {
                Volume = randomizedVolume,
                Pitch = randomizedPitch,
                Pan = randomizedPan,
                BaseVolumeAtStart = mVolume,
                BasePitchAtStart = mPitch,
                BasePanAtStart = mPan
            };
        }

        private MixerVoice CreateVoice(SoundPermutation sound, PlaybackParameters parameters)
        {
            if (sound == null)
            {
                throw new ArgumentNullException(nameof(sound));
            }

            if (sound.Data == null)
            {
                throw new ArgumentNullException(nameof(sound.Data));
            }

            if (sound.Header == null)
            {
                throw new ArgumentNullException(nameof(sound.Header));
            }

            MemoryStream memoryStream = null;
            WaveFileReader waveReader = null;

            try
            {
                memoryStream =
                    MarathonFileUtils.Sounds.Utils.CreateWaveStream(
                        sound.Data,
                        sound.Header);

                if (memoryStream == null)
                {
                    throw new InvalidOperationException("CreateWaveStream returned null.");
                }

                memoryStream.Position = 0;

                waveReader = new WaveFileReader(memoryStream);

                ISampleProvider sourceProvider =
                    waveReader.ToSampleProvider();

                SmbPitchShiftingSampleProvider pitchProvider =
                    new SmbPitchShiftingSampleProvider(sourceProvider);

                pitchProvider.PitchFactor =
                    (float)parameters.Pitch;

                VolumePanSampleProvider volumePanProvider =
                    new VolumePanSampleProvider(pitchProvider);

                volumePanProvider.Volume =
                    (float)parameters.Volume;

                volumePanProvider.Pan =
                    (float)parameters.Pan;

                ISampleProvider engineFormatProvider =
                    ConvertToEngineFormat(volumePanProvider);

                MixerVoice voice = null;

                AutoDisposeSampleProvider endingProvider =
                    new AutoDisposeSampleProvider(
                        engineFormatProvider,
                        delegate
                        {
                            VoiceFinished(voice);
                        });

                voice = new MixerVoice(
                    memoryStream,
                    waveReader,
                    pitchProvider,
                    volumePanProvider,
                    endingProvider,
                    parameters);

                return voice;
            }
            catch
            {
                if (waveReader != null)
                {
                    waveReader.Dispose();
                }

                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                }

                throw;
            }
        }

        //private void Voice_PlaybackStopped(object sender, StoppedEventArgs e)
        //{
        //    MixerVoice finishedVoice;

        //    lock (mSyncRoot)
        //    {
        //        if (mActiveVoice == null || !ReferenceEquals(mActiveVoice.Output, sender))
        //        {
        //            return;
        //        }

        //        finishedVoice = mActiveVoice;
        //        mActiveVoice = null;
        //    }

        //    finishedVoice.Output.PlaybackStopped -= Voice_PlaybackStopped;

        //    finishedVoice.Dispose();

        //    OnVoiceFinished(e.Exception);
        //}

        private void UpdateActiveVoice()
        {
            MixerVoice voice = mActiveVoice;

            if (voice == null)
            {
                return;
            }

            double volumeRandomContribution = voice.Parameters.Volume - voice.Parameters.BaseVolumeAtStart;
            double pitchRandomContribution = voice.Parameters.Pitch - voice.Parameters.BasePitchAtStart;
            double panRandomContribution = voice.Parameters.Pan - voice.Parameters.BasePanAtStart;

            voice.Parameters.Volume = Clamp(mVolume + volumeRandomContribution, 0.0, 1.0);
            voice.Parameters.Pitch = Clamp(mPitch + pitchRandomContribution, mMinimumPitch, mMaximumPitch);
            voice.Parameters.Pan = Clamp(mPan + panRandomContribution, -1.0, 1.0);

            voice.Parameters.BaseVolumeAtStart = mVolume;
            voice.Parameters.BasePitchAtStart = mPitch;
            voice.Parameters.BasePanAtStart = mPan;

            voice.VolumePanProvider.Volume = (float)voice.Parameters.Volume;
            voice.PitchProvider.PitchFactor = (float)voice.Parameters.Pitch;
            voice.VolumePanProvider.Pan = (float)voice.Parameters.Pan;
        }

        private double GetRandomSignedValueUnsafe(double amount)
        {
            if (amount <= 0.0)
            {
                return 0.0;
            }

            return ((mRng.NextDouble() * 2.0) - 1.0) * amount;
        }

        private T GetRandomElement<T>(IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }

            if (list.Count == 0)
            {
                throw new InvalidOperationException("Cannot select an element from an empty list.");
            }

            return list[mRng.Next(list.Count)];
        }

        private void ValidateSoundSlot()
        {
            if (mSoundSlot == null)
            {
                throw new InvalidOperationException("SoundSlot has not been assigned.");
            }

            if (mSoundSlot.Samples == null || mSoundSlot.Samples.Count == 0)
            {
                throw new InvalidOperationException("The SoundSlot does not contain any samples.");
            }
        }

        private static double ClampFinite(double value, double minimum, double maximum, string parameterName)
        {
            ValidateFinite(value, parameterName);
            return Clamp(value, minimum, maximum);
        }

        private void ThrowIfDisposed()
        {
            if (mDisposed)
            {
                throw new ObjectDisposedException(nameof(SoundSource));
            }
        }

        private ISampleProvider ConvertToEngineFormat(
    ISampleProvider source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            ISampleProvider converted = source;

            /*
             * VolumePanSampleProvider should already output stereo, but retain this
             * validation in case the provider chain changes later.
             */
            if (converted.WaveFormat.Channels == 1)
            {
                converted =
                    new MonoToStereoSampleProvider(converted);
            }
            else if (converted.WaveFormat.Channels != 2)
            {
                throw new NotSupportedException(
                    "Only mono and stereo audio is supported.");
            }

            if (converted.WaveFormat.SampleRate !=
                mSoundEngine.WaveFormat.SampleRate)
            {
                converted = new WdlResamplingSampleProvider(
                    converted,
                    mSoundEngine.WaveFormat.SampleRate);
            }

            return converted;
        }

        private void FinishVoiceOutsideMixerRead(
    MixerVoice finishedVoice)
        {
            bool continuePlayback;

            lock (mSyncRoot)
            {
                /*
                 * If another sound was already assigned, this completion belongs
                 * to an obsolete voice and must not start another sound.
                 */
                if (!ReferenceEquals(mActiveVoice, finishedVoice))
                {
                    finishedVoice.Dispose();
                    return;
                }

                mActiveVoice = null;

                continuePlayback =
                    mStarted &&
                    !mDisposed;
            }

            /*
             * The mixer has already removed this provider after it returned zero.
             * It is now safe to dispose the WAV reader and MemoryStream.
             */
            finishedVoice.Dispose();

            if (!continuePlayback)
            {
                return;
            }

            try
            {
                OnVoiceFinished(null);
            }
            catch (ObjectDisposedException)
            {
                // Stop() or Dispose() raced with natural completion.
            }
            catch (Exception exception)
            {
                OnPlaybackError(exception);
            }
        }

        protected bool TrySetStarted()
        {
            lock (mSyncRoot)
            {
                ThrowIfDisposed();

                if (mStarted)
                {
                    return false;
                }

                ValidateSoundSlot();
                mStarted = true;

                return true;
            }
        }

        protected void SetStopped()
        {
            lock (mSyncRoot)
            {
                mStarted = false;
            }
        }

        #endregion

    }
}
