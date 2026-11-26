using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MarathonSoundGen.Controls
{
    public partial class PlatformPotControl : UserControl
    {
        #region Public Properties

        public event EventHandler SoundPropertyChanged;

        [DefaultValue(1.0)]
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

        [DefaultValue(1.0)]
        public double ExtendedVolume
        {
            get
            {
                return mExtendedVolume;
            }
            set
            {
                extendVolume_Pot.Value = value;
                mExtendedVolume = value;
            }
        }

        [DefaultValue(1.0)]
        public double RetractedVolume
        {
            get
            {
                return mRetractedVolume;
            }
            set
            {
                retractVolume_Pot.Value = value;
                mRetractedVolume = value;
            }
        }

        [DefaultValue(0.0)]
        public double ExtendedPan
        {
            get
            {
                return mExtendedPan;
            }
            set
            {
                extendedPan_Pot.Value = value;
                mExtendedPan = value;
            }
        }

        [DefaultValue(0.0)]
        public double RetractedPan
        {
            get
            {
                return mRetractedPan;
            }
            set
            {
                retractedPan_Pot.Value = value;
                mRetractedPan = value;
            }
        }

        [DefaultValue(1.0)]
        public double ExtendSpeed_WU_s
        {
            get
            {
                return mExtendSpeed_WU_s;
            }
            set
            {
                extendSpeed_Pot.Value = value;
                mExtendSpeed_WU_s = value;
            }
        }

        [DefaultValue(1.0)]
        public double RetractSpeed_WU_s
        {
            get
            {
                return mRetractSpeed_WU_s;
            }
            set
            {
                retractSpeed_Pot.Value = value;
                mRetractSpeed_WU_s = value;
            }
        }

        [DefaultValue(1.0)]
        public double ExtendDelay_s
        {
            get
            {
                return mExtendDelay_s;
            }
            set
            {
                extendDelay_Pot.Value = value;
                mExtendDelay_s = value;
            }
        }

        [DefaultValue(1.0)]
        public double RetractDelay_s
        {
            get
            {
                return mRetractDelay_s;
            }
            set
            {
                retractDelay_Pot.Value = value;
                mRetractDelay_s = value;
            }
        }

        [DefaultValue(1.0)]
        public double Distance_WU
        {
            get
            {
                return mDistance_WU;
            }
            set
            {
                distance_Pot.Value = value;
                mDistance_WU = value;
            }
        }

        #endregion

        #region Private Properties

        private double mPitch;
        private double mExtendedVolume;
        private double mRetractedVolume;
        private double mExtendedPan;
        private double mRetractedPan;
        private double mExtendSpeed_WU_s;
        private double mRetractSpeed_WU_s;
        private double mExtendDelay_s;
        private double mRetractDelay_s;
        private double mDistance_WU;

        #endregion

        #region Constructor

        public PlatformPotControl()
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
            mPitch = 1;
            mExtendedVolume = 1;
            mRetractedVolume = 1;
            mExtendedPan = 0;
            mRetractedPan = 0;
            mExtendSpeed_WU_s = 1;
            mRetractSpeed_WU_s = 1;
            mExtendDelay_s = 1;
            mRetractDelay_s = 1;
            mDistance_WU = 1;
        }

        private void UpdateValues()
        {
            mPitch = pitch_Pot.Value;
            mExtendedVolume = extendVolume_Pot.Value;
            mRetractedVolume = retractVolume_Pot.Value;
            mExtendedPan = extendedPan_Pot.Value;
            mRetractedPan = retractedPan_Pot.Value;
            mExtendSpeed_WU_s = extendSpeed_Pot.Value;
            mRetractSpeed_WU_s = retractSpeed_Pot.Value;
            mExtendDelay_s = extendDelay_Pot.Value;
            mRetractDelay_s = retractDelay_Pot.Value;
            mDistance_WU = distance_Pot.Value;
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
