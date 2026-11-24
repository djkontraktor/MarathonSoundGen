namespace MarathonSoundGen.Forms
{
    partial class SoundIdForm
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
            master_SplitContainer = new SplitContainer();
            sounds_DataGridView = new DataGridView();
            controls_FlowLayoutPanel = new FlowLayoutPanel();
            csv_Button = new Button();
            ((System.ComponentModel.ISupportInitialize)master_SplitContainer).BeginInit();
            master_SplitContainer.Panel1.SuspendLayout();
            master_SplitContainer.Panel2.SuspendLayout();
            master_SplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sounds_DataGridView).BeginInit();
            controls_FlowLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // master_SplitContainer
            // 
            master_SplitContainer.Dock = DockStyle.Fill;
            master_SplitContainer.FixedPanel = FixedPanel.Panel2;
            master_SplitContainer.IsSplitterFixed = true;
            master_SplitContainer.Location = new Point(0, 0);
            master_SplitContainer.Name = "master_SplitContainer";
            master_SplitContainer.Orientation = Orientation.Horizontal;
            // 
            // master_SplitContainer.Panel1
            // 
            master_SplitContainer.Panel1.Controls.Add(sounds_DataGridView);
            // 
            // master_SplitContainer.Panel2
            // 
            master_SplitContainer.Panel2.Controls.Add(controls_FlowLayoutPanel);
            master_SplitContainer.Size = new Size(800, 450);
            master_SplitContainer.SplitterDistance = 414;
            master_SplitContainer.TabIndex = 0;
            // 
            // sounds_DataGridView
            // 
            sounds_DataGridView.BorderStyle = BorderStyle.Fixed3D;
            sounds_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            sounds_DataGridView.Dock = DockStyle.Fill;
            sounds_DataGridView.Location = new Point(0, 0);
            sounds_DataGridView.MultiSelect = false;
            sounds_DataGridView.Name = "sounds_DataGridView";
            sounds_DataGridView.RowHeadersVisible = false;
            sounds_DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            sounds_DataGridView.Size = new Size(800, 414);
            sounds_DataGridView.TabIndex = 0;
            // 
            // controls_FlowLayoutPanel
            // 
            controls_FlowLayoutPanel.Controls.Add(csv_Button);
            controls_FlowLayoutPanel.Dock = DockStyle.Fill;
            controls_FlowLayoutPanel.FlowDirection = FlowDirection.RightToLeft;
            controls_FlowLayoutPanel.Location = new Point(0, 0);
            controls_FlowLayoutPanel.Name = "controls_FlowLayoutPanel";
            controls_FlowLayoutPanel.Size = new Size(800, 32);
            controls_FlowLayoutPanel.TabIndex = 0;
            // 
            // csv_Button
            // 
            csv_Button.Location = new Point(677, 3);
            csv_Button.Name = "csv_Button";
            csv_Button.Size = new Size(120, 23);
            csv_Button.TabIndex = 0;
            csv_Button.Text = "Generate CSV List";
            csv_Button.UseVisualStyleBackColor = true;
            csv_Button.Click += CsvGenerateClick;
            // 
            // SoundIdForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(master_SplitContainer);
            Name = "SoundIdForm";
            Text = "Define Sound Names";
            master_SplitContainer.Panel1.ResumeLayout(false);
            master_SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)master_SplitContainer).EndInit();
            master_SplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sounds_DataGridView).EndInit();
            controls_FlowLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer master_SplitContainer;
        private FlowLayoutPanel controls_FlowLayoutPanel;
        private DataGridView sounds_DataGridView;
        private Button csv_Button;
    }
}