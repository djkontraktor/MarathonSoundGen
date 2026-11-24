using MarathonSoundsPlayer;

namespace MarathonSoundGen.Controls.Effects
{
    public abstract class EffectTabPage : TabPage
    {

        #region Public Properties

        public EventHandler EffectChanged;
        public bool Bypassed;
        public float Mix = 1f;
        public List<IEffectParameter> UserParameters = new List<IEffectParameter>();
        public List<IUserSetting> UserSettings = new List<IUserSetting>();

        #endregion

        #region Protected/Private Properties

        protected string mEffectName;

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

        #region Abstract Members

        protected abstract void AddControls();
        protected abstract void PopulateControls(SoundSource soundSource);

        #endregion

        #region Private Members

        protected void ConstructBase()
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

            foreach (IEffectParameter p in UserParameters)
            {
                Control userControl;

                switch (p)
                {
                    case EffectParameter<float> fParam:

                        LabeledPot pot = new LabeledPot(fParam.Name);
                        pot.Pot.Maximum = fParam.MaxValue;
                        pot.Pot.Minimum = fParam.MinValue;
                        pot.Pot.Value = fParam.DefaultValue;
                        pot.Pot.ValueChanged += Pot_ValueChanged;
                        userControl = pot;
                        p.Control = pot;

                        break;

                    case EffectParameter<int> iParam:

                        NumericUpDown nud = new NumericUpDown { Value = iParam.DefaultValue, Minimum = iParam.MinValue, Maximum = iParam.MaxValue };
                        nud.ValueChanged += Nud_ValueChanged;
                        userControl = nud;
                        p.Control = nud;

                        break;

                    case EffectParameter<bool> bParam:

                        CheckBox cb = new CheckBox { Text = bParam.Name, Checked = bParam.DefaultValue, Appearance = Appearance.Button };
                        cb.CheckedChanged += Cb_CheckedChanged;
                        userControl = cb;
                        p.Control = cb;

                        break;

                    default:
                        throw new NotSupportedException("Unsupported effect parameter type: " + p.ValueType.FullName);
                }

                controls_Table.Controls.Add(userControl);
            }

            UpdateValues();
        }

        private void Cb_CheckedChanged(object? sender, EventArgs e)
        {
            UpdateValues();
            HandleEffectChanged();
        }

        private void Nud_ValueChanged(object? sender, EventArgs e)
        {
            UpdateValues();
            HandleEffectChanged();
        }

        private void Pot_ValueChanged(object? sender, EventArgs e)
        {
            UpdateValues();
            HandleEffectChanged();
        }

        private void BypassChanged(object? sender, EventArgs e)
        {
            Bypassed = bypass_CheckBox.Checked;
            HandleEffectChanged();
        }

        private void MixPot_ValueChanged(object? sender, EventArgs e)
        {
            Mix = (float)mix_Pot.Value;
            HandleEffectChanged();
        }

        private void UpdateValues()
        {
            UserSettings.Clear();

            foreach (IEffectParameter p in UserParameters)
            {
                IUserSetting userSetting;

                switch (p)
                {
                    case EffectParameter<float> fParam:

                        LabeledPot pot = fParam.Control as LabeledPot;
                        userSetting = new UserSetting<float>(fParam.EffectName, fParam.Name, (float)pot.Pot.Value);

                        break;

                    case EffectParameter<int> iParam:

                        NumericUpDown nud = iParam.Control as NumericUpDown;
                        userSetting = new UserSetting<int>(iParam.EffectName, iParam.Name, (int)nud.Value);

                        break;

                    case EffectParameter<bool> bParam:

                        CheckBox cb = bParam.Control as CheckBox;
                        userSetting = new UserSetting<bool>(bParam.EffectName, bParam.Name, cb.Checked);

                        break;

                    default:
                        throw new NotSupportedException("Unsupported effect parameter type: " + p.ValueType.FullName);
                }

                UserSettings.Add(userSetting);
            }
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
