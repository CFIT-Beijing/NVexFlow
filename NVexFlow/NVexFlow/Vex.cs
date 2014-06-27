using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVexFlow
{
    public partial class Vex
    {
        public static IList<object> Merge(IList<object> objs1, IList<object> objs2)
        {
            return objs1.Concat(objs2).ToList();
        }

        public static double Min(double a, double b)
        {
            return (a > b) ? b : a;
        }

        public static double Max(double a, double b)
        {
            return (a > b) ? a : b;
        }


        public static double RoundN(double x, double n)
        {
            return 0;
        }


        public static double MidLine(double a, double b)
        {
            return 0;
        }


        public static IList<object> SortAndUnique(IList<object> arr, IComparer<object> cmp, Delegate eq)
        {
            return null;;
        }

        public static bool Contains<T>(IList<T> arr, T a)
        {
            return false;
        }

        public static object GetCanvasContext(object canvasSel)
        {
            return null;
        }

        public void DrawDot(object ctx, double x, double y, object color)
        { }

        public void BM(object s, object f)
        { }
    }
}
