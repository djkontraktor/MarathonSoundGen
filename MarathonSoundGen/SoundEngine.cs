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

        public M2SoundsFile SoundsFile;
        public bool SoundsFileLoaded = false;

        public WaveFormat WaveFormat
        {
            get
            {
                return mMixer.WaveFormat;
            }
        }

        public bool OutputEnabled
        {
            get
            {
                lock (mSync)
                {
                    return mOutputEnabled;
                }
            }
        }

        public int ActiveSourceCount
        {
            get
            {
                lock (mSync)
                {
                    return mActiveSources.Count;
                }
            }
        }

        #endregion

        #region Private Properties

        private readonly object mSync = new object();
        private readonly MixingSampleProvider mMixer;
        private readonly WaveOutEvent mOutputDevice;
        private readonly HashSet<object> mActiveSources = new HashSet<object>();
        private bool mOutputEnabled;
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

            mMixer = new MixingSampleProvider(mixerFormat)
            {
                // This is the critical setting. The mixer returns silence instead
                // of returning zero when it temporarily has no inputs. Therefore,
                // WaveOutEvent does not interpret an empty mixer as end-of-stream.
                ReadFully = true,
            };

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

                lock (mSync)
                {
                    ThrowIfDisposed();

                    mActiveSources.Add(owner);

                    if (!mOutputEnabled)
                    {
                        mOutputDevice.Play();
                        mOutputEnabled = true;
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

            lock (mSync)
            {
                if (mDisposed)
                {
                    return;
                }

                mActiveSources.Remove(owner);
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

                lock (mSync)
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

            lock (mSync)
            {
                if (mDisposed)
                {
                    return;
                }

                mMixer.RemoveMixerInput(input);
            }
        }

        public void LoadSoundsFile(string filePath)
        {
            SoundsFile = new M2SoundsFile(filePath);
            SoundsFileLoaded = true;
        }

        public void Dispose()
        {
            lock (mSync)
            {
                if (mDisposed)
                {
                    return;
                }

                mDisposed = true;
                mActiveSources.Clear();

                if (mOutputEnabled)
                {
                    mOutputDevice.Stop();
                    mOutputEnabled = false;
                }

                mOutputDevice.Dispose();
            }

            GC.SuppressFinalize(this);
        }

        public void LoadFromFile(string filePath)
        {
            // First load sounds file from path
            string soundsFilePath;

            // Then load all sound sources

        }

        public void SaveToFile(string filePath)
        {
            // First save sounds file path

            // Then save all sound sources

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
