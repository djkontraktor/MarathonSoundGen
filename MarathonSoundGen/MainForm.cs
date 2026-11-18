using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MarathonSoundGen
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadM2SoundFile_ButtonClick(object sender, EventArgs e)
        {
            string filePath = PromptSelectSoundFile();
            List<MaraSoundDefinition> soundsFile = SoundsUtils.OpenM2SoundFile(filePath);

            SoundsUtils.StartAudioStreamer();

            foreach (MaraSoundDefinition soundSlot in soundsFile)
            {
                foreach (MaraSoundPermutation sound in soundSlot.Permutations)
                {
                    SoundsUtils.PlaySound(sound.Data, sound.Header);
                }
            }

            SoundsUtils.StopAudioStreamer();
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

    }
}
