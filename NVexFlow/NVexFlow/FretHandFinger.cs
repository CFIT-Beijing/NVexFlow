
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            /// Class to draws string numbers into the notation.
            /// </summary>
            public class FretHandFinger : Modifier
            {
                #region 方法
                public FretHandFinger(object number)
                {
                    Init(number);
                }

                public void Init(object number)
                {
                    this.note = null;
                    this.index = null;
                    this.finger = number;
                    this.width = 7;
                    this.position = Modifier.ModifierPosition.LEFT;  // Default position above stem or note head
                    this.xShift = 0;
                    this.yShift = 0;
                    this.xOffset = 0;       // Horizontal offset from default
                    this.yOffset = 0;       // Vertical offset from default
                    this.font = new Font()
                    {
                        Family = "sans-serif",
                        Size = 9,
                        Weight = "bold"
                    };
                }


                public override void Draw()
                { }
                #endregion


                #region 属性字段
                public override Note Note
                {
                    get
                    {
                        return this.Note;
                    }
                    set
                    {
                        this.Note = value;
                    }
                }
                Note note;

                public override object Index
                {
                    get
                    {
                        return this.Index;
                    }
                    set
                    {
                        this.Index = value;
                    }
                }
                object index;

                public override ModifierPosition Position
                {
                    get
                    {
                        return this.position;
                    }
                    set
                    {
                        if (value >= ModifierPosition.LEFT && value <= ModifierPosition.BELOW)
                        {
                            this.position = value;
                        }
                    }
                }
                ModifierPosition position;

                private object finger;
                //JS属性名叫做FretHandFinger，和类名冲突了
                public object Finger
                {
                    set { this.finger = value; }
                }

                public double OffsetX
                {
                    set { this.xOffset = value; }
                }
                private double xOffset;


                public double OffsetY
                {
                    set { this.yOffset = value; }
                }
                private double yOffset;


                private Font font;             
                private double width;                
                private double xShift;
                private double yShift;
                #endregion
            }
        }
    }
}
