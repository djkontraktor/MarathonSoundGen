using MarathonSoundsPlayer;

namespace MarathonSoundGen.Controls.Effects
{
    public class EffectTabPage : TabPage
    {

        #region Public Properties

        public EventHandler EffectChanged;
        public bool Bypassed;

        #endregion

        #region Private Properties

        protected TableLayoutPanel controls_Table = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 5,
            RowCount = 2,
        };

        protected CheckBox bypass_CheckBox = new CheckBox
        {
            Appearance = Appearance.Button,
            Text = "Bypass",
        };

        #endregion

        #region Constructors

        public EffectTabPage()
        {
            ConstructBase();
        }

        public EffectTabPage(SoundSource soundSource)
        {
            ConstructBase();
            PopulateControlsBase(soundSource);
        }

        #endregion

        #region Private Members

        private void ConstructBase()
        {
            controls_Table.RowStyles.Add(new RowStyle(SizeType.Percent));
            this.Controls.Add(controls_Table);
            bypass_CheckBox.CheckedChanged += BypassChanged;
            controls_Table.Controls.Add(bypass_CheckBox);
        }

        private void PopulateControlsBase(SoundSource soundSource)
        {

        }

        private void BypassChanged(object? sender, EventArgs e)
        {
            Bypassed = bypass_CheckBox.Checked;
            HandleEffectChanged();
        }

        protected void HandleEffectChanged()
        {
            EventHandler handler = EffectChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion

    }
}
