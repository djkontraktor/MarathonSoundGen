namespace MarathonSoundGen
{
    partial class SoundSourcePotControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.master_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.frequency_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.frequency_Label = new System.Windows.Forms.Label();
            this.deltaFrequency_Label = new System.Windows.Forms.Label();
            this.deltaFrequencyOffset_Label = new System.Windows.Forms.Label();
            this.frequency_Pot = new LabeledPot();
            this.deltaFrequency_Pot = new LabeledPot();
            this.deltaFrequencyOffset_Pot = new LabeledPot();
            this.volume_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.volume_Label = new System.Windows.Forms.Label();
            this.deltaVolume_Label = new System.Windows.Forms.Label();
            this.deltaVolumeOffset_Label = new System.Windows.Forms.Label();
            this.volume_Pot = new LabeledPot();
            this.deltaVolume_Pot = new LabeledPot();
            this.deltaVolumeOffset_Pot = new LabeledPot();
            this.pan_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pan_Label = new System.Windows.Forms.Label();
            this.deltaPan_Label = new System.Windows.Forms.Label();
            this.deltaPanOffset_Label = new System.Windows.Forms.Label();
            this.pan_Pot = new LabeledPot();
            this.deltaPan_Pot = new LabeledPot();
            this.deltaPanOffset_Pot = new LabeledPot();
            this.pitch_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.deltaPitchOffset_Pot = new LabeledPot();
            this.deltaPitch_Pot = new LabeledPot();
            this.pitch_Pot = new LabeledPot();
            this.deltaPitchOffset_Label = new System.Windows.Forms.Label();
            this.deltaPitch_Label = new System.Windows.Forms.Label();
            this.pitch_Label = new System.Windows.Forms.Label();
            this.master_TableLayoutPanel.SuspendLayout();
            this.frequency_TableLayoutPanel.SuspendLayout();
            this.volume_TableLayoutPanel.SuspendLayout();
            this.pan_TableLayoutPanel.SuspendLayout();
            this.pitch_TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // master_TableLayoutPanel
            // 
            this.master_TableLayoutPanel.ColumnCount = 1;
            this.master_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.master_TableLayoutPanel.Controls.Add(this.frequency_TableLayoutPanel, 0, 3);
            this.master_TableLayoutPanel.Controls.Add(this.volume_TableLayoutPanel, 0, 0);
            this.master_TableLayoutPanel.Controls.Add(this.pan_TableLayoutPanel, 0, 2);
            this.master_TableLayoutPanel.Controls.Add(this.pitch_TableLayoutPanel, 0, 1);
            this.master_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.master_TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.master_TableLayoutPanel.Name = "master_TableLayoutPanel";
            this.master_TableLayoutPanel.RowCount = 4;
            this.master_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.master_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.master_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.master_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.master_TableLayoutPanel.Size = new System.Drawing.Size(678, 535);
            this.master_TableLayoutPanel.TabIndex = 0;
            // 
            // frequency_TableLayoutPanel
            // 
            this.frequency_TableLayoutPanel.ColumnCount = 3;
            this.frequency_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.frequency_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.frequency_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.frequency_TableLayoutPanel.Controls.Add(this.frequency_Label, 0, 0);
            this.frequency_TableLayoutPanel.Controls.Add(this.deltaFrequency_Label, 1, 0);
            this.frequency_TableLayoutPanel.Controls.Add(this.deltaFrequencyOffset_Label, 2, 0);
            this.frequency_TableLayoutPanel.Controls.Add(this.frequency_Pot, 0, 1);
            this.frequency_TableLayoutPanel.Controls.Add(this.deltaFrequency_Pot, 1, 1);
            this.frequency_TableLayoutPanel.Controls.Add(this.deltaFrequencyOffset_Pot, 2, 1);
            this.frequency_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frequency_TableLayoutPanel.Location = new System.Drawing.Point(3, 402);
            this.frequency_TableLayoutPanel.Name = "frequency_TableLayoutPanel";
            this.frequency_TableLayoutPanel.RowCount = 2;
            this.frequency_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.frequency_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.frequency_TableLayoutPanel.Size = new System.Drawing.Size(672, 130);
            this.frequency_TableLayoutPanel.TabIndex = 3;
            // 
            // frequency_Label
            // 
            this.frequency_Label.AutoSize = true;
            this.frequency_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frequency_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frequency_Label.Location = new System.Drawing.Point(3, 0);
            this.frequency_Label.Name = "frequency_Label";
            this.frequency_Label.Size = new System.Drawing.Size(218, 24);
            this.frequency_Label.TabIndex = 0;
            this.frequency_Label.Text = "Frequency (Hz)";
            this.frequency_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deltaFrequency_Label
            // 
            this.deltaFrequency_Label.AutoSize = true;
            this.deltaFrequency_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaFrequency_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaFrequency_Label.Location = new System.Drawing.Point(227, 0);
            this.deltaFrequency_Label.Name = "deltaFrequency_Label";
            this.deltaFrequency_Label.Size = new System.Drawing.Size(218, 24);
            this.deltaFrequency_Label.TabIndex = 1;
            this.deltaFrequency_Label.Text = "Delta Frequency";
            this.deltaFrequency_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deltaFrequencyOffset_Label
            // 
            this.deltaFrequencyOffset_Label.AutoSize = true;
            this.deltaFrequencyOffset_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaFrequencyOffset_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaFrequencyOffset_Label.Location = new System.Drawing.Point(451, 0);
            this.deltaFrequencyOffset_Label.Name = "deltaFrequencyOffset_Label";
            this.deltaFrequencyOffset_Label.Size = new System.Drawing.Size(218, 24);
            this.deltaFrequencyOffset_Label.TabIndex = 2;
            this.deltaFrequencyOffset_Label.Text = "Delta Frequency Offset";
            this.deltaFrequencyOffset_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frequency_Pot
            // 
            this.frequency_Pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frequency_Pot.Location = new System.Drawing.Point(3, 27);
            this.frequency_Pot.Pot.Maximum = 2D;
            this.frequency_Pot.Pot.Minimum = 0.01D;
            this.frequency_Pot.Name = "frequency_Pot";
            this.frequency_Pot.Size = new System.Drawing.Size(218, 100);
            this.frequency_Pot.TabIndex = 3;
            this.frequency_Pot.Pot.Value = 1D;
            this.frequency_Pot.Pot.ValueChanged += new System.EventHandler(this.PotChanged);
            // 
            // deltaFrequency_Pot
            // 
            this.deltaFrequency_Pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaFrequency_Pot.Location = new System.Drawing.Point(227, 27);
            this.deltaFrequency_Pot.Pot.Maximum = 2D;
            this.deltaFrequency_Pot.Pot.Minimum = -2D;
            this.deltaFrequency_Pot.Name = "deltaFrequency_Pot";
            this.deltaFrequency_Pot.Size = new System.Drawing.Size(218, 100);
            this.deltaFrequency_Pot.TabIndex = 4;
            this.deltaFrequency_Pot.Pot.Value = 0D;
            this.deltaFrequency_Pot.Pot.ValueChanged += new System.EventHandler(this.PotChanged);
            // 
            // deltaFrequencyOffset_Pot
            // 
            this.deltaFrequencyOffset_Pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaFrequencyOffset_Pot.Location = new System.Drawing.Point(451, 27);
            this.deltaFrequencyOffset_Pot.Pot.Maximum = 2D;
            this.deltaFrequencyOffset_Pot.Pot.Minimum = -2D;
            this.deltaFrequencyOffset_Pot.Name = "deltaFrequencyOffset_Pot";
            this.deltaFrequencyOffset_Pot.Size = new System.Drawing.Size(218, 100);
            this.deltaFrequencyOffset_Pot.TabIndex = 5;
            this.deltaFrequencyOffset_Pot.Pot.Value = 0D;
            this.deltaFrequencyOffset_Pot.Pot.ValueChanged += new System.EventHandler(this.PotChanged);
            // 
            // volume_TableLayoutPanel
            // 
            this.volume_TableLayoutPanel.ColumnCount = 3;
            this.volume_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.volume_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.volume_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.volume_TableLayoutPanel.Controls.Add(this.volume_Label, 0, 0);
            this.volume_TableLayoutPanel.Controls.Add(this.deltaVolume_Label, 1, 0);
            this.volume_TableLayoutPanel.Controls.Add(this.deltaVolumeOffset_Label, 2, 0);
            this.volume_TableLayoutPanel.Controls.Add(this.volume_Pot, 0, 1);
            this.volume_TableLayoutPanel.Controls.Add(this.deltaVolume_Pot, 1, 1);
            this.volume_TableLayoutPanel.Controls.Add(this.deltaVolumeOffset_Pot, 2, 1);
            this.volume_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volume_TableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.volume_TableLayoutPanel.Name = "volume_TableLayoutPanel";
            this.volume_TableLayoutPanel.RowCount = 2;
            this.volume_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.volume_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.volume_TableLayoutPanel.Size = new System.Drawing.Size(672, 127);
            this.volume_TableLayoutPanel.TabIndex = 0;
            // 
            // volume_Label
            // 
            this.volume_Label.AutoSize = true;
            this.volume_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volume_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volume_Label.Location = new System.Drawing.Point(3, 0);
            this.volume_Label.Name = "volume_Label";
            this.volume_Label.Size = new System.Drawing.Size(218, 24);
            this.volume_Label.TabIndex = 0;
            this.volume_Label.Text = "Volume";
            this.volume_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deltaVolume_Label
            // 
            this.deltaVolume_Label.AutoSize = true;
            this.deltaVolume_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaVolume_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaVolume_Label.Location = new System.Drawing.Point(227, 0);
            this.deltaVolume_Label.Name = "deltaVolume_Label";
            this.deltaVolume_Label.Size = new System.Drawing.Size(218, 24);
            this.deltaVolume_Label.TabIndex = 1;
            this.deltaVolume_Label.Text = "Delta Volume";
            this.deltaVolume_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deltaVolumeOffset_Label
            // 
            this.deltaVolumeOffset_Label.AutoSize = true;
            this.deltaVolumeOffset_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaVolumeOffset_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaVolumeOffset_Label.Location = new System.Drawing.Point(451, 0);
            this.deltaVolumeOffset_Label.Name = "deltaVolumeOffset_Label";
            this.deltaVolumeOffset_Label.Size = new System.Drawing.Size(218, 24);
            this.deltaVolumeOffset_Label.TabIndex = 2;
            this.deltaVolumeOffset_Label.Text = "Delta Volume Offset";
            this.deltaVolumeOffset_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // volume_Pot
            // 
            this.volume_Pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volume_Pot.Location = new System.Drawing.Point(3, 27);
            this.volume_Pot.Pot.Maximum = 1D;
            this.volume_Pot.Pot.Minimum = 0D;
            this.volume_Pot.Name = "volume_Pot";
            this.volume_Pot.Size = new System.Drawing.Size(218, 97);
            this.volume_Pot.TabIndex = 3;
            this.volume_Pot.Pot.Value = 1D;
            this.volume_Pot.Pot.ValueChanged += new System.EventHandler(this.PotChanged);
            // 
            // deltaVolume_Pot
            // 
            this.deltaVolume_Pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaVolume_Pot.Location = new System.Drawing.Point(227, 27);
            this.deltaVolume_Pot.Pot.Maximum = 1D;
            this.deltaVolume_Pot.Pot.Minimum = 0D;
            this.deltaVolume_Pot.Name = "deltaVolume_Pot";
            this.deltaVolume_Pot.Size = new System.Drawing.Size(218, 97);
            this.deltaVolume_Pot.TabIndex = 4;
            this.deltaVolume_Pot.Pot.Value = 0D;
            this.deltaVolume_Pot.Pot.ValueChanged += new System.EventHandler(this.PotChanged);
            // 
            // deltaVolumeOffset_Pot
            // 
            this.deltaVolumeOffset_Pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaVolumeOffset_Pot.Location = new System.Drawing.Point(451, 27);
            this.deltaVolumeOffset_Pot.Pot.Maximum = 1D;
            this.deltaVolumeOffset_Pot.Pot.Minimum = 0D;
            this.deltaVolumeOffset_Pot.Name = "deltaVolumeOffset_Pot";
            this.deltaVolumeOffset_Pot.Size = new System.Drawing.Size(218, 97);
            this.deltaVolumeOffset_Pot.TabIndex = 5;
            this.deltaVolumeOffset_Pot.Pot.Value = 0D;
            this.deltaVolumeOffset_Pot.Pot.ValueChanged += new System.EventHandler(this.PotChanged);
            // 
            // pan_TableLayoutPanel
            // 
            this.pan_TableLayoutPanel.ColumnCount = 3;
            this.pan_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pan_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pan_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pan_TableLayoutPanel.Controls.Add(this.pan_Label, 0, 0);
            this.pan_TableLayoutPanel.Controls.Add(this.deltaPan_Label, 1, 0);
            this.pan_TableLayoutPanel.Controls.Add(this.deltaPanOffset_Label, 2, 0);
            this.pan_TableLayoutPanel.Controls.Add(this.pan_Pot, 0, 1);
            this.pan_TableLayoutPanel.Controls.Add(this.deltaPan_Pot, 1, 1);
            this.pan_TableLayoutPanel.Controls.Add(this.deltaPanOffset_Pot, 2, 1);
            this.pan_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_TableLayoutPanel.Location = new System.Drawing.Point(3, 269);
            this.pan_TableLayoutPanel.Name = "pan_TableLayoutPanel";
            this.pan_TableLayoutPanel.RowCount = 2;
            this.pan_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pan_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pan_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pan_TableLayoutPanel.Size = new System.Drawing.Size(672, 127);
            this.pan_TableLayoutPanel.TabIndex = 1;
            // 
            // pan_Label
            // 
            this.pan_Label.AutoSize = true;
            this.pan_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pan_Label.Location = new System.Drawing.Point(3, 0);
            this.pan_Label.Name = "pan_Label";
            this.pan_Label.Size = new System.Drawing.Size(218, 24);
            this.pan_Label.TabIndex = 0;
            this.pan_Label.Text = "Pan";
            this.pan_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deltaPan_Label
            // 
            this.deltaPan_Label.AutoSize = true;
            this.deltaPan_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaPan_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaPan_Label.Location = new System.Drawing.Point(227, 0);
            this.deltaPan_Label.Name = "deltaPan_Label";
            this.deltaPan_Label.Size = new System.Drawing.Size(218, 24);
            this.deltaPan_Label.TabIndex = 1;
            this.deltaPan_Label.Text = "Delta Pan";
            this.deltaPan_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deltaPanOffset_Label
            // 
            this.deltaPanOffset_Label.AutoSize = true;
            this.deltaPanOffset_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaPanOffset_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaPanOffset_Label.Location = new System.Drawing.Point(451, 0);
            this.deltaPanOffset_Label.Name = "deltaPanOffset_Label";
            this.deltaPanOffset_Label.Size = new System.Drawing.Size(218, 24);
            this.deltaPanOffset_Label.TabIndex = 2;
            this.deltaPanOffset_Label.Text = "Delta Pan Offset";
            this.deltaPanOffset_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pan_Pot
            // 
            this.pan_Pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_Pot.Location = new System.Drawing.Point(3, 27);
            this.pan_Pot.Pot.Maximum = 1D;
            this.pan_Pot.Pot.Minimum = -1D;
            this.pan_Pot.Name = "pan_Pot";
            this.pan_Pot.Size = new System.Drawing.Size(218, 97);
            this.pan_Pot.TabIndex = 3;
            this.pan_Pot.Pot.Value = 0D;
            this.pan_Pot.Pot.ValueChanged += new System.EventHandler(this.PotChanged);
            // 
            // deltaPan_Pot
            // 
            this.deltaPan_Pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaPan_Pot.Location = new System.Drawing.Point(227, 27);
            this.deltaPan_Pot.Pot.Maximum = 1D;
            this.deltaPan_Pot.Pot.Minimum = -1D;
            this.deltaPan_Pot.Name = "deltaPan_Pot";
            this.deltaPan_Pot.Size = new System.Drawing.Size(218, 97);
            this.deltaPan_Pot.TabIndex = 4;
            this.deltaPan_Pot.Pot.Value = 0D;
            this.deltaPan_Pot.Pot.ValueChanged += new System.EventHandler(this.PotChanged);
            // 
            // deltaPanOffset_Pot
            // 
            this.deltaPanOffset_Pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaPanOffset_Pot.Location = new System.Drawing.Point(451, 27);
            this.deltaPanOffset_Pot.Pot.Maximum = 1D;
            this.deltaPanOffset_Pot.Pot.Minimum = -1D;
            this.deltaPanOffset_Pot.Name = "deltaPanOffset_Pot";
            this.deltaPanOffset_Pot.Size = new System.Drawing.Size(218, 97);
            this.deltaPanOffset_Pot.TabIndex = 5;
            this.deltaPanOffset_Pot.Pot.Value = 0D;
            this.deltaPanOffset_Pot.Pot.ValueChanged += new System.EventHandler(this.PotChanged);
            // 
            // pitch_TableLayoutPanel
            // 
            this.pitch_TableLayoutPanel.ColumnCount = 3;
            this.pitch_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pitch_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pitch_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pitch_TableLayoutPanel.Controls.Add(this.deltaPitchOffset_Pot, 2, 1);
            this.pitch_TableLayoutPanel.Controls.Add(this.deltaPitch_Pot, 1, 1);
            this.pitch_TableLayoutPanel.Controls.Add(this.pitch_Pot, 0, 1);
            this.pitch_TableLayoutPanel.Controls.Add(this.deltaPitchOffset_Label, 2, 0);
            this.pitch_TableLayoutPanel.Controls.Add(this.deltaPitch_Label, 1, 0);
            this.pitch_TableLayoutPanel.Controls.Add(this.pitch_Label, 0, 0);
            this.pitch_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pitch_TableLayoutPanel.Location = new System.Drawing.Point(3, 136);
            this.pitch_TableLayoutPanel.Name = "pitch_TableLayoutPanel";
            this.pitch_TableLayoutPanel.RowCount = 2;
            this.pitch_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pitch_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pitch_TableLayoutPanel.Size = new System.Drawing.Size(672, 127);
            this.pitch_TableLayoutPanel.TabIndex = 2;
            // 
            // deltaPitchOffset_Pot
            // 
            this.deltaPitchOffset_Pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaPitchOffset_Pot.Location = new System.Drawing.Point(451, 66);
            this.deltaPitchOffset_Pot.Pot.Maximum = 5D;
            this.deltaPitchOffset_Pot.Pot.Minimum = -5D;
            this.deltaPitchOffset_Pot.Name = "deltaPitchOffset_Pot";
            this.deltaPitchOffset_Pot.Size = new System.Drawing.Size(218, 58);
            this.deltaPitchOffset_Pot.TabIndex = 6;
            this.deltaPitchOffset_Pot.Pot.Value = 0D;
            this.deltaPitchOffset_Pot.Pot.ValueChanged += new System.EventHandler(this.PotChanged);
            // 
            // deltaPitch_Pot
            // 
            this.deltaPitch_Pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaPitch_Pot.Location = new System.Drawing.Point(227, 66);
            this.deltaPitch_Pot.Pot.Maximum = 5D;
            this.deltaPitch_Pot.Pot.Minimum = -5D;
            this.deltaPitch_Pot.Name = "deltaPitch_Pot";
            this.deltaPitch_Pot.Size = new System.Drawing.Size(218, 58);
            this.deltaPitch_Pot.TabIndex = 5;
            this.deltaPitch_Pot.Pot.Value = 0D;
            this.deltaPitch_Pot.Pot.ValueChanged += new System.EventHandler(this.PotChanged);
            // 
            // pitch_Pot
            // 
            this.pitch_Pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pitch_Pot.Location = new System.Drawing.Point(3, 66);
            this.pitch_Pot.Pot.Maximum = 5D;
            this.pitch_Pot.Pot.Minimum = 0D;
            this.pitch_Pot.Name = "pitch_Pot";
            this.pitch_Pot.Size = new System.Drawing.Size(218, 58);
            this.pitch_Pot.TabIndex = 4;
            this.pitch_Pot.Pot.Value = 1D;
            this.pitch_Pot.Pot.ValueChanged += new System.EventHandler(this.PotChanged);
            // 
            // deltaPitchOffset_Label
            // 
            this.deltaPitchOffset_Label.AutoSize = true;
            this.deltaPitchOffset_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaPitchOffset_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaPitchOffset_Label.Location = new System.Drawing.Point(451, 0);
            this.deltaPitchOffset_Label.Name = "deltaPitchOffset_Label";
            this.deltaPitchOffset_Label.Size = new System.Drawing.Size(218, 63);
            this.deltaPitchOffset_Label.TabIndex = 3;
            this.deltaPitchOffset_Label.Text = "Delta Pitch Offset";
            this.deltaPitchOffset_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deltaPitch_Label
            // 
            this.deltaPitch_Label.AutoSize = true;
            this.deltaPitch_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deltaPitch_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deltaPitch_Label.Location = new System.Drawing.Point(227, 0);
            this.deltaPitch_Label.Name = "deltaPitch_Label";
            this.deltaPitch_Label.Size = new System.Drawing.Size(218, 63);
            this.deltaPitch_Label.TabIndex = 2;
            this.deltaPitch_Label.Text = "Delta Pitch";
            this.deltaPitch_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pitch_Label
            // 
            this.pitch_Label.AutoSize = true;
            this.pitch_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pitch_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pitch_Label.Location = new System.Drawing.Point(3, 0);
            this.pitch_Label.Name = "pitch_Label";
            this.pitch_Label.Size = new System.Drawing.Size(218, 63);
            this.pitch_Label.TabIndex = 1;
            this.pitch_Label.Text = "Pitch";
            this.pitch_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SoundSourcePotControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.master_TableLayoutPanel);
            this.Name = "SoundSourcePotControl";
            this.Size = new System.Drawing.Size(678, 535);
            this.master_TableLayoutPanel.ResumeLayout(false);
            this.frequency_TableLayoutPanel.ResumeLayout(false);
            this.frequency_TableLayoutPanel.PerformLayout();
            this.volume_TableLayoutPanel.ResumeLayout(false);
            this.volume_TableLayoutPanel.PerformLayout();
            this.pan_TableLayoutPanel.ResumeLayout(false);
            this.pan_TableLayoutPanel.PerformLayout();
            this.pitch_TableLayoutPanel.ResumeLayout(false);
            this.pitch_TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel master_TableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel volume_TableLayoutPanel;
        private System.Windows.Forms.Label volume_Label;
        private System.Windows.Forms.Label deltaVolume_Label;
        private System.Windows.Forms.Label deltaVolumeOffset_Label;
        private LabeledPot volume_Pot;
        private LabeledPot deltaVolume_Pot;
        private LabeledPot deltaVolumeOffset_Pot;
        private System.Windows.Forms.TableLayoutPanel pan_TableLayoutPanel;
        private System.Windows.Forms.Label pan_Label;
        private System.Windows.Forms.Label deltaPan_Label;
        private System.Windows.Forms.Label deltaPanOffset_Label;
        private LabeledPot pan_Pot;
        private LabeledPot deltaPan_Pot;
        private LabeledPot deltaPanOffset_Pot;
        private System.Windows.Forms.TableLayoutPanel pitch_TableLayoutPanel;
        private System.Windows.Forms.Label pitch_Label;
        private System.Windows.Forms.Label deltaPitchOffset_Label;
        private System.Windows.Forms.Label deltaPitch_Label;
        private LabeledPot deltaPitchOffset_Pot;
        private LabeledPot deltaPitch_Pot;
        private LabeledPot pitch_Pot;
        private System.Windows.Forms.TableLayoutPanel frequency_TableLayoutPanel;
        private System.Windows.Forms.Label frequency_Label;
        private System.Windows.Forms.Label deltaFrequency_Label;
        private System.Windows.Forms.Label deltaFrequencyOffset_Label;
        private LabeledPot frequency_Pot;
        private LabeledPot deltaFrequency_Pot;
        private LabeledPot deltaFrequencyOffset_Pot;
    }
}
