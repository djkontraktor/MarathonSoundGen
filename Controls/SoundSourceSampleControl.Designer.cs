namespace MarathonSoundGen.Controls
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
            this.soundName_ComboBox = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.soundSource_Label = new System.Windows.Forms.Label();
            this.playStop_Button = new System.Windows.Forms.Button();
            this.random_CheckBox = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // soundName_ComboBox
            // 
            this.soundName_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.soundName_ComboBox.FormattingEnabled = true;
            this.soundName_ComboBox.Location = new System.Drawing.Point(81, 3);
            this.soundName_ComboBox.Name = "soundName_ComboBox";
            this.soundName_ComboBox.Size = new System.Drawing.Size(227, 21);
            this.soundName_ComboBox.TabIndex = 1;
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.Controls.Add(this.soundSource_Label);
            this.flowLayoutPanel.Controls.Add(this.soundName_ComboBox);
            this.flowLayoutPanel.Controls.Add(this.playStop_Button);
            this.flowLayoutPanel.Controls.Add(this.random_CheckBox);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(640, 57);
            this.flowLayoutPanel.TabIndex = 1;
            // 
            // soundSource_Label
            // 
            this.soundSource_Label.AutoSize = true;
            this.soundSource_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soundSource_Label.Location = new System.Drawing.Point(3, 0);
            this.soundSource_Label.Name = "soundSource_Label";
            this.soundSource_Label.Size = new System.Drawing.Size(72, 29);
            this.soundSource_Label.TabIndex = 2;
            this.soundSource_Label.Text = "Sound Name:";
            this.soundSource_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // playStop_Button
            // 
            this.playStop_Button.Location = new System.Drawing.Point(314, 3);
            this.playStop_Button.Name = "playStop_Button";
            this.playStop_Button.Size = new System.Drawing.Size(75, 23);
            this.playStop_Button.TabIndex = 3;
            this.playStop_Button.Text = "Play/Stop";
            this.playStop_Button.UseVisualStyleBackColor = true;
            // 
            // random_CheckBox
            // 
            this.random_CheckBox.AutoSize = true;
            this.random_CheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.random_CheckBox.Location = new System.Drawing.Point(395, 3);
            this.random_CheckBox.Name = "random_CheckBox";
            this.random_CheckBox.Size = new System.Drawing.Size(144, 23);
            this.random_CheckBox.TabIndex = 4;
            this.random_CheckBox.Text = "Play As Random Sound?";
            this.random_CheckBox.UseVisualStyleBackColor = true;
            this.random_CheckBox.CheckedChanged += new System.EventHandler(this.RandomCheckChanged);
            // 
            // SoundSourceSampleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "SoundSourceSampleControl";
            this.Size = new System.Drawing.Size(640, 57);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox soundName_ComboBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Label soundSource_Label;
        private System.Windows.Forms.Button playStop_Button;
        private System.Windows.Forms.CheckBox random_CheckBox;
    }
}
