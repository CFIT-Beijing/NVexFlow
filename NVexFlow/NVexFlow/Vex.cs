using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NVexFlow
{
    public partial class Vex
    {
        public static IList<object> Merge(IList<object> objs1, IList<object> objs2)
        {
            return objs1.Concat(objs2).ToList();
        }

        //Type类型元数据和其他项目中的Type不一样，可能是项目目标框架的原因？
        // C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETPortable\v4.5\Profile\Profile7\System.Runtime.dll
        // C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5\mscorlib.dll
        public static T Merge<T>(T destination, T source)
        {
            Type type = typeof(T);
            var pros = type.GetRuntimeProperties();
            foreach (var pro in pros)
            {
                pro.SetValue(destination, pro.GetValue(source));
            }
            return destination;
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
            return null;
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
