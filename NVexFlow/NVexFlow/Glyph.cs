using System.Collections.Generic;
using System;
using NVexFlow.Model;

namespace NVexFlow
{
    public partial class Flow
    {
        /**
         * A quick and dirty static glyph renderer. Renders glyphs from the default
         * font defined in Vex.Flow.Font.
         *
         * @param {!Object} ctx The canvas context.
         * @param {number} x_pos X coordinate.
         * @param {number} y_pos Y coordinate.
         * @param {number} point The point size to use.
         * @param {string} val The glyph code in Vex.Flow.Font.
         * @param {boolean} nocache If set, disables caching of font outline.
         */
        public static void RenderGlyph(CanvasContext ctx,double x_pos,double y_pos,double point,object val,bool nocache = false)
        {
            //var scale = point * 72.0 / (Vex.Flow.Font.resolution * 100.0);
            //var metrics = Vex.Flow.Glyph.loadMetrics(Vex.Flow.Font,val,!nocache);
            //Vex.Flow.Glyph.renderOutline(ctx,metrics.outline,scale,x_pos,y_pos);
        }
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
        public double yShift;
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
}
