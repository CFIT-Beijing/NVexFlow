using System.Collections.Generic;
using System;
using NVexFlow.Model;

namespace NVexFlow
{
    public class Metrics
    {
        public double xMin;
        public double xMax;

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

        public object outline;
    }


    public class Glyph
    {
        public double scale;
        public static void LoadMetrics(object font,string code,object cache)
        { }

        public static void RenderOutline(object ctx,object outline,object scale,double x_pos,double y_pos)
        { }

        public double xShift;

        public double X_shift
        {
            get
            { return xShift; }
            set
            { xShift = value; }
        }
        private double yShift;
        public Glyph SetYShift(double yShift)
        {
            this.yShift = yShift;
            return this;
        }
        public double Y_shift
        {
            get
            { return yShift; }
            set
            { yShift = value; }
        }
        public Stave stave;

        public Stave Stave
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


        public Glyph(string code,double point,GlyphsOpts options = null)
        {

        }
        public virtual Metrics GetMetrics()
        {
           throw new NotImplementedException();
        }
        public Metrics Metrics
        {
            get
            { throw new NotImplementedException(); }
        }
        public Metrics metrics;
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
