using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZhCJB.VexFlow.CS
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Volta:StaveModifier
            {
                #region 属性字段
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
                    get { return type; }
                    set { type = value; }
                }
                double x;

                public double X
                {
                    get { return x; }
                    set { x = value; }
                }
                double yShift;

                public double YShift
                {
                    get { return yShift; }
                    set { yShift = value; }
                }
                int number;

                public int Number
                {
                    get { return number; }
                    set { number = value; }
                }
                Font font;

                public Font Font
                {
                    get { return font; }
                    set { font = value; }
                } 
                #endregion


                #region 方法
                public Volta(VoltaType type, int number, double x, double y_shift)
                {
                    Init(type, number, x, y_shift);
                }

                public void Init(VoltaType type, int number, double x, double y_shift)
                {
                    this.type = type;
                    this.x = x;
                    this.yShift = y_shift;
                    this.number = number;
                    this.font = new Font()
                    {
                        Family = "sans-serif",
                        Size = 9,
                        Weight = "bold"
                    };
                }

                public void Draw(Stave stave, double x)
                { }
                
                #endregion
                

            }


        }

    }
}
