using MarathonFileUtils.Sounds;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarathonSoundGen
{
    public partial class SoundSourceSampleControl : UserControl
    {

        #region Public Properties

        public SoundId SelectedId { get; private set; }
        public event EventHandler SoundSourceChanged;
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
            SelectedId = soundName_ComboBox.SelectedItem as SoundId;

            EventHandler handler = SoundSourceChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion

    }
}
