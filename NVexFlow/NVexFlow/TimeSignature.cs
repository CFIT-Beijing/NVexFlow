using NVexFlow.MODEL;
using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{//TimeSignature
    public partial class Vex
    {
        public partial class Flow
        {
            public class TimeSignature : StaveModifier
            {
                #region 静态
                public static IDictionary<string, GlyphsModel> glyphs = new Dictionary<string, GlyphsModel>() { 
                 {"C",new GlyphsModel(){code="v41",point=40,line=2}},
                 {"C|",new GlyphsModel(){code="vb6",point=40,line=2}}
                };

                public static IDictionary<string, GlyphsModel> Glyphs
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


                private void Init(string timeSpec, double customPadding)
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
