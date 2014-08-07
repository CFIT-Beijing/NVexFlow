using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{//TickContext
    public class TickContext
    {
        public TickContext()
        { }

        private void Init()
        { }

        object context;

        public object Context
        {
            get
            { return context; }
            set
            { context = value; }
        }

        bool ignore_ticks;

        public bool ShouldIgnoreTicks
        {
            set
            { ignore_ticks = value; }
        }
        double padding;
        public double Padding
        {
            set
            { padding = value; }
        }

        double width;
        public double Width
        {
            get
            {
                return this.width + (this.padding * 2);
            }
        }

        double x;

        public double X
        {
            get
            { return x; }
            set
            { x = value; }
        }

        object pixelsUsed;

        public object PixelsUsed
        {
            get
            { return pixelsUsed; }
            set
            { pixelsUsed = value; }
        }

        IList<object> maxTicks;

        public IList<object> MaxTicks
        {
            get
            { return maxTicks; }
        }
        IList<object> minTicks;
        public IList<object> MinTicks
        {
            get
            { return maxTicks; }
        }
        IList<object> tickables;
        public IList<object> Tickables
        {
            get
            { return maxTicks; }
        }

        public object GetMetrics()
        {
            return null;
        }

        object currentTick;
        object preFormatted;
        public object CurrentTick
        {
            get
            { return currentTick; }
            set
            {
                currentTick = value;
                this.preFormatted = false;
            }
        }

        public TickContextExtraPx ExtraPx
        {
            get
            {
                return null;
            }
        }

        public TickContext AddTickable(object tickable)
        {
            return this;
        }

        public TickContext PreFormat()
        {
            return this;
        }

        public TickContext PostFormat()
        {
            return this;
        }

        public static object GetNextContext(object tContext)
        {
            return null;
        }
    }
}
