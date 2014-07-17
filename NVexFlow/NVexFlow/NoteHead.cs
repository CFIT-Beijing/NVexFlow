////对应 notehead.js
using NVexFlow.Model;
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            public class NoteHead : Note
            {
                #region 方法
                public NoteHead(NoteStruct head_options)
                    : base(head_options)
                {
                    Init(head_options);
                }
                /// <summary>
                /// Draw slashnote head manually. No glyph exists for this.
                //
                // Parameters:
                // * `ctx`: the Canvas context
                // * `duration`: the duration of the note. ex: "4"
                // * `x`: the x coordinate to draw at
                // * `y`: the y coordinate to draw at
                // * `stem_direction`: the direction of the stem
                /// </summary>
                /// <param name="ctx"></param>
                /// <param name="duration"></param>
                /// <param name="x"></param>
                /// <param name="y"></param>
                /// <param name="stemDirection"></param>
                private void DrawSlashNoteHead(CanvasContext ctx, string duration, double x, double y, int stemDirection)
                {

                    //var width = 15 + (Vex.Flow.STEM_WIDTH / 2);
                    //ctx.setLineWidth(Vex.Flow.STEM_WIDTH);

                    //var fill = false;
                    //if (duration != 1 &&
                    //    duration != 2 &&
                    //    duration != "h" &&
                    //    duration != "w")
                    //{
                    //    fill = true;
                    //}

                    //if (!fill) x -= (Vex.Flow.STEM_WIDTH / 2) * stem_direction;

                    //ctx.beginPath();
                    //ctx.moveTo(x, y + 11);
                    //ctx.lineTo(x, y + 1);
                    //ctx.lineTo(x + width, y - 10);
                    //ctx.lineTo(x + width, y);
                    //ctx.lineTo(x, y + 11);
                    //ctx.closePath();

                    //if (fill)
                    //{
                    //    ctx.fill();
                    //}
                    //else
                    //{
                    //    ctx.stroke();
                    //}
                    //ctx.setLineWidth(1);
                }

                private void Init(NoteStruct head_options)
                { }
                public override string Category
                {
                    get
                    {
                        return "notehead";
                    }
                }
                public override CanvasContext Context
                {
                    set
                    {
                        context = value;
                    }
                }
                public override double Width
                {
                    get
                    {
                        return this.width;
                    }
                }
                public bool IsDisplaced
                {
                    get { return object.ReferenceEquals(this.displaced, true); }
                }
                public NoteHeadStyle Style
                {
                    get { return style; }
                    set { style = value; }
                }
                public override object Glyph
                {
                    get
                    {
                        return this.glyph;
                    }
                }
                public override double X
                {
                    set
                    {
                        this.x = value;
                    }
                }
                public double Y
                {
                    get { return this.y; }
                    set { this.y = value; }
                }
                public double Line
                {
                    get { return line; }
                }
                public override double AbsoluteX
                {
                    get
                    {
                        //var getAbsoluteX = NoteHead.superclass.getAbsoluteX;

                        //// If the note has not been preformatted, then get the static x value
                        //// Otherwise, it's been formatted and we should use it's x value relative
                        //// to its tick context
                        //var x = !this.preFormatted ? this.x : getAbsoluteX.call(this);

                        //return x + (this.displaced ? this.width * this.stem_direction : 0);
                        //*************************************************************************************//
                        //var getAbsoluteX = NoteHead.superclass.getAbsoluteX;
                        //getAbsoluteX.call(this);
                        //用父类的方法，通过子类的字段得到一个x，说明子类父类字段的值不一致。
                        return 0;
                    }
                }

                public BoundingBox GetBoundingBox()
                {
                    return null;
                }
                
                



                



                public override Stave Stave
                {
                    get
                    {
                        return base.Stave;
                    }
                    set
                    {
                        base.Stave = value;
                    }
                }


                

                public NoteHead ApplyStyle()
                {
                    return null;
                }

                public NoteHead PreFormat()
                {
                    return null;
                }

                public void Draw()
                { }
                #endregion


                #region 隐含字段            
                object index;//不清楚
                protected double y;
                string noteType;
                string duration;
                bool displaced;
                int stemDirection;
                double line;
                double xShift;
                string glyphCode;
                CanvasContext context;
                NoteHeadStyle style;//复杂类型，目前还不清楚  `style` is an `object` with the following properties: `shadowColor`, `shadowBlur`, `fillStyle`, `strokeStyle`
                object slashed;//不清楚类型
                

                #endregion
            }
        }
    }
}
