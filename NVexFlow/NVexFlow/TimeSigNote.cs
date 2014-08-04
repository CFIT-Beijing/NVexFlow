//对应 timeSigNote.js
using NVexFlow.Model;
using System.Collections.Generic;
using System;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class TimeSigNote : Note
            {
                #region js直译部分
                public TimeSigNote(string timeSpec, double customPadding)
                    : base(new NoteStruct() { duration = "b" })
                { }
                private void Init(string timeSpec, double customPadding)
                {
                    TimeSignature timeSignature = new Vex.Flow.TimeSignature(timeSpec, customPadding);
                    this.timeSig = timeSignature.TimeSig;
                    this.SetWidth(this.timeSig.Glyph.Metrics.Width);
                    //// Note properties
                    this.ignoreTicks = true;
                }
                public override Stave Stave
                {
                    set
                    {
                        base.Stave = value;
                    }
                }
                public override object BoundingBox
                {
                    get { return new BoundingBox(0, 0, 0, 0); }
                }
                public TimeSigNote AddToModifierContext()
                {
                    //* overridden to ignore */
                    return this;
                }
                public new TimeSigNote PreFormat()
                {
                    this.PreFormatted = true;
                    return this;
                }
                public void Draw()
                {

                }
                #endregion


                #region 隐含字段
                protected TimeSig timeSig;
                public override string Category
                {
                    get { throw new Exception("js文件没有这个属性。在Modifier分支里有一个属性叫Note，暂时写成了Note类型。为了让不同的Note都能点儿出Category，先在Note里加入了Category"); }
                }
                #endregion


     

                
            }
        }
    }
}
