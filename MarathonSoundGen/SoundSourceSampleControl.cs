using MarathonFileUtils.Sounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MarathonSoundGen
{
    public partial class SoundSourceSampleControl : UserControl
    {

        #region Public Properties

        public SoundId SelectedId
        {
            get
            {
                return mSelectedId;
            }
            set
            {
                SoundId matchingSoundId = soundName_ComboBox.Items.Cast<SoundId>().FirstOrDefault(s => s.Id == value.Id);
                soundName_ComboBox.SelectedItem = matchingSoundId;
                mSelectedId = value;
            }
        }

        public bool IsRandom
        {
            get
            {
                return mIsRandom;
            }
            set
            {
                random_CheckBox.Checked = value;
            }
        }

        public event EventHandler SoundSourceChanged;
        public event EventHandler RandomCheckedChanged;

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
        private SoundId mSelectedId;
        private bool mIsRandom;

        #endregion

        #region Constructor

        public SoundSourceSampleControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Members

        public void PopulateSamples(List<SoundId> ids)
        {
            mSoundIds = ids;
            soundName_ComboBox.DisplayMember = nameof(SoundId.Name);
            soundName_ComboBox.DataSource = mSoundIds;
            soundName_ComboBox.SelectedIndexChanged += SoundName_ComboBox_SelectedIndexChanged;
        }

        #endregion

        #region Control Callbacks

        private void SoundName_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mSelectedId = soundName_ComboBox.SelectedItem as SoundId;

            EventHandler handler = SoundSourceChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void RandomCheckChanged(object sender, EventArgs e)
        {
            mIsRandom = random_CheckBox.Checked;

            EventHandler handler = RandomCheckedChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion

    }
}
