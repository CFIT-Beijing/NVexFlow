using System.Collections.Generic;
using System;
using NVexFlow.Model;

namespace NVexFlow
{
    public class Metrics
    {
        private double x_Min;

        public double X_Min
        {
            get
            { return x_Min; }
            set
            { x_Min = value; }
        }
        private double x_Max;

        public double X_Max
        {
            get
            { return x_Max; }
            set
            { x_Max = value; }
        }
        //TextNote直接使用了width字段
        public double width;

        public double Width
        {
            get
            { return width; }
            set
            { width = value; }
        }
        private double height;

        public double Height
        {
            get
            { return height; }
            set
            { height = value; }
        }
    }


    public class Glyph
    {
        public static void LoadMetrics(object font,string code,object cache)
        { }

        public static void RenderOutline(object ctx,object outline,object scale,double x_pos,double y_pos)
        { }

        private double x_shift;

        public double X_shift
        {
            get
            { return x_shift; }
            set
            { x_shift = value; }
        }
        private double y_shift;

        public double Y_shift
        {
            get
            { return y_shift; }
            set
            { y_shift = value; }
        }
        private object stave;

        public object Stave
        {
            get
            { return stave; }
            set
            { stave = value; }
        }
        IList<object> options;

        public IList<object> Options
        {

            set
            {
                //重写
                options = value;
            }
        }

        object context;

        public object Context
        {
            get
            { return context; }
            set
            { context = value; }
        }


        public Glyph(string code,int point,GlyphsOpts options = null)
        {

        }

        public Metrics Metrics
        {
            get
            { throw new NotImplementedException(); }
        }

        public void Reset()
        { }

        public void Render(object ctx,double x_pos,double y_pos)
        { }

        public void RenderToStave(double x)
        { }

        //setXShift: function(xShift) { this.xShift = xShift; return this; },
        //setYShift: function(yShift) { this.yShift = yShift; return this; },
        //setContext: function(context) { this.context = context; return this; },
        //getContext: function() { return this.context; },
    }
}
