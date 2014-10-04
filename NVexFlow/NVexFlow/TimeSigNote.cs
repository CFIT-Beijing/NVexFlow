﻿//对应 timeSigNote.js
using System;
using NVexFlow.Model;

namespace NVexFlow
{
    public class TimeSigNote:Note
    {
        #region js直译部分
        public TimeSigNote(string timeSpec,double customPadding)
            : base(new NoteStruct() { duration = "b" })
        { }
        private void Init(string timeSpec,double customPadding)
        {
            TimeSignature timeSignature = new TimeSignature(timeSpec,customPadding);
            this.time_sig = timeSignature.GetTimeSig();
            this.SetWidth(this.time_sig.glyph.Metrics.Width);
            //// Note properties
            this.ignore_ticks = true;
        }
        public new TimeSigNote SetStave(Stave stave)
        {
            base.SetStave(stave);
            return this;
        }
        public override BoundingBox GetBoundingBox()
        {
            return new BoundingBox(0, 0, 0, 0);
        }
        public TimeSigNote AddToModifierContext()
        {
            //* overridden to ignore */
            return this;
        }
        public new TimeSigNote PreFormat()
        {
            this.SetPreFormatted(true);
            return this;
        }
        public override void Draw()
        {

        }
        #endregion


        #region 隐含字段
        public TimeSig time_sig;
        public override string GetCategory()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
