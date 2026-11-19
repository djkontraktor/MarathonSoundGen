using MarathonFileUtils.Sounds;
using System;
using System.Windows.Forms;

namespace MarathonSoundGen
{
    public partial class SoundSourceTabPage : TabPage
    {

        #region Public Properties

        public SoundSourcePotControl PotControl = new SoundSourcePotControl { Dock  = DockStyle.Fill };
        public SoundSourceSampleControl SampleControl = new SoundSourceSampleControl { Dock = DockStyle.Fill };
        public bool RandomChecked { get; private set; }
        public EventHandler SoundChanged;
        public EventHandler PlaybackToggled;

        #endregion

        #region Private Properties

        private SplitContainer master_SplitContainer = new SplitContainer
        {
            Dock = DockStyle.Fill,
            Orientation = Orientation.Horizontal,
            SplitterDistance = 30,
            IsSplitterFixed = true,
            FixedPanel = FixedPanel.Panel1
        };

        #endregion

        #region Constructor

        public SoundSourceTabPage()
        {
            InitializeComponent();

            this.Controls.Add(master_SplitContainer);
            master_SplitContainer.Panel1.Controls.Add(SampleControl);
            master_SplitContainer.Panel2.Controls.Add(PotControl);

            SampleControl.PopulateSamples(M2SoundIds.IDs);
            SampleControl.SoundSourceChanged += SampleControl_SoundSourceChanged;
            SampleControl.RandomCheckedChanged += SampleControl_RandomCheckedChanged;
            PotControl.SoundPropertyChanged += PotControl_SoundPropertyChanged;
            SampleControl.PlayStopButton.Click += PlayPauseButton_Click;
        }

        #endregion

        #region Control Callbacks

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

        private void SampleControl_RandomCheckedChanged(object sender, EventArgs e)
        {
            RandomChecked = SampleControl.IsRandom;
            HandleSoundPropertyChanged();
        }

        #endregion

        #region Private Members

        private void HandleSoundPropertyChanged()
        {
            EventHandler handler = SoundChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion

    }
}
