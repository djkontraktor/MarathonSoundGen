namespace MarathonSoundGen
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadM2SoundFile_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loadM2SoundFile_Button
            // 
            this.loadM2SoundFile_Button.Location = new System.Drawing.Point(12, 12);
            this.loadM2SoundFile_Button.Name = "loadM2SoundFile_Button";
            this.loadM2SoundFile_Button.Size = new System.Drawing.Size(75, 23);
            this.loadM2SoundFile_Button.TabIndex = 0;
            this.loadM2SoundFile_Button.Text = "Load M2";
            this.loadM2SoundFile_Button.UseVisualStyleBackColor = true;
            this.loadM2SoundFile_Button.Click += new System.EventHandler(this.LoadM2SoundFile_ButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loadM2SoundFile_Button);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadM2SoundFile_Button;
    }
}

