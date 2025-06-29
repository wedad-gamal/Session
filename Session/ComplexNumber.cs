namespace Session
{
    public class ComplexNumber
    {
        public int Real { get; set; }
        public int Imaginary { get; set; }
        public ComplexNumber()
        {

        }
        public ComplexNumber(int real, int imag)
        {
            Real = real;
            Imaginary = imag;
        }

        public override string ToString()
        {
            return $"{Real} + {Imaginary}i";
        }

        public static ComplexNumber operator +(ComplexNumber left, ComplexNumber right)
        {
            return new ComplexNumber()
            {
                Real = (left?.Real ?? 0) + (right?.Real ?? 0),
                Imaginary = (left?.Imaginary ?? 0) + (right?.Imaginary ?? 0)
            };
        }
        public static ComplexNumber operator +(ComplexNumber left, int right)
        {
            return new ComplexNumber()
            {
                Real = (left?.Real ?? 0) + right,
                Imaginary = left?.Imaginary ?? 0
            };
        }
        public static ComplexNumber operator +(int left, ComplexNumber right)
        {
            //return new ComplexNumber()
            //{
            //    Real = left + (right?.Real ?? 0),
            //    Imaginary = right?.Imaginary ?? 0
            //};
            return right + left;
        }
        public static ComplexNumber operator ++(ComplexNumber left)
        {
            return new ComplexNumber()
            {
                Real = left?.Real + 1 ?? 0,
                Imaginary = left?.Imaginary ?? 0
            };
        }
        public static bool operator ==(ComplexNumber left, ComplexNumber right)
        {
            return (left?.Real == right?.Real) && (left?.Imaginary == right?.Imaginary);
        }
        public static bool operator !=(ComplexNumber left, ComplexNumber right)
        {
            return (left?.Real != right?.Real) || (left?.Imaginary != right?.Imaginary);
        }

        public static bool operator >(ComplexNumber left, ComplexNumber right)
        {
            return (left?.Real > right?.Real);
        }
        public static bool operator <(ComplexNumber left, ComplexNumber right)
        {
            return (left?.Real < right?.Real);
        }
        public static bool operator >=(ComplexNumber left, ComplexNumber right)
        {
            return (left?.Real >= right?.Real);
        }
        public static bool operator <=(ComplexNumber left, ComplexNumber right)
        {
            return (left?.Real <= right?.Real);
        }

        //implicit casting operator overloading
        //ComplexNumber c1 = 10;
        public static implicit operator ComplexNumber(int value)
        {
            return new ComplexNumber()
            {
                Real = value,
                Imaginary = 0
            };
        }
        //explicit casting operator overloading
        //int i = (int)c1;
        public static explicit operator int(ComplexNumber value)
        {
            return value?.Real ?? 0;
        }


    }
}
