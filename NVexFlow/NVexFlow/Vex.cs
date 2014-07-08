using System;
//这个文件目前这样就可以了，不需要实现其中任何方法
//留着这些方法将来检查所有引用使用
//原则上不应该被使用才对
namespace NVexFlow
{
    /// <summary>
    /// This file implements utility methods used by the rest of the VexFlow
    /// </summary>
    public partial class Vex
    {
        /// <summary>
        /// Default log function sends all arguments to console.
        /// </summary>
        public static void L(object block,object args)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Default runtime exception.
        /// </summary>
        public static void RuntimeError(object code,object message)
        {
            throw new NotImplementedException();
        }
        //Vex.RuntimeError.prototype.toString = function()
        //{
        //    return "RuntimeError: "+this.message;
        //};
        /// <summary>
        /// Shortcut method for `RuntimeError`.
        /// </summary>
        public static void RERR(object code,object message)
        {
            RuntimeError(code,message);
        }
        //destination和source应该是不同的类型，所以你之前用泛型肯定行不通
        /// <summary>
        /// Merge `destination` hash with `source` hash, overwriting like keys
        /// in `source` if necessary.
        /// </summary>
        public static object Merge(object destination,object source)
        {
            throw new NotImplementedException();
        }
        //DEPRECATED表示过时的，我们不再体现过时的方法。
        //翻译其它代码时切记把Vex.Min和Vex.Max
        //用.NET对应的Math.Min和Math.Max
        //// DEPRECATED. Use `Math.min`.
        //Vex.Min = function(a,b)
        //{
        //    return (a>b) ? b : a;
        //};
        //// DEPRECATED. Use `Math.max`.
        //Vex.Max = function(a,b)
        //{
        //    return (a>b) ? a : b;
        //};

        /// <summary>
        /// Round number to nearest fractional value (`.5`, `.25`, etc.)
        /// </summary>
        public static double RoundN(double x,double n)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Locate the mid point between stave lines. Returns a fractional line if a space.
        /// </summary>
        public static double MidLine(double a,double b)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Take `arr` and return a new list consisting of the sorted, unique,
        /// contents of arr. Does not modify `arr`.
        /// </summary>
        public static object SortAndUnique(object arr,object cmp,object eq)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Check if array `a` contains `obj`.
        /// </summary>
        public static bool Contains(object a,object obj)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get the 2D Canvas context from DOM element `canvas_sel`.
        /// </summary>
        public static object GetCanvasContext(object canvasSel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Draw a tiny dot marker on the specified canvas. A great debugging aid.
        /// `ctx`: Canvas context.
        /// `x`, `y`: Dot coordinates.
        /// </summary>
        public static void DrawDot(object ctx,double x,double y,object color)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Benchmark. Run function `f` once and report time elapsed shifted by `s` milliseconds.
        /// </summary>
        public static void BM(object s,object f)
        {
            throw new NotImplementedException();
        }
    }
}
