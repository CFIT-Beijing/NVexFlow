namespace NVexFlow
{
    public class Volta:StaveModifier
    {
        #region 隐含字段
        public enum VoltaType
        {
            NONE,
            BEGIN,
            MID,
            END,
            BEGIN_END
        }

        VoltaType type;

        public VoltaType Type
        {
            get
            { return type; }
            set
            { type = value; }
        }
        double x;

        public double X
        {
            get
            { return x; }
            set
            { x = value; }
        }
        double yShift;

        public double YShift
        {
            get
            { return yShift; }
            set
            { yShift = value; }
        }
        int number;

        public int Number
        {
            get
            { return number; }
            set
            { number = value; }
        }
        Font font;

        public Font Font
        {
            get
            { return font; }
            set
            { font = value; }
        }
        #endregion


        #region js直译部分
        public Volta(VoltaType type,int number,double x,double y_shift)
        {
            Init(type,number,x,y_shift);
        }

        private void Init(VoltaType type,int number,double x,double y_shift)
        {
            this.type = type;
            this.x = x;
            this.yShift = y_shift;
            this.number = number;
            this.font = new Font() {
                family = "sans-serif",
                size = 9,
                weight = "bold"
            };
        }

        public void Draw(Stave stave,double x)
        { }

        #endregion
    }
}
