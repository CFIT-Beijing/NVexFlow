using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZhCJB.VexFlow.CS.MODEL;

namespace ZhCJB.VexFlow.CS
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class ClefNote:Note
            {
                #region 属性字段
                private ClefType clef;

                public ClefType Clef
                {
                    get { return clef; }
                    set
                    {
                        clef = value;
                        this.glyph = new Glyph(this.clef.Code, this.clef.Point, null);
                        this.Width = this.glyph.GetMetrics().Width;
                    }
                }

                private Glyph glyph;

                private double width;

                private BoundingBox boundingBox;

                public BoundingBox BoundingBox
                {
                    get { return new BoundingBox(0, 0, 0, 0); }
                    set { boundingBox = value; }
                }

                public double Width
                {
                    get { return width; }
                    set { width = value; }
                }

                private bool ignoreTicks = false;





                #endregion


                #region 方法
                public ClefNote(string clef)
                    : base(new KeyValuePair<string, string>("duration", "b"))
                { }

                public void Init(string clef)
                {
                    this.Clef = Vex.Flow.Clef.Types[clef];
                    this.ignoreTicks = true;
                }

                public ClefNote AddToModifierContext()
                {
                    return null;
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
            }
        }
    }
}
