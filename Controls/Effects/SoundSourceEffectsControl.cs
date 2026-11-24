using NAudio.Effects;

namespace MarathonSoundGen.Controls.Effects
{
    public partial class SoundSourceEffectsControl : UserControl
    {

        #region Public Properties

        public Dictionary<EffectTabPage, IAudioEffect> EffectPages = new Dictionary<EffectTabPage, IAudioEffect>();
        private TabPage mSelectedPage;
        public event EventHandler EffectChanged;

        #endregion

        #region Constructor

        public SoundSourceEffectsControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Members

        public void AddEffect(IAudioEffect effect)
        {
            EffectTabPage effectPage;
            string effectName = effect.ToString().ToLower();
            
            if (effectName.Contains("reverb") && !effectName.Contains("convolution"))
            {
                effectPage = new ReverbEffectTabPage
                {
                    Text = "Reverb",
                };
            }
            else if (effectName.Contains("automaticgaincontroleffect"))
            {
                effectPage = new AgcEffectTabPage
                {
                    Text = "Automatic Gain Control",
                };
            }    
            else
            {
                effectPage = null;
            }

            effectPage.EffectChanged += SoundSourceEffectsControl_EffectChanged;
            EffectPages.Add(effectPage, effect);
            UpdateControls();
        }

        private void SoundSourceEffectsControl_EffectChanged(object? sender, EventArgs e)
        {
            HandleEffectChanged();
        }

        public void RemoveEffect(IAudioEffect effect)
        {

        }

        #endregion

        #region Private Members

        private void UpdateControls()
        {
            this.effects_TabControl.TabPages.Clear();

            foreach (EffectTabPage page in EffectPages.Keys)
            {
                this.effects_TabControl.TabPages.Add(page);
            }

            EnsureValidSelectedTab();
        }

        private void HandleEffectChanged()
        {
            EventHandler handler = EffectChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void EnsureValidSelectedTab()
        {
            if (effects_TabControl.IsDisposed)
            {
                return;
            }

            if (effects_TabControl.TabPages.Count == 0)
            {
                SetCurrentTabPage(null);
                return;
            }

            // Select the first page if WinForms currently has no valid selection.
            if (effects_TabControl.SelectedIndex < 0)
            {
                effects_TabControl.SelectedIndex = 0;
            }

            SetCurrentTabPage(effects_TabControl.SelectedTab);
        }

        private void SetCurrentTabPage(TabPage tabPage)
        {
            if (ReferenceEquals(mSelectedPage, tabPage))
            {
                return;
            }

            mSelectedPage = tabPage;

            // Perform any work required when the effective tab changes.
            CurrentTabPageChanged(mSelectedPage);
        }

        private void CurrentTabPageChanged(TabPage currentTabPage)
        {
            if (currentTabPage == null)
            {
                // There are truly no pages in the TabControl.
                return;
            }

            // currentTabPage is the currently displayed page.
            string pageName = currentTabPage.Name;
            string pageText = currentTabPage.Text;
        }

        #endregion

    }
}
