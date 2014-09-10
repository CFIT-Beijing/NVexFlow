namespace System
{
    public struct Fraction:IComparable, IComparable<Fraction>, IEquatable<Fraction>
    {
        public static readonly Fraction NaN = new Fraction(0,0);
        public static readonly Fraction Zero = new Fraction(0,1);
        public static readonly Fraction One = new Fraction(1,1);
        public static readonly Fraction MaxValue = new Fraction(int.MaxValue,1);
        public static readonly Fraction MinValue = new Fraction(-int.MaxValue,1);
        public static readonly Fraction Epsilon = new Fraction(1,int.MaxValue);
        private int numerator;
        private int denominator;
        public int Numerator
        { get { return numerator; } }
        public int Denominator
        { get { return denominator; } }
        public bool IsNaN
        { get { return denominator == 0 || numerator == int.MinValue || denominator == int.MinValue; } }
        public bool IsZero
        { get { return numerator == 0 && !IsNaN; } }
        public bool IsOne
        { get { return numerator == denominator && !IsNaN; } }
        public bool IsPositive
        {
            get
            {
                if(denominator > 0)
                    return numerator > 0;
                if(denominator < 0 && denominator != int.MinValue)
                    return numerator < 0 && numerator != int.MinValue;
                return false;
            }
        }
        public bool IsNegative
        {
            get
            {
                if(denominator > 0)
                    return numerator < 0 && numerator != int.MinValue;
                if(denominator < 0 && denominator != int.MinValue)
                    return numerator > 0;
                return false;
            }
        }
        /// <summary>
        /// 用两个int表示分数的struct。提供简单的四则运算和类型转换。
        /// 分子分母绝对值均应不超过int.MaxValue，否则为Fraction.NaN。
        /// </summary>
        /// <param name="numerator">分数的分子（分数线上面的数）</param>
        /// <param name="denominator">分数的分母（分数线下面的数）</param>
        public Fraction(int numerator,int denominator)
        {
            if(numerator == int.MinValue || denominator == int.MinValue)
            {
                this.numerator = 0;
                this.denominator = 0;
                return;
            }
            this.numerator = numerator;
            this.denominator = denominator;
        }
        /// <summary>
        /// 用两个int表示分数的struct。提供简单的四则运算和类型转换。
        /// 具有约分化简功能的构造函数。
        /// </summary>
        /// <param name="numerator">分数的分子（分数线上面的数）</param>
        /// <param name="denominator">分数的分母（分数线下面的数）</param>
        public Fraction(long long_numerator,long long_denominator)
        {
            if(long_denominator == 0L)
            {
                this.numerator = 0;
                this.denominator = 0;
                return;
            }
            if(long_numerator == 0L)
            {
                this.numerator = 0;
                this.denominator = 1;
                return;
            }
            long a = long_numerator;
            long b = long_denominator;
            long t;
            while(b != 0L)
            {
                t = b;
                b = a % b;
                a = t;
            }
            long_numerator /= a;
            long_denominator /= a;
            if(long_numerator < -int.MaxValue || long_numerator > int.MaxValue ||
                long_denominator < -int.MaxValue || long_denominator > int.MaxValue)
            {
                this.numerator = 0;
                this.denominator = 0;
                return;
            }
            this.numerator = (int)long_numerator;
            this.denominator = (int)long_denominator;
            if(this.denominator < 0)
            {
                this.numerator = -this.numerator;
                this.denominator = -this.denominator;
            }
        }
        public static implicit operator Fraction(int a)
        {
            return new Fraction(a,1);
        }
        public static implicit operator double (Fraction a)
        {
            if(a.IsNaN)
                return double.NaN;
            if(a.IsZero)
                return 0.0;
            if(a.IsOne)
                return 1.0;
            return (double)a.numerator / a.denominator;
        }
        public static Fraction operator +(Fraction a,Fraction b)
        {
            if(a.IsNaN || b.IsNaN)
                return NaN;
            if(a.IsZero)
                return b;
            if(b.IsZero)
                return a;
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
            return a + -b;
        }
        public static Fraction operator -(Fraction a)
        {
            if(a.IsNaN)
                return NaN;
            if(a.IsZero)
                return Zero;
            return new Fraction(-a.numerator,a.denominator);
        }
        public static Fraction operator *(Fraction a,Fraction b)
        {
            if(a.IsNaN || b.IsNaN)
                return NaN;
            if(a.IsZero || b.IsZero)
                return Zero;
            if(a.IsOne)
                return b;
            if(b.IsOne)
                return a;
            long n = a.numerator;
            n *= b.numerator;
            long d = a.denominator;
            d *= b.denominator;
            return new Fraction(n,d);
        }
        public static Fraction operator /(Fraction a,Fraction b)
        {
            return a * Reciprocal(b);
        }
        public static Fraction Reciprocal(Fraction a)
        {
            if(a.IsNaN || a.IsZero)
                return NaN;
            if(a.IsOne)
                return One;
            return new Fraction(a.denominator,a.numerator);
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
            return a.CompareTo(b) == 0;
        }
        public static bool operator !=(Fraction a,Fraction b)
        {
            return a.CompareTo(b) != 0;
        }
        public int CompareTo(object obj)
        {
            if(obj is Fraction)
                return CompareTo((Fraction)obj);
            throw new ArgumentException();
        }
        public int CompareTo(Fraction other)
        {
            if(this.IsNaN && !other.IsNaN)
                return -1;
            if(this.IsNaN && other.IsNaN)
                return 0;
            if(!this.IsNaN && other.IsNaN)
                return 1;
            //(!this.IsNaN && !other.IsNaN)
            if(this.IsPositive && !other.IsPositive)
                return 1;
            if(!this.IsPositive && other.IsPositive)
                return -1;
            long an = numerator;
            an *= other.denominator;
            long bn = other.numerator;
            bn *= denominator;
            return Math.Sign(an - bn) * Math.Sign(denominator) * Math.Sign(other.denominator);
        }
        public bool Equals(Fraction other)
        {
            return CompareTo(other) == 0;
        }
        public override bool Equals(object obj)
        {
            if(obj is Fraction)
                return Equals((Fraction)obj);
            return false;
        }
        public override int GetHashCode()
        {
            return ((double)this).GetHashCode();
        }
        public override string ToString()
        {
            if(this.IsNaN)
                return double.NaN.ToString();
            if(this.IsZero)
                return "0";
            if(this.IsOne)
                return "1";
            return "(" + numerator + "/" + denominator + ")";
        }
        /// <summary>
        /// 没找到哪个方法对应multiply，先写个假的你看到了再改
        /// </summary>
        /// <returns></returns>
        public Fraction Multiply(object param1,object param2)
        {
            return 0;
        }
    }
}
