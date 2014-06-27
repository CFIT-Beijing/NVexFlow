
namespace NVexFlow
{//StaveTempo
    public partial class Vex
    {
        public partial class Flow
        {
            public class StaveTempo : StaveModifier
            {
                #region 属性字段

                private double x;
                Modifier.ModifierPosition position;
                Font font;
                object renderOptions;

                private object tempo;

                public object Tempo
                {
                    set { tempo = value; }
                }
                private double shiftX;

                public double ShiftX
                {
                    set { shiftX = value; }
                }
                private double shiftY;

                public double ShiftY
                {
                    set { shiftY = value; }
                }
                #endregion


                #region 方法
                public StaveTempo(object tempo, double x, double shift_y)
                { }

                public void Init(object tempo, double x, double shift_y)
                { }



                public void Draw(Stave stave, double shift_x)
                { }
                #endregion
            }
        }
    }
}
