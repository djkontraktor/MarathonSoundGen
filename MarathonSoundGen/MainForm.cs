using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MarathonSoundGen
{
    public partial class MainForm : Form
    {
        private Dictionary<SoundSource, TabPage> mSoundSourcePages = new Dictionary<SoundSource, TabPage>();

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
            mSoundSourcePages.Add(new AmbientSoundSource(), new TabPage());
        }

        private void RemoveSoundSourceClick(object sender, EventArgs e)
        {

        }

        #endregion

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

    }
}
