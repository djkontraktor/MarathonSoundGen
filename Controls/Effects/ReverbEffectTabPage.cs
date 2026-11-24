using MarathonSoundsPlayer;

namespace MarathonSoundGen.Controls.Effects
{
    public class ReverbEffectTabPage : EffectTabPage
    {

        /// <summary>
        /// Make a new default tab page.
        /// </summary>
        public ReverbEffectTabPage()
        {
            AddControls();
        }

        /// <summary>
        /// Make a tab page from an existing sound source and set its properties.
        /// </summary>
        /// <param name="soundSource"></param>
        public ReverbEffectTabPage(SoundSource soundSource)
        {
            AddControls();
            PopulateControls(soundSource);
        }

        protected override void AddControls()
        {
            mEffectName = "Reverb";
            UserParameters.Add(new EffectParameter<float>(mEffectName, "Room Size", 0.5f, 0f, 1f));
            UserParameters.Add(new EffectParameter<float>(mEffectName, "Damping", 0.5f, 0f, 1f));
            UserParameters.Add(new EffectParameter<float>(mEffectName, "Width", 1f, 0f, 1f));
            ConstructBase();
        }

        protected override void PopulateControls(SoundSource soundSource)
        {

        }

    }
}
