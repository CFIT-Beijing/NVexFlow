
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
                    this.Width = 5;
                    this.dotShiftY = 0;
                }



                public override void Draw()
                { }
                #endregion


                #region 属性字段
                double width;
                double dotShiftY;
                object index;
                Modifier.ModifierPosition position;

                public double Radius
                {
                    get { return radius; }
                    set { radius = value; }
                }
                private double radius;

                public override Note Note
                {
                    set
                    {
                        this.note = value;
                        if (this.note is GraceNote)
                        {
                            this.radius *= 0.50;
                            this.Width = 3;
                        }
                    }
                }
                private Note note;
                #endregion
            }
        }

    }
}
