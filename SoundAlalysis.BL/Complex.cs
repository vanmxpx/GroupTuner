using System;

namespace SoundAlalysis.BL
{
    public struct Complex
    {
        public Double Re;
        public Double Im;

        public Complex(Double re)
        {
            this.Re = re;
            this.Im = 0;
        }

        public Complex(Double re, Double im)
        {
            this.Re = re;
            this.Im = im;
        }

        public static Complex operator *(Complex n1, Complex n2)
        {
            return new Complex(n1.Re * n2.Re - n1.Im * n2.Im,
                n1.Im * n2.Re + n1.Re * n2.Im);
        }

        public static Complex operator +(Complex n1, Complex n2)
        {
            return new Complex(n1.Re + n2.Re, n1.Im + n2.Im);
        }

        public static Complex operator -(Complex n1, Complex n2)
        {
            return new Complex(n1.Re - n2.Re, n1.Im - n2.Im);
        }

        public static Complex operator -(Complex n)
        {
            return new Complex(-n.Re, -n.Im);
        }

        public static implicit operator Complex(Double n)
        {
            return new Complex(n, 0);
        }

        public Complex PoweredE()
        {
            Double e = Math.Exp(Re);
            return new Complex(e * Math.Cos(Im), e * Math.Sin(Im));
        }

        public Double Power2()
        {
            return Re * Re - Im * Im;
        }
    }
}
