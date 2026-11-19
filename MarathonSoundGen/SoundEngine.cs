using MarathonFileUtils.Sounds;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;

namespace MarathonSoundGen
{
    public class SoundEngine : IDisposable
    {

        #region Public Properties

        public static SoundScape SoundScape = new SoundScape();
        public static M2SoundsFile SoundsFile;
        public static bool SoundsFileLoaded = false;

        public WaveFormat WaveFormat
        {
            get
            {
                return mMixer.WaveFormat;
            }
        }

        public bool IsOutputRunning
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mOutputRunning;
                }
            }
        }

        public int ActiveSourceCount
        {
            get
            {
                lock (mSyncRoot)
                {
                    return mActiveOwners.Count;
                }
            }
        }

        #endregion

        #region Private Properties

        private readonly object mSyncRoot = new object();
        private readonly MixingSampleProvider mMixer;
        private readonly WaveOutEvent mOutputDevice;
        private readonly HashSet<object> mActiveOwners = new HashSet<object>();
        private bool mOutputRunning;
        private bool mDisposed;

        #endregion

        #region Constructor

        public SoundEngine(int sampleRate = 44100, int desiredLatency_ms = 100)
        {
            if (sampleRate <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sampleRate));
            }

            if (desiredLatency_ms <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(desiredLatency_ms));
            }

            WaveFormat mixerFormat = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, 2);

            mMixer = new MixingSampleProvider(mixerFormat);

            /*
             * This is the critical setting. The mixer returns silence instead
             * of returning zero when it temporarily has no inputs. Therefore,
             * WaveOutEvent does not interpret an empty mixer as end-of-stream.
             */
            mMixer.ReadFully = true;

            mOutputDevice = new WaveOutEvent
            {
                DesiredLatency = desiredLatency_ms
            };

            mOutputDevice.Init(mMixer);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Registers a SoundSource as active. The first active source starts
        /// the persistent output device.
        /// </summary>
        public void ActivateSource(object owner)
        {
            if (SoundsFileLoaded)
            {
                if (owner == null)
                {
                    throw new ArgumentNullException(nameof(owner));
                }

                lock (mSyncRoot)
                {
                    ThrowIfDisposed();

                    mActiveOwners.Add(owner);

                    if (!mOutputRunning)
                    {
                        mOutputDevice.Play();
                        mOutputRunning = true;
                    }
                }
            }
        }

        /// <summary>
        /// Marks a SoundSource as inactive. When no sources remain, the output
        /// can either stop or continue playing silence, depending on the argument.
        /// </summary>
        public void DeactivateSource(object owner)
        {
            if (owner == null)
            {
                return;
            }

            lock (mSyncRoot)
            {
                if (mDisposed)
                {
                    return;
                }

                mActiveOwners.Remove(owner);
            }
        }

        public void AddInput(ISampleProvider input)
        {
            if (SoundsFileLoaded)
            {
                if (input == null)
                {
                    throw new ArgumentNullException(nameof(input));
                }

                lock (mSyncRoot)
                {
                    ThrowIfDisposed();

                    if (!WaveFormatsMatch(input.WaveFormat, mMixer.WaveFormat))
                    {
                        throw new ArgumentException("The input format does not match the mixer format. Expected " + mMixer.WaveFormat + ", but received " + input.WaveFormat + ".", nameof(input));
                    }

                    mMixer.AddMixerInput(input);
                }
            }
        }

        public void RemoveInput(ISampleProvider input)
        {
            if (input == null)
            {
                return;
            }

            lock (mSyncRoot)
            {
                if (mDisposed)
                {
                    return;
                }

                mMixer.RemoveMixerInput(input);
            }
        }

        public static void LoadSoundsFile(string filePath)
        {
            SoundsFile = new M2SoundsFile(filePath);
            SoundsFileLoaded = true;
        }

        public void Dispose()
        {
            lock (mSyncRoot)
            {
                if (mDisposed)
                {
                    return;
                }

                mDisposed = true;
                mActiveOwners.Clear();

                if (mOutputRunning)
                {
                    mOutputDevice.Stop();
                    mOutputRunning = false;
                }

                mOutputDevice.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        #endregion

        #region Private Members

        private static bool WaveFormatsMatch(WaveFormat first, WaveFormat second)
        {
            return first.SampleRate == second.SampleRate &&
                   first.Channels == second.Channels &&
                   first.Encoding == second.Encoding &&
                   first.BitsPerSample == second.BitsPerSample;
        }

        private void ThrowIfDisposed()
        {
            if (mDisposed)
            {
                throw new ObjectDisposedException(nameof(SoundEngine));
            }
        }

        #endregion

    }
}
