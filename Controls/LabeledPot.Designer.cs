namespace MarathonSoundGen.Controls
{
    partial class LabeledPot
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
            this.pot = new NAudio.Gui.Pot();
            this.value_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pot
            // 
            this.pot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pot.Location = new System.Drawing.Point(0, 0);
            this.pot.Maximum = 1D;
            this.pot.Minimum = 0D;
            this.pot.Name = "pot";
            this.pot.Size = new System.Drawing.Size(150, 150);
            this.pot.TabIndex = 0;
            this.pot.Value = 0.5D;
            this.pot.ValueChanged += new System.EventHandler(this.PotChanged);
            // 
            // value_TextBox
            // 
            this.value_TextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.value_TextBox.Location = new System.Drawing.Point(0, 130);
            this.value_TextBox.Name = "value_TextBox";
            this.value_TextBox.Size = new System.Drawing.Size(150, 20);
            this.value_TextBox.TabIndex = 1;
            this.value_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.value_TextBox.WordWrap = false;
            this.value_TextBox.TextChanged += new System.EventHandler(this.ValueChangedText);
            // 
            // LabeledPot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.value_TextBox);
            this.Controls.Add(this.pot);
            this.Name = "LabeledPot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NAudio.Gui.Pot pot;
        private System.Windows.Forms.TextBox value_TextBox;
    }
}
