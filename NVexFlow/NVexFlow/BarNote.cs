﻿////对应 barnote.js
using System.Collections.Generic;
using NVexFlow.Model;
using System;

namespace NVexFlow
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
    public class BarNote:Note
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
            this.metrics = new NoteMetrics();
            this.metrics.widths.Add(Barline.BarlineType.SINGLE,8);
            this.metrics.widths.Add(Barline.BarlineType.DOUBLE,12);
            this.metrics.widths.Add(Barline.BarlineType.END,15);
            this.metrics.widths.Add(Barline.BarlineType.REPEAT_BEGIN,14);
            this.metrics.widths.Add(Barline.BarlineType.REPEAT_END,14);
            this.metrics.widths.Add(Barline.BarlineType.REPEAT_BOTH,18);
            this.metrics.widths.Add(Barline.BarlineType.NONE,0);
            //// Tell the formatter that bar notes have no duration
            this.ignore_ticks = true;
            this.type = Barline.BarlineType.SINGLE;
            // Set width to width of relevant `Barline`.
            this.SetWidth(this.metrics.widths[this.type]);
        }
        /// <summary>
        /// Get and set the type of Bar note. `type` must be one of `Vex.Flow.Barline.type`.
        /// </summary>
        public Barline.BarlineType GetBarlineType()
        {
            return this.type;
        }
        public BarNote SetBarlineType(Barline.BarlineType type)
        {
            this.type = type;
            this.SetWidth(this.metrics.widths[this.type]);
            return this;
        }
        public override BoundingBox GetBoundingBox()
        {
            return new BoundingBox(0,0,0,0);
            ;
        }
        public BarNote AddToModifierContext()
        {
            /* overridden to ignore */
            return this;
        }
        public new BarNote PreFormat()
        {
            this.SetPreFormatted(true);
            return this;
        }
        /// <summary>
        /// // Render note to stave.
        /// </summary>
        public override void Draw()
        {
            throw new System.NotImplementedException();
        }
        #endregion


        #region 隐含的字段
        public Barline.BarlineType type;
        public NoteMetrics metrics;
        public override string GetCategory()
        {
            throw new System.NotImplementedException();
        }
        #endregion

    }
}
