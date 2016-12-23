using System;
using NAudio.CoreAudioApi;

namespace Tuner
{
    public interface  ITuner
    {
        void ShowFreq(Double freq);
        void SetDevices(MMDevice[] devices);

        event EventHandler StartButtonClick;
        event EventHandler StopButtonClick;
        event EventHandler DevicesOpened;
    }
}
