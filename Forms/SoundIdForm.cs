using MarathonFileUtils.Sounds.DataStructures;
using NAudio.Wave;
using System.ComponentModel;
using System.Text;

namespace MarathonSoundGen.Forms
{
    public partial class SoundIdForm : Form
    {

        #region Private Properties

        private readonly BindingSource mPermutationBindingSource = new BindingSource();
        private BindingList<PermutationGridRow> mPermutationRows;
        private DataGridViewButtonColumn mPlayColumn;
        private List<SoundDefinition> mDefinitions = new List<SoundDefinition>();
        private WaveOut mOutputDevice;
        WaveFormat mFormat;
        private MemoryStream mSoundStream;
        private RawSourceWaveStream mRawStream;

        #endregion

        #region Constructor

        public SoundIdForm(List<SoundDefinition> definitions)
        {
            InitializeComponent();
            mDefinitions = definitions;
            ConfigureSoundGrid();
            SetSoundEntries(mDefinitions);
        }

        #endregion

        #region Control Callbacks

        private void SoundDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex != mPlayColumn.Index)
            {
                return;
            }

            DataGridViewRow gridRow = sounds_DataGridView.Rows[e.RowIndex];

            PermutationGridRow row = gridRow.DataBoundItem as PermutationGridRow;

            if (row == null)
            {
                return;
            }

