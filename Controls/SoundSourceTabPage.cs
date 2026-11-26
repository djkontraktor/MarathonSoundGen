using MarathonFileUtils.Sounds;
using MarathonFileUtils.Sounds.SoundIds;
using MarathonSoundGen.Controls.Effects;
using MarathonSoundsPlayer;
using MarathonSoundsPlayer.SoundBehavior;

namespace MarathonSoundGen.Controls
{
    public class SoundSourceTabPage : TabPage
    {

        #region Public Properties

        public SoundSourcePotControl PotControl = new SoundSourcePotControl { Dock = DockStyle.Fill };
        public PlatformPotControl PlatPotControl = new PlatformPotControl { Dock = DockStyle.Fill };
        public SoundSourceSampleControl SampleControl = new SoundSourceSampleControl { Dock = DockStyle.Fill };
        public PlatformSampleControl PlatSampleControl = new PlatformSampleControl { Dock = DockStyle.Fill };
        public SoundSourceEffectsControl EffectsControl = new SoundSourceEffectsControl { Dock = DockStyle.Fill };
        public bool RandomChecked { get; private set; }
        public EventHandler SoundPropertyChanged;
        public EventHandler SampleChanged;
        public EventHandler PlaybackToggled;

        #endregion

        #region Private Properties

        private SplitContainer upper_SplitContainer = new SplitContainer
        {
            Dock = DockStyle.Fill,
            Orientation = Orientation.Horizontal,
            //SplitterDistance = 30,
            //IsSplitterFixed = true,
            //FixedPanel = FixedPanel.Panel1,
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
        public SoundSourceTabPage(SoundsFileFormat format, SoundSourceType type)
        {
            switch (type)
            {
                case SoundSourceType.Ambient:
                case SoundSourceType.Random:

                    ConstructEnvironmental(format);

                    break;
                case SoundSourceType.Platform:

                    ConstructPlatform(format);

                    break;
            }
        }

        /// <summary>
        /// Make a tab page from an existing sound source and set its properties.
        /// </summary>
        /// <param name="soundSource"></param>
        public SoundSourceTabPage(SoundSource soundSource, SoundSourceType type)
        {
            switch (type)
            {
                case SoundSourceType.Ambient:
                case SoundSourceType.Random:

                    ConstructEnvironmental(soundSource.SoundBehavior.Format);
                    PopulateControls(soundSource, type);

                    break;
                case SoundSourceType.Platform:

                    ConstructPlatform(soundSource.SoundBehavior.Format);
                    PopulateControls(soundSource, type);

                    break;
            }
        }

        private void ConstructEnvironmental(SoundsFileFormat format)
        {
            this.Controls.Add(upper_SplitContainer);
            upper_SplitContainer.Panel1.Controls.Add(SampleControl);
            upper_SplitContainer.Panel2.Controls.Add(lower_SplitContainer);
            lower_SplitContainer.Panel1.Controls.Add(PotControl);
            lower_SplitContainer.Panel2.Controls.Add(EffectsControl);

            switch (format)
            {
                case SoundsFileFormat.M1:
                    SampleControl.PopulateSamples(SoundIdLoader.Marathon1SoundIds);
                    break;
                case SoundsFileFormat.M2:
                    SampleControl.PopulateSamples(SoundIdLoader.Marathon2SoundIds);
                    break;
                case SoundsFileFormat.Rubicon:
                    SampleControl.PopulateSamples(SoundIdLoader.RubiconSoundIds);
                    break;
            }

            SampleControl.SampleChanged += SampleControl_SampleChanged;
            SampleControl.RandomCheckedChanged += SampleControl_RandomCheckedChanged;
            SampleControl.PlayStopButton.Click += PlayPauseButton_Click;
            PotControl.SoundPropertyChanged += PotControl_SoundPropertyChanged;
            EffectsControl.EffectChanged += EffectsControl_EffectChanged;
        }

        private void ConstructPlatform(SoundsFileFormat format)
        {
            this.Controls.Add(upper_SplitContainer);
            upper_SplitContainer.Panel1.Controls.Add(PlatSampleControl);
            upper_SplitContainer.Panel2.Controls.Add(lower_SplitContainer);
            lower_SplitContainer.Panel1.Controls.Add(PlatPotControl);
            lower_SplitContainer.Panel2.Controls.Add(EffectsControl);

            switch (format)
            {
                case SoundsFileFormat.M1:
                    PlatSampleControl.PopulateSamples(SoundIdLoader.Marathon1SoundIds);
                    break;
                case SoundsFileFormat.M2:
                    PlatSampleControl.PopulateSamples(SoundIdLoader.Marathon2SoundIds);
                    break;
                case SoundsFileFormat.Rubicon:
                    PlatSampleControl.PopulateSamples(SoundIdLoader.RubiconSoundIds);
                    break;
            }

            PlatSampleControl.SampleChanged += PlatSampleControl_SampleChanged;
            PlatSampleControl.PlayStopButton.Click += PlayPauseButton_Click;
            PlatPotControl.SoundPropertyChanged += PotControl_SoundPropertyChanged;
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

        private void SampleControl_SampleChanged(object sender, EventArgs e)
        {
            this.Text = SampleControl.SelectedId.Name;
            HandleSampleChanged();
        }

        private void PlatSampleControl_SampleChanged(object sender, EventArgs e)
        {
            this.Text = PlatSampleControl.StartExtendSound.Name;
            HandleSampleChanged();
        }

        private void SampleControl_RandomCheckedChanged(object sender, EventArgs e)
        {
            RandomChecked = SampleControl.IsRandom;
            HandleSoundPropertyChanged();
        }

        private void EffectsControl_EffectChanged(object? sender, EventArgs e)
        {
            HandleSoundPropertyChanged();
        }

        #endregion

        #region Private Members

        private void PopulateControls(SoundSource soundSource, SoundSourceType type)
        {
            switch (type)
            {
                case SoundSourceType.Ambient:
                case SoundSourceType.Random:

                    //SampleControl.SelectedId = soundSource.SoundBehavior.CurrentSound.ID;
                    SampleControl.IsRandom = soundSource.SoundBehavior is RandomSoundBehavior;
                    PotControl.Volume = soundSource.SoundBehavior.Volume;
                    PotControl.DeltaVolume = soundSource.SoundBehavior.RandomVolume;
                    PotControl.DeltaVolumeOffset = soundSource.SoundBehavior.RandomVolumeOffset;
                    PotControl.Pitch = soundSource.SoundBehavior.Pitch;
                    PotControl.DeltaPitch = soundSource.SoundBehavior.RandomPitch;
                    PotControl.DeltaPitchOffset = soundSource.SoundBehavior.RandomPitchOffset;
                    PotControl.Pan = soundSource.SoundBehavior.Pan;
                    PotControl.DeltaPan = soundSource.SoundBehavior.RandomPan;
                    PotControl.DeltaPanOffset = soundSource.SoundBehavior.RandomPanOffset;
                    PotControl.Frequency = soundSource.SoundBehavior.Frequency_Hz;
                    PotControl.DeltaFrequency = soundSource.SoundBehavior.RandomFrequency_Hz;
                    PotControl.DeltaFrequencyOffset = soundSource.SoundBehavior.RandomFrequencyOffset_Hz;

                    break;
                case SoundSourceType.Platform:

                    PlatPotControl.Pitch = soundSource.SoundBehavior.Pitch;
                    PlatPotControl.ExtendedVolume = soundSource.SoundBehavior.ExtendedVolume;
                    PlatPotControl.RetractedVolume = soundSource.SoundBehavior.RetractedVolume;
                    PlatPotControl.ExtendedPan = soundSource.SoundBehavior.ExtendedPan;
                    PlatPotControl.RetractedPan = soundSource.SoundBehavior.RetractedPan;
                    PlatPotControl.ExtendSpeed_WU_s = soundSource.SoundBehavior.ExtendSpeed_WU_s;
                    PlatPotControl.RetractSpeed_WU_s = soundSource.SoundBehavior.RetractSpeed_WU_s;
                    PlatPotControl.ExtendDelay_s = soundSource.SoundBehavior.ExtendDelay_s;
                    PlatPotControl.RetractDelay_s = soundSource.SoundBehavior.RetractDelay_s;
                    PlatPotControl.Distance_WU = soundSource.SoundBehavior.Distance_WU;

                    break;
            }
        }

        private void HandleSoundPropertyChanged()
        {
            EventHandler handler = SoundPropertyChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
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
