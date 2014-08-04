////对应 barnote.js
using System.Collections.Generic;
using NVexFlow.Model;
using System;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            /// ## Description
            //
            // A `BarNote` is used to render bar lines (from `barline.js`). `BarNote`s can
            // be added to a voice and rendered in the middle of a stave. Since it has no
            // duration, it consumes no `tick`s, and is dealt with appropriately by the formatter.
            //
            // See `tests/barnote_tests.js` for usage examples.
            /// </summary>
            public class BarNote : Note
            {
                #region js直译部分
                public BarNote()
                    : base(new BarNoteStruct() { duration = "b" })
                {
                    Init();
                }
                private void Init()
                {
                    //// Defined this way to prevent lint errors.
                    this.metrics = new Model.Metrics();
                    this.metrics.widths.Add(Barline.BarlineType.SINGLE, 8);
                    this.metrics.widths.Add(Barline.BarlineType.DOUBLE, 12);
                    this.metrics.widths.Add(Barline.BarlineType.END, 15);
                    this.metrics.widths.Add(Barline.BarlineType.REPEAT_BEGIN, 14);
                    this.metrics.widths.Add(Barline.BarlineType.REPEAT_END, 14);
                    this.metrics.widths.Add(Barline.BarlineType.REPEAT_BOTH, 18);
                    this.metrics.widths.Add(Barline.BarlineType.NONE, 0);
                    //// Tell the formatter that bar notes have no duration
                    this.ignoreTicks = true;
                    this.type = Barline.BarlineType.SINGLE;
                    // Set width to width of relevant `Barline`.
                    this.SetWidth(this.metrics.widths[this.type]);
                }
                /// <summary>
                /// Get and set the type of Bar note. `type` must be one of `Vex.Flow.Barline.type`.
                /// </summary>
                public Barline.BarlineType Type
                {
                    get { return this.type; }
                    set
                    {
                        this.type = value;
                        this.SetWidth(this.metrics.widths[this.type]);
                    }
                }
                public BoundingBox GetBoundingBox()
                {
                    return new BoundingBox(0, 0, 0, 0); ;
                }
                public BarNote AddToModifierContext()
                {
                    /* overridden to ignore */
                    return this;
                }
                public BarNote PreFormat()
                {
                    this.PreFormatted = true;
                    return this;
                }
                /// <summary>
                /// // Render note to stave.
                /// </summary>
                public void Draw()
                {
                    throw new System.NotImplementedException();
                }
                #endregion


                #region 隐含的字段
                protected Barline.BarlineType type;
                protected Model.Metrics metrics;
                public override string Category
                {
                    get { throw new NotImplementedException(); }
                }
                #endregion

            }
        }
    }
}
