namespace MarathonSoundGen.Forms
{
    partial class QuickAuditionForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.nextButton = new System.Windows.Forms.Button();
            this.srcLbl = new System.Windows.Forms.Label();
            this.indexLbl = new System.Windows.Forms.Label();
            this.bitsLbl = new System.Windows.Forms.Label();
            this.stereoLbl = new System.Windows.Forms.Label();
            this.idLbl = new System.Windows.Forms.Label();
            this.slotLbl = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.audBtn = new System.Windows.Forms.Button();
            this.source_Txt = new System.Windows.Forms.Label();
            this.Index_text = new System.Windows.Forms.Label();
            this.bitDepth_Text = new System.Windows.Forms.Label();
            this.stereo_txt = new System.Windows.Forms.Label();
            this.ID_txt = new System.Windows.Forms.Label();
            this.slotTxt = new System.Windows.Forms.Label();
            this.sampleRateNud = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleRateNud)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.srcLbl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.indexLbl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.bitsLbl, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.stereoLbl, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.idLbl, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.slotLbl, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.source_Txt, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Index_text, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.bitDepth_Text, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.stereo_txt, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.ID_txt, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.slotTxt, 5, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 222);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(713, 415);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextClick);
            // 
            // srcLbl
            // 
            this.srcLbl.AutoSize = true;
            this.srcLbl.Location = new System.Drawing.Point(3, 0);
            this.srcLbl.Name = "srcLbl";
            this.srcLbl.Size = new System.Drawing.Size(41, 13);
            this.srcLbl.TabIndex = 0;
            this.srcLbl.Text = "Source";
            // 
            // indexLbl
            // 
            this.indexLbl.AutoSize = true;
            this.indexLbl.Location = new System.Drawing.Point(132, 0);
            this.indexLbl.Name = "indexLbl";
            this.indexLbl.Size = new System.Drawing.Size(33, 13);
            this.indexLbl.TabIndex = 1;
            this.indexLbl.Text = "Index";
            // 
            // bitsLbl
            // 
            this.bitsLbl.AutoSize = true;
            this.bitsLbl.Location = new System.Drawing.Point(261, 0);
            this.bitsLbl.Name = "bitsLbl";
            this.bitsLbl.Size = new System.Drawing.Size(51, 13);
            this.bitsLbl.TabIndex = 3;
            this.bitsLbl.Text = "Bit Depth";
            // 
            // stereoLbl
            // 
            this.stereoLbl.AutoSize = true;
            this.stereoLbl.Location = new System.Drawing.Point(390, 0);
            this.stereoLbl.Name = "stereoLbl";
            this.stereoLbl.Size = new System.Drawing.Size(38, 13);
            this.stereoLbl.TabIndex = 4;
            this.stereoLbl.Text = "Stereo";
            // 
            // idLbl
            // 
            this.idLbl.AutoSize = true;
            this.idLbl.Location = new System.Drawing.Point(519, 0);
            this.idLbl.Name = "idLbl";
            this.idLbl.Size = new System.Drawing.Size(18, 13);
            this.idLbl.TabIndex = 5;
            this.idLbl.Text = "ID";
            // 
            // slotLbl
            // 
            this.slotLbl.AutoSize = true;
            this.slotLbl.Location = new System.Drawing.Point(648, 0);
            this.slotLbl.Name = "slotLbl";
            this.slotLbl.Size = new System.Drawing.Size(25, 13);
            this.slotLbl.TabIndex = 6;
            this.slotLbl.Text = "Slot";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(12, 240);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(776, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // audBtn
            // 
            this.audBtn.Location = new System.Drawing.Point(632, 415);
            this.audBtn.Name = "audBtn";
            this.audBtn.Size = new System.Drawing.Size(75, 23);
            this.audBtn.TabIndex = 3;
            this.audBtn.Text = "Sample";
            this.audBtn.UseVisualStyleBackColor = true;
            this.audBtn.Click += new System.EventHandler(this.hearItButtonClick);
            // 
            // source_Txt
            // 
            this.source_Txt.AutoSize = true;
            this.source_Txt.Location = new System.Drawing.Point(3, 111);
            this.source_Txt.Name = "source_Txt";
            this.source_Txt.Size = new System.Drawing.Size(35, 13);
            this.source_Txt.TabIndex = 7;
            this.source_Txt.Text = "label1";
            // 
            // Index_text
            // 
            this.Index_text.AutoSize = true;
            this.Index_text.Location = new System.Drawing.Point(132, 111);
            this.Index_text.Name = "Index_text";
            this.Index_text.Size = new System.Drawing.Size(35, 13);
            this.Index_text.TabIndex = 8;
            this.Index_text.Text = "label1";
            // 
            // bitDepth_Text
            // 
            this.bitDepth_Text.AutoSize = true;
            this.bitDepth_Text.Location = new System.Drawing.Point(261, 111);
            this.bitDepth_Text.Name = "bitDepth_Text";
            this.bitDepth_Text.Size = new System.Drawing.Size(35, 13);
            this.bitDepth_Text.TabIndex = 9;
            this.bitDepth_Text.Text = "label1";
            // 
            // stereo_txt
            // 
            this.stereo_txt.AutoSize = true;
            this.stereo_txt.Location = new System.Drawing.Point(390, 111);
            this.stereo_txt.Name = "stereo_txt";
            this.stereo_txt.Size = new System.Drawing.Size(35, 13);
            this.stereo_txt.TabIndex = 10;
            this.stereo_txt.Text = "label1";
            // 
            // ID_txt
            // 
            this.ID_txt.AutoSize = true;
            this.ID_txt.Location = new System.Drawing.Point(519, 111);
            this.ID_txt.Name = "ID_txt";
            this.ID_txt.Size = new System.Drawing.Size(35, 13);
            this.ID_txt.TabIndex = 11;
            this.ID_txt.Text = "label1";
            // 
            // slotTxt
            // 
            this.slotTxt.AutoSize = true;
            this.slotTxt.Location = new System.Drawing.Point(648, 111);
            this.slotTxt.Name = "slotTxt";
            this.slotTxt.Size = new System.Drawing.Size(35, 13);
            this.slotTxt.TabIndex = 12;
            this.slotTxt.Text = "label1";
            // 
            // sampleRateNud
            // 
            this.sampleRateNud.Location = new System.Drawing.Point(663, 266);
            this.sampleRateNud.Maximum = new decimal(new int[] {
            96000,
            0,
            0,
            0});
            this.sampleRateNud.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.sampleRateNud.Name = "sampleRateNud";
            this.sampleRateNud.Size = new System.Drawing.Size(120, 20);
            this.sampleRateNud.TabIndex = 4;
            this.sampleRateNud.Value = new decimal(new int[] {
            44100,
            0,
            0,
            0});
            this.sampleRateNud.ValueChanged += new System.EventHandler(this.sampleRateChanged);
            // 
            // QuickAuditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sampleRateNud);
            this.Controls.Add(this.audBtn);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QuickAuditionForm";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleRateNud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label srcLbl;
        private System.Windows.Forms.Label indexLbl;
        private System.Windows.Forms.Label bitsLbl;
        private System.Windows.Forms.Label stereoLbl;
        private System.Windows.Forms.Label idLbl;
        private System.Windows.Forms.Label slotLbl;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button audBtn;
        private System.Windows.Forms.Label source_Txt;
        private System.Windows.Forms.Label Index_text;
        private System.Windows.Forms.Label bitDepth_Text;
        private System.Windows.Forms.Label stereo_txt;
        private System.Windows.Forms.Label ID_txt;
        private System.Windows.Forms.Label slotTxt;
        private System.Windows.Forms.NumericUpDown sampleRateNud;
    }
}