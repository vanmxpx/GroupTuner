using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using NAudio.CoreAudioApi;
using NAudio.Utils;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace SoundCapture.BL
{
    public abstract class AudioCatch
    {
        private IWaveIn _waveIn;
        private byte[] _buff;
        private WaveBuffer _waveBuffer;
        private MMDevice _device;

        public Int32 BitsPerSample { get { return 16; } }
        public Int32 ChannelCount { get { return 2; } }
        public Int32 SampleRate { get { return 96000; } }

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
            //_waveIn.DeviceNumber = 0;
            _waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(_waveIn_DataAvailable);
            _waveIn.WaveFormat = new WaveFormat(SampleRate, BitsPerSample, ChannelCount);            
            _waveIn.StartRecording();
        }

        public void Stop()
        {
            _waveIn.StopRecording();
            _waveIn.Dispose();
            _waveIn = null;
            //_buffer = null;
        }

        private void _waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            _buff = e.Buffer;
            _waveBuffer = new WaveBuffer(8192);
            //var samples = new float[e.BytesRecorded];
            var samples = (from i in _buff select BitConverter.ToSingle(_buff, i)).ToArray();
            //_buffer.AddSamples(e.Buffer, 0, e.BytesRecorded);
            ProcessData(_waveBuffer.FloatBuffer);


            //byte[] buffer = e.Buffer;
            //float[] newBuffer = new float[e.BytesRecorded / 4];


            //for (int i = 0; i < e.BytesRecorded / 4; i++)
            //{
            //    newBuffer[i] = BitConverter.ToInt16(buffer, i * 4) / 32768f;
            //}


            //for (int index = 0; index < e.BytesRecorded; index += 2)
            //{
            //    short sample = (short)((buffer[index + 1] << 8) |
            //                            buffer[index + 0]);
            //    newBuffer[index] = sample / 32768f;
            //}
            //ProcessData(newBuffer);
        }

        protected abstract void ProcessData(Single[] data);
    }
}
