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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.file_dropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.loadSoundscapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSoundscapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMarathonSoundsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edit_dropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundScape_dropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.playAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSoundSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCurrentSoundSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentSoundFile_toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.soundSources_TabControl = new System.Windows.Forms.TabControl();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_dropDownButton,
            this.edit_dropDownButton,
            this.soundScape_dropDownButton,
            this.currentSoundFile_toolStripLabel});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(800, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // file_dropDownButton
            // 
            this.file_dropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.file_dropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSoundscapeToolStripMenuItem,
            this.saveSoundscapeToolStripMenuItem,
            this.loadMarathonSoundsFileToolStripMenuItem});
            this.file_dropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("file_dropDownButton.Image")));
            this.file_dropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.file_dropDownButton.Name = "file_dropDownButton";
            this.file_dropDownButton.Size = new System.Drawing.Size(38, 22);
            this.file_dropDownButton.Text = "File";
            // 
            // loadSoundscapeToolStripMenuItem
            // 
            this.loadSoundscapeToolStripMenuItem.Name = "loadSoundscapeToolStripMenuItem";
            this.loadSoundscapeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadSoundscapeToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.loadSoundscapeToolStripMenuItem.Text = "Load Soundscape";
            this.loadSoundscapeToolStripMenuItem.Click += new System.EventHandler(this.LoadSoundscapeFileClick);
            // 
            // saveSoundscapeToolStripMenuItem
            // 
            this.saveSoundscapeToolStripMenuItem.Name = "saveSoundscapeToolStripMenuItem";
            this.saveSoundscapeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveSoundscapeToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.saveSoundscapeToolStripMenuItem.Text = "Save Soundscape";
            this.saveSoundscapeToolStripMenuItem.Click += new System.EventHandler(this.SaveSoundscapeFileClick);
            // 
            // loadMarathonSoundsFileToolStripMenuItem
            // 
            this.loadMarathonSoundsFileToolStripMenuItem.Name = "loadMarathonSoundsFileToolStripMenuItem";
            this.loadMarathonSoundsFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadMarathonSoundsFileToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.loadMarathonSoundsFileToolStripMenuItem.Text = "Load Marathon Sounds File";
            this.loadMarathonSoundsFileToolStripMenuItem.Click += new System.EventHandler(this.loadMarathonSoundsFileToolStripMenuItem_Click);
            // 
            // edit_dropDownButton
            // 
            this.edit_dropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.edit_dropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.edit_dropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("edit_dropDownButton.Image")));
            this.edit_dropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.edit_dropDownButton.Name = "edit_dropDownButton";
            this.edit_dropDownButton.Size = new System.Drawing.Size(40, 22);
            this.edit_dropDownButton.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // soundScape_dropDownButton
            // 
            this.soundScape_dropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.soundScape_dropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playAllToolStripMenuItem,
            this.addSoundSourceToolStripMenuItem,
            this.removeCurrentSoundSourceToolStripMenuItem});
            this.soundScape_dropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("soundScape_dropDownButton.Image")));
            this.soundScape_dropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.soundScape_dropDownButton.Name = "soundScape_dropDownButton";
            this.soundScape_dropDownButton.Size = new System.Drawing.Size(85, 22);
            this.soundScape_dropDownButton.Text = "SoundScape";
            // 
            // playAllToolStripMenuItem
            // 
            this.playAllToolStripMenuItem.Name = "playAllToolStripMenuItem";
            this.playAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.playAllToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.playAllToolStripMenuItem.Text = "Play/Stop All Sound Sources";
            // 
            // addSoundSourceToolStripMenuItem
            // 
            this.addSoundSourceToolStripMenuItem.Name = "addSoundSourceToolStripMenuItem";
            this.addSoundSourceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.addSoundSourceToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.addSoundSourceToolStripMenuItem.Text = "Add Sound Source";
            this.addSoundSourceToolStripMenuItem.Click += new System.EventHandler(this.AddSoundSourceClick);
            // 
            // removeCurrentSoundSourceToolStripMenuItem
            // 
            this.removeCurrentSoundSourceToolStripMenuItem.Name = "removeCurrentSoundSourceToolStripMenuItem";
            this.removeCurrentSoundSourceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.removeCurrentSoundSourceToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.removeCurrentSoundSourceToolStripMenuItem.Text = "Remove Current Sound Source";
            this.removeCurrentSoundSourceToolStripMenuItem.Click += new System.EventHandler(this.RemoveSoundSourceClick);
            // 
            // currentSoundFile_toolStripLabel
            // 
            this.currentSoundFile_toolStripLabel.Name = "currentSoundFile_toolStripLabel";
            this.currentSoundFile_toolStripLabel.Size = new System.Drawing.Size(131, 22);
            this.currentSoundFile_toolStripLabel.Text = "No Sounds File Loaded.";
            this.currentSoundFile_toolStripLabel.ToolTipText = "Current Sounds File";
            // 
            // soundSources_TabControl
            // 
            this.soundSources_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soundSources_TabControl.Location = new System.Drawing.Point(0, 25);
            this.soundSources_TabControl.Multiline = true;
            this.soundSources_TabControl.Name = "soundSources_TabControl";
            this.soundSources_TabControl.SelectedIndex = 0;
            this.soundSources_TabControl.Size = new System.Drawing.Size(800, 425);
            this.soundSources_TabControl.TabIndex = 2;
            this.soundSources_TabControl.TabIndexChanged += new System.EventHandler(this.TabSwitched);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.soundSources_TabControl);
            this.Controls.Add(this.toolStrip);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marathon Sounds Generator v0.1";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton file_dropDownButton;
        private System.Windows.Forms.ToolStripMenuItem loadSoundscapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSoundscapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMarathonSoundsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton soundScape_dropDownButton;
        private System.Windows.Forms.ToolStripDropDownButton edit_dropDownButton;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel currentSoundFile_toolStripLabel;
        private System.Windows.Forms.TabControl soundSources_TabControl;
        private System.Windows.Forms.ToolStripMenuItem addSoundSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCurrentSoundSourceToolStripMenuItem;
    }
}

