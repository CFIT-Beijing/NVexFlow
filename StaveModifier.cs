using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZhCJB.VexFlow.CS
{//StaveModifier
    public partial class Vex
    {
        public partial class Flow
        {
            public class StaveModifier
            {
                #region 属性字段
                double padding;

                public virtual double Padding
                {
                    get { return padding; }
                    set { padding = value; }
                } 
                #endregion


                #region 方法

                public StaveModifier()
                {
                    Init();
                }

                public void Init()
                {
                    this.padding = 10;
                }


                public IList<object> MakeSpacer(double padding)
                {
                    //返回一堆函数，不同类型。。。
                    return null;
                }



                public void PlaceGlyphOnLine(Glyph glyph, Stave stave, object line)
                {
                    glyph.Y_shift = stave.GetYForLine(line) - stave.GetYForGlyph();
                }


                public StaveModifier AddToStave(Stave stave, Glyph firstGlyph)
                {
                    if (firstGlyph == null)
                    {
                        //stave.addGlyph(this.makeSpacer(this.padding)); 此处类型有问题
                    }
                    this.AddModifier(stave);
                    return this;
                }

                public StaveModifier AddToStaveEnd(Stave stave, Glyph firstGlyph)
                {
                    if (firstGlyph == null)
                    {
                        //    stave.addEndGlyph(this.makeSpacer(this.padding));
                    }
                    else
                    {
                        //    stave.addEndGlyph(this.makeSpacer(2));
                    }
                    this.AddEndModifier(stave);
                    return this;
                }

                public virtual void AddModifier(Stave stave)
                {
                    //  throw new Vex.RERR("MethodNotImplemented",
                    //      "addModifier() not implemented for this stave modifier.");
                }

                public virtual void AddEndModifier(Stave stave)
                {
                    //  throw new Vex.RERR("MethodNotImplemented",
                    //      "addEndModifier() not implemented for this stave modifier.");
                } 
                #endregion

            }
        }
    }
}
