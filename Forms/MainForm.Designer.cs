namespace MarathonSoundGen.Forms
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
            toolStrip = new ToolStrip();
            file_dropDownButton = new ToolStripDropDownButton();
            loadSoundscapeToolStripMenuItem = new ToolStripMenuItem();
            saveSoundscapeToolStripMenuItem = new ToolStripMenuItem();
            loadMarathonSoundsFileToolStripMenuItem = new ToolStripMenuItem();
            edit_dropDownButton = new ToolStripDropDownButton();
            undoToolStripMenuItem = new ToolStripMenuItem();
            redoToolStripMenuItem = new ToolStripMenuItem();
            soundScape_dropDownButton = new ToolStripDropDownButton();
            playAllToolStripMenuItem = new ToolStripMenuItem();
            addSoundSourceToolStripMenuItem = new ToolStripMenuItem();
            removeCurrentSoundSourceToolStripMenuItem = new ToolStripMenuItem();
            addEffectToolStripMenuItem = new ToolStripMenuItem();
            reverbToolStripMenuItem = new ToolStripMenuItem();
            convolutionReverbToolStripMenuItem = new ToolStripMenuItem();
            delayToolStripMenuItem = new ToolStripMenuItem();
            chorusToolStripMenuItem = new ToolStripMenuItem();
            compressorToolStripMenuItem = new ToolStripMenuItem();
            autoGainControlToolStripMenuItem = new ToolStripMenuItem();
            bitcrusherToolStripMenuItem = new ToolStripMenuItem();
            cabinetToolStripMenuItem = new ToolStripMenuItem();
            dCBlockerToolStripMenuItem = new ToolStripMenuItem();
            deEsserToolStripMenuItem = new ToolStripMenuItem();
            comfortNoiseToolStripMenuItem = new ToolStripMenuItem();
            equalizerToolStripMenuItem = new ToolStripMenuItem();
            feedbackDelayToolStripMenuItem = new ToolStripMenuItem();
            flangerToolStripMenuItem = new ToolStripMenuItem();
            gateToolStripMenuItem = new ToolStripMenuItem();
            limiterToolStripMenuItem = new ToolStripMenuItem();
            multibandCompressorToolStripMenuItem = new ToolStripMenuItem();
            noiseSuppressionToolStripMenuItem = new ToolStripMenuItem();
            phaserToolStripMenuItem = new ToolStripMenuItem();
            saturationToolStripMenuItem = new ToolStripMenuItem();
            stereoWidthToolStripMenuItem = new ToolStripMenuItem();
            transientShaperToolStripMenuItem = new ToolStripMenuItem();
            tremoloToolStripMenuItem = new ToolStripMenuItem();
            removeCurrentEffectToolStripMenuItem = new ToolStripMenuItem();
            currentSoundFile_toolStripLabel = new ToolStripLabel();
            soundSources_TabControl = new TabControl();
            auditionGenerateSoundDefinitioncsvToolStripMenuItem = new ToolStripMenuItem();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.Items.AddRange(new ToolStripItem[] { file_dropDownButton, edit_dropDownButton, soundScape_dropDownButton, currentSoundFile_toolStripLabel });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(933, 25);
            toolStrip.TabIndex = 1;
            toolStrip.Text = "toolStrip1";
            // 
            // file_dropDownButton
            // 
            file_dropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            file_dropDownButton.DropDownItems.AddRange(new ToolStripItem[] { loadSoundscapeToolStripMenuItem, saveSoundscapeToolStripMenuItem, loadMarathonSoundsFileToolStripMenuItem, auditionGenerateSoundDefinitioncsvToolStripMenuItem });
            file_dropDownButton.ImageTransparentColor = Color.Magenta;
            file_dropDownButton.Name = "file_dropDownButton";
            file_dropDownButton.Size = new Size(38, 22);
            file_dropDownButton.Text = "File";
            // 
            // loadSoundscapeToolStripMenuItem
            // 
            loadSoundscapeToolStripMenuItem.Name = "loadSoundscapeToolStripMenuItem";
            loadSoundscapeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            loadSoundscapeToolStripMenuItem.Size = new Size(287, 22);
            loadSoundscapeToolStripMenuItem.Text = "Load Soundscape";
            loadSoundscapeToolStripMenuItem.Click += LoadSoundscapeFileClick;
            // 
            // saveSoundscapeToolStripMenuItem
            // 
            saveSoundscapeToolStripMenuItem.Name = "saveSoundscapeToolStripMenuItem";
            saveSoundscapeToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveSoundscapeToolStripMenuItem.Size = new Size(287, 22);
            saveSoundscapeToolStripMenuItem.Text = "Save Soundscape";
            saveSoundscapeToolStripMenuItem.Click += SaveSoundscapeFileClick;
            // 
            // loadMarathonSoundsFileToolStripMenuItem
            // 
            loadMarathonSoundsFileToolStripMenuItem.Name = "loadMarathonSoundsFileToolStripMenuItem";
            loadMarathonSoundsFileToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
            loadMarathonSoundsFileToolStripMenuItem.Size = new Size(287, 22);
            loadMarathonSoundsFileToolStripMenuItem.Text = "Load Marathon Sounds File";
            loadMarathonSoundsFileToolStripMenuItem.Click += loadMarathonSoundsFileToolStripMenuItem_Click;
            // 
            // edit_dropDownButton
            // 
            edit_dropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            edit_dropDownButton.DropDownItems.AddRange(new ToolStripItem[] { undoToolStripMenuItem, redoToolStripMenuItem });
            edit_dropDownButton.ImageTransparentColor = Color.Magenta;
            edit_dropDownButton.Name = "edit_dropDownButton";
            edit_dropDownButton.Size = new Size(40, 22);
            edit_dropDownButton.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            undoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Y;
            undoToolStripMenuItem.Size = new Size(180, 22);
            undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            redoToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            redoToolStripMenuItem.Size = new Size(180, 22);
            redoToolStripMenuItem.Text = "Redo";
            // 
            // soundScape_dropDownButton
            // 
            soundScape_dropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            soundScape_dropDownButton.DropDownItems.AddRange(new ToolStripItem[] { playAllToolStripMenuItem, addSoundSourceToolStripMenuItem, removeCurrentSoundSourceToolStripMenuItem, addEffectToolStripMenuItem, removeCurrentEffectToolStripMenuItem });
            soundScape_dropDownButton.ImageTransparentColor = Color.Magenta;
            soundScape_dropDownButton.Name = "soundScape_dropDownButton";
            soundScape_dropDownButton.Size = new Size(85, 22);
            soundScape_dropDownButton.Text = "SoundScape";
            // 
            // playAllToolStripMenuItem
            // 
            playAllToolStripMenuItem.Name = "playAllToolStripMenuItem";
            playAllToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Space;
            playAllToolStripMenuItem.Size = new Size(288, 22);
            playAllToolStripMenuItem.Text = "Play/Stop All Sound Sources";
            playAllToolStripMenuItem.Click += AllSoundSources_TogglePlaybackClick;
            // 
            // addSoundSourceToolStripMenuItem
            // 
            addSoundSourceToolStripMenuItem.Name = "addSoundSourceToolStripMenuItem";
            addSoundSourceToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            addSoundSourceToolStripMenuItem.Size = new Size(288, 22);
            addSoundSourceToolStripMenuItem.Text = "Add Sound Source";
            addSoundSourceToolStripMenuItem.Click += AddSoundSourceClick;
            // 
            // removeCurrentSoundSourceToolStripMenuItem
            // 
            removeCurrentSoundSourceToolStripMenuItem.Name = "removeCurrentSoundSourceToolStripMenuItem";
            removeCurrentSoundSourceToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Delete;
            removeCurrentSoundSourceToolStripMenuItem.Size = new Size(288, 22);
            removeCurrentSoundSourceToolStripMenuItem.Text = "Remove Current Sound Source";
            removeCurrentSoundSourceToolStripMenuItem.Click += RemoveSoundSourceClick;
            // 
            // addEffectToolStripMenuItem
            // 
            addEffectToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reverbToolStripMenuItem, convolutionReverbToolStripMenuItem, delayToolStripMenuItem, chorusToolStripMenuItem, compressorToolStripMenuItem, autoGainControlToolStripMenuItem, bitcrusherToolStripMenuItem, cabinetToolStripMenuItem, dCBlockerToolStripMenuItem, deEsserToolStripMenuItem, comfortNoiseToolStripMenuItem, equalizerToolStripMenuItem, feedbackDelayToolStripMenuItem, flangerToolStripMenuItem, gateToolStripMenuItem, limiterToolStripMenuItem, multibandCompressorToolStripMenuItem, noiseSuppressionToolStripMenuItem, phaserToolStripMenuItem, saturationToolStripMenuItem, stereoWidthToolStripMenuItem, transientShaperToolStripMenuItem, tremoloToolStripMenuItem });
            addEffectToolStripMenuItem.Name = "addEffectToolStripMenuItem";
            addEffectToolStripMenuItem.Size = new Size(288, 22);
            addEffectToolStripMenuItem.Text = "Add Effect";
            // 
            // reverbToolStripMenuItem
            // 
            reverbToolStripMenuItem.Name = "reverbToolStripMenuItem";
            reverbToolStripMenuItem.Size = new Size(247, 22);
            reverbToolStripMenuItem.Text = "Reverb";
            reverbToolStripMenuItem.Click += AddReverbEffect;
            // 
            // convolutionReverbToolStripMenuItem
            // 
            convolutionReverbToolStripMenuItem.Name = "convolutionReverbToolStripMenuItem";
            convolutionReverbToolStripMenuItem.Size = new Size(247, 22);
            convolutionReverbToolStripMenuItem.Text = "Convolution Reverb";
            convolutionReverbToolStripMenuItem.Click += AddConvolutionReverbEffect;
            // 
            // delayToolStripMenuItem
            // 
            delayToolStripMenuItem.Name = "delayToolStripMenuItem";
            delayToolStripMenuItem.Size = new Size(247, 22);
            delayToolStripMenuItem.Text = "Delay";
            delayToolStripMenuItem.Click += AddDelayEffect;
            // 
            // chorusToolStripMenuItem
            // 
            chorusToolStripMenuItem.Name = "chorusToolStripMenuItem";
            chorusToolStripMenuItem.Size = new Size(247, 22);
            chorusToolStripMenuItem.Text = "Chorus";
            chorusToolStripMenuItem.Click += AddChorusEffect;
            // 
            // compressorToolStripMenuItem
            // 
            compressorToolStripMenuItem.Name = "compressorToolStripMenuItem";
            compressorToolStripMenuItem.Size = new Size(247, 22);
            compressorToolStripMenuItem.Text = "Compressor";
            compressorToolStripMenuItem.Click += AddCompressorEffect;
            // 
            // autoGainControlToolStripMenuItem
            // 
            autoGainControlToolStripMenuItem.Name = "autoGainControlToolStripMenuItem";
            autoGainControlToolStripMenuItem.Size = new Size(247, 22);
            autoGainControlToolStripMenuItem.Text = "Auto Gain Control";
            autoGainControlToolStripMenuItem.Click += AddAutoGainControlEffect;
            // 
            // bitcrusherToolStripMenuItem
            // 
            bitcrusherToolStripMenuItem.Name = "bitcrusherToolStripMenuItem";
            bitcrusherToolStripMenuItem.Size = new Size(247, 22);
            bitcrusherToolStripMenuItem.Text = "Bitcrusher";
            bitcrusherToolStripMenuItem.Click += AddBitcrusherEffect;
            // 
            // cabinetToolStripMenuItem
            // 
            cabinetToolStripMenuItem.Name = "cabinetToolStripMenuItem";
            cabinetToolStripMenuItem.Size = new Size(247, 22);
            cabinetToolStripMenuItem.Text = "Cabinet";
            cabinetToolStripMenuItem.Click += AddCabinetEffect;
            // 
            // dCBlockerToolStripMenuItem
            // 
            dCBlockerToolStripMenuItem.Name = "dCBlockerToolStripMenuItem";
            dCBlockerToolStripMenuItem.Size = new Size(247, 22);
            dCBlockerToolStripMenuItem.Text = "DC Blocker";
            dCBlockerToolStripMenuItem.Click += AddDcBlockerEffect;
            // 
            // deEsserToolStripMenuItem
            // 
            deEsserToolStripMenuItem.Name = "deEsserToolStripMenuItem";
            deEsserToolStripMenuItem.Size = new Size(247, 22);
            deEsserToolStripMenuItem.Text = "De-Esser";
            deEsserToolStripMenuItem.Click += AddDeEsserEffect;
            // 
            // comfortNoiseToolStripMenuItem
            // 
            comfortNoiseToolStripMenuItem.Name = "comfortNoiseToolStripMenuItem";
            comfortNoiseToolStripMenuItem.Size = new Size(247, 22);
            comfortNoiseToolStripMenuItem.Text = "Comfort Noise";
            comfortNoiseToolStripMenuItem.Click += AddComfortNoiseEffect;
            // 
            // equalizerToolStripMenuItem
            // 
            equalizerToolStripMenuItem.Name = "equalizerToolStripMenuItem";
            equalizerToolStripMenuItem.Size = new Size(247, 22);
            equalizerToolStripMenuItem.Text = "Equalizer";
            equalizerToolStripMenuItem.Click += AddEqualizerEffect;
            // 
            // feedbackDelayToolStripMenuItem
            // 
            feedbackDelayToolStripMenuItem.Name = "feedbackDelayToolStripMenuItem";
            feedbackDelayToolStripMenuItem.Size = new Size(247, 22);
            feedbackDelayToolStripMenuItem.Text = "Feedback-Delay-Network Reverb";
            feedbackDelayToolStripMenuItem.Click += AddFeedbackDelayNetReverbEffect;
            // 
            // flangerToolStripMenuItem
            // 
            flangerToolStripMenuItem.Name = "flangerToolStripMenuItem";
            flangerToolStripMenuItem.Size = new Size(247, 22);
            flangerToolStripMenuItem.Text = "Flanger";
            flangerToolStripMenuItem.Click += AddFlangerEffect;
            // 
            // gateToolStripMenuItem
            // 
            gateToolStripMenuItem.Name = "gateToolStripMenuItem";
            gateToolStripMenuItem.Size = new Size(247, 22);
            gateToolStripMenuItem.Text = "Gate";
            gateToolStripMenuItem.Click += AddGateEffect;
            // 
            // limiterToolStripMenuItem
            // 
            limiterToolStripMenuItem.Name = "limiterToolStripMenuItem";
            limiterToolStripMenuItem.Size = new Size(247, 22);
            limiterToolStripMenuItem.Text = "Limiter";
            limiterToolStripMenuItem.Click += AddLimiterEffect;
            // 
            // multibandCompressorToolStripMenuItem
            // 
            multibandCompressorToolStripMenuItem.Name = "multibandCompressorToolStripMenuItem";
            multibandCompressorToolStripMenuItem.Size = new Size(247, 22);
            multibandCompressorToolStripMenuItem.Text = "Multiband Compressor";
            multibandCompressorToolStripMenuItem.Click += AddMultibandCompressorEffect;
            // 
            // noiseSuppressionToolStripMenuItem
            // 
            noiseSuppressionToolStripMenuItem.Name = "noiseSuppressionToolStripMenuItem";
            noiseSuppressionToolStripMenuItem.Size = new Size(247, 22);
            noiseSuppressionToolStripMenuItem.Text = "Noise Suppression";
            noiseSuppressionToolStripMenuItem.Click += AddNoiseSuppressionEffect;
            // 
            // phaserToolStripMenuItem
            // 
            phaserToolStripMenuItem.Name = "phaserToolStripMenuItem";
            phaserToolStripMenuItem.Size = new Size(247, 22);
            phaserToolStripMenuItem.Text = "Phaser";
            phaserToolStripMenuItem.Click += AddPhaserEffect;
            // 
            // saturationToolStripMenuItem
            // 
            saturationToolStripMenuItem.Name = "saturationToolStripMenuItem";
            saturationToolStripMenuItem.Size = new Size(247, 22);
            saturationToolStripMenuItem.Text = "Saturation";
            saturationToolStripMenuItem.Click += AddSaturationEffect;
            // 
            // stereoWidthToolStripMenuItem
            // 
            stereoWidthToolStripMenuItem.Name = "stereoWidthToolStripMenuItem";
            stereoWidthToolStripMenuItem.Size = new Size(247, 22);
            stereoWidthToolStripMenuItem.Text = "Stereo Width";
            stereoWidthToolStripMenuItem.Click += AddStereoWidthEffect;
            // 
            // transientShaperToolStripMenuItem
            // 
            transientShaperToolStripMenuItem.Name = "transientShaperToolStripMenuItem";
            transientShaperToolStripMenuItem.Size = new Size(247, 22);
            transientShaperToolStripMenuItem.Text = "Transient Shaper";
            transientShaperToolStripMenuItem.Click += AddTransientShaperEffect;
            // 
            // tremoloToolStripMenuItem
            // 
            tremoloToolStripMenuItem.Name = "tremoloToolStripMenuItem";
            tremoloToolStripMenuItem.Size = new Size(247, 22);
            tremoloToolStripMenuItem.Text = "Tremolo";
            tremoloToolStripMenuItem.Click += AddTremeloEffect;
            // 
            // removeCurrentEffectToolStripMenuItem
            // 
            removeCurrentEffectToolStripMenuItem.Name = "removeCurrentEffectToolStripMenuItem";
            removeCurrentEffectToolStripMenuItem.Size = new Size(288, 22);
            removeCurrentEffectToolStripMenuItem.Text = "Remove Current Effect";
            removeCurrentEffectToolStripMenuItem.Click += RemoveEffectClick;
            // 
            // currentSoundFile_toolStripLabel
            // 
            currentSoundFile_toolStripLabel.Name = "currentSoundFile_toolStripLabel";
            currentSoundFile_toolStripLabel.Size = new Size(131, 22);
            currentSoundFile_toolStripLabel.Text = "No Sounds File Loaded.";
            currentSoundFile_toolStripLabel.ToolTipText = "Current Sounds File";
            // 
            // soundSources_TabControl
            // 
            soundSources_TabControl.Dock = DockStyle.Fill;
            soundSources_TabControl.Location = new Point(0, 25);
            soundSources_TabControl.Margin = new Padding(4, 3, 4, 3);
            soundSources_TabControl.Multiline = true;
            soundSources_TabControl.Name = "soundSources_TabControl";
            soundSources_TabControl.SelectedIndex = 0;
            soundSources_TabControl.Size = new Size(933, 494);
            soundSources_TabControl.TabIndex = 2;
            soundSources_TabControl.SelectedIndexChanged += TabSwitched;
            // 
            // auditionGenerateSoundDefinitioncsvToolStripMenuItem
            // 
            auditionGenerateSoundDefinitioncsvToolStripMenuItem.Name = "auditionGenerateSoundDefinitioncsvToolStripMenuItem";
            auditionGenerateSoundDefinitioncsvToolStripMenuItem.Size = new Size(287, 22);
            auditionGenerateSoundDefinitioncsvToolStripMenuItem.Text = "Audition/Generate Sound Definition .csv";
            auditionGenerateSoundDefinitioncsvToolStripMenuItem.Click += Audition_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(933, 519);
            Controls.Add(soundSources_TabControl);
            Controls.Add(toolStrip);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marathon Sounds Generator v0.1";
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
        private ToolStripMenuItem addEffectToolStripMenuItem;
        private ToolStripMenuItem removeCurrentEffectToolStripMenuItem;
        private ToolStripMenuItem reverbToolStripMenuItem;
        private ToolStripMenuItem convolutionReverbToolStripMenuItem;
        private ToolStripMenuItem delayToolStripMenuItem;
        private ToolStripMenuItem chorusToolStripMenuItem;
        private ToolStripMenuItem compressorToolStripMenuItem;
        private ToolStripMenuItem autoGainControlToolStripMenuItem;
        private ToolStripMenuItem bitcrusherToolStripMenuItem;
        private ToolStripMenuItem cabinetToolStripMenuItem;
        private ToolStripMenuItem dCBlockerToolStripMenuItem;
        private ToolStripMenuItem deEsserToolStripMenuItem;
        private ToolStripMenuItem comfortNoiseToolStripMenuItem;
        private ToolStripMenuItem equalizerToolStripMenuItem;
        private ToolStripMenuItem feedbackDelayToolStripMenuItem;
        private ToolStripMenuItem flangerToolStripMenuItem;
        private ToolStripMenuItem gateToolStripMenuItem;
        private ToolStripMenuItem limiterToolStripMenuItem;
        private ToolStripMenuItem multibandCompressorToolStripMenuItem;
        private ToolStripMenuItem noiseSuppressionToolStripMenuItem;
        private ToolStripMenuItem phaserToolStripMenuItem;
        private ToolStripMenuItem saturationToolStripMenuItem;
        private ToolStripMenuItem stereoWidthToolStripMenuItem;
        private ToolStripMenuItem transientShaperToolStripMenuItem;
        private ToolStripMenuItem tremoloToolStripMenuItem;
        private ToolStripMenuItem auditionGenerateSoundDefinitioncsvToolStripMenuItem;
    }
}

