using MarathonSoundsPlayer;
using System.ComponentModel;

namespace MarathonSoundGen.Controls.Effects
{
    public class ReverbEffectTabPage : EffectTabPage
    {

        #region Public Properties

        /// <summary>Room size, 0 (small) to 1 (large). Default 0.5.</summary>
        [DefaultValue(0.5d)]
        public double RoomSize { get; set; } = 0.5f;

        /// <summary>High-frequency damping, 0 (bright) to 1 (dark). Default 0.5.</summary>
        [DefaultValue(0.5d)]
        public double Damping { get; set; } = 0.5f;

        /// <summary>Stereo width of the reverb, 0 (mono) to 1 (wide). Default 1.</summary>
        [DefaultValue(0.5d)]
        public double Width { get; set; } = 1f;

        #endregion

        #region Private Properties

        private LabeledPot roomSize_Pot = new LabeledPot("Room Size");
        private LabeledPot damping_Pot = new LabeledPot("Damping");
        private LabeledPot width_Pot = new LabeledPot("Width");

        #endregion

        #region Constructor

        /// <summary>
        /// Make a new default tab page.
        /// </summary>
        public ReverbEffectTabPage() : base()
        {
            Construct();
        }

        /// <summary>
        /// Make a tab page from an existing sound source and set its properties.
        /// </summary>
        /// <param name="soundSource"></param>
        public ReverbEffectTabPage(SoundSource soundSource) : base(soundSource)
        {
            Construct();
            PopulateControls(soundSource);
        }

        #endregion

        #region Private Members

        private void Construct()
        {
            roomSize_Pot.Pot.Minimum = 0;
            roomSize_Pot.Pot.Maximum = 1;
            roomSize_Pot.Pot.Value = 0.5;
            damping_Pot.Pot.Minimum = 0;
            damping_Pot.Pot.Maximum = 1;
            damping_Pot.Pot.Value = 0.5;
            width_Pot.Pot.Minimum = 0;
            width_Pot.Pot.Maximum = 1;
            width_Pot.Pot.Value = 1;

            roomSize_Pot.Pot.ValueChanged += Pot_ValueChanged;
            damping_Pot.Pot.ValueChanged += Pot_ValueChanged;
            width_Pot.Pot.ValueChanged += Pot_ValueChanged;

            this.controls_Table.Controls.Add(roomSize_Pot);
            this.controls_Table.Controls.Add(damping_Pot);
            this.controls_Table.Controls.Add(width_Pot);
        }

        private void Pot_ValueChanged(object? sender, EventArgs e)
        {
            UpdateValues();
            HandleEffectChanged();
        }

        private void PopulateControls(SoundSource soundSource)
        {

        }

        private void UpdateValues()
        {
            RoomSize = roomSize_Pot.Pot.Value;
            Damping = damping_Pot.Pot.Value;
            Width = width_Pot.Pot.Value;
        }

        #endregion

    }
}
