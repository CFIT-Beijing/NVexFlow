using System;
using NVexFlow.Model;
namespace NVexFlow
{//Vibrato
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
                        VibratoWidth=20,
                        WaveHeight=6,
                        WaveWidth=4,
                        WaveGirth=2
                    };
                    this.VibratoWidth=this.renderOptions.VibratoWidth;
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
                private bool harsh;
                public double VibratoWidth
                {
                    set
                    {
                        this.vibratoWidth=value;
                        this.Width=this.vibratoWidth;
                    }
                }
                private double vibratoWidth;
                public override void Draw()
                {
                    throw new NotImplementedException();
                }
                #endregion
                #region 隐含的字段
                protected RenderOptions renderOptions;
                #endregion
            }
        }
    }
}
