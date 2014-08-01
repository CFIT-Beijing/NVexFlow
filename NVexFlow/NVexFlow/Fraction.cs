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
        public bool IsZero
        {
            get
            {
                return numerator == 0 && denominator != 0;
            }
        }
        public bool IsNaN
        {
            get
            {
                return denominator == 0;
            }
        }
        /// <summary>
        /// 用两个int表示分数的struct。提供简单的四则运算和类型转换。
        /// </summary>
        /// <param name="numerator">分数的分子（分数线上面的数）</param>
        /// <param name="denominator">分数的分母（分数线下面的数）</param>
        public Fraction(int numerator,int denominator)
        {
            if(numerator == int.MinValue || denominator == int.MinValue) {
                this.numerator = 0;
                this.denominator = 0;
                return;
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }
        private Fraction(long numerator,long denominator)
        {
            if(denominator == 0L) {
                this.numerator = 0;
                this.denominator = 0;
                return;
            }
            long a = numerator;
            long b = denominator;
            long t;
            while(b != 0) {
                t = b;
                b = a % b;
                a = t;
            }
            numerator /= a;
            denominator /= a;
            if(numerator < -int.MaxValue || numerator > int.MaxValue ||
                denominator < -int.MaxValue || denominator > int.MaxValue) {
                this.numerator = 0;
                this.denominator = 0;
                return;
            }
            if(denominator < 0L) {
                numerator = -numerator;
                denominator = -denominator;
            }
            this.numerator = (int)numerator;
            this.denominator = (int)denominator;
        }
        public static implicit operator Fraction(int a)
        {
            return new Fraction(a,1);
        }
        public static implicit operator double (Fraction a)
        {
            if(a.denominator == 0) {
                return double.NaN;
            }
            return ((double)a.numerator) / a.denominator;
        }
        public static Fraction operator +(Fraction a,Fraction b)
        {
            if(a.denominator == 0 || b.denominator == 0) {
                return new Fraction(0,0);
            }
            long an = a.numerator;
            an *= b.denominator;
            long bn = b.numerator;
            bn *= a.denominator;
            long d = a.denominator;
            d *= b.denominator;
            return new Fraction(an + bn,d);
        }
        public static Fraction operator -(Fraction a,Fraction b)
        {
            if(a.denominator == 0 || b.denominator == 0) {
                return new Fraction(0,0);
            }
            long an = a.numerator;
            an *= b.denominator;
            long bn = b.numerator;
            bn *= a.denominator;
            long d = a.denominator;
            d *= b.denominator;
            return new Fraction(an - bn,d);
        }
        public static Fraction operator -(Fraction a)
        {
            return new Fraction(-a.numerator,a.denominator);
        }
        public static Fraction operator *(Fraction a,Fraction b)
        {
            if(a.denominator == 0 || b.denominator == 0) {
                return new Fraction(0,0);
            }
            long n = a.numerator;
            n *= b.numerator;
            long d = a.denominator;
            d *= b.denominator;
            return new Fraction(n,d);
        }
        public static Fraction operator /(Fraction a,Fraction b)
        {
            if(a.denominator == 0 || b.denominator == 0) {
                return new Fraction(0,0);
            }
            long n = a.numerator;
            n *= b.denominator;
            long d = a.denominator;
            d *= b.numerator;
            return new Fraction(n,d);
        }
        public static bool operator <(Fraction a,Fraction b)
        {
            return a.CompareTo(b) < 0;
        }
        public static bool operator >(Fraction a,Fraction b)
        {
            return a.CompareTo(b) > 0;
        }
        public static bool operator <=(Fraction a,Fraction b)
        {
            return a.CompareTo(b) <= 0;
        }
        public static bool operator >=(Fraction a,Fraction b)
        {
            return a.CompareTo(b) >= 0;
        }
        public static bool operator ==(Fraction a,Fraction b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(Fraction a,Fraction b)
        {
            return !a.Equals(b);
        }
        public int CompareTo(object obj)
        {
            if(obj is Fraction) {
                return CompareTo((Fraction)obj);
            }
            throw new ArgumentException();
        }
        public int CompareTo(Fraction other)
        {
            if(this.denominator == 0 && other.denominator == 0) {
                return 0;
            }
            long thisn = this.numerator;
            thisn *= other.denominator;
            long othern = other.numerator;
            othern *= this.denominator;
            long diff = thisn - othern;
            if(diff < int.MinValue) {
                return int.MinValue;
            }
            if(diff > int.MaxValue) {
                return int.MaxValue;
            }
            return (int)diff;
        }
        public bool Equals(Fraction other)
        {
            return this.CompareTo(other) == 0;
        }
    }
}
