﻿////对应 clefnote.js
using NVexFlow.Model;
using System;
using System.Collections.Generic;

namespace NVexFlow
{
    public class ClefNote:Note
    {
        #region js直译部分
        public ClefNote(string clef)
            : base(new ClefNoteStruct() { duration = "b" })
        { }
        private void Init(string clef)
        {
            this.SetClef(NVexFlow.Clef.clefTypes[clef]);
            // Note properties
            this.ignore_ticks = true;
        }
        public ClefType GetClef()
        {
            return clef;
        }
        public ClefNote SetClef(ClefType clef)
        {
            this.clef = clef;//外界这样赋值  this.clef= Vex.Flow.Clef.Types["treble"];
            this.glyph = new Glyph(this.clef.code, this.clef.point);
            this.SetWidth(this.glyph.Metrics.Width);
            return this;
        }
        public new ClefNote SetStave(Stave stave)
        {
            base.stave = stave;//这里这样写感觉不合适，建议base.SetStave(stave);
            return this;
        }
        public override BoundingBox GetBoundingBox()
        {
            return new BoundingBox(0, 0, 0, 0);
        }
        public ClefNote AddToModifierContext()
        {
            /* overridden to ignore */
            return this;
        }
        public new ClefNote PreFormat()
        {
            this.SetPreFormatted(true);
            return this;
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region 隐含字段
        public ClefType clef;
        public new Glyph glyph;
        #endregion

        public override string GetCategory()
        {
            throw new System.NotImplementedException();
        }
    }
}
