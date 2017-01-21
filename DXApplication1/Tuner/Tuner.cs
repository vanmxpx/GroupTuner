using System;
using System.Linq;
using NAudio.CoreAudioApi;


namespace Tuner
{
    public partial class Tuner : DevExpress.XtraEditors.XtraForm, ITuner
    {
        public Tuner()
        {
            InitializeComponent();
        }
        public void ShowFreq(double freq)
        {
            if (this.InvokeRequired)
                lblFreq?.Invoke(new Action(() => lblFreq.Text = freq.ToString()));
            else
                lblFreq.Text = freq.ToString();
        }

        public void SetDevices(MMDevice[] devices)
        {
            devicesListBox.DataSource = devices?.Select(d => d.FriendlyName).ToList();
        }

        public event EventHandler StartButtonClick;

        public event EventHandler StopButtonClick;

        public event EventHandler DevicesOpened;

        private void butStart_Click(object sender, EventArgs e)
        {
            StartButtonClick?.Invoke(this, e);
        }

        private void Tuner_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            StartButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
