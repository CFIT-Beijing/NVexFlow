
namespace NVexFlow
{//StaveSection
    public partial class Vex
    {
        public partial class Flow
        {
            public class StaveSection : Modifier
            {
                #region 方法
                public StaveSection(object section, double x, double shift_y)
                {
                    Init(section, x, shift_y);
                }

                public void Init(object section, double x, double shift_y)
                {
                    this.section = section;
                    this.shiftX = 0;
                    this.shiftY = shift_y;
                    this.x = x;
                    this.position = ModifierPosition.ABOVE;
                    this.font = new Font() { Family = "sans-serif", Size = 12, Weight = "bold" };
                }

                public override void Draw()
                {
                    throw new System.NotImplementedException();
                }

                public void Draw(object stave, double shift_x)
                { }
                #endregion


                #region 属性字段
                public object Section
                {
                    set { section = value; }
                }
                object section;

                

                public double ShiftX
                {
                    set { shiftX = value; }
                }
                double shiftX;
                

                public double ShiftY
                {
                    set { shiftY = value; }
                }
                double shiftY;



                Font font;
                Modifier.ModifierPosition position;
                double x;
                
                #endregion
            }
        }

    }
}
