using MarathonFileUtils.Sounds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MarathonSoundGen
{
    public partial class MainForm : Form
    {

        #region Private Properties

        private Dictionary<TabPage, SoundSource> mSoundSourcePages = new Dictionary<TabPage, SoundSource>();
        private TabPage mSelectedPage;

        #endregion

        #region Form Lifecycle

        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SoundEngine.DisposeAllSources();
        }

        #endregion

        #region Control Callbacks

        private void loadMarathonSoundsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = PromptSelectSoundFile();

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                SoundEngine.LoadSoundsFile(filePath);
                currentSoundFile_toolStripLabel.Text = filePath;
            }
        }

        private void AddSoundSourceClick(object sender, EventArgs e)
        {
            if (SoundEngine.SoundsFileLoaded)
            {
                SoundSlot firstSlot = SoundEngine.SoundsFile.SoundSlots.First();
                SoundSourceTabPage tabPage = new SoundSourceTabPage { Text = firstSlot.ID.Name };
                tabPage.SoundChanged += TabPageSoundChanged;
                tabPage.PlaybackToggled += PlaybackToggled;
                mSoundSourcePages.Add(tabPage, new AmbientSoundSource(firstSlot, 1, 0, 0, 1, 0, 0, 0, 0, 0));
                UpdateControls();
            }
            else
            {
                ShowLoadSoundsFileErrorDialog();
            }
        }

        private void TabPageSoundChanged(object sender, EventArgs e)
        {
            SoundSourceTabPage page = sender as SoundSourceTabPage;
            mSoundSourcePages[page].Volume = page.PotControl.Volume;
            mSoundSourcePages[page].RandomVolume = page.PotControl.DeltaVolume;
            mSoundSourcePages[page].RandomVolumeOffset = page.PotControl.DeltaVolumeOffset;
            mSoundSourcePages[page].Pitch = page.PotControl.Pitch;
            mSoundSourcePages[page].RandomPitch = page.PotControl.DeltaPitch;
            mSoundSourcePages[page].RandomPitchOffset = page.PotControl.DeltaPitchOffset;
            mSoundSourcePages[page].Pan = page.PotControl.Pan;
            mSoundSourcePages[page].RandomPan = page.PotControl.DeltaPan;
            mSoundSourcePages[page].RandomPanOffset = page.PotControl.DeltaPanOffset;
            //mSoundSourcePages[page].Frequency = page.PotControl.Frequency;
            //mSoundSourcePages[page].RandomFrequency = page.PotControl.DeltaFrequency;
            //mSoundSourcePages[page].RandomFrequencyOffset = page.PotControl.DeltaFrequencyOffset;
            mSoundSourcePages[page].SoundSlot = SoundEngine.SoundsFile.SoundSlots.Where(s => s.ID == page.SampleControl.SelectedId).First();
        }

        private void PlaybackToggled(object sender, EventArgs e)
        {
            if (SoundEngine.SoundsFileLoaded)
            {
                SoundSourceTabPage page = sender as SoundSourceTabPage;

                if (mSoundSourcePages[page].IsPlaying)
                {
                    mSoundSourcePages[page].Stop();
                }
                else
                {
                    mSoundSourcePages[page].Start();
                }
            }
            else
            {
                ShowLoadSoundsFileErrorDialog();
            }
        }

        private void RemoveSoundSourceClick(object sender, EventArgs e)
        {
            mSoundSourcePages.Remove(mSelectedPage);
            UpdateControls();
        }

        private void TabSwitched(object sender, EventArgs e)
        {
            mSelectedPage = this.soundSources_TabControl.SelectedTab;
        }

        #endregion

        #region Private Methods

        private void UpdateControls()
        {
            this.soundSources_TabControl.TabPages.Clear();

            foreach (SoundSourceTabPage page in mSoundSourcePages.Keys)
            {
                this.soundSources_TabControl.TabPages.Add(page);
            }
        }

        private static string PromptSelectSoundFile()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select Sound File";

                // The dialog may display .sndA and extensionless files.
                dialog.Filter = "Sound files (*.sndA; extensionless)|*.sndA;*.|sndA files (*.sndA)|*.sndA|All files (*.*)|*.*";

                dialog.FilterIndex = 1;
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.Multiselect = false;
                dialog.AddExtension = false;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return string.Empty;
                }

                string fullPath = Path.GetFullPath(dialog.FileName);

                // Accept only .sndA or extensionless files.
                string extension = Path.GetExtension(fullPath);

                if (string.IsNullOrEmpty(extension) || extension.Equals(".sndA", System.StringComparison.OrdinalIgnoreCase))
                {
                    return fullPath;
                }

                return string.Empty;
            }
        }

        private static void ShowLoadSoundsFileErrorDialog()
        {
            MessageBox.Show("No sounds file is loaded. Please load a Marathon sounds file or Aleph One .sndA file first.", "No Sounds File Loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

    }
}
