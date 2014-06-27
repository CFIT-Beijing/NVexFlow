using System.Collections.Generic;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class BarNote : Note
            {
                #region 属性字段
                Barline.BarlineType type;

                public Barline.BarlineType Type
                {
                    get { return type; }
                    set { type = value; }
                }

                object metrics;
                // Defined this way to prevent lint errors.
                //this.metrics.widths[TYPE.SINGLE] = 8;
                //this.metrics.widths[TYPE.DOUBLE] = 12;
                //this.metrics.widths[TYPE.END] = 15;
                //this.metrics.widths[TYPE.REPEAT_BEGIN] = 14;
                //this.metrics.widths[TYPE.REPEAT_END] = 14;
                //this.metrics.widths[TYPE.REPEAT_BOTH] = 18;
                //this.metrics.widths[TYPE.NONE] = 0;


                bool ignoreTicks;



                #endregion


                #region 方法

                public BarNote()
                    : base(new KeyValuePair<string, string>("duration", "b"))
                { }

                public void Init()
                {

                }



                public BoundingBox GetBoundingBox()
                {
                    return new BoundingBox(0, 0, 0, 0); ;
                }

                public BarNote AddToModifierContext()
                {
                    return this;
                }

                public override void PreFormat()
                {
                    base.PreFormat();
                }

                public void Draw()
                { }
                #endregion
            }
        }
    }
}
