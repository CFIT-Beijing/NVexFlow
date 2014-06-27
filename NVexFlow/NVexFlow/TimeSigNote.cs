using NVexFlow.MODEL;
using System.Collections.Generic;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class TimeSigNote : Note
            {

                #region 属性字段
                private object boundingBox;

                public override object BoundingBox
                {
                    get { return new BoundingBox(0, 0, 0, 0); }
                }

                private TimeSig timeSig;

                private double width;

                public override double Width
                {
                    get { return width; }
                    set { width = value; }
                }

                private bool ignoreTicks = false;




                #endregion


                #region 方法
                public TimeSigNote(string timeSpec, double customPadding)
                    : base(new KeyValuePair<string, string>("duration", "b"))
                { }

                public void Init(string timeSpec, double customPadding)
                {
                    TimeSignature timeSignature = new Vex.Flow.TimeSignature(timeSpec, customPadding);
                    this.timeSig = timeSignature.TimeSig;
                    this.Width = this.timeSig.Glyph.GetMetrics().Width;

                    //// Note properties
                    this.ignoreTicks = true;
                }

                public TimeSigNote AddToModifierContext()
                {
                    return null;
                }

                public TimeSigNote PreFormat()
                {
                    this.PreFormatted = true;
                    return this;
                }

                public void Draw()
                {

                }
                #endregion
            }
        }
    }
}
