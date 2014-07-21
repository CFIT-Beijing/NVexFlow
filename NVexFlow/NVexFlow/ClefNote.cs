////对应 clefnote.js
using NVexFlow.Model;
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
                        this.glyph = new Glyph(this.clef.code, this.clef.point, null);
                        //this.Width = this.glyph.GetMetrics().Width;
                    }
                }
                public override Stave Stave
                {
                    set
                    {
                        //var superclass = Vex.Flow.ClefNote.superclass;
                        //superclass.setStave.call(this, stave);
                        //这里的意思是，调用父类的方法，为子类stave字段赋值。赋值完成后，父类的该字段不应该受影响。（父类子类都有stave字段，值不一样）

                        this.stave = value;
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
