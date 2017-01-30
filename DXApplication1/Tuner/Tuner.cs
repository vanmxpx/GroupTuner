using System;
using System.Linq;
using Accord.Audio;
using Accord.DirectSound;
using System.Numerics;
using SoundAlalysis.BL;


namespace Tuner
{
    public partial class Tuner : DevExpress.XtraEditors.XtraForm
    {
        private IAudioSource source;
        const int MinFreq = 20;
        const int MaxFreq = 700;
        Action act;
             
        public Tuner()
        {
            InitializeComponent();       
        }

        private void butStart_Click(object sender, EventArgs e)
        {
            AudioDeviceInfo audioDeviceInfo = this.devicesListBox.SelectedItem as AudioDeviceInfo;
            if (audioDeviceInfo == null)
            {
                throw new ArgumentException("No audio devices available.");
            }
            source = new AudioCaptureDevice(audioDeviceInfo)
            {
                DesiredFrameSize = 8192,
                SampleRate = 96000,
                Channels = 2,
            };
            source.NewFrame += new EventHandler<NewFrameEventArgs>(NewFrame);
            source.Start();
        }

        private void butStop_Click(object sender, EventArgs e)
        {
            if (source != null)
                source.SignalToStop();
            source = null;
        }

        public void ShowFreq(double freq)
        {
            act = new Action(() => lblFreq.Text = freq.ToString("F"));
            if (lblFreq == null)
                return;
            if (lblFreq.InvokeRequired)
                lblFreq.Invoke(act);
            else
                lblFreq.Text = freq.ToString();
        }

        private void NewFrame(object sender, NewFrameEventArgs eventArgs)
        {

                    //FFT
            var freq = FFTMethod.ProcessThread(eventArgs.Signal.ToFloat(), eventArgs.Signal.SampleRate, MinFreq, MaxFreq);
            ShowFreq(freq);
                    //Accord
            //ComplexSignal complexSignal = ComplexSignal.FromSignal(eventArgs.Signal);
            //complexSignal.ForwardFourierTransform();
            //Complex[] channel = complexSignal.GetChannel(0);//хз почему, но channel 0 дает лучше результат
            //double[] powerSpectrum = Tools.GetPowerSpectrum(channel);
            //double[] frequencyVector = Tools.GetFrequencyVector(complexSignal.Length, complexSignal.SampleRate);
            //powerSpectrum[0] = 0.0;         
            //ShowFreq(frequencyVector[powerSpectrum.GetIndexOfMax()]);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AudioDeviceCollection audioDeviceCollection = new AudioDeviceCollection(AudioDeviceCategory.Capture);
            foreach (AudioDeviceInfo current in audioDeviceCollection)
            {
                devicesListBox.Items.Add(current);
            }
            if (devicesListBox.Items.Count == 0)
            {
                devicesListBox.Items.Add("No local capture devices");
                devicesListBox.Enabled = false;
            }
            devicesListBox.SelectedIndex = 0;
        }
    }
    public static class Extensions
    {
        public static int GetIndexOfMax(this double[] arr) 
        {
            double max = arr.Max();
            for(int i=0;i<arr.Length;i++)
            {
                if (max==arr[i]) return i;
            }
            return -1;
        }
    }
}
