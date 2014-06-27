
namespace NVexFlow
{//StaveSection
    public partial class Vex
    {
        public partial class Flow
        {
            public class StaveSection : Modifier
            {
                #region 属性字段
                Font font;

                public Font Font
                {
                    get { return font; }
                    set { font = value; }
                }

                double width;
                Modifier.ModifierPosition position;

                double x;

                public double X
                {
                    get { return x; }
                    set { x = value; }
                }

                double shiftX;

                public double ShiftX
                {
                    get { return shiftX; }
                    set { shiftX = value; }
                }
                double shiftY;

                public double ShiftY
                {
                    get { return shiftY; }
                    set { shiftY = value; }
                }
                object section;

                public object Section
                {
                    get { return section; }
                    set { section = value; }
                }
                #endregion


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
                    this.Position = ModifierPosition.ABOVE;
                    this.font = new Font() { Family = "sans-serif", Size = 12, Weight = "bold" };
                }

                public void Draw(object stave, double shift_x)
                { }
                #endregion



            }
        }

    }
}
