using System;
using System.Linq;
using System.Collections.Generic;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace SoundCapture.BL
{
    public class DeviceManager
    {
        MMDeviceEnumerator deviceEnum;
        MMDeviceCollection deviceCol;

        private void UpdateDevices()
        {
            MMDeviceEnumerator deviceEnum = new MMDeviceEnumerator();
            MMDeviceCollection deviceCol = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
        }

        public MMDevice[] GetActiveDevices()
        {
            UpdateDevices();
            return deviceCol.ToArray();
        }

        public MMDevice GetDeviceByNumber(Int32 deviceAt)
        {
            UpdateDevices();
            return deviceCol.ElementAt(deviceAt);
        }

        public MMDevice GetDefaultDevice()
        {
            UpdateDevices();
            return deviceEnum.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);
        }
    }
}
