using System;
using System.Collections.Generic;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            //暂时不细化这个类。这个类是分数运算util类
            public class Fraction
            {
                public Fraction(double numerator, double denominator)
                {

                }

                private double numerator;
                private double denominator;

                public static object GCD(object a, object b)
                {
                    return null;
                }

                public static object LCM(object a, object b)
                {
                    return null;
                }

                public static object LCM(IList<object> @params)
                {
                    return null;
                }

                public Fraction Set(double numerator, double denominator)
                {
                    return this;
                }

                public double Value()
                {
                    return this.numerator / this.denominator;
                }

                public Fraction simplify()
                {
                    return null;
                }

                public Fraction Add(object param1, object param2)
                {
                    return null;
                }


                public Fraction Subtract(object param1, object param2)
                {
                    return null;
                }


                public Fraction Multiply(object param1, object param2)
                {
                    return null;
                }


                public Fraction Divide(object param1, object param2)
                {
                    return null;
                }

                public bool IsEquals(object compare)
                {
                    return false;
                }

                public Fraction Clone()
                {
                    return new Fraction(this.numerator, this.denominator);
                }

                public Fraction Copy(Fraction copy)
                {
                    return new Fraction(copy.numerator, copy.denominator);
                }

                public double Quotient()
                {
                    return Math.Floor(this.numerator / this.denominator);
                }

                public double Fraction2()
                {
                    return this.numerator % this.denominator;
                }

                public Fraction Abs()
                {
                    //this.denominator = Math.abs(this.denominator);
                    //this.numerator = Math.abs(this.numerator);
                    return this;
                }

                public override string ToString()
                {
                    return this.numerator.ToString() + '/' + this.denominator.ToString();
                }

                public string ToSimplifiedString()
                {
                    return "";
                }

                public string ToMixedString()
                {
                    return "";
                }

                public Fraction Parse(string str)
                {
                    return null;
                }
                public static Fraction compareA = new Fraction(0, 0);
                public static Fraction compareB = new Fraction(0, 0);
                public static Fraction tmp = new Fraction(0, 0);
            }
        }
    }
}
