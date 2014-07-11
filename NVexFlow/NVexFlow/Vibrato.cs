//对应vibrato.js
//框架：    已完成
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
            /// <summary>
            /// This class implements vibratos.
            /// </summary>
            public class Vibrato:Modifier
            {
                #region js直译部分
                public Vibrato()
                {
                    Init();
                }
                public override void Init()
                {
                    this.harsh=false;
                    this.position=Vex.Flow.Modifier.ModifierPosition.RIGHT;
                    this.renderOptions=new RenderOptions() {
                        vibratoWidth=20,
                        waveHeight=6,
                        waveWidth=4,
                        waveGirth=2
                    };
                    this.VibratoWidth=this.renderOptions.vibratoWidth;
                }
                public override string Category
                {
                    get
                    {
                        return "vibratos";
                    }
                }
                public bool Harsh
                {
                    set
                    {
                        harsh=value;
                    }
                }
                public double VibratoWidth
                {
                    set
                    {
                        this.vibratoWidth=value;
                        this.Width=this.vibratoWidth;
                    }
                }
                public override void Draw()
                {
                    throw new NotImplementedException();
                }
                #endregion
                #region 隐含的字段
                protected RenderOptions renderOptions;
                protected bool harsh;
                protected double vibratoWidth;
                #endregion
            }
        }
    }
}
