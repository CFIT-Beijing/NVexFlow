//对应 stavetext.js
//框架：    未完成
//类型定义：存在改进空间
//原js：    存在改进空间
using System;
using NVexFlow.Model;
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class StaveText:Modifier
            {
                #region 方法
                public StaveText(string text,ModifierPosition position,StaveTextOpts options)
                {
                    Init(text,position,options);
                }
                public void Init(string text,ModifierPosition position,StaveTextOpts options)
                {
                    this.Width=16;
                    this.text=text;
                    this.position=position;
                    this.options=new StaveTextOpts() {
                        shiftX=0,
                        shiftY=0,
                        justification=Vex.Flow.TextNote.TextNoteJustification.CENTER
                    };

                    Vex.Merge(this.options,options);
                    this.font=new Font() {
                        family="times",
                        size=16,
                        weight="normal"
                    };
                }
                public override string Category
                {
                    get
                    {
                        return "stavetext";
                    }
                }
                public string StaveTxt
                {
                    set
                    {
                        this.text = value;
                    }
                }
                public double ShiftX
                {
                    set
                    {
                        shiftX = value;
                    }
                }
                public double ShiftY
                {
                    set
                    {
                        shiftY = value;
                    }
                }
                public Font Font
                {
                    set
                    {
                        Vex.Merge(this.font, value);
                    }
                }
                public string Text
                {
                    set
                    {
                        this.text = value;
                    }
                }
                public override void Draw()
                {
                    throw new System.NotImplementedException();
                }
                public void Draw(Stave stave)
                {
                }
                #endregion


                #region 属性字段
                protected string text;            
                protected double shiftX;         
                protected double shiftY;
                protected StaveTextOpts options;
                #endregion
            }
        }
    }
}
