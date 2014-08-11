namespace NVexFlow
{//StaveTempo
    public class StaveTempo:StaveModifier
    {
        #region 隐含字段

        private double x;
        Modifier.ModifierPosition position;
        Font font;
        object renderOptions;

        private object tempo;

        public object Tempo
        {
            set
            { tempo = value; }
        }
        private double shiftX;

        public double ShiftX
        {
            set
            { shiftX = value; }
        }
        private double shiftY;

        public double ShiftY
        {
            set
            { shiftY = value; }
        }
        #endregion


        #region js直译部分
        public StaveTempo(object tempo,double x,double shift_y)
        { }

        private void Init(object tempo,double x,double shift_y)
        { }



        public void Draw(Stave stave,double shift_x)
        { }
        #endregion
    }
}
