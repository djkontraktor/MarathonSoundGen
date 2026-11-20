using System;
using System.Windows.Forms;

namespace MarathonSoundGen
{
    public partial class SoundSourcePotControl : UserControl
    {

        #region Public Properties

        public event EventHandler SoundPropertyChanged;

        public double Volume
        {
            get
            {
                return mVolume;
            }
            set
            {
                volume_Pot.Value = value;
                mVolume = value;
            }
        }

        public double DeltaVolume
        {
            get
            {
                return mDeltaVolume;
            }
            set
            {
                deltaVolume_Pot.Value = value;
                mDeltaVolume = value;
            }
        }

        public double DeltaVolumeOffset
        {
            get
            {
                return mDeltaVolumeOffset;
            }
            set
            {
                deltaVolumeOffset_Pot.Value = value;
                mDeltaVolumeOffset = value;
            }
        }

        public double Pitch
        {
            get
            {
                return mPitch;
            }
            set
            {
                pitch_Pot.Value = value;
                mPitch = value;
            }
        }

        public double DeltaPitch
        {
            get
            {
                return mDeltaPitch;
            }
            set
            {
                deltaPitch_Pot.Value = value;
                mDeltaPitch = value;
            }
        }

        public double DeltaPitchOffset
        {
            get
            {
                return mDeltaPitchOffset;
            }
            set
            {
                deltaPitchOffset_Pot.Value = value;
                mDeltaPitchOffset = value;
            }
        }

        public double Pan
        {
            get
            {
                return mPan;
            }
            set
            {
                pan_Pot.Value = value;
                mPan = value;
            }
        }

        public double DeltaPan
        {
            get
            {
                return mDeltaPan;
            }
            set
            {
                deltaPan_Pot.Value = value;
                mDeltaPan = value;
            }
        }

        public double DeltaPanOffset
        {
            get
            {
                return mDeltaPanOffset;
            }
            set
            {
                deltaPanOffset_Pot.Value = value;
                mDeltaPanOffset = value;
            }
        }

        public double Frequency
        {
            get
            {
                return mFrequency;
            }
            set
            {
                frequency_Pot.Value = value;
                mFrequency = value;
            }
        }

        public double DeltaFrequency
        {
            get
            {
                return mDeltaFrequency;
            }
            set
            {
                deltaFrequency_Pot.Value = value;
                mDeltaFrequency = value;
            }
        }

        public double DeltaFrequencyOffset
        {
            get
            {
                return mDeltaFrequencyOffset;
            }
            set
            {
                deltaFrequencyOffset_Pot.Value = value;
                mDeltaFrequencyOffset = value;
            }
        }

        #endregion

        #region Private Properties

        private double mVolume;
        private double mDeltaVolume;
        private double mDeltaVolumeOffset;
        private double mPitch;
        private double mDeltaPitch;
        private double mDeltaPitchOffset;
        private double mPan;
        private double mDeltaPan;
        private double mDeltaPanOffset;
        private double mFrequency;
        private double mDeltaFrequency;
        private double mDeltaFrequencyOffset;

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
            mVolume = 1;
            mDeltaVolume = 0;
            mDeltaVolumeOffset = 0;
            mPitch = 1;
            mDeltaPitch = 0;
            mDeltaPitchOffset = 0;
            mPan = 0;
            mDeltaPan = 0;
            mDeltaPanOffset = 0;
            mFrequency = 1;
            mDeltaFrequency = 0;
            mDeltaFrequencyOffset = 0;
        }

        private void UpdateValues()
        {
            mVolume = volume_Pot.Value;
            mDeltaVolume = deltaVolume_Pot.Value;
            mDeltaVolumeOffset = deltaVolumeOffset_Pot.Value;
            mPitch = pitch_Pot.Value;
            mDeltaPitch = deltaPitch_Pot.Value;
            mDeltaPitchOffset = deltaPitchOffset_Pot.Value;
            mPan = pan_Pot.Value;
            mDeltaPan = deltaPan_Pot.Value;
            mDeltaPanOffset = deltaPanOffset_Pot.Value;
            mFrequency = frequency_Pot.Value;
            mDeltaFrequency = deltaFrequency_Pot.Value;
            mDeltaFrequencyOffset = deltaFrequencyOffset_Pot.Value;
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
