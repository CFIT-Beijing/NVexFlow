namespace System
{
    public struct Fraction:IComparable, IComparable<Fraction>, IEquatable<Fraction>
    {
        private int numerator;
        private int denominator;
        public int Numerator
        {
            get
            {
                return numerator;
            }
        }
        public int Denominator
        {
            get
            {
                return denominator;
            }
        }
        public static readonly Fraction Epsilon = new Fraction(-1,int.MinValue);
        public static readonly Fraction MaxValue = new Fraction(int.MinValue,-1);
        public static readonly Fraction MinValue = new Fraction(int.MinValue,1);
        public static readonly Fraction NaN = new Fraction(0,0);
        public static readonly Fraction PositiveInfinity = new Fraction(1,0);
        public static readonly Fraction NegativeInfinity = new Fraction(-1,0);
        public Fraction(int numerator,int denominator)
        {
            this.numerator=numerator;
            this.denominator=denominator;
        }
        public static implicit operator Fraction(int fraction)
        {
            return new Fraction(fraction,1);
        }
        public static implicit operator double (Fraction fraction)
        {
            if(fraction.denominator==0) {
                if(fraction.numerator>0) {
                    return double.PositiveInfinity;
                }
                else if(fraction.numerator<0) {
                    return double.NegativeInfinity;
                }
                else {
                    return double.NaN;
                }
            }
            return ((double)fraction.numerator)/fraction.denominator;
        }
        public static Fraction operator +(Fraction a,Fraction b)
        {
            if(a.denominator==0) {
                if(b.denominator==0) {
                    if(a.numerator>0) {

                    }
                }
            }
            throw new NotImplementedException();
        }
        public static Fraction operator -(Fraction a,Fraction b)
        {
            throw new NotImplementedException();
        }
        public static Fraction operator -(Fraction a)
        {
            throw new NotImplementedException();
        }
        public static Fraction operator *(Fraction a,Fraction b)
        {
            throw new NotImplementedException();
        }
        public static Fraction operator /(Fraction a,Fraction b)
        {
            throw new NotImplementedException();
        }
        public static Fraction Simplify(Fraction fraction)
        {
            if(fraction.denominator==0)
                return fraction;
            int a = fraction.numerator;
            int b = fraction.denominator;
            int t;
            while(b!=0) {
                t=b;
                b=a%b;
                a=t;
            }
            int nn = fraction.numerator/a;
            int nd = fraction.denominator/a;
            if(nd>0) {
                return new Fraction(-nn,-nd);
            }
            else {
                return new Fraction(nn,nd);
            }
        }
        public static int Sign(Fraction fraction)
        {
            if(fraction.denominator<0) {
                if(fraction.numerator>0) {
                    return -1;
                }
                else if(fraction.numerator<0) {
                    return 1;
                }
                else {
                    return 0;
                }
            }
            else {
                if(fraction.numerator>0) {
                    return 1;
                }
                else if(fraction.numerator<0) {
                    return -1;
                }
                else {
                    return 0;
                }
            }
        }
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
        public int CompareTo(Fraction other)
        {
            throw new NotImplementedException();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public bool Equals(Fraction other)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
