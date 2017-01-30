using System;
using System.Numerics;

namespace SoundAlalysis.BL
{
    public static class FFTMethod
    {
        private static float _sampleRate;
        private static int _minFreq;
        private static int _maxFreq;

        public static float ProcessThread(float[] frame, float sampleRate,int minFreq, int maxFreq)
        {
            _sampleRate = sampleRate;
            _maxFreq = minFreq;
            _maxFreq = maxFreq;
            var complexArray = FrequencyUtil.ConvertToComplex(frame);

            var spectrum = DecimationInFrequency(complexArray);


            return DetectPitch(spectrum);
        }

        private static float DetectPitch( Complex[] frames)
        {
                        //нахождение фундаментальной частоты путем нахождения самой большой амплитуды
            float binSize = frames.Length / _sampleRate; //период дискретизации (m/r)
            int minBin = (int)(_minFreq * binSize); //m(номер елемента) = v(частота) * T(период);
            int maxBin = (int)(_maxFreq * binSize);
            float maxIntensity = 0f;
            int maxBinIndex = 0;

            for (int bin = minBin; bin <= maxBin; bin++)
            {
                double intensity = frames[bin].Real * frames[bin].Real
                    + frames[bin].Imaginary * frames[bin].Imaginary;
                if (intensity > maxIntensity)
                {
                    maxIntensity = (float)intensity;
                    maxBinIndex = bin;
                }
            }
            return maxBinIndex/binSize;
        }

        private static Complex[] DecimationInFrequency(Complex[] frame)//прореживание по частоте
        //(разбиение на две части 0<n<N/2, N/2<n<N)
        {
            if (frame.Length == 1) return frame;
            var halfSampleSize = frame.Length >> 1; // frame.Length/2
            var fullSampleSize = frame.Length;

            var arg = -2 * Math.PI / fullSampleSize;
            var omegaPowBase = new System.Numerics.Complex(Math.Cos(arg), Math.Sin(arg));//експонента для комплексного числа
            var omega = System.Numerics.Complex.One;
            var spectrum = new System.Numerics.Complex[fullSampleSize];

            for (var j = 0; j < halfSampleSize; j++)
            {
                //первая половина
                //
                spectrum[j] = frame[j] + frame[j + halfSampleSize];
                //вторая половина
                //
                spectrum[j + halfSampleSize] = omega * (frame[j] - frame[j + halfSampleSize]);
                omega *= omegaPowBase; // степерь k будет накапливаться
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
