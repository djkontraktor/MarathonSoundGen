namespace MarathonSoundGen.Controls
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
            this.frequency_Pot = new LabeledPot("Frequency (Hz)");
            this.deltaFrequency_Pot = new LabeledPot("Delta Frequency (Hz)");
            this.deltaFrequencyOffset_Pot = new LabeledPot("Delta Frequency Offset (Hz)");
            this.volume_Pot = new LabeledPot("Volume");
            this.deltaVolume_Pot = new LabeledPot("Delta Volume");
            this.deltaVolumeOffset_Pot = new LabeledPot("Delta Volume Offset");
            this.pan_Pot = new LabeledPot("Pan");
            this.deltaPan_Pot = new LabeledPot("Delta Pan");
            this.deltaPanOffset_Pot = new LabeledPot("Delta Pan Offset");
            this.deltaPitchOffset_Pot = new LabeledPot("Delta Pitch Offset");
            this.deltaPitch_Pot = new LabeledPot("Delta Pitch");
            this.pitch_Pot = new LabeledPot("Pitch");
            this.master_TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // master_TableLayoutPanel
            // 
            this.master_TableLayoutPanel.ColumnCount = 3;
            this.master_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.master_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.master_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.master_TableLayoutPanel.Controls.Add(this.volume_Pot, 0, 0);
            this.master_TableLayoutPanel.Controls.Add(this.deltaVolume_Pot, 1, 0);
            this.master_TableLayoutPanel.Controls.Add(this.deltaVolumeOffset_Pot, 2, 0);
            this.master_TableLayoutPanel.Controls.Add(this.pitch_Pot, 0, 1);
            this.master_TableLayoutPanel.Controls.Add(this.deltaPitch_Pot, 1, 1);
            this.master_TableLayoutPanel.Controls.Add(this.deltaPitchOffset_Pot, 2, 1);
            this.master_TableLayoutPanel.Controls.Add(this.pan_Pot, 0, 2);
            this.master_TableLayoutPanel.Controls.Add(this.deltaPan_Pot, 1, 2);
            this.master_TableLayoutPanel.Controls.Add(this.deltaPanOffset_Pot, 2, 2);
            this.master_TableLayoutPanel.Controls.Add(this.frequency_Pot, 0, 3);
            this.master_TableLayoutPanel.Controls.Add(this.deltaFrequency_Pot, 1, 3);
            this.master_TableLayoutPanel.Controls.Add(this.deltaFrequencyOffset_Pot, 1, 3);
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
            // SoundSourcePotControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.master_TableLayoutPanel);
            this.Name = "SoundSourcePotControl";
            this.Size = new System.Drawing.Size(678, 535);
            this.master_TableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel master_TableLayoutPanel;
        private LabeledPot volume_Pot;
        private LabeledPot deltaVolume_Pot;
        private LabeledPot deltaVolumeOffset_Pot;
        private LabeledPot pan_Pot;
        private LabeledPot deltaPan_Pot;
        private LabeledPot deltaPanOffset_Pot;
        private LabeledPot deltaPitchOffset_Pot;
        private LabeledPot deltaPitch_Pot;
        private LabeledPot pitch_Pot;
        private LabeledPot frequency_Pot;
        private LabeledPot deltaFrequency_Pot;
        private LabeledPot deltaFrequencyOffset_Pot;
    }
}
