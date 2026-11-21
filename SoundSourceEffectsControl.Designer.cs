namespace MarathonSoundGen
{
    partial class SoundSourceEffectsControl
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
            effects_TabControl = new TabControl();
            SuspendLayout();
            // 
            // effects_TabControl
            // 
            effects_TabControl.Dock = DockStyle.Fill;
            effects_TabControl.Location = new Point(0, 0);
            effects_TabControl.Name = "effects_TabControl";
            effects_TabControl.SelectedIndex = 0;
            effects_TabControl.Size = new Size(795, 360);
            effects_TabControl.TabIndex = 0;
            // 
            // SoundSourceEffectsControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(effects_TabControl);
            Name = "SoundSourceEffectsControl";
            Size = new Size(795, 360);
            ResumeLayout(false);
        }

        #endregion

        private TabControl effects_TabControl;
    }
}
