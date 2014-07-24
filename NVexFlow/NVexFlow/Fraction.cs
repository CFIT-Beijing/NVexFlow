namespace System
{
    public struct Fraction
    {
        private int numerator;
        private int denominator;
        /// <summary>
        /// 用两个int表示分数的struct。提供简单的四则运算和类型转换。
        /// </summary>
        /// <param name="numerator">分数的分子（分数线上面的数）</param>
        /// <param name="denominator">分数的分母（分数线下面的数）</param>
        public Fraction(int numerator,int denominator)
        {
            if(numerator==int.MinValue||denominator==int.MinValue) {
                this.numerator=0;
                this.denominator=0;
                return;
            }
            this.numerator=numerator;
            this.denominator=denominator;
        }
        private Fraction(long numerator,long denominator)
        {
            if(denominator==0L) {
                this.numerator=0;
                this.denominator=0;
                return;
            }
            long a = numerator;
            long b = denominator;
            long t;
            while(b!=0) {
                t=b;
                b=a%b;
                a=t;
            }
            numerator/=a;
            denominator/=a;
            if(numerator<-int.MaxValue||numerator>int.MaxValue||
                denominator<-int.MaxValue||denominator>int.MaxValue) {
                this.numerator=0;
                this.denominator=0;
                return;
            }
            if(denominator<0L) {
                numerator=-numerator;
                denominator=-denominator;
            }
            this.numerator=(int)numerator;
            this.denominator=(int)denominator;
        }
        public static implicit operator Fraction(int a)
        {
            return new Fraction(a,1);
        }
        public static implicit operator double (Fraction a)
        {
            if(a.denominator==0) {
                return double.NaN;
            }
            return ((double)a.numerator)/a.denominator;
        }
        public static Fraction operator +(Fraction a,Fraction b)
        {
            if(a.denominator==0||b.denominator==0) {
                return new Fraction(0,0);
            }
            long an = a.numerator;
            an*=b.denominator;
            long bn = b.numerator;
            bn*=a.denominator;
            long d = a.denominator;
            d*=b.denominator;
            return new Fraction(an+bn,d);
        }
        public static Fraction operator -(Fraction a,Fraction b)
        {
            if(a.denominator==0||b.denominator==0) {
                return new Fraction(0,0);
            }
            long an = a.numerator;
            an*=b.denominator;
            long bn = b.numerator;
            bn*=a.denominator;
            long d = a.denominator;
            d*=b.denominator;
            return new Fraction(an-bn,d);
        }
        public static Fraction operator -(Fraction a)
        {
            return new Fraction(-a.numerator,a.denominator);
        }
        public static Fraction operator *(Fraction a,Fraction b)
        {
            if(a.denominator==0||b.denominator==0) {
                return new Fraction(0,0);
            }
            long n = a.numerator;
            n*=b.numerator;
            long d = a.denominator;
            d*=b.denominator;
            return new Fraction(n,d);
        }
        public static Fraction operator /(Fraction a,Fraction b)
        {
            if(a.denominator==0||b.denominator==0) {
                return new Fraction(0,0);
            }
            long n = a.numerator;
            n*=b.denominator;
            long d = a.denominator;
            d*=b.numerator;
            return new Fraction(n,d);
        }
    }
}
