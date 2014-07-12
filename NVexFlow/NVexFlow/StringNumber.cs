//对应 stringnumber.js
//框架：    已完成
//类型定义：存在改进空间
//原js：    存在改进空间
using System;

namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            /// Class to draws string numbers into the notation.
            /// </summary>
            public class StringNumber:Modifier
            {
                #region js直译部分
                public StringNumber(string number)
                {
                    Init(number);
                }

                public void Init(string number)
                {
                    this.note=null;
                    this.lastNote=null;
                    this.index=null;
                    this.stringNumber=number;
                    this.Width=20;
                    this.position=Modifier.ModifierPosition.ABOVE;  // Default position above stem or note head
                    this.xShift=0;
                    this.yShift=0;
                    this.xOffset=0;                               // Horizontal offset from default
                    this.yOffset=0;                               // Vertical offset from default
                    this.dashed=true;                              // true - draw dashed extension  false - no extension
                    this.leg=Vex.Flow.Renderer.RendererLineEndType.NONE;   // draw upward/downward leg at the of extension line
                    this.radius=8;
                    this.font=new Font() {
                        family="sans-serif",
                        size=10,
                        weight="bold"
                    };
                }
                public override string Category
                {
                    get
                    {
                        return "stringnumber";
                    }
                }
                public override Note Note
                {
                    get
                    {
                        return this.Note;
                    }
                    set
                    {
                        this.Note=value;
                    }
                }
                public override object Index
                {
                    get
                    {
                        return this.Index;
                    }
                    set
                    {
                        this.Index=value;
                    }
                }
                public Renderer.RendererLineEndType LineEndType
                {
                    set
                    {
                        if(value>=Renderer.RendererLineEndType.NONE&&value<=Renderer.RendererLineEndType.DOWN)
                        {
                            this.leg=value;
                        }
                    }
                }
                public override ModifierPosition Position
                {
                    get
                    {
                        return this.Position;
                    }
                    set
                    {
                        if(value>=ModifierPosition.LEFT&&value<=ModifierPosition.BELOW)
                        {
                            this.Position=value;
                        }
                    }
                }
                public string String_Number
                {
                    set
                    {
                        this.stringNumber=value;
                    }
                }
                public double XOffset
                {
                    set
                    {
                        this.xOffset=value;
                    }
                }
                public double YOffset
                {
                    set
                    {
                        this.yOffset=value;
                    }
                }
                public object LastNote
                {//应该和EndNote是一回事，将来找机会统一
                    set
                    {
                        this.lastNote=value;
                    }
                }
                public bool Dashed
                {
                    set
                    {
                        this.dashed=value;
                    }
                }
                public override void Draw()
                {
                    throw new NotImplementedException();
                }
                #endregion
                #region 隐含的字段
                protected double xOffset;
                protected double yOffset;
                protected object lastNote;
                protected bool dashed;
                protected Renderer.RendererLineEndType leg;
                protected string stringNumber;
                protected int radius;
                #endregion              
            }
        }
    }
}
