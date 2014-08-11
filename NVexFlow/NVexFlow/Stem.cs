using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    public class Stem
    {
        public Stem(StemOpts options)
        {
            Init(options);
        }

        public static int UP = 1;
        public static int Down = -1;
        // Theme
        //Stem.WIDTH = Vex.Flow.STEM_WIDTH;
        //Stem.HEIGHT = Vex.Flow.STEM_HEIGHT;
        public static double WIDTH;
        public static double HEIGHT;
        public bool hide;
        private void Init(StemOpts options)
        { }

        private object x_begin;
        private object x_end;
        public Stem SetNoteHeadXBounds(object x_begin,object x_end)
        {
            this.x_begin = x_begin;
            this.x_end = x_end;
            return this;
        }

        private object stem_direction;

        public object Direction
        {
            set
            { stem_direction = value; }
        }

        private object stem_extension;

        public object Extension
        {
            set
            { stem_extension = value; }
        }

        private double y_top;
        private double y_bottom;
        public Stem SetYBounds(double y_top,double y_bottom)
        {
            this.y_top = y_top;
            this.y_bottom = y_bottom;
            return this;
        }

        private string category;

        public string Category
        {
            get
            { return "stem"; }
        }

        private object context;

        public object Context
        {
            set
            { context = value; }
        }

        public double GetHeight()
        {
            return 0;
        }

        public void GetBoundingBox()
        { }

        public object GetExtents()
        { return null; }

        public void Draw()
        { }
    }
}
