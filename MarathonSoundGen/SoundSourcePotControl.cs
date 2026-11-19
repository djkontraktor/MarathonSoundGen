using System;
using System.Windows.Forms;

namespace MarathonSoundGen
{
    public partial class SoundSourcePotControl : UserControl
    {

        #region Public Properties

        public event EventHandler SoundPropertyChanged;
        public double Volume { get; private set; }
        public double DeltaVolume { get; private set; }
        public double DeltaVolumeOffset { get; private set; }
        public double Pitch { get; private set; }
        public double DeltaPitch { get; private set; }
        public double DeltaPitchOffset { get; private set; }
        public double Pan { get; private set; }
        public double DeltaPan { get; private set; }
        public double DeltaPanOffset { get; private set; }
        public double Frequency { get; private set; }
        public double DeltaFrequency { get; private set; }
        public double DeltaFrequencyOffset { get; private set; }

        #endregion

        #region Constructor

        public SoundSourcePotControl()
        {
            InitializeComponent();
            InitializeValues();
        }

        #endregion

        #region Control Callbacks

        private void PotChanged(object sender, EventArgs e)
        {
            UpdateValues();
            HandleSoundPropertyChanged();
        }

        #endregion

        #region Private Properties

        private void InitializeValues()
        {
            Volume = 1;
            DeltaVolume = 0;
            DeltaVolumeOffset = 0;
            Pitch = 1;
            DeltaPitch = 0;
            DeltaPitchOffset = 0;
            Pan = 0;
            DeltaPan = 0;
            DeltaPanOffset = 0;
            Frequency = 1;
            DeltaFrequency = 0;
            DeltaFrequencyOffset = 0;
        }

        private void UpdateValues()
        {
            Volume = volume_Pot.Value;
            DeltaVolume = deltaVolume_Pot.Value;
            DeltaVolumeOffset = deltaVolumeOffset_Pot.Value;
            Pitch = pitch_Pot.Value;
            DeltaPitch = deltaPitch_Pot.Value;
            DeltaPitchOffset = deltaPitchOffset_Pot.Value;
            Pan = pan_Pot.Value;
            DeltaPan = deltaPan_Pot.Value;
            DeltaPanOffset = deltaPanOffset_Pot.Value;
            Frequency = frequency_Pot.Value;
            DeltaFrequency = deltaFrequency_Pot.Value;
            DeltaFrequencyOffset = deltaFrequencyOffset_Pot.Value;
        }

        private void HandleSoundPropertyChanged()
        {
            EventHandler handler = SoundPropertyChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion

    }
}
