using NAudio.Gui;
using System.ComponentModel;

namespace MarathonSoundGen.Controls
{
    public partial class LabeledPot : UserControl
    {

        #region Public Properties

        public Pot Pot
        {
            get
            {
                return pot;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Value
        {
            get
            {
                return pot.Value;
            }
            set
            {
                pot.Value = value;
            }
        }

        #endregion

        #region Constructor

        public LabeledPot(string title)
        {
            InitializeComponent();
            title_Label.Text = title;
            this.HandleCreated += LabeledPot_HandleCreated;
        }

        #endregion

        #region Control Callbacks

        private void LabeledPot_HandleCreated(object sender, EventArgs e)
        {
            value_TextBox.Text = pot.Value.ToString();
        }

        private void PotChanged(object sender, EventArgs e)
        {
            value_TextBox.Text = pot.Value.ToString();
        }

        private void ValueChangedText(object sender, EventArgs e)
        {
            double oldVal = pot.Value;

            if (double.TryParse(value_TextBox.Text, out double result))
            {
                if (result >= pot.Minimum && result <= pot.Maximum)
                {
                    pot.Value = result;
                }
                else
                {
                    value_TextBox.Text = oldVal.ToString();
                }
            }
            else
            {
                value_TextBox.Text = oldVal.ToString();
            }
        }

        #endregion

    }
}
