using System;
using System.ComponentModel;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace SoundCapture.BL
{
    public class SoundCapture
    {
        private IWaveIn _waveIn;
        private WaveBuffer _buffer;
        private MMDevice _device;

        public SoundCapture()
        {
        }

        public void Start()
        {
            _waveIn = new WasapiCapture(_device);
            _waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(_waveIn_DataAvailable);
            _waveIn.WaveFormat = new WaveFormat(44100, 16, 1);

            _waveIn.StartRecording();
        }

        public void Stop()
        {
            if (_waveIn != null)
                _waveIn.StopRecording();
            _waveIn.Dispose();
            _waveIn = null;
        }

        private void _waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            _buffer.BindTo(e.Buffer);
            ProcessData(_buffer.FloatBuffer);
        }

        protected abstract void ProcessData(float[] data);
    }
}
