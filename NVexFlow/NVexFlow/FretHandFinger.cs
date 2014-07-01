
namespace NVexFlow
{//FretHandFinger
    public partial class Vex
    {
        public partial class Flow
        {
            public class FretHandFinger : Modifier
            {
                #region 属性字段
                private Font font;
                private object finger;
                public object Finger
                {
                    set { finger = value; }
                }
                private object note;
                private object index;
                private double width;
                private double offsetX;

                public double OffsetX
                {
                    get { return offsetX; }
                    set { offsetX = value; }
                }
                private double offsetY;

                public double OffsetY
                {
                    get { return offsetY; }
                    set { offsetY = value; }
                }
                private double xShift;
                private double yShift;
                public override ModifierPosition Position
                {
                    get
                    {
                        return base.Position;
                    }
                    set
                    {
                        //base.Position = value;
                        if (value >= ModifierPosition.LEFT && value <= ModifierPosition.BELOW)
                        {
                            base.Position = value;
                        }
                    }
                }

                #endregion


                #region 方法
                public FretHandFinger(object number)
                { }

                public void Init(object number)
                { }


                public override void Draw()
                { }
                #endregion
            }
        }
    }
}
