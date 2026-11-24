using MarathonSoundsPlayer;

namespace MarathonSoundGen.Controls.Effects
{
    public class ReverbEffectTabPage : EffectTabPage
    {

        #region Constructor

        /// <summary>
        /// Make a new default tab page.
        /// </summary>
        public ReverbEffectTabPage()
        {
            AddControls();
            ConstructBase();
        }

        /// <summary>
        /// Make a tab page from an existing sound source and set its properties.
        /// </summary>
        /// <param name="soundSource"></param>
        public ReverbEffectTabPage(SoundSource soundSource)
        {
            AddControls();
            ConstructBase();
            PopulateControls(soundSource);
        }

        #endregion

        #region Private Members

        protected override void AddControls()
        {
            UserParameters.Add(new EffectParameter<float>("Reverb", "Room Size", 0.5f, 0f, 1f));
            UserParameters.Add(new EffectParameter<float>("Reverb", "Damping", 0.5f, 0f, 1f));
            UserParameters.Add(new EffectParameter<float>("Reverb", "Width", 1f, 0f, 1f));
        }

        protected override void PopulateControls(SoundSource soundSource)
        {

        }

        #endregion

    }
}
