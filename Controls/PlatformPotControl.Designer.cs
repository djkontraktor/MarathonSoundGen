namespace MarathonSoundGen.Controls
{
    partial class PlatformPotControl
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
            master_TableLayoutPanel = new TableLayoutPanel();
            extendVolume_Pot = new LabeledPot("Extend Volume");
            retractVolume_Pot = new LabeledPot("Retract Volume");
            extendedPan_Pot = new LabeledPot("Extended Pan");
            retractedPan_Pot = new LabeledPot("Retracted Pan");
            extendSpeed_Pot = new LabeledPot("Extend Speed (WU/s)");
            retractSpeed_Pot = new LabeledPot("Retract Speed (WU/s)");
            extendDelay_Pot = new LabeledPot("Extend Delay (s)");
            retractDelay_Pot = new LabeledPot("Retract Delay (s)");
            pitch_Pot = new LabeledPot("Pitch");
            distance_Pot = new LabeledPot("Distance (WU)");

            master_TableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // master_TableLayoutPanel
            // 
            master_TableLayoutPanel.ColumnCount = 3;
            master_TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            master_TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            master_TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            master_TableLayoutPanel.Controls.Add(extendVolume_Pot, 0, 0);
            master_TableLayoutPanel.Controls.Add(retractVolume_Pot, 1, 0);
            master_TableLayoutPanel.Controls.Add(extendedPan_Pot, 2, 0);
            master_TableLayoutPanel.Controls.Add(pitch_Pot, 0, 1);
            master_TableLayoutPanel.Controls.Add(retractDelay_Pot, 1, 1);
            master_TableLayoutPanel.Controls.Add(extendDelay_Pot, 2, 1);
            master_TableLayoutPanel.Controls.Add(retractedPan_Pot, 0, 2);
            master_TableLayoutPanel.Controls.Add(extendSpeed_Pot, 1, 2);
            master_TableLayoutPanel.Controls.Add(retractSpeed_Pot, 2, 2);
            master_TableLayoutPanel.Controls.Add(distance_Pot, 0, 3);
            master_TableLayoutPanel.Dock = DockStyle.Fill;
            master_TableLayoutPanel.Location = new Point(0, 0);
            master_TableLayoutPanel.Margin = new Padding(4, 3, 4, 3);
            master_TableLayoutPanel.Name = "master_TableLayoutPanel";
            master_TableLayoutPanel.RowCount = 4;
            master_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            master_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            master_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            master_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            master_TableLayoutPanel.Size = new Size(791, 617);
            master_TableLayoutPanel.TabIndex = 0;
            // 
            // extendVolume_Pot
            // 
            extendVolume_Pot.Dock = DockStyle.Fill;
            extendVolume_Pot.Location = new Point(5, 3);
            extendVolume_Pot.Margin = new Padding(5, 3, 5, 3);
            extendVolume_Pot.Name = "extendVolume_Pot";
            extendVolume_Pot.Size = new Size(253, 148);
            extendVolume_Pot.TabIndex = 3;
            extendVolume_Pot.Pot.ValueChanged += PotChanged;
            // 
            // retractVolume_Pot
            // 
            retractVolume_Pot.Dock = DockStyle.Fill;
            retractVolume_Pot.Location = new Point(268, 3);
            retractVolume_Pot.Margin = new Padding(5, 3, 5, 3);
            retractVolume_Pot.Name = "retractVolume_Pot";
            retractVolume_Pot.Size = new Size(253, 148);
            retractVolume_Pot.TabIndex = 4;
            retractVolume_Pot.Pot.ValueChanged += PotChanged;
            // 
            // extendedPan_Pot
            // 
            extendedPan_Pot.Dock = DockStyle.Fill;
            extendedPan_Pot.Location = new Point(531, 3);
            extendedPan_Pot.Margin = new Padding(5, 3, 5, 3);
            extendedPan_Pot.Name = "extendedPan_Pot";
            extendedPan_Pot.Size = new Size(255, 148);
            extendedPan_Pot.TabIndex = 5;
            extendedPan_Pot.Pot.ValueChanged += PotChanged;
            // 
            // pitch_Pot
            // 
            pitch_Pot.Dock = DockStyle.Fill;
            pitch_Pot.Location = new Point(5, 157);
            pitch_Pot.Margin = new Padding(5, 3, 5, 3);
            pitch_Pot.Name = "pitch_Pot";
            pitch_Pot.Size = new Size(253, 148);
            pitch_Pot.TabIndex = 4;
            pitch_Pot.Pot.ValueChanged += PotChanged;
            // 
            // retractDelay_Pot
            // 
            retractDelay_Pot.Dock = DockStyle.Fill;
            retractDelay_Pot.Location = new Point(268, 157);
            retractDelay_Pot.Margin = new Padding(5, 3, 5, 3);
            retractDelay_Pot.Name = "retractDelay_Pot";
            retractDelay_Pot.Size = new Size(253, 148);
            retractDelay_Pot.TabIndex = 5;
            retractDelay_Pot.Pot.ValueChanged += PotChanged;
            // 
            // extendDelay_Pot
            // 
            extendDelay_Pot.Dock = DockStyle.Fill;
            extendDelay_Pot.Location = new Point(531, 157);
            extendDelay_Pot.Margin = new Padding(5, 3, 5, 3);
            extendDelay_Pot.Name = "extendDelay_Pot";
            extendDelay_Pot.Size = new Size(255, 148);
            extendDelay_Pot.TabIndex = 6;
            extendDelay_Pot.Pot.ValueChanged += PotChanged;
            // 
            // retractedPan_Pot
            // 
            retractedPan_Pot.Dock = DockStyle.Fill;
            retractedPan_Pot.Location = new Point(5, 311);
            retractedPan_Pot.Margin = new Padding(5, 3, 5, 3);
            retractedPan_Pot.Name = "retractedPan_Pot";
            retractedPan_Pot.Size = new Size(253, 148);
            retractedPan_Pot.TabIndex = 3;
            retractedPan_Pot.Pot.ValueChanged += PotChanged;
            // 
            // extendSpeed_Pot
            // 
            extendSpeed_Pot.Dock = DockStyle.Fill;
            extendSpeed_Pot.Location = new Point(268, 311);
            extendSpeed_Pot.Margin = new Padding(5, 3, 5, 3);
            extendSpeed_Pot.Name = "extendSpeed_Pot";
            extendSpeed_Pot.Size = new Size(253, 148);
            extendSpeed_Pot.TabIndex = 4;
            extendSpeed_Pot.Pot.ValueChanged += PotChanged;
            // 
            // retractSpeed_Pot
            // 
            retractSpeed_Pot.Dock = DockStyle.Fill;
            retractSpeed_Pot.Location = new Point(531, 311);
            retractSpeed_Pot.Margin = new Padding(5, 3, 5, 3);
            retractSpeed_Pot.Name = "retractSpeed_Pot";
            retractSpeed_Pot.Size = new Size(255, 148);
            retractSpeed_Pot.TabIndex = 5;
            retractSpeed_Pot.Pot.ValueChanged += PotChanged;
            // 
            // distance_Pot
            // 
            distance_Pot.Dock = DockStyle.Fill;
            distance_Pot.Location = new Point(5, 465);
            distance_Pot.Margin = new Padding(5, 3, 5, 3);
            distance_Pot.Name = "distance_Pot";
            distance_Pot.Size = new Size(253, 149);
            distance_Pot.TabIndex = 3;
            distance_Pot.Pot.ValueChanged += PotChanged;
            // 
            // PlatformPotControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(master_TableLayoutPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "PlatformPotControl";
            Size = new Size(791, 617);
            master_TableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel master_TableLayoutPanel;
        private LabeledPot extendVolume_Pot;
        private LabeledPot retractVolume_Pot;
        private LabeledPot extendedPan_Pot;
        private LabeledPot retractedPan_Pot;
        private LabeledPot extendSpeed_Pot;
        private LabeledPot retractSpeed_Pot;
        private LabeledPot extendDelay_Pot;
        private LabeledPot retractDelay_Pot;
        private LabeledPot pitch_Pot;
        private LabeledPot distance_Pot;
    }
}
