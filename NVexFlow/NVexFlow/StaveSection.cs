
namespace NVexFlow
{//StaveSection
    public partial class Vex
    {
        public partial class Flow
        {
            public class StaveSection : Modifier
            {
                #region js直译部分
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
                    this.font = new Font() { family = "sans-serif", size = 12, weight = "bold" };
                }


                public override string Category
                {
                    get
                    {
                        return "stavesection";
                    }
                }


                public object Section
                {
                    set { section = value; }
                }


                public double ShiftX
                {
                    set { shiftX = value; }
                }


                public double ShiftY
                {
                    set { shiftY = value; }
                }


                public override void Draw()
                {
                    throw new System.NotImplementedException();
                }

                public void Draw(object stave, double shift_x)
                { }
                #endregion


                #region 隐含的字段
                protected object section;
                protected double shiftX;
                protected double shiftY;
                protected double x;           
                #endregion
            }
        }

    }
}
