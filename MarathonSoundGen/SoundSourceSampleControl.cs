using MarathonFileUtils.Sounds;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarathonSoundGen
{
    public partial class SoundSourceSampleControl : UserControl
    {
        public SoundId SelectedId { get; private set; }
        public event EventHandler SoundSourceChanged;

        private List<SoundId> mSoundIds;

        public SoundSourceSampleControl()
        {
            InitializeComponent();
        }

        public void PopulateSamples(List<SoundId> ids)
        {
            mSoundIds = ids;
            soundName_ComboBox.DisplayMember = nameof(SoundId.Name);
            soundName_ComboBox.DataSource = mSoundIds;
            soundName_ComboBox.SelectedIndexChanged += SoundName_ComboBox_SelectedIndexChanged;
        }

        private void SoundName_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedId = soundName_ComboBox.SelectedItem as SoundId;

            EventHandler handler = SoundSourceChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
