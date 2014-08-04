////对应 clefnote.js
using NVexFlow.Model;
using System;
using System.Collections.Generic;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class ClefNote : Note
            {
                #region js直译部分
                public ClefNote(string clef)
                    : base(new ClefNoteStruct() { duration="b"})
                { }
                private void Init(string clef)
                {
                    this.Clef = Vex.Flow.Clef.Types[clef];
                    // Note properties
                    this.ignoreTicks = true;
                }
                public ClefType Clef
                {
                    get { return clef; }
                    set
                    {
                        this.clef = value;//外界这样赋值  this.clef= Vex.Flow.Clef.Types["treble"];
                        this.glyph = new Glyph(this.clef.code, this.clef.point);
                        this.SetWidth(this.glyph.Metrics.Width);
                    }
                }
                public override Stave Stave
                {
                    set
                    {
                        base.stave = value;
                    }
                }
                public BoundingBox BoundingBox
                {
                    get { return new BoundingBox(0, 0, 0, 0); }
                }
                public ClefNote AddToModifierContext()
                {
                    /* overridden to ignore */
                    return this;
                }
                public ClefNote PreFormat()
                {
                    this.PreFormatted = true;
                    return this;
                }
                public void Draw()
                {
                    throw new NotImplementedException();
                }
                #endregion


                #region 隐含字段
                private ClefType clef;
                private Glyph glyph;
                private bool ignoreTicks;
                #endregion

                public override string Category
                {
                    get { throw new System.NotImplementedException(); }
                }
            }
        }
    }
}
