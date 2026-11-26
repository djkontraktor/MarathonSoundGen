using MarathonFileUtils.Sounds.DataStructures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MarathonSoundGen.Controls
{
    public partial class PlatformSampleControl : UserControl
    {
        #region Public Properties

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SoundId StartExtendSound
        {
            get
            {
                return mStartExtendSound;
            }
            set
            {
                SoundId matchingSoundId = startExtend_ComboBox.Items.Cast<SoundId>().FirstOrDefault(s => s.Id == value.Id);
                startExtend_ComboBox.SelectedItem = matchingSoundId;
                mStartExtendSound = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SoundId StopExtendSound
        {
            get
            {
                return mStopExtendSound;
            }
            set
            {
                SoundId matchingSoundId = stopExtend_ComboBox.Items.Cast<SoundId>().FirstOrDefault(s => s.Id == value.Id);
                stopExtend_ComboBox.SelectedItem = matchingSoundId;
                mStopExtendSound = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SoundId StartRetractSound
        {
            get
            {
                return mStartRetractSound;
            }
            set
            {
                SoundId matchingSoundId = startRetract_ComboBox.Items.Cast<SoundId>().FirstOrDefault(s => s.Id == value.Id);
                startRetract_ComboBox.SelectedItem = matchingSoundId;
                mStartRetractSound = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SoundId StopRetractSound
        {
            get
            {
                return mStopRetractSound;
            }
            set
            {
                SoundId matchingSoundId = stopRetract_ComboBox.Items.Cast<SoundId>().FirstOrDefault(s => s.Id == value.Id);
                stopRetract_ComboBox.SelectedItem = matchingSoundId;
                mStopRetractSound = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SoundId RunningSound
        {
            get
            {
                return mRunningSound;
            }
            set
            {
                SoundId matchingSoundId = runningSound_ComboBox.Items.Cast<SoundId>().FirstOrDefault(s => s.Id == value.Id);
                runningSound_ComboBox.SelectedItem = matchingSoundId;
                mRunningSound = value;
            }
        }

        public event EventHandler SampleChanged;

        public Button PlayStopButton
        {
            get
            {
                return playStop_Button;
            }
        }

        #endregion

        #region Private Properties

        private List<SoundId> mSoundIds;
        private SoundId mStartExtendSound;
        private SoundId mStopExtendSound;
        private SoundId mStartRetractSound;
        private SoundId mStopRetractSound;
        private SoundId mRunningSound;

        #endregion

        #region Constructor

        public PlatformSampleControl()
        {
            InitializeComponent();
            startExtend_ComboBox.SelectedIndexChanged += StartExtend_ComboBox_SelectedIndexChanged;
            stopExtend_ComboBox.SelectedIndexChanged += StopExtend_ComboBox_SelectedIndexChanged;
            startRetract_ComboBox.SelectedIndexChanged += StartRetract_ComboBox_SelectedIndexChanged;
            stopRetract_ComboBox.SelectedIndexChanged += StopRetract_ComboBox_SelectedIndexChanged;
            runningSound_ComboBox.SelectedIndexChanged += Running_ComboBox_SelectedIndexChanged;
        }

        #endregion

        #region Public Members

        public void PopulateSamples(List<SoundId> ids)
        {
            mSoundIds = ids;
            startExtend_ComboBox.DisplayMember = nameof(SoundId.Name);
            startExtend_ComboBox.DataSource = mSoundIds;
            stopExtend_ComboBox.DisplayMember = nameof(SoundId.Name);
            stopExtend_ComboBox.DataSource = mSoundIds;
            startRetract_ComboBox.DisplayMember = nameof(SoundId.Name);
            startRetract_ComboBox.DataSource = mSoundIds;
            stopRetract_ComboBox.DisplayMember = nameof(SoundId.Name);
            stopRetract_ComboBox.DataSource = mSoundIds;
            runningSound_ComboBox.DisplayMember = nameof(SoundId.Name);
            runningSound_ComboBox.DataSource = mSoundIds;
        }

        #endregion

        #region Control Callbacks

        private void StartExtend_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mStartExtendSound = startExtend_ComboBox.SelectedItem as SoundId;
            HandleSampleChanged();
        }

        private void StopExtend_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mStopExtendSound = stopExtend_ComboBox.SelectedItem as SoundId;
            HandleSampleChanged();
        }

        private void StartRetract_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mStartRetractSound = startRetract_ComboBox.SelectedItem as SoundId;
            HandleSampleChanged();
        }

        private void StopRetract_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mStopRetractSound = stopRetract_ComboBox.SelectedItem as SoundId;
            HandleSampleChanged();
        }

        private void Running_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mRunningSound = runningSound_ComboBox.SelectedItem as SoundId;
            HandleSampleChanged();
        }

        private void HandleSampleChanged()
        {
            EventHandler handler = SampleChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion

    }
}
