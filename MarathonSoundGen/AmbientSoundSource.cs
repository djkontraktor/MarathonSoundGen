using MarathonFileUtils.Sounds;
using System;

namespace MarathonSoundGen
{
    public class AmbientSoundSource : SoundSource
    {
        public AmbientSoundSource(SoundSlot soundId, double volume, double randomVolume, double randomVolumeOffset, double pitch, double randomPitch, double randomPitchOffset, double pan, double randomPan, double randomPanOffset) :
            base(soundId, volume, randomVolume, randomVolumeOffset, pitch, randomPitch, randomPitchOffset, pan, randomPan, randomPanOffset)
        {

        }

        protected override void OnVoiceFinished(Exception exception)
        {
            base.OnVoiceFinished(exception);

            if (!IsStarted)
            {
                return;
            }

            /*
             * Start the next permutation directly from the completion event.
             * Each call recalculates volume, pitch, and pan randomization.
             */
            try
            {
                PlayRandomSound();
            }
            catch (ObjectDisposedException)
            {
                // Disposal raced with natural playback completion.
            }
            catch (Exception playbackException)
            {
                OnPlaybackError(playbackException);
            }
        }

    }
}
