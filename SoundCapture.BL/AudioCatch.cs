using System;
using System.ComponentModel;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace SoundCapture.BL
{
    public abstract class AudioCatch
    {
        private IWaveIn _waveIn;
        private WaveBuffer _buffer;
        private MMDevice _device;

        public Int32 BitsPerSample { get { return 16; } }
        public Int32 ChannelCount { get { return 1; } }
        public Int32 SampleRate { get { return 44100; } }

        public AudioCatch()
            : this(DeviceManager.GetDefaultDevice())
        {
        }

        public AudioCatch(MMDevice _device)
        {
            this._device = _device;
        }

        public void SetNewDevice(MMDevice _device)
        {
            this._device = _device;
        }

        public void Start()
        {
            _waveIn = new WasapiCapture(_device);
            _waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(_waveIn_DataAvailable);
            _waveIn.WaveFormat = new WaveFormat(SampleRate, BitsPerSample, ChannelCount);

            _waveIn.StartRecording();
        }

        public void Stop()
        {
            if (_waveIn != null)
                _waveIn.StopRecording();
            _waveIn.Dispose();
            _waveIn = null;
            _buffer = null;
        }

        private void _waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            _buffer = new WaveBuffer(e.Buffer);
            ProcessData(_buffer.FloatBuffer);
        }

        protected abstract void ProcessData(Single[] data);
    }
}
