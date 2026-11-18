namespace MarathonSoundGen
{
    partial class SoundSourceSampleControl
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
            this.slotName_Label = new System.Windows.Forms.Label();
            this.soundName_ComboBox = new System.Windows.Forms.ComboBox();
            this.properties_Label = new System.Windows.Forms.Label();
            this.properties_CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.master_TableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // master_TableLayoutPanel
            // 
            this.master_TableLayoutPanel.ColumnCount = 2;
            this.master_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.master_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.master_TableLayoutPanel.Controls.Add(this.slotName_Label, 0, 0);
            this.master_TableLayoutPanel.Controls.Add(this.soundName_ComboBox, 0, 1);
            this.master_TableLayoutPanel.Controls.Add(this.properties_Label, 1, 0);
            this.master_TableLayoutPanel.Controls.Add(this.properties_CheckedListBox, 1, 1);
            this.master_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.master_TableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.master_TableLayoutPanel.Name = "master_TableLayoutPanel";
            this.master_TableLayoutPanel.RowCount = 2;
            this.master_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.master_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.master_TableLayoutPanel.Size = new System.Drawing.Size(651, 57);
            this.master_TableLayoutPanel.TabIndex = 0;
            // 
            // slotName_Label
            // 
            this.slotName_Label.AutoSize = true;
            this.slotName_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slotName_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slotName_Label.Location = new System.Drawing.Point(3, 0);
            this.slotName_Label.Name = "slotName_Label";
            this.slotName_Label.Size = new System.Drawing.Size(319, 24);
            this.slotName_Label.TabIndex = 0;
            this.slotName_Label.Text = "Sound Name";
            this.slotName_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // soundName_ComboBox
            // 
            this.soundName_ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soundName_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.soundName_ComboBox.FormattingEnabled = true;
            this.soundName_ComboBox.Location = new System.Drawing.Point(3, 27);
            this.soundName_ComboBox.Name = "soundName_ComboBox";
            this.soundName_ComboBox.Size = new System.Drawing.Size(319, 21);
            this.soundName_ComboBox.TabIndex = 1;
            // 
            // properties_Label
            // 
            this.properties_Label.AutoSize = true;
            this.properties_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.properties_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.properties_Label.Location = new System.Drawing.Point(328, 0);
            this.properties_Label.Name = "properties_Label";
            this.properties_Label.Size = new System.Drawing.Size(320, 24);
            this.properties_Label.TabIndex = 2;
            this.properties_Label.Text = "Sound Properties";
            this.properties_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // properties_CheckedListBox
            // 
            this.properties_CheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.properties_CheckedListBox.FormattingEnabled = true;
            this.properties_CheckedListBox.Items.AddRange(new object[] {
            "Is Random"});
            this.properties_CheckedListBox.Location = new System.Drawing.Point(328, 27);
            this.properties_CheckedListBox.MultiColumn = true;
            this.properties_CheckedListBox.Name = "properties_CheckedListBox";
            this.properties_CheckedListBox.Size = new System.Drawing.Size(320, 96);
            this.properties_CheckedListBox.TabIndex = 3;
            this.properties_CheckedListBox.ThreeDCheckBoxes = true;
            // 
            // SoundSourceSampleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.master_TableLayoutPanel);
            this.Name = "SoundSourceSampleControl";
            this.Size = new System.Drawing.Size(651, 57);
            this.master_TableLayoutPanel.ResumeLayout(false);
            this.master_TableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel master_TableLayoutPanel;
        private System.Windows.Forms.Label slotName_Label;
        private System.Windows.Forms.ComboBox soundName_ComboBox;
        private System.Windows.Forms.Label properties_Label;
        private System.Windows.Forms.CheckedListBox properties_CheckedListBox;
    }
}
