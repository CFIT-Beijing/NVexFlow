
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            /// <summary>
            /// Class to draws string numbers into the notation.
            /// </summary>
            public class StringNumber : Modifier
            {
                #region 方法
                public StringNumber(string number)
                {
                    Init(number);
                }

                public void Init(string number)
                {
                    this.note = null;
                    this.lastNote = null;
                    this.index = null;
                    this.stringNumber = number;
                    base.Width = 20;

                    this.position = Modifier.ModifierPosition.ABOVE;  // Default position above stem or note head

                    this.xShift = 0;
                    this.yShift = 0;
                    this.xOffset = 0;                               // Horizontal offset from default
                    this.yOffset = 0;                               // Vertical offset from default
                    this.dashed = true;                              // true - draw dashed extension  false - no extension
                    this.leg = Vex.Flow.Renderer.RendererLineEndType.NONE;   // draw upward/downward leg at the of extension line

                    this.radius = 8;
                    this.font = new Font()
                    {
                        Family = "sans-serif",
                        Size = 10,
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


                

                public Renderer.RendererLineEndType LineEndType
                {
                    set
                    {
                        if (value >= Renderer.RendererLineEndType.NONE && value <= Renderer.RendererLineEndType.DOWN)
                        { this.leg = value; }
                    }
                }
                Renderer.RendererLineEndType leg;


                

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
                ModifierPosition position;

                

                public string String_Number
                {
                    set { this.stringNumber = value; }
                }
                string stringNumber;

                
                

                public double XOffset
                {
                    set { this.xOffset = value; }
                }
                double xOffset;
                

                public double YOffset
                {
                    set { this.yOffset = value; }
                }
                double yOffset;

                

                public object LastNote
                {
                    set { this.lastNote = value; }
                }
                object lastNote;

                
                public bool Dashed
                {
                    set { this.dashed = value; }
                }
                bool dashed;

                Font font;
                int radius;
                double xShift;
                double yShift;
                #endregion              
            }
        }
    }
}
