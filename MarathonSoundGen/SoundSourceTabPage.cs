using MarathonFileUtils.Sounds;
using System;
using System.Windows.Forms;

namespace MarathonSoundGen
{
    public partial class SoundSourceTabPage : TabPage
    {
        public SoundSourcePotControl PotControl = new SoundSourcePotControl();
        public SoundSourceSampleControl SampleControl = new SoundSourceSampleControl();
        public EventHandler SoundChanged;
        public EventHandler PlaybackToggled;

        private FlowLayoutPanel mControlPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
        };
        private Button mPlayPauseButton = new Button { Text = "Play/Pause" };

        public SoundSourceTabPage()
        {
            InitializeComponent();

            this.Controls.Add(mControlPanel);
            mControlPanel.Controls.Add(PotControl);
            mControlPanel.Controls.Add(SampleControl);
            mControlPanel.Controls.Add(mPlayPauseButton);

            SampleControl.PopulateSamples(M2SoundIds.IDs);
            SampleControl.SoundSourceChanged += SampleControl_SoundSourceChanged;
            PotControl.SoundPropertyChanged += PotControl_SoundPropertyChanged;
            mPlayPauseButton.Click += PlayPauseButton_Click;
        }

        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            EventHandler handler = PlaybackToggled;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void PotControl_SoundPropertyChanged(object sender, EventArgs e)
        {
            HandleSoundPropertyChanged();
        }

        private void SampleControl_SoundSourceChanged(object sender, EventArgs e)
        {
            this.Text = SampleControl.SelectedId.Name;
            HandleSoundPropertyChanged();
        }

        private void HandleSoundPropertyChanged()
        {
            EventHandler handler = SoundChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
