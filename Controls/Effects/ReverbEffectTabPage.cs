using MarathonSoundsPlayer;

namespace MarathonSoundGen.Controls.Effects
{
    public partial class ReverbEffectTabPage : TabPage
    {

        #region Public Properties

        public EventHandler ControlChanged;

        #endregion

        #region Private Properties

        private TableLayoutPanel controls_Table = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 5,
            RowCount = 2,
        };

        #endregion

        #region Constructor

        /// <summary>
        /// Make a new default tab page.
        /// </summary>
        public ReverbEffectTabPage()
        {
            ConstructBase();
        }

        /// <summary>
        /// Make a tab page from an existing sound source and set its properties.
        /// </summary>
        /// <param name="soundSource"></param>
        public ReverbEffectTabPage(SoundSource soundSource)
        {
            ConstructBase();
            PopulateControls(soundSource);
        }

        private void ConstructBase()
        {
            InitializeComponent();
            controls_Table.RowStyles.Add(new RowStyle(SizeType.Percent));

            this.Controls.Add(controls_Table);
        }

        #endregion

        #region Control Callbacks



        #endregion

        #region Private Members

        private void PopulateControls(SoundSource soundSource)
        {
            //PotControl.Volume = soundSource.Volume;
            //PotControl.DeltaVolume = soundSource.RandomVolume;
            //PotControl.DeltaVolumeOffset = soundSource.RandomVolumeOffset;
            //PotControl.Pitch = soundSource.Pitch;
            //PotControl.DeltaPitch = soundSource.RandomPitch;
            //PotControl.DeltaPitchOffset = soundSource.RandomPitchOffset;
            //PotControl.Pan = soundSource.Pan;
            //PotControl.DeltaPan = soundSource.RandomPan;
            //PotControl.DeltaPanOffset = soundSource.RandomPanOffset;
            //PotControl.Frequency = soundSource.Frequency_Hz;
            //PotControl.DeltaFrequency = soundSource.RandomFrequency_Hz;
            //PotControl.DeltaFrequencyOffset = soundSource.RandomFrequencyOffset_Hz;
        }

        private void HandleSoundPropertyChanged()
        {
            EventHandler handler = ControlChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        #endregion

    }
}