            PlayPermutation(row.Definition, row.Permutation, row.SampleRate);
        }

        private void PlayPermutation(SoundDefinition soundEntry, SoundPermutation permutation, int sampleRate)
        {
            int channels = permutation.Header.Stereo ? 2 : 1;

            mFormat = new WaveFormat(sampleRate, permutation.Header.BitsPerSample, channels);

            mSoundStream = new MemoryStream(permutation.Data, false);
            mRawStream = new RawSourceWaveStream(mSoundStream, mFormat);

            mOutputDevice = new WaveOut();
            mOutputDevice.Init(mRawStream);
            mOutputDevice.Play();
        }

        private void SoundDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            DataGridViewColumn changedColumn = sounds_DataGridView.Columns[e.ColumnIndex];

            if (changedColumn.Name != "SampleRateColumn")
            {
                return;
            }

            PermutationGridRow row = sounds_DataGridView.Rows[e.RowIndex].DataBoundItem as PermutationGridRow;

            if (row == null)
            {
                return;
            }
        }

        private void CsvGenerateClick(object sender, EventArgs e)
        {
            // Commit the value still being edited in the current cell.
            sounds_DataGridView.EndEdit();

            if (sounds_DataGridView.DataSource is BindingSource bindingSource)
            {
                bindingSource.EndEdit();
            }

            StringBuilder csv = new StringBuilder();

            // Write column headers, excluding button columns.
            bool firstColumn = true;
            csv.Append("Id,Index,Name,SampleRate\r\n");

            foreach (DataGridViewRow row in sounds_DataGridView.Rows)
            {
                // Ignore the blank "new row", if enabled.
                if (row.IsNewRow)
                {
                    continue;
                }

                firstColumn = true;

                foreach (DataGridViewColumn column in sounds_DataGridView.Columns)
                {
                    if (!column.Visible || !(column is DataGridViewTextBoxColumn) || column.Name.Equals("BitDepthColumn"))
                    {
                        continue;
                    }

                    if (!firstColumn)
                    {
                        csv.Append(',');
                    }

                    object value = row.Cells[column.Index].Value;
                    csv.Append(EscapeCsvValue(value));
                    firstColumn = false;
                }

                csv.Append("\r\n");
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
                textBox.Text = csv.ToString() ?? string.Empty;

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

        #endregion

        #region Private Members

        public void SetSoundEntries(IEnumerable<SoundDefinition> soundEntries)
        {
            IEnumerable<SoundDefinition> safeEntries = soundEntries ?? Enumerable.Empty<SoundDefinition>();

            List<PermutationGridRow> rows = safeEntries
                .Where(soundEntry => soundEntry != null)
                .SelectMany(soundEntry => (soundEntry.Permutations ?? new List<SoundPermutation>())
                .Where(permutation => permutation != null)
                .Select(permutation => new PermutationGridRow( soundEntry, permutation)))
                .ToList();

            mPermutationRows = new BindingList<PermutationGridRow>(rows);
            mPermutationBindingSource.DataSource = mPermutationRows;
            sounds_DataGridView.DataSource = mPermutationBindingSource;
        }

        private void ConfigureSoundGrid()
        {
            sounds_DataGridView.AutoGenerateColumns = false;
            sounds_DataGridView.AllowUserToAddRows = false;
            sounds_DataGridView.AllowUserToDeleteRows = false;
            sounds_DataGridView.MultiSelect = false;
            sounds_DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            sounds_DataGridView.Columns.Clear();

            mPlayColumn = new DataGridViewButtonColumn
            {
                Name = "PlayColumn",
                HeaderText = "",
                Text = "Play",
                UseColumnTextForButtonValue = true,
                ReadOnly = true,
                Width = 60
            };

            sounds_DataGridView.Columns.Add(mPlayColumn);

            sounds_DataGridView.Columns.Add(
                CreateTextColumn(
                    "CodeColumn",
                    "ID",
                    nameof(PermutationGridRow.ID),
                    true));

            sounds_DataGridView.Columns.Add(
                CreateTextColumn(
                    "IndexColumn",
                    "Index",
                    nameof(PermutationGridRow.Index),
                    true));

            sounds_DataGridView.Columns.Add(
                CreateTextColumn(
                    "BitDepthColumn",
                    "Bit Depth",
                    nameof(PermutationGridRow.BitDepth),
                    true));

            sounds_DataGridView.Columns.Add(
                CreateTextColumn(
                    "NameColumn",
                    "Name",
                    nameof(PermutationGridRow.Name),
                    false));

            DataGridViewTextBoxColumn sampleRateColumn =
                CreateTextColumn(
                    "SampleRateColumn",
                    "Sample Rate (Hz)",
                    nameof(PermutationGridRow.SampleRate),
                    false);

            sampleRateColumn.ValueType = typeof(int);
            sounds_DataGridView.Columns.Add(sampleRateColumn);

            sounds_DataGridView.Columns.Add(
                new DataGridViewCheckBoxColumn
                {
                    Name = "StereoColumn",
                    HeaderText = "Stereo",
                    DataPropertyName =
                        nameof(PermutationGridRow.Stereo),
                    ReadOnly = true,
                    ValueType = typeof(bool),
                    Width = 60
                });

            sounds_DataGridView.DataSource = mPermutationBindingSource;
            sounds_DataGridView.CellContentClick += SoundDataGridView_CellContentClick;
            sounds_DataGridView.CellValueChanged += SoundDataGridView_CellValueChanged;
            sounds_DataGridView.DataError += SoundDataGridView_DataError;
        }

        private static DataGridViewTextBoxColumn CreateTextColumn(string name, string headerText, string propertyName, bool readOnly)
        {
            return new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = headerText,
                DataPropertyName = propertyName,
                ReadOnly = readOnly,
                SortMode = DataGridViewColumnSortMode.Automatic
            };
        }

        private void SoundDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            if (sounds_DataGridView.Columns[e.ColumnIndex].Name == "SampleRateColumn")
            {
                MessageBox.Show("Sample Rate must be a valid whole number.", "Invalid Sample Rate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.ThrowException = false;
                e.Cancel = true;
            }
        }

        private static string EscapeCsvValue(object value)
        {
            if (value == null || value == DBNull.Value)
            {
                return string.Empty;
            }

            string text = Convert.ToString(value) ?? string.Empty;

            // Quotes inside CSV fields are represented by two quotes.
            bool requiresQuotes =
                text.IndexOf(',') >= 0 ||
                text.IndexOf('"') >= 0 ||
                text.IndexOf('\r') >= 0 ||
                text.IndexOf('\n') >= 0;

            if (text.IndexOf('"') >= 0)
            {
                text = text.Replace("\"", "\"\"");
            }

            if (requiresQuotes)
            {
                text = "\"" + text + "\"";
            }

            return text;
        }

        #endregion

        #region Classes

        private class PermutationGridRow
        {
            public SoundDefinition Definition { get; private set; }

            public SoundPermutation Permutation { get; private set; }

            private int mSampleRate = 22050;
            private string mName = string.Empty;

            public PermutationGridRow(SoundDefinition definition, SoundPermutation permutation)
            {
                Definition = definition;
                Permutation = permutation;
            }

            public short ID
            {
                get { return Permutation.Definition.SoundCode; }
            }

            public int Index
            {
                get { return Permutation.SoundIndex; }
            }

            public int BitDepth
            {
                get { return Permutation.Header.BitsPerSample; }
            }

            public int SampleRate
            {
                get { return mSampleRate; }
                set { mSampleRate = value; }
            }

            public bool Stereo
            {
                get { return Permutation.Header.Stereo; }
            }

            public string Name
            {
                get { return mName; }
                set { mName = value; }
            }
        }

        #endregion

    }
}
