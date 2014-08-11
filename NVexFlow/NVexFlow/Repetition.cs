namespace NVexFlow
{//Repetition
    public class Repetition:StaveModifier
    {
        #region 隐含字段
        public enum RepetitionType
        {
            NONE,
            CODA_LEFT,
            CODA_RIGHT,
            SEGNO_LEFT,
            SEGNO_RIGHT,
            DC,
            DC_AL_CODA,
            DC_AL_FINE,
            DS,
            DS_AL_CODA,
            DS_AL_FINE,
            FINE
        }


        private double x;

        public double X
        {
            set
            { x = value; }
        }
        private double y;

        public double Y
        {
            set
            { y = value; }
        }

        private double xShift;

        public double XShift
        {
            set
            { xShift = value; }
        }


        private double yShift;

        public double YShift
        {
            set
            { yShift = value; }
        }

        private Font font;
        #endregion


        #region js直译部分

        public Repetition(object type,double x,double y_shift)
        {
            Init(type,x,y_shift);
        }

        private void Init(object type,double x,double y_shift)
        { }




        public Repetition Draw(Stave stave,double x)
        {
            return this;
        }

        public Repetition DrawCodaFixed(Stave stave,double x)
        {
            return this;
        }

        public Repetition DrawSignoFixed(Stave stave,double x)
        {
            return this;
        }

        public Repetition DrawSymbolText(Stave stave,double x)
        {
            return this;
        }
        #endregion
    }
}
