
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
            public class Vibrato : Modifier
            {
                #region 方法
                public Vibrato()
                {
                    Init();
                }

                public override void Init()
                {
                    this.harsh = false;
                    this.position = Vex.Flow.Modifier.ModifierPosition.RIGHT;
                    this.renderOptions = new RenderOptions()
                    {
                        VibratoWidth = 20,
                        WaveHeight = 6,
                        WaveWidth = 4,
                        WaveGirth = 2
                    };
                    this.VibratoWidth = this.renderOptions.VibratoWidth;

                }


                public override void Draw()
                { }
                #endregion


                #region 属性字段

                public bool Harsh
                {
                    set { harsh = value; }
                }
                private bool harsh;

                public double VibratoWidth
                {
                    set
                    {
                        vibratoWidth = value;
                        base.Width = this.vibratoWidth;
                    }
                }
                private double vibratoWidth;

                

                Modifier.ModifierPosition position;
                RenderOptions renderOptions;

                #endregion
            }
        }
    }
}
