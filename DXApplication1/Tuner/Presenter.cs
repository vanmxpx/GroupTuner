using System;
using SoundCapture.BL;
using SoundAlalysis.BL;

namespace Tuner
{
    public class Presenter : AudioCatch
    {
        private ITuner _form;
        const Double MinFreq = 60;
        const Double MaxFreq = 1300;

        public Presenter(ITuner _form)
        {
            this._form = _form;
            _form.SetDevices(DeviceManager.GetActiveDevices());
            _form.StartButtonClick += _form_StartButtonClick;
        }

        private void _form_StartButtonClick(object sender, EventArgs e)
        {
            this.Start();
        }


        protected override void ProcessData(Single[] data)
        {
            //_form.ShowFreq(FrequencyUtil.DetectPitch(data, SampleRate, MinFreq, MaxFreq));
            _form.ShowFreq(FFTMethod.ProcessThread(data, SampleRate));
        }
    }
}
