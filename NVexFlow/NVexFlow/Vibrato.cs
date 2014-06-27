
namespace NVexFlow
{//Vibrato
    public partial class Vex
    {
        public partial class Flow
        {
            public class Vibrato : Modifier
            {

                #region 属性字段
                private bool harsh;

                public bool Harsh
                {
                    set { harsh = value; }
                }

                private double vibratoWidth;

                public double VibratoWidth
                {
                    set
                    {
                        vibratoWidth = value;
                        base.Width = this.vibratoWidth;
                    }
                }

                Modifier.ModifierPosition position;
                object renderOptions;

                #endregion


                #region 方法
                public Vibrato()
                {
                    Init();
                }

                public override void Init()
                { }


                public override void Draw()
                { }
                #endregion
            }
        }
    }
}
