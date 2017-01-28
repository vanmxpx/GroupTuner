using System;
using System.Numerics;

namespace SoundAlalysis.BL
{
    public static class FFTMethod
    {
        public static float ProcessThread(float[] frame, float sampleRate)
        {

            var complexArray = FrequencyUtil.ConvertToComplex(frame);

            var spectrum = DecimationInFrequency(complexArray);

            float binSize = sampleRate / frame.Length;
            int minBin = (int)(85 / binSize);
            int maxBin = (int)(300 / binSize);
            float maxIntensity = 0f;
            int maxBinIndex = 0;

            for (int bin = minBin; bin <= maxBin; bin++)
            {
                double intensity = spectrum[bin].Real * spectrum[bin].Real
                    + spectrum[bin].Imaginary * spectrum[bin].Imaginary;
                if (intensity > maxIntensity)
                {
                    maxIntensity = (float)intensity;
                    maxBinIndex = bin;
                }
            }

            return binSize * maxBinIndex;
        }
        private static Complex[] DecimationInFrequency(Complex[] frame)
        {
            if (frame.Length == 1) return frame;
            var halfSampleSize = frame.Length >> 1; // frame.Length/2
            var fullSampleSize = frame.Length;

            var arg = -2 * Math.PI / fullSampleSize;
            var omegaPowBase = new System.Numerics.Complex(Math.Cos(arg), Math.Sin(arg));
            var omega = System.Numerics.Complex.One;
            var spectrum = new System.Numerics.Complex[fullSampleSize];

            for (var j = 0; j < halfSampleSize; j++)
            {
                spectrum[j] = frame[j] + frame[j + halfSampleSize];
                spectrum[j + halfSampleSize] = omega * (frame[j] - frame[j + halfSampleSize]);
                omega *= omegaPowBase;
            }

            var yTop = new System.Numerics.Complex[halfSampleSize];
            var yBottom = new System.Numerics.Complex[halfSampleSize];
            for (var i = 0; i < halfSampleSize; i++)
            {
                yTop[i] = spectrum[i];
                yBottom[i] = spectrum[i + halfSampleSize];
            }

            yTop = DecimationInFrequency(yTop);
            yBottom = DecimationInFrequency(yBottom);
            for (var i = 0; i < halfSampleSize; i++)
            {
                var j = i << 1; // i = 2*j;
                spectrum[j] = yTop[i];
                spectrum[j + 1] = yBottom[i];
            }

            return spectrum;
        }
    }
}
