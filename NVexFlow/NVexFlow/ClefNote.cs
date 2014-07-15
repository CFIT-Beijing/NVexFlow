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
                    : base(new NoteStruct() { duration="b"})
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
                        this.Width = this.glyph.GetMetrics().Width;
                    }
                }
                public override Stave Stave
                {
                    set
                    {
                        //var superclass = Vex.Flow.ClefNote.superclass;
                        //superclass.setStave.call(this, stave);
                        //这里的意思是，这样显示的声明，才说明我要在子类的方法中调用父类的赋值方法。
                        //目前我们的做法是不管他是否这样显示的声明，通通忽略base和this的差异，一律使用base的protected的stave？这就是上次说的翻译时语义上存在差异，但是执行结果不一定受影响，主要还是看他后面怎么用的

                        this.stave = value;//这里的stave是父类的protected的stave，在这里这样用是对的，但是其他地方我们也都是这样用的
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
            }
        }
    }
}
