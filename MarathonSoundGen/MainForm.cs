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

        #region Public Properties

        public Dictionary<TabPage, SoundSource> SoundSourcePages = new Dictionary<TabPage, SoundSource>();

        #endregion

        #region Private Properties

        private readonly SoundEngine mSoundEngine;
        
        private TabPage mSelectedPage;

        #endregion

        #region Form Lifecycle

        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
            mSoundEngine = new SoundEngine(44100, 50);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mSoundEngine.Dispose();
        }

        #endregion

        #region Control Callbacks

        private void LoadSoundscapeFileClick(object sender, EventArgs e)
        {
            string filePath = PromptSelectSoundscapeFile();

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                List<SoundSource> soundSources = mSoundEngine.LoadFromFile(filePath, out string soundsFilePath);

                foreach (SoundSource soundSource in soundSources)
                {
                    SoundSourceTabPage tabPage = new SoundSourceTabPage(soundSource);
                    tabPage.SoundChanged += TabPageSoundChanged;
                    tabPage.PlaybackToggled += PlaybackToggled;
                    SoundSourcePages.Add(tabPage, soundSource);
                }

                UpdateControls();
            }
        }

        private void SaveSoundscapeFileClick(object sender, EventArgs e)
        {
            string filePath = PromptSaveSoundscapeFile();

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                mSoundEngine.SaveToFile(filePath, SoundSourcePages.Values.ToList());
            }
        }

        private void loadMarathonSoundsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = PromptSelectSoundFile();

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                mSoundEngine.LoadSoundsFile(filePath);
                currentSoundFile_toolStripLabel.Text = filePath;
            }
        }

        private void AddSoundSourceClick(object sender, EventArgs e)
        {
            if (mSoundEngine.SoundsFileLoaded)
            {
                SoundSlot firstSlot = mSoundEngine.SoundsFile.SoundSlots.First();
                SoundSourceTabPage tabPage = new SoundSourceTabPage { Text = firstSlot.ID.Name };
                tabPage.SoundChanged += TabPageSoundChanged;
                tabPage.PlaybackToggled += PlaybackToggled;
                SoundSourcePages.Add(tabPage, new SoundSource(SoundSourceType.Ambient, mSoundEngine, firstSlot, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0));
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
            SoundSource source = SoundSourcePages[page];
            source.SourceType = page.RandomChecked ? SoundSourceType.Random : SoundSourceType.Ambient;
            source.Volume = page.PotControl.Volume;
            source.RandomVolume = page.PotControl.DeltaVolume;
            source.RandomVolumeOffset = page.PotControl.DeltaVolumeOffset;
            source.Pitch = page.PotControl.Pitch;
            source.RandomPitch = page.PotControl.DeltaPitch;
            source.RandomPitchOffset = page.PotControl.DeltaPitchOffset;
            source.Pan = page.PotControl.Pan;
            source.RandomPan = page.PotControl.DeltaPan;
            source.RandomPanOffset = page.PotControl.DeltaPanOffset;
            source.Frequency_Hz = page.PotControl.Frequency;
            source.RandomFrequency_Hz = page.PotControl.DeltaFrequency;
            source.RandomFrequencyOffset_Hz = page.PotControl.DeltaFrequencyOffset;

            try
            {
                source.CurrentSound = mSoundEngine.SoundsFile.SoundSlots.Where(s => s.ID == page.SampleControl.SelectedId).First();
            }
            catch (Exception ex)
            {

            }
        }

        private void PlaybackToggled(object sender, EventArgs e)
        {
            if (mSoundEngine.SoundsFileLoaded)
            {
                SoundSourceTabPage page = sender as SoundSourceTabPage;

                if (SoundSourcePages[page].Playing)
                {
                    SoundSourcePages[page].Stop();
                }
                else
                {
                    SoundSourcePages[page].Start();
                }
            }
            else
            {
                ShowLoadSoundsFileErrorDialog();
            }
        }

        private void RemoveSoundSourceClick(object sender, EventArgs e)
        {
            SoundSourcePages.Remove(mSelectedPage);
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

            foreach (SoundSourceTabPage page in SoundSourcePages.Keys)
            {
                this.soundSources_TabControl.TabPages.Add(page);
            }
        }

        private static string PromptSelectSoundFile()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Open Marathon Sounds File";

                // The dialog may display .sndA and extensionless files.
                dialog.Filter = "Aleph One Format (*.sndA)|*.sndA|Marathon Format (*.*)|*.*";

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

        private static string PromptSelectSoundscapeFile()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Open Soundscape File";

                // The dialog may display .sndA and extensionless files.
                dialog.Filter = "Soundscape files (*.soundscape)|*.soundscape;*.|All files (*.*)|*.*";

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

                if (string.IsNullOrEmpty(extension) || extension.Equals(".soundscape", System.StringComparison.OrdinalIgnoreCase))
                {
                    return fullPath;
                }

                return string.Empty;
            }
        }

        private static string PromptSaveSoundscapeFile()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Save Soundscape File";
                dialog.Filter = "Soundscape files (*.soundscape)|*.soundscape";
                dialog.DefaultExt = "soundscape";
                dialog.AddExtension = true;
                dialog.OverwritePrompt = true;
                dialog.CheckPathExists = true;
                dialog.FileName = "mysoundscape.soundscape";

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return string.Empty;
                }

                string fullPath = Path.GetFullPath(dialog.FileName);

                if (!string.Equals(Path.GetExtension(fullPath), ".soundscape", System.StringComparison.OrdinalIgnoreCase))
                {
                    fullPath += ".soundscape";
                }

                return fullPath;
            }
        }

        private static void ShowLoadSoundsFileErrorDialog()
        {
            MessageBox.Show("No sounds file is loaded. Please load a classic Macintosh-formatted Marathon sounds file or Aleph One .sndA file first.", "No Sounds File Loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

    }
}
