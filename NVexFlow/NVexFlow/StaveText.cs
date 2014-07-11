using System.Collections.Generic;
using NVexFlow.Model;

namespace NVexFlow
{//StaveText
    public partial class Vex
    {
        public partial class Flow
        {
            public class StaveText : Modifier
            {
                #region 方法
                public StaveText(string text, ModifierPosition position, StaveTextOpts options)
                {
                    Init(text, position, options);
                }

                public void Init(string text, ModifierPosition position, StaveTextOpts options)
                {
                    this.Width = 16;
                    this.text = text;
                    this.position = position;
                    this.options = new StaveTextOpts()
                    {
                        shiftX = 0,
                        shiftY = 0,
                        justification = Vex.Flow.TextNote.TextNoteJustification.CENTER
                    };

                    Vex.Merge(this.options, options);
                    this.font = new Font()
                    {
                        family = "times",
                        size = 16,
                        weight = "normal"
                    };
                }

                public override void Draw()
                {
                    throw new System.NotImplementedException();
                }

                public void Draw(Stave stave)
                { }
                #endregion


                #region 属性字段
                
                public string StaveTxt
                {
                    set { this.text = value; }
                }
                private string text;


                public double ShiftX
                {
                    set { shiftX = value; }
                }
                private double shiftX;


               
                public double ShiftY
                {
                    set { shiftY = value; }
                }
                private double shiftY;



                public Font Font
                {
                    set
                    {
                        Vex.Merge(this.font, value);
                    }

                }
                private Font font;

                public string Text
                {
                    set { this.text = value; }
                }



                Modifier.ModifierPosition position;
                StaveTextOpts options;
                #endregion
            }
        }
    }
}
