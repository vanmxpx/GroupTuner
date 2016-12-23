using System;

namespace SoundAlalysis.BL
{
    public static class FrequencyUtil
    {
        //Здесь будет происходить очиска буфера, заполнение концов нулями 
        public static Double DetectPitch(Single[] data, Int32 sampleRate, Double minFreq, Double maxFreq)
        {
            return 0;
        }

        //Павающее окно
        private static Single HammingWindow(Int32 n, Int32 N)
        {
            return 0.54f - 0.46f * (Single)Math.Cos((2 * Math.PI * n) / (N - 1));
        }
    }
}
