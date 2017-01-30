using System;

namespace SoundAlalysis.BL
{
    public static class FrequencyUtil
    {
        //Здесь будет происходить очиска буфера, заполнение концов нулями 
        public static System.Numerics.Complex[] ConvertToComplex(float[] samples)
        {
            //int length;
            //int bitsInLength;
            //автоматическая подстановка размера log n(2) (нихуя)
            //if (IsPowerOfTwo(samples.Length))
            //{
            //    length = samples.Length;
            //    bitsInLength = Log2(length) - 1;
            //}
            //else
            //{
            //    bitsInLength = Log2(samples.Length);
            //    length = 1 << bitsInLength;
            //    // the items will be pad with zeros
            //}

            System.Numerics.Complex[] data = new System.Numerics.Complex[samples.Length];
            for (int i = 0; i < samples.Length; i++)
            {
                var temp = samples[i];
                temp = samples[i] * HammingWindow(i, samples.Length); //для удобства комментирования и проверки результатов с ним\без него
                data[i] = new System.Numerics.Complex(temp, 0);
            }
            return data;
        }

        //Для редварительной обработки весовой функцией "окно", увеличивает точность нахождения пиковой частоты
        //сглаживая функцию
        private static Single HammingWindow(Int32 n, Int32 N)
        {
            return 0.54f - 0.46f * (Single)Math.Cos((2 * Math.PI * n) / (N - 1));
        }

        //Тут понятно
        private static int Log2(int n)
        {
            int i = 0;
            while (n > 0)
            {
                ++i; n >>= 1;
            }
            return i;
        }

        //может понадобиться для прореживания по времени
        private static int ReverseBits(int n, int bitsCount)
        {
            int reversed = 0;
            for (int i = 0; i < bitsCount; i++)
            {
                int nextBit = n & 1;
                n >>= 1;

                reversed <<= 1;
                reversed |= nextBit;
            }
            return reversed;
        }

        private static bool IsPowerOfTwo(int n)
        {
            return n > 1 && (n & (n - 1)) == 0;
        }
    }
}
