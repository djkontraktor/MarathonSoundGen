using MarathonFileUtils.Sounds;
using NAudio.Wave;

namespace MarathonSoundGen.Forms
{
    public partial class QuickAuditionForm : Form
    {

        #region Private Properties

        private int mSampleRate = 44100;
        private List<SndEntry> mSndEntries = new List<SndEntry>();
        private List<SoundDefinition> mDefinitions = new List<SoundDefinition>();
        private SoundDefinition mCurrentDef;
        private SoundPermutation mCurrentPerm;
        private WaveOut mOutputDevice;
        WaveFormat mFormat;
        private MemoryStream mSoundStream;
        private RawSourceWaveStream mRawStream;

        #endregion

        #region Constructor

        public QuickAuditionForm(List<SoundDefinition> definitions)
        {
            InitializeComponent();
            mDefinitions = definitions;

            List<SoundPermutation> perms = new List<SoundPermutation>();
            int defIndex = 0;

            while (perms.Count == 0)
            {
                mCurrentDef = mDefinitions[defIndex];
                perms = mCurrentDef.Permutations;

                if (perms.Count > 0)
                {
                    break;
                }

                defIndex++;
            }

            mCurrentPerm = mCurrentDef.Permutations.First();

            UpdateControls();
        }

        #endregion

        #region Control Callbacks

        private void nextClick(object sender, EventArgs e)
        {
            int curDef = mDefinitions.IndexOf(mCurrentDef);
            int curPrm = mCurrentDef.Permutations.IndexOf(mCurrentPerm);

            try
            {
                mCurrentPerm = mCurrentDef.Permutations[curPrm + 1];
            }
            catch (Exception ex)
            {
                try
                {
                    mCurrentDef = mDefinitions[curDef + 1];
                    mSndEntries.Add(new SndEntry { ID = mCurrentPerm.Definition.SoundCode, Index = mCurrentPerm.SoundIndex, Name = nameTextBox.Text.Trim(), SampleRate = (int)sampleRateNud.Value });
                }
                catch (Exception ex2)
                {
                    string generatedCsv = "Id,Index,Name,SampleRate\r\n";

                    foreach (SndEntry ent in mSndEntries)
                    {
                        generatedCsv += $"{ent.ID},{ent.Index},{ent.Name},{ent.SampleRate}\r\n";
                    }

                    using (Form popup = new Form())
                    using (TextBox textBox = new TextBox())
                    using (Button closeButton = new Button())
                    {
                        popup.Text = "Last one reached.";
                        popup.StartPosition = FormStartPosition.CenterParent;
                        popup.Size = new Size(700, 500);
                        popup.MinimumSize = new Size(400, 300);
                        popup.ShowInTaskbar = false;

                        textBox.Multiline = true;
                        textBox.ReadOnly = true;
                        textBox.ScrollBars = ScrollBars.Both;
                        textBox.WordWrap = false;
                        textBox.Dock = DockStyle.Fill;
                        textBox.Font = new Font("Consolas", 10.0f);
                        textBox.Text = generatedCsv ?? string.Empty;

                        closeButton.Text = "Close";
                        closeButton.Dock = DockStyle.Bottom;
                        closeButton.Height = 35;
                        closeButton.DialogResult = DialogResult.OK;

                        popup.Controls.Add(textBox);
                        popup.Controls.Add(closeButton);

                        popup.AcceptButton = closeButton;
                        popup.CancelButton = closeButton;

                        popup.Shown += delegate
                        {
                            textBox.Focus();
                            textBox.SelectAll();
                        };

                        popup.ShowDialog();
                    }

                    this.Close();
                }
            }

            UpdateControls();
        }

        private void hearItButtonClick(object sender, EventArgs e)
        {
            
            int channels = mCurrentPerm.Header.Stereo ? 2 : 1;

            mFormat = new WaveFormat(mSampleRate, mCurrentPerm.Header.BitsPerSample, channels);

            mSoundStream = new MemoryStream(mCurrentPerm.Data, false);
            mRawStream = new RawSourceWaveStream(mSoundStream, mFormat);

            mOutputDevice = new WaveOut();
            mOutputDevice.Init(mRawStream);
            mOutputDevice.Play();
        }

        private void sampleRateChanged(object sender, EventArgs e)
        {
            mSampleRate = (int)sampleRateNud.Value;
        }

        #endregion

        #region Private Members

        private void UpdateControls()
        {
            source_Txt.Text = mCurrentPerm.Source.ToString();
            Index_text.Text = mCurrentPerm.SoundIndex.ToString();
            bitDepth_Text.Text = mCurrentPerm.Header.BitsPerSample.ToString();
            stereo_txt.Text = mCurrentPerm.Header.Stereo.ToString();
            ID_txt.Text = mCurrentPerm.Definition.SoundCode.ToString();
            slotTxt.Text = (mCurrentPerm.Permutation + 1).ToString();
        }

        #endregion

        #region Classes

        private class SndEntry
        {
            public short ID { get; set; }
            public int Index { get; set; }
            public string Name { get; set; }
            public int SampleRate { get; set; }
        }

        #endregion

    }
}
