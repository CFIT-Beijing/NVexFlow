using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class Tremolo : Modifier
            {
                #region 方法
                public Tremolo(int num)
                {
                    Init(num);
                }

                public void Init(int num)
                {
                    this.num = num;
                    this.note = null;
                    this.index = null;
                    //JS原文是Modifier.ModifierPosition.CENTER;可是枚举里没有Center选项
                    this.position = Modifier.ModifierPosition.ABOVE;
                    this.code = "v74";
                    this.shiftRight = -2;
                    this.ySpacing = 4;
                    this.renderOptions = new RenderOptions()
                    {
                        FontScale = 35,
                        StrokePx = 3,
                        StrokeSpacing = 10
                    };
                    this.font = new Font() { Family = "Arial", Weight = string.Empty, Size = 16 };
                }

                public override void Draw()
                { }
                #endregion


                #region 属性字段
                private double num;
                private object index;
                private Note note;
                private string code;
                private int shiftRight;
                private int ySpacing;
                private Modifier.ModifierPosition position;
                private RenderOptions renderOptions;
                private Font font;
                #endregion
            }
        }
    }
}
