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
            throw new NotImplementedException();
        }

        public void SetDevices(MMDevice[] devices)
        {
            if (devices != null)
                devicesListBox.DataSource = devices.Select(d => d.FriendlyName).ToList();
        }

        public event EventHandler StartButtonClick;

        public event EventHandler StopButtonClick;

        public event EventHandler DevicesOpened;
    }
}
