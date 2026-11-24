using MarathonSoundsPlayer;
using System.ComponentModel;

namespace MarathonSoundGen.Controls.Effects
{
    public class AgcEffectTabPage : EffectTabPage
    {

        #region Public Properties

        /// <summary>Target RMS level in dBFS. Default -18 dB.</summary>
        [DefaultValue(-18d)]
        public double Target_dB { get; set; } = -18d;

        /// <summary>Maximum boost in dB. Default 30 dB.</summary>
        [DefaultValue(30d)]
        public double MaxGain_dB { get; set; } = 30d;

        /// <summary>Maximum attenuation in dB (negative). Default -20 dB.</summary>
        [DefaultValue(-20d)]
        public double MinGain_dB { get; set; } = -20d;

        /// <summary>RMS detector window in milliseconds. Default 50 ms.</summary>
        [DefaultValue(50d)]
        public double RmsWindow_ms { get; set; } = 50d;

        /// <summary>When true, gain is held while no voice is detected. Default true.</summary>
        [DefaultValue(true)]
        public bool UseVoiceDetection { get; set; } = true;

        /// <summary>Time (ms) to pull gain down when too loud. Default 50 ms.</summary>
        [DefaultValue(50d)]
        public double Attack_ms { get; set; } = 50d;

        /// <summary>Time (ms) to bring gain up when too quiet. Default 400 ms.</summary>
        [DefaultValue(400d)]
        public double Release_ms { get; set; } = 400d;

        /// <summary>The current applied gain in dB, for metering.</summary>
        [DefaultValue(0d)]
        public double Gain_dB { get; set; } = 0;

        #endregion

        #region Private Properties

        private LabeledPot target_Pot = new LabeledPot("Target (dB)");
        private LabeledPot maxGain_Pot = new LabeledPot("Max Gain (dB)");
        private LabeledPot minGain_Pot = new LabeledPot("Min Gain (dB)");
        private LabeledPot rmsWindow_Pot = new LabeledPot("RMS Detector Window (ms)");
        private CheckBox useVoiceDetection_CheckBox = new CheckBox { Text = "Use Voice Detection?", Checked = true, Appearance = Appearance.Button };
        private LabeledPot attack_Pot = new LabeledPot("Attack (ms)");
        private LabeledPot release_Pot = new LabeledPot("Release (ms)");
        private LabeledPot gain_Pot = new LabeledPot("Gain (dB)");

        #endregion

        #region Constructor

        /// <summary>
        /// Make a new default tab page.
        /// </summary>
        public AgcEffectTabPage() : base()
        {
            AddControls();
        }

        /// <summary>
        /// Make a tab page from an existing sound source and set its properties.
        /// </summary>
        /// <param name="soundSource"></param>
        public AgcEffectTabPage(SoundSource soundSource) : base()
        {
            AddControls();
            PopulateControls(soundSource);
        }

        #endregion

        #region Private Members

        protected override void AddControls()
        {
            target_Pot.Pot.Minimum = -99;
            target_Pot.Pot.Maximum = 0;
            target_Pot.Pot.Value = Target_dB;
            maxGain_Pot.Pot.Minimum = -99;
            maxGain_Pot.Pot.Maximum = 99;
            maxGain_Pot.Pot.Value = MaxGain_dB;
            minGain_Pot.Pot.Minimum = -99;
            minGain_Pot.Pot.Maximum = 99;
            minGain_Pot.Pot.Value = MinGain_dB;
            rmsWindow_Pot.Pot.Minimum = 0;
            rmsWindow_Pot.Pot.Maximum = 1000;
            rmsWindow_Pot.Pot.Value = RmsWindow_ms;
            attack_Pot.Pot.Minimum = 0;
            attack_Pot.Pot.Maximum = 1000;
            attack_Pot.Pot.Value = Attack_ms;
            release_Pot.Pot.Minimum = 0;
            release_Pot.Pot.Maximum = 1000;
            release_Pot.Pot.Value = Release_ms;
            gain_Pot.Pot.Minimum = -99;
            gain_Pot.Pot.Maximum = 99;
            gain_Pot.Pot.Value = Gain_dB;

            target_Pot.Pot.ValueChanged += Pot_ValueChanged;
            maxGain_Pot.Pot.ValueChanged += Pot_ValueChanged;
            minGain_Pot.Pot.ValueChanged += Pot_ValueChanged;
            rmsWindow_Pot.Pot.ValueChanged += Pot_ValueChanged;
            useVoiceDetection_CheckBox.CheckedChanged += UseVoiceDetection_CheckBox_CheckedChanged;
            attack_Pot.Pot.ValueChanged += Pot_ValueChanged;
            release_Pot.Pot.ValueChanged += Pot_ValueChanged;
            gain_Pot.Pot.ValueChanged += Pot_ValueChanged;

            this.controls_Table.Controls.Add(target_Pot);
            this.controls_Table.Controls.Add(maxGain_Pot);
            this.controls_Table.Controls.Add(minGain_Pot);
            this.controls_Table.Controls.Add(rmsWindow_Pot);
            this.controls_Table.Controls.Add(attack_Pot);
            this.controls_Table.Controls.Add(release_Pot);
            this.controls_Table.Controls.Add(gain_Pot);
        }

        private void UseVoiceDetection_CheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            UpdateValues();
            HandleEffectChanged();
        }

        protected override void PopulateControls(SoundSource soundSource)
        {

        }

        private void Pot_ValueChanged(object? sender, EventArgs e)
        {
            UpdateValues();
            HandleEffectChanged();
        }

        private void UpdateValues()
        {
            Target_dB = target_Pot.Pot.Value;
            MaxGain_dB = maxGain_Pot.Pot.Value;
            MinGain_dB = minGain_Pot.Pot.Value;
            RmsWindow_ms = rmsWindow_Pot.Pot.Value;
            UseVoiceDetection = useVoiceDetection_CheckBox.Checked;
            Attack_ms = attack_Pot.Pot.Value;
            Release_ms = release_Pot.Pot.Value;
            Gain_dB = gain_Pot.Pot.Value;
        }

        #endregion

    }
}
