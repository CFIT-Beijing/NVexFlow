using System.Collections.Generic;

namespace NVexFlow
{//StaveText
    public partial class Vex
    {
        public partial class Flow
        {
            public class StaveText : Modifier
            {
                #region 属性字段
                double width;
                Modifier.ModifierPosition position;
                object options;

                private string staveTxt;

                public string StaveTxt
                {
                    set { staveTxt = value; }
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
                private Font font;

                public Font Font
                {
                    //Vex.Merge(this.font, font);
                    set { font = value; }
                }
                private string text;

                public string Text
                {
                    set { text = value; }
                }
                #endregion


                #region 方法
                public StaveText(string text, ModifierPosition position, IList<object> options)
                {
                    Init(text, position, options);
                }

                public void Init(string text, ModifierPosition position, IList<object> options)
                { }



                public void Draw(Stave stave)
                { }
                #endregion
            }
        }
    }
}
