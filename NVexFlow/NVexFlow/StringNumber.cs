
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class StringNumber : Modifier
            {

                #region 属性字段
                object note;
                object index;
                double width;
                Renderer.RendererLineEndType leg;
                Font font;
                int radius;

                public override ModifierPosition Position
                {
                    get
                    {
                        return base.Position;
                    }
                    set
                    {
                        if (value >= ModifierPosition.LEFT && value <= ModifierPosition.BELOW)
                        {
                            this.Position = value;
                        }
                    }
                }

                object stringNumber;

                public object String_Number
                {
                    set { stringNumber = value; }
                }

                double xOffset;

                public double XOffset
                {
                    set { xOffset = value; }
                }
                double yOffset;

                public double YOffset
                {
                    set { yOffset = value; }
                }

                object lastNote;

                public object LastNote
                {
                    get { return lastNote; }
                }

                object dashed;

                public object Dashed
                {
                    set { dashed = value; }
                }
                #endregion


                #region 方法
                public StringNumber(object number)
                {
                    Init(number);
                }

                public void Init(object number)
                { }



                public override void Draw()
                { }
                #endregion
            }
        }
    }
}
