using MarathonSoundsPlayer;

namespace MarathonSoundGen.Controls.Effects
{
    public class AgcEffectTabPage : EffectTabPage
    {

        /// <summary>
        /// Make a new default tab page.
        /// </summary>
        public AgcEffectTabPage()
        {
            AddControls();
        }

        /// <summary>
        /// Make a tab page from an existing sound source and set its properties.
        /// </summary>
        /// <param name="soundSource"></param>
        public AgcEffectTabPage(SoundSource soundSource)
        {
            AddControls();
            PopulateControls(soundSource);
        }

        protected override void AddControls()
        {
            mEffectName = "Automatic Gain Control";
            UserParameters.Add(new EffectParameter<float>(mEffectName, "Target (dB)", -18f, -99f, 99f));
            UserParameters.Add(new EffectParameter<float>(mEffectName, "Max Gain (dB)", 30f, -99f, 99f));
            UserParameters.Add(new EffectParameter<float>(mEffectName, "Min Gain (dB)", -20f, -99f, 99f));
            UserParameters.Add(new EffectParameter<float>(mEffectName, "RMS Detector Window (ms)", 50f, 1f, 1000f));
            UserParameters.Add(new EffectParameter<bool>(mEffectName, "Voice Detection", true, false, true));
            UserParameters.Add(new EffectParameter<float>(mEffectName, "Attack (ms)", 50f, 1f, 1000f));
            UserParameters.Add(new EffectParameter<float>(mEffectName, "Release (ms)", 400f, 1f, 1000f));
            ConstructBase();
        }

        protected override void PopulateControls(SoundSource soundSource)
        {

        }

    }
}
