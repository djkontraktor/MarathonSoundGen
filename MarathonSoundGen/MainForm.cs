using System;
using System.IO;
using System.Windows.Forms;

namespace MarathonSoundGen
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose all
        }

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
