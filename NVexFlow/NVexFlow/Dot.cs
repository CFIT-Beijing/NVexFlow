
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            ///  This class implements dot modifiers for notes.
            /// </summary>
            public class Dot : Modifier
            {
                #region 方法
                public Dot()
                {
                    Init();
                }

                public override void Init()
                {
                    this.note = null;
                    this.index = null;
                    this.position = Modifier.ModifierPosition.RIGHT;

                    this.radius = 2;
                    base.Width = 5;
                    this.dotShiftY = 0;
                }



                public override void Draw()
                { }
                #endregion


                #region 属性字段
                public override Note Note
                {
                    set
                    {
                        this.note = value;
                        if (this.note is GraceNote)
                        {
                            this.radius *= 0.50;
                            base.Width = 3;
                        }
                    }
                }
                private Note note;
            

                public double DotShiftY
                {
                    set { dotShiftY = value; }
                }
                double dotShiftY;


                object index;
                Modifier.ModifierPosition position;
                private double radius;


                #endregion
            }
        }

    }
}
