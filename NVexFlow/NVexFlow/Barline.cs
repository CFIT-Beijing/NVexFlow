
namespace NVexFlow
{//Barline
    public partial class Vex
    {
        public partial class Flow
        {
            public class Barline : StaveModifier
            {
                #region 属性字段
                public enum BarlineType
                {
                    SINGLE,
                    DOUBLE,
                    END,
                    REPEAT_BEGIN,
                    REPEAT_END,
                    REPEAT_BOTH,
                    NONE
                }

                private double x;

                public double X
                {
                    get { return x; }
                    set { x = value; }
                }

                private object barLine;
                #endregion


                #region 方法
                public Barline(BarlineType type, double x)
                {
                    Init(type, x);
                }

                public void Init(BarlineType type, double x)
                { }


                //////////
                //draw: function(stave, xShift)
                //drawVerticalBar: function(stave, x, double_bar)
                // drawVerticalEndBar: function(stave, x)
                //drawRepeatBar: function(stave, x, begin)

                public void Draw(object stave, double x_shift)
                { }

                public void DrawVerticalBar(object stave, double x, object double_bar)
                { }

                public void DrawVerticalEndBar(object stave, double x)
                { }

                public void DrawRepeatBar(object stave, double x, object begin)
                { }
                #endregion
            }
        }
    }
}
