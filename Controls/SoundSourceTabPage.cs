using MarathonFileUtils.Sounds;
using MarathonSoundGen.Controls.Effects;
using MarathonSoundsPlayer;

namespace MarathonSoundGen.Controls
{
    public partial class SoundSourceTabPage : TabPage
    {

        #region Public Properties

        public SoundSourcePotControl PotControl = new SoundSourcePotControl { Dock = DockStyle.Fill };
        public SoundSourceSampleControl SampleControl = new SoundSourceSampleControl { Dock = DockStyle.Fill };
        public SoundSourceEffectsControl EffectsControl = new SoundSourceEffectsControl { Dock = DockStyle.Fill };
        public bool RandomChecked { get; private set; }
        public EventHandler SoundChanged;
        public EventHandler PlaybackToggled;

        #endregion

        #region Private Properties

        private SplitContainer upper_SplitContainer = new SplitContainer
        {
            Dock = DockStyle.Fill,
            Orientation = Orientation.Horizontal,
            SplitterDistance = 30,
            IsSplitterFixed = true,
            FixedPanel = FixedPanel.Panel1,
        };

        private SplitContainer lower_SplitContainer = new SplitContainer
        {
            Dock = DockStyle.Fill,
            Orientation = Orientation.Horizontal,
        };

        #endregion

        #region Constructor

        /// <summary>
        /// Make a new default tab page.
        /// </summary>
        public SoundSourceTabPage(SoundsFileFormat format)
        {
            ConstructBase(format);
        }

        /// <summary>
        /// Make a tab page from an existing sound source and set its properties.
        /// </summary>
        /// <param name="soundSource"></param>
        public SoundSourceTabPage(SoundSource soundSource)
        {
            ConstructBase(soundSource.Format);
            PopulateControls(soundSource);
        }

        private void ConstructBase(SoundsFileFormat format)
        {
            InitializeComponent();

            this.Controls.Add(upper_SplitContainer);
            upper_SplitContainer.Panel1.Controls.Add(SampleControl);
            upper_SplitContainer.Panel2.Controls.Add(lower_SplitContainer);
            lower_SplitContainer.Panel1.Controls.Add(PotControl);
            lower_SplitContainer.Panel2.Controls.Add(EffectsControl);

            switch (format)
            {
                case SoundsFileFormat.M1:
                    SampleControl.PopulateSamples(M1SoundIds.IDs);
                    break;
                case SoundsFileFormat.M2:
                    SampleControl.PopulateSamples(M2SoundIds.IDs);
                    break;
            }

            SampleControl.SoundSourceChanged += SampleControl_SoundSourceChanged;
            SampleControl.RandomCheckedChanged += SampleControl_RandomCheckedChanged;
            SampleControl.PlayStopButton.Click += PlayPauseButton_Click;
            PotControl.SoundPropertyChanged += PotControl_SoundPropertyChanged;
            EffectsControl.EffectChanged += EffectsControl_EffectChanged;
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

        private void EffectsControl_EffectChanged(object? sender, EventArgs e)
        {
            
        }

        #endregion

        #region Private Members

        private void PopulateControls(SoundSource soundSource)
        {
            SampleControl.SelectedId = soundSource.CurrentSound.ID;
            SampleControl.IsRandom = soundSource.SourceType.Equals(SoundSourceType.Random);
            PotControl.Volume = soundSource.Volume;
            PotControl.DeltaVolume = soundSource.RandomVolume;
            PotControl.DeltaVolumeOffset = soundSource.RandomVolumeOffset;
            PotControl.Pitch = soundSource.Pitch;
            PotControl.DeltaPitch = soundSource.RandomPitch;
            PotControl.DeltaPitchOffset = soundSource.RandomPitchOffset;
            PotControl.Pan = soundSource.Pan;
            PotControl.DeltaPan = soundSource.RandomPan;
            PotControl.DeltaPanOffset = soundSource.RandomPanOffset;
            PotControl.Frequency = soundSource.Frequency_Hz;
            PotControl.DeltaFrequency = soundSource.RandomFrequency_Hz;
            PotControl.DeltaFrequencyOffset = soundSource.RandomFrequencyOffset_Hz;
        }

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
