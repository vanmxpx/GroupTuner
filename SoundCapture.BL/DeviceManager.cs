using System;
using System.Linq;
using System.Collections.Generic;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace SoundCapture.BL
{
    public static class DeviceManager
    {
        private static MMDeviceEnumerator deviceEnum;
        private static MMDeviceCollection deviceCol;

        private static void UpdateDevices()
        {
            deviceEnum = new MMDeviceEnumerator();
            deviceCol = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
        }

        public static MMDevice[] GetActiveDevices()
        {
            UpdateDevices();
            try
            {
                return deviceCol.ToArray();
            }
            catch (ArgumentNullException)
            {
                XtraMessageBox.Show("We cannot find any devices at your computer.", "Device error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static MMDevice GetDeviceByNumber(Int32 deviceAt)
        {
            UpdateDevices();
            return deviceCol.ElementAt(deviceAt);
        }

        public static MMDevice GetDefaultDevice()
        {
            UpdateDevices();
            try
            {
                return deviceEnum.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);
            }
            catch (NullReferenceException)
            {
                XtraMessageBox.Show("We cannot find default device at your computer.", "Device error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
