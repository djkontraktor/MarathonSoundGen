using MarathonFileUtils.Sounds;

namespace MarathonSoundGen
{
    public class AmbientSoundSource : SoundSource
    {

        #region Private Properties

        private readonly object mSyncRoot = new object();
        private ContinuousRandomSampleProvider mAmbientProvider;

        #endregion

        #region Constructor

        public AmbientSoundSource(SoundEngine soundEngine, SoundSlot soundSlot, double volume, double randomVolume, double randomVolumeOffset, double pitch, double randomPitch, double randomPitchOffset, double pan, double randomPan, double randomPanOffset)
        : base(soundEngine, soundSlot, volume, randomVolume, randomVolumeOffset, pitch, randomPitch, randomPitchOffset, pan, randomPan, randomPanOffset)
        {

        }

        #endregion

        #region Public Members

        public override void Start()
        {
            lock (mSyncRoot)
            {
                if (mAmbientProvider != null)
                {
                    return;
                }

                if (!TrySetStarted())
                {
                    return;
                }

                ContinuousRandomSampleProvider provider = new ContinuousRandomSampleProvider(SoundEngine.WaveFormat, CreateRandomOwnedProvider);

                try
                {
                    SoundEngine.ActivateSource(this);
                    SoundEngine.AddInput(provider);
                    mAmbientProvider = provider;
                }
                catch
                {
                    SetStopped();
                    SoundEngine.RemoveInput(provider);
                    SoundEngine.DeactivateSource(this);
                    provider.Dispose();
                    throw;
                }
            }
        }

        public override void Stop()
        {
            ContinuousRandomSampleProvider provider;

            lock (mSyncRoot)
            {
                provider = mAmbientProvider;
                mAmbientProvider = null;
                SetStopped();
            }

            if (provider != null)
            {
                provider.Stop();
                SoundEngine.RemoveInput(provider);
                provider.Dispose();
            }

            SoundEngine.DeactivateSource(this);
        }

        public override void Dispose()
        {
            Stop();
            base.Dispose();
        }

        #endregion

    }
}
