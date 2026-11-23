namespace MarathonSoundGen.Controls.Effects
{
    public partial class SoundSourceEffectsControl : UserControl
    {

        #region Public Properties

        public event EventHandler EffectChanged;

        #endregion

        public SoundSourceEffectsControl()
        {
            InitializeComponent();
        }

        private void HandleEffectChanged()
        {
            EventHandler handler = EffectChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

    }
}
