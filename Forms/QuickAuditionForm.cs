using MarathonFileUtils.Sounds;
using NAudio.Wave;

namespace MarathonSoundGen.Forms
{
    public partial class QuickAuditionForm : Form
    {
        private int mSampleRate = 44100;
        private List<SndEntry> mSndEntries = new List<SndEntry>();
        private List<SoundDefinition> mDefinitions = new List<SoundDefinition>();
        private SoundDefinition mCurrentDef;
        private SoundPermutation mCurrentPerm;

        public QuickAuditionForm(List<SoundDefinition> definitions)
        {
            InitializeComponent();
            mDefinitions = definitions;
            mCurrentDef = mDefinitions.First();
            mCurrentPerm = mCurrentDef.Permutations.First();
            UpdateControls();
        }

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
                    string generatedCode =
                        "public static List<SoundId> IDs = new List<SoundId>\r\n" +
                        "{\r\n";

                    foreach (SndEntry ent in mSndEntries)
                    {
                        generatedCode += $"\tnew SoundId({ent.ID}, {ent.Index}, \"{ent.Name}\"), // Sample rate: {ent.SampleRate}\r\n";
                    }

                    generatedCode += "};\r\n";

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
                        textBox.Text = generatedCode ?? string.Empty;

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
                }
            }

            UpdateControls();
        }

        private void hearItButtonClick(object sender, EventArgs e)
        {
            WaveOut outputDevice;
            int channels = mCurrentPerm.Header.Stereo ? 2 : 1;

            WaveFormat format = new WaveFormat(mSampleRate, mCurrentPerm.Header.BitsPerSample, channels);

            using (MemoryStream soundStream = new MemoryStream(mCurrentPerm.Data, false))
            using (RawSourceWaveStream rawStream = new RawSourceWaveStream(soundStream, format))
            using (LoopStream loopStream = new LoopStream(rawStream))
            {
                outputDevice = new WaveOut();
                outputDevice.Init(loopStream);
                outputDevice.Play();
            }
        }

        private void UpdateControls()
        {
            source_Txt.Text = mCurrentPerm.Source.ToString();
            Index_text.Text = mCurrentPerm.SoundIndex.ToString();
            bitDepth_Text.Text = mCurrentPerm.Header.BitsPerSample.ToString();
            stereo_txt.Text = mCurrentPerm.Header.Stereo.ToString();
            ID_txt.Text = mCurrentPerm.Definition.SoundCode.ToString();
            slotTxt.Text = (mCurrentPerm.Permutation + 1).ToString();
        }

        private class SndEntry
        {
            public short ID { get; set; }
            public int Index { get; set; }
            public string Name { get; set; }
            public int SampleRate { get; set; }
        }

        private void sampleRateChanged(object sender, EventArgs e)
        {
            mSampleRate = (int)sampleRateNud.Value;
        }

        private sealed class LoopStream : WaveStream
        {
            private readonly WaveStream mSourceStream;

            public LoopStream(WaveStream sourceStream)
            {
                if (sourceStream == null)
                    throw new ArgumentNullException(nameof(sourceStream));

                if (!sourceStream.CanSeek)
                {
                    throw new ArgumentException(
                        "The source stream must support seeking.",
                        nameof(sourceStream));
                }

                mSourceStream = sourceStream;
            }

            public override WaveFormat WaveFormat
            {
                get { return mSourceStream.WaveFormat; }
            }

            public override long Length
            {
                get { return long.MaxValue; }
            }

            public override long Position
            {
                get { return mSourceStream.Position; }
                set { mSourceStream.Position = value; }
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                int totalBytesRead = 0;

                while (totalBytesRead < count)
                {
                    int bytesRead = mSourceStream.Read(
                        buffer,
                        offset + totalBytesRead,
                        count - totalBytesRead);

                    if (bytesRead == 0)
                    {
                        mSourceStream.Position = 0;
                        continue;
                    }

                    totalBytesRead += bytesRead;
                }

                return totalBytesRead;
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                    mSourceStream.Dispose();

                base.Dispose(disposing);
            }
        }
    }
}
