namespace MarathonSoundGen.Controls
{
    partial class PlatformSampleControl
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
            startExtend_ComboBox = new ComboBox();
            master_FlowLayoutPanel = new FlowLayoutPanel();
            sounds_TableLayoutPanel = new TableLayoutPanel();
            runningSound_ComboBox = new ComboBox();
            stopRetract_ComboBox = new ComboBox();
            startRetract_ComboBox = new ComboBox();
            stopExtend_ComboBox = new ComboBox();
            stopExtend_Label = new Label();
            startExtend_Label = new Label();
            startRetract_Label = new Label();
            stopRetract_Label = new Label();
            runningSound_Label = new Label();
            playStop_Button = new Button();
            master_FlowLayoutPanel.SuspendLayout();
            sounds_TableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // startExtend_ComboBox
            // 
            startExtend_ComboBox.Dock = DockStyle.Fill;
            startExtend_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            startExtend_ComboBox.FormattingEnabled = true;
            startExtend_ComboBox.Location = new Point(123, 3);
            startExtend_ComboBox.Margin = new Padding(4, 3, 4, 3);
            startExtend_ComboBox.Name = "startExtend_ComboBox";
            startExtend_ComboBox.Size = new Size(212, 23);
            startExtend_ComboBox.TabIndex = 1;
            // 
            // master_FlowLayoutPanel
            // 
            master_FlowLayoutPanel.Controls.Add(sounds_TableLayoutPanel);
            master_FlowLayoutPanel.Controls.Add(playStop_Button);
            master_FlowLayoutPanel.Dock = DockStyle.Fill;
            master_FlowLayoutPanel.Location = new Point(0, 0);
            master_FlowLayoutPanel.Margin = new Padding(4, 3, 4, 3);
            master_FlowLayoutPanel.Name = "master_FlowLayoutPanel";
            master_FlowLayoutPanel.Size = new Size(441, 165);
            master_FlowLayoutPanel.TabIndex = 1;
            // 
            // sounds_TableLayoutPanel
            // 
            sounds_TableLayoutPanel.ColumnCount = 2;
            sounds_TableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            sounds_TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            sounds_TableLayoutPanel.Controls.Add(runningSound_ComboBox, 1, 4);
            sounds_TableLayoutPanel.Controls.Add(stopRetract_ComboBox, 1, 3);
            sounds_TableLayoutPanel.Controls.Add(startRetract_ComboBox, 1, 2);
            sounds_TableLayoutPanel.Controls.Add(stopExtend_ComboBox, 1, 1);
            sounds_TableLayoutPanel.Controls.Add(stopExtend_Label, 0, 1);
            sounds_TableLayoutPanel.Controls.Add(startExtend_Label, 0, 0);
            sounds_TableLayoutPanel.Controls.Add(startExtend_ComboBox, 1, 0);
            sounds_TableLayoutPanel.Controls.Add(startRetract_Label, 0, 2);
            sounds_TableLayoutPanel.Controls.Add(stopRetract_Label, 0, 3);
            sounds_TableLayoutPanel.Controls.Add(runningSound_Label, 0, 4);
            sounds_TableLayoutPanel.Location = new Point(3, 3);
            sounds_TableLayoutPanel.Name = "sounds_TableLayoutPanel";
            sounds_TableLayoutPanel.RowCount = 5;
            sounds_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            sounds_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            sounds_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            sounds_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            sounds_TableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            sounds_TableLayoutPanel.Size = new Size(339, 158);
            sounds_TableLayoutPanel.TabIndex = 4;
            // 
            // runningSound_ComboBox
            // 
            runningSound_ComboBox.Dock = DockStyle.Fill;
            runningSound_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            runningSound_ComboBox.FormattingEnabled = true;
            runningSound_ComboBox.Location = new Point(123, 127);
            runningSound_ComboBox.Margin = new Padding(4, 3, 4, 3);
            runningSound_ComboBox.Name = "runningSound_ComboBox";
            runningSound_ComboBox.Size = new Size(212, 23);
            runningSound_ComboBox.TabIndex = 10;
            // 
            // stopRetract_ComboBox
            // 
            stopRetract_ComboBox.Dock = DockStyle.Fill;
            stopRetract_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            stopRetract_ComboBox.FormattingEnabled = true;
            stopRetract_ComboBox.Location = new Point(123, 96);
            stopRetract_ComboBox.Margin = new Padding(4, 3, 4, 3);
            stopRetract_ComboBox.Name = "stopRetract_ComboBox";
            stopRetract_ComboBox.Size = new Size(212, 23);
            stopRetract_ComboBox.TabIndex = 9;
            // 
            // startRetract_ComboBox
            // 
            startRetract_ComboBox.Dock = DockStyle.Fill;
            startRetract_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            startRetract_ComboBox.FormattingEnabled = true;
            startRetract_ComboBox.Location = new Point(123, 65);
            startRetract_ComboBox.Margin = new Padding(4, 3, 4, 3);
            startRetract_ComboBox.Name = "startRetract_ComboBox";
            startRetract_ComboBox.Size = new Size(212, 23);
            startRetract_ComboBox.TabIndex = 8;
            // 
            // stopExtend_ComboBox
            // 
            stopExtend_ComboBox.Dock = DockStyle.Fill;
            stopExtend_ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            stopExtend_ComboBox.FormattingEnabled = true;
            stopExtend_ComboBox.Location = new Point(123, 34);
            stopExtend_ComboBox.Margin = new Padding(4, 3, 4, 3);
            stopExtend_ComboBox.Name = "stopExtend_ComboBox";
            stopExtend_ComboBox.Size = new Size(212, 23);
            stopExtend_ComboBox.TabIndex = 7;
            // 
            // stopExtend_Label
            // 
            stopExtend_Label.AutoSize = true;
            stopExtend_Label.Dock = DockStyle.Fill;
            stopExtend_Label.Location = new Point(4, 31);
            stopExtend_Label.Margin = new Padding(4, 0, 4, 0);
            stopExtend_Label.Name = "stopExtend_Label";
            stopExtend_Label.Size = new Size(111, 31);
            stopExtend_Label.TabIndex = 3;
            stopExtend_Label.Text = "Stop Extend Sound:";
            stopExtend_Label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // startExtend_Label
            // 
            startExtend_Label.AutoSize = true;
            startExtend_Label.Dock = DockStyle.Fill;
            startExtend_Label.Location = new Point(4, 0);
            startExtend_Label.Margin = new Padding(4, 0, 4, 0);
            startExtend_Label.Name = "startExtend_Label";
            startExtend_Label.Size = new Size(111, 31);
            startExtend_Label.TabIndex = 2;
            startExtend_Label.Text = "Start Extend Sound:";
            startExtend_Label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // startRetract_Label
            // 
            startRetract_Label.AutoSize = true;
            startRetract_Label.Dock = DockStyle.Fill;
            startRetract_Label.Location = new Point(4, 62);
            startRetract_Label.Margin = new Padding(4, 0, 4, 0);
            startRetract_Label.Name = "startRetract_Label";
            startRetract_Label.Size = new Size(111, 31);
            startRetract_Label.TabIndex = 4;
            startRetract_Label.Text = "Start Retract Sound:";
            startRetract_Label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // stopRetract_Label
            // 
            stopRetract_Label.AutoSize = true;
            stopRetract_Label.Dock = DockStyle.Fill;
            stopRetract_Label.Location = new Point(4, 93);
            stopRetract_Label.Margin = new Padding(4, 0, 4, 0);
            stopRetract_Label.Name = "stopRetract_Label";
            stopRetract_Label.Size = new Size(111, 31);
            stopRetract_Label.TabIndex = 5;
            stopRetract_Label.Text = "Stop Retract Sound:";
            stopRetract_Label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // runningSound_Label
            // 
            runningSound_Label.AutoSize = true;
            runningSound_Label.Dock = DockStyle.Fill;
            runningSound_Label.Location = new Point(4, 124);
            runningSound_Label.Margin = new Padding(4, 0, 4, 0);
            runningSound_Label.Name = "runningSound_Label";
            runningSound_Label.Size = new Size(111, 34);
            runningSound_Label.TabIndex = 6;
            runningSound_Label.Text = "Running Sound:";
            runningSound_Label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // playStop_Button
            // 
            playStop_Button.Location = new Point(349, 3);
            playStop_Button.Margin = new Padding(4, 3, 4, 3);
            playStop_Button.Name = "playStop_Button";
            playStop_Button.Size = new Size(88, 27);
            playStop_Button.TabIndex = 3;
            playStop_Button.Text = "Play/Stop";
            playStop_Button.UseVisualStyleBackColor = true;
            // 
            // PlatformSampleControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(master_FlowLayoutPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "PlatformSampleControl";
            Size = new Size(441, 165);
            master_FlowLayoutPanel.ResumeLayout(false);
            sounds_TableLayoutPanel.ResumeLayout(false);
            sounds_TableLayoutPanel.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ComboBox startExtend_ComboBox;
        private System.Windows.Forms.FlowLayoutPanel master_FlowLayoutPanel;
        private System.Windows.Forms.Label startExtend_Label;
        private System.Windows.Forms.Button playStop_Button;
        private TableLayoutPanel sounds_TableLayoutPanel;
        private Label stopExtend_Label;
        private Label startRetract_Label;
        private Label stopRetract_Label;
        private Label runningSound_Label;
        private ComboBox stopExtend_ComboBox;
        private ComboBox startRetract_ComboBox;
        private ComboBox stopRetract_ComboBox;
        private ComboBox runningSound_ComboBox;
    }
}
