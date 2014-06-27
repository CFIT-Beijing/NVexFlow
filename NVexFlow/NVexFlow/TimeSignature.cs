using NVexFlow.MODEL;
using System.Collections.Generic;

namespace NVexFlow
{//TimeSignature
    public partial class Vex
    {
        public partial class Flow
        {
            public class TimeSignature : StaveModifier
            {
                #region 静态
                public static IDictionary<string, Glyphs> glyphs = new Dictionary<string, Glyphs>() { 
                 {"C",new Glyphs(){Code="v41",Point=40,Line=2}},
                 {"C|",new Glyphs(){Code="vb6",Point=40,Line=2}}
                };

                public static IDictionary<string, Glyphs> Glyphs
                {
                    get { return TimeSignature.glyphs; }
                    set { TimeSignature.glyphs = value; }
                }
                #endregion


                #region 属性字段
                private double point;
                private double topLine;
                private double bottomLine;
                private TimeSig timeSig;
                public override double Padding
                {
                    get { return this.Padding; }
                    set { this.Padding = value; }
                }

                public TimeSig TimeSig
                {
                    get { return timeSig; }
                }
                #endregion


                #region 方法
                public TimeSignature(string timeSpec, double customPadding)
                {
                    Init(timeSpec, customPadding);
                }


                public void Init(string timeSpec, double customPadding)
                {
                    double padding = customPadding == 0 ? padding = 15 : padding = customPadding;
                    this.Padding = padding;
                    this.point = 40;
                    this.topLine = 2;
                    this.bottomLine = 4;
                    this.timeSig = ParseTimeSpec(timeSpec);
                }


                public TimeSig ParseTimeSpec(string timeSpec)
                {
                    return null;
                }

                public override void AddModifier(Stave stave)
                {

                }

                public override void AddEndModifier(Stave stave)
                {

                }

                public Glyph MakeTimeSignatureGlyph(object topNums, object botNums)
                {
                    return null;
                }
                #endregion
            }
        }
    }
}
