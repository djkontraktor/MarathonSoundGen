using MarathonSoundsPlayer;
using NAudio.Gui;

namespace MarathonSoundGen.Controls.Effects
{
    public class EffectTabPage : TabPage
    {

        #region Public Properties

        public EventHandler EffectChanged;
        public bool Bypassed;
        public double Mix = 1;

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

        protected LabeledPot mix_Pot = new LabeledPot("Dry/Wet");

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
            mix_Pot.Pot.Minimum = 0;
            mix_Pot.Pot.Maximum = 1;
            mix_Pot.Pot.Value = 1;
            mix_Pot.Pot.ValueChanged += MixPot_ValueChanged;
            controls_Table.Controls.Add(mix_Pot);
        }

        private void PopulateControlsBase(SoundSource soundSource)
        {

        }

        private void BypassChanged(object? sender, EventArgs e)
        {
            Bypassed = bypass_CheckBox.Checked;
            HandleEffectChanged();
        }

        private void MixPot_ValueChanged(object? sender, EventArgs e)
        {
            Mix = mix_Pot.Value;
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
