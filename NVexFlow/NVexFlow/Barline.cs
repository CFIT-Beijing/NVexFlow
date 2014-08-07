namespace NVexFlow
{//Barline
    public class Barline:StaveModifier
    {
        #region 属性字段
        public enum BarlineType
        {
            SINGLE = 1,
            DOUBLE = 2,
            END = 3,
            REPEAT_BEGIN = 4,
            REPEAT_END = 5,
            REPEAT_BOTH = 6,
            NONE = 7
        }

        private double x;

        public double X
        {
            get
            { return x; }
            set
            { x = value; }
        }

        private object barLine;
        #endregion


        #region 方法
        public Barline(BarlineType type,double x)
        {
            Init(type,x);
        }

        private void Init(BarlineType type,double x)
        { }


        //////////
        //draw: function(stave, xShift)
        //drawVerticalBar: function(stave, x, double_bar)
        // drawVerticalEndBar: function(stave, x)
        //drawRepeatBar: function(stave, x, begin)

        public void Draw(object stave,double x_shift)
        { }

        public void DrawVerticalBar(object stave,double x,object double_bar)
        { }

        public void DrawVerticalEndBar(object stave,double x)
        { }

        public void DrawRepeatBar(object stave,double x,object begin)
        { }
        #endregion
    }
}
