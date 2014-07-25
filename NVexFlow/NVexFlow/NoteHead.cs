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
                public NoteHead(NoteHeadStruct head_options)
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

                private void Init(NoteHeadStruct head_options)
                {
                    //          NoteHead.superclass.init.call(this, head_options);
                    //this.index = head_options.index;
                    //this.x = head_options.x || 0;
                    //this.y = head_options.y || 0;
                    //this.note_type = head_options.note_type;
                    //this.duration = head_options.duration;
                    //this.displaced = head_options.displaced || false;
                    //this.stem_direction = head_options.stem_direction || Vex.Flow.StaveNote.STEM_UP;
                    //this.line = head_options.line;

                    //// Get glyph code based on duration and note type. This could be
                    //// regular notes, rests, or other custom codes.
                    //this.glyph = Vex.Flow.durationToGlyph(this.duration, this.note_type);
                    //if (!this.glyph) {
                    //  throw new Vex.RuntimeError("BadArguments",
                    //      "No glyph found for duration '" + this.duration +
                    //      "' and type '" + this.note_type + "'");
                    //}

                    //this.glyph_code = this.glyph.code_head;
                    //this.x_shift = head_options.x_shift;
                    //if (head_options.custom_glyph_code) {
                    //  this.custom_glyph = true;
                    //  this.glyph_code = head_options.custom_glyph_code;
                    //}

                    //this.context = null;
                    //this.style = head_options.style;
                    //this.slashed = head_options.slashed;

                    //Vex.Merge(this.render_options, {
                    //  glyph_font_scale: 35, // font size for note heads
                    //  stroke_px: 3         // number of stroke px to the left and right of head
                    //});

                    //if (head_options.glyph_font_scale) {
                    //  this.render_options.glyph_font_scale = head_options.glyph_font_scale;
                    //}

                    //this.setWidth(this.glyph.head_width);
                }
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
                        this.context = value;
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
                    get { return this.style; }
                    set { this.style = value; }
                }
                public override object Glyph
                {
                    get
                    {
                        return this.glyph;
                    }
                }
                public NoteHead SetX(double x)
                {
                    this.x = x;
                    return this;
                }
                public double Y
                {
                    get { return this.y; }
                    set { this.y = value; }
                }
                public double Line
                {
                    get { return this.line; }
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
                        return 0;
                    }
                }

                public BoundingBox GetBoundingBox()
                {
                    //           if (!this.preFormatted) throw new Vex.RERR("UnformattedNote",
                    //"Can't call getBoundingBox on an unformatted note.");

                    //           var spacing = this.stave.getSpacingBetweenLines();
                    //           var half_spacing = spacing / 2;
                    //           var min_y = this.y - half_spacing;

                    //           return new Vex.Flow.BoundingBox(this.getAbsoluteX(), min_y, this.width, spacing);
                    return null;
                }
                public NoteHead ApplyStyle()
                {
                    //var style = this.getStyle();
                    //if (style.shadowColor) context.setShadowColor(style.shadowColor);
                    //if (style.shadowBlur) context.setShadowBlur(style.shadowBlur);
                    //if (style.fillStyle) context.setFillStyle(style.fillStyle);
                    //if (style.strokeStyle) context.setStrokeStyle(style.strokeStyle);
                    //return this;
                    return null;
                }
                public override Stave Stave
                {
                    set
                    {
                        //                        setStave: function(stave){
                        //  var line = this.getLine();

                        //  this.stave = stave;
                        //  this.setY(stave.getYForNote(line));
                        //  this.context = this.stave.context;
                        //  return this;
                        //},
                    }
                }
                public NoteHead PreFormat()
                {
                    //if (this.preFormatted) return this;

                    //var glyph = this.getGlyph();
                    //var width = glyph.head_width + this.extraLeftPx + this.extraRightPx;

                    //this.setWidth(width);
                    //this.setPreFormatted(true);
                    //return this;
                    return null;
                }
                public void Draw()
                { }
                #endregion


                #region 隐含字段
                object index;//猜测是int或者int？
                protected double y;
                bool displaced;
                int stemDirection;
                double line;
                string glyphCode;
                NoteHeadStyle style;//复杂类型，目前还不清楚  `style` is an `object` with the following properties: `shadowColor`, `shadowBlur`, `fillStyle`, `strokeStyle`
                object slashed;//不清楚类型


                #endregion
            }
        }
    }
}
