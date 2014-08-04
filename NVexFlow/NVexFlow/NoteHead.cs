////对应 notehead.js
using System;
using NVexFlow.Model;
namespace NVexFlow
{
    public partial class Vex
    {
        public partial class Flow
        {
            // This file implements `NoteHeads`. `NoteHeads` are typically not manipulated
            // directly, but used internally in `StaveNote`.
            public class NoteHead : Note
            {
                #region js直译部分
                public NoteHead(NoteHeadStruct headOptions)
                    : base(headOptions)
                {
                    Init(headOptions);
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
                private void DrawSlashNoteHead(CanvasContext ctx, string duration, double x, double y, int stemDirection)
                {
                    //应该是和界面canvas相关的方法，暂时不写？
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

                private void Init(NoteHeadStruct headOptions)
                {
                    this.index = headOptions.index;
                    this.x = headOptions.x.HasValue ? headOptions.x.Value : 0;
                    this.y = headOptions.y.HasValue ? headOptions.y.Value : 0;
                    this.noteType = headOptions.noteType;
                    this.duration = headOptions.duration;
                    this.displaced = headOptions.displaced.HasValue ? headOptions.displaced.Value : false;
                    this.stemDirection = headOptions.stemDirection.HasValue ? headOptions.stemDirection.Value : Vex.Flow.StaveNote.STEM_UP;
                    this.line = headOptions.line;

                    // Get glyph code based on duration and note type. This could be regular notes, rests, or other custom codes.
                    this.glyph = Vex.Flow.DurationToGlyph(this.duration, this.noteType) as Glyph4NoteHead;
                    //其实Glyph4NoteHead可以写成partial的Glyph4Note，想表达的是Glyph4NoteHead比父类里使用的Glyph4Note多几个字段。你看看怎么弄吧
                    //做成Glyph4NoteHead:Glyph4Note吧
                    if (this.glyph == null)
                    {
                        throw new Exception("BadArguments,No glyph found for duration '" + this.duration + "' and type '" + this.noteType + "'");
                    }
                    this.glyphCode = (this.glyph as Glyph4NoteHead).codeHead;
                    this.xShift = headOptions.xShift;
                    if (!string.IsNullOrEmpty(headOptions.customGlyphCode))
                    {
                        this.customGlyph = true;
                        this.glyphCode = headOptions.customGlyphCode;
                    }
                    this.context = null;
                    this.style = headOptions.style;
                    this.slashed = headOptions.slashed;
                    //其实NoteHeadRenderOpts可以写成partial的NoteRenderOpts，想表达的是NoteHeadRenderOpts比父类里使用的RenderOpts多几个字段。你看看怎么弄吧
                    //做成NoteHeadRenderOpts:NoteRenderOpts吧。必要时仿照CrescendoRenderOpts实现NoteHeadRenderOpts.Merge静态方法。
                    this.renderOptions = new NoteHeadRenderOpts()
                    {
                        glyphFontScale = 35,// font size for note heads
                        strokePx = 3// number of stroke px to the left and right of head
                    };
                    if (headOptions.glyphFontScale.HasValue)
                    {
                        (this.renderOptions as NoteHeadRenderOpts).glyphFontScale = headOptions.glyphFontScale.Value;
                    }
                    this.SetWidth((this.glyph as Glyph4NoteHead).headWidth);
                }
                /// <summary>
                /// Get the `ModifierContext` category
                /// </summary>
                public override string Category
                {
                    get
                    {
                        return "notehead";
                    }
                }
                /// <summary>
                /// Set the Cavnas context for drawing
                /// </summary>
                public override CanvasContext Context
                {
                    set
                    {
                        this.context = value;
                    }
                }
                /// <summary>
                /// Get the width of the notehead
                /// </summary>
                public override double Width
                {
                    get
                    {
                        return this.width;
                    }
                }
                /// <summary>
                /// Determine if the notehead is displaced
                /// </summary>
                public bool IsDisplaced
                {//js之所以用===true多半是防止非bool类型的displaced被动态转换成bool出乱子
                    get { return this.displaced; }
                }
                /// <summary>
                /// Get/set the notehead's style 
                /// style` is an `object` with the following properties: `shadowColor`, `shadowBlur`, `fillStyle`, `strokeStyle`
                /// </summary>
                public NoteHeadStyle Style
                {
                    get { return this.style; }
                    set { this.style = value; }
                }
                /// <summary>
                /// Get the glyph data
                /// </summary>
                public override Glyph4Note Glyph
                {
                    get
                    {
                        return this.glyph;
                    }
                }
                /// <summary>
                /// Set the X coordinate
                /// </summary>
                public NoteHead SetX(double x)
                {
                    this.x = x;
                    return this;
                }
                /// <summary>
                /// get/set the Y coordinate
                /// </summary>
                public double Y
                {
                    get { return this.y; }
                    set { this.y = value; }
                }
                /// <summary>
                /// Get the stave line the notehead is placed on 
                /// </summary>
                public double Line
                {
                    get { return this.line; }
                }
                /// <summary>
                /// Get the canvas `x` coordinate position of the notehead.
                /// </summary>
                public override double AbsoluteX
                {
                    get
                    {
                        // If the note has not been preformatted, then get the static x value Otherwise, it's been formatted and we should use it's x value relative to its tick context
                        double x = !this.preFormatted ? this.x : base.AbsoluteX;
                        return x+(this.displaced?this.width*this.stemDirection:0);
                    }
                }
                /// <summary>
                /// Get the `BoundingBox` for the `NoteHead`
                /// </summary>
                public BoundingBox GetBoundingBox()
                {
                    if (!this.preFormatted)
                    {
                        throw new Exception("UnformattedNote,Can't call getBoundingBox on an unformatted note.");
                    }
                    double spacing= this.stave.SpacingBetweenLines;
                    double halfSpacing = spacing / 2;
                    double minY = this.y - halfSpacing;
                    return new BoundingBox(this.AbsoluteX, minY, this.width, spacing);
                }
                /// <summary>
                /// Apply current style to Canvas `context`
                /// </summary>
                public NoteHead ApplyStyle()
                {
                    NoteHeadStyle style = this.Style;
                    if (style.shadowColor != null)
                    { this.context.ShadowColor = style.shadowColor; }
                    if (style.shadowBlur != null)
                    { this.context.ShadowBlur = style.shadowBlur; }
                    if (style.fillStyle != null)
                    { this.context.FillStyle = style.fillStyle; }
                    if (style.strokeStyle != null)
                    { this.context.StrokeStyle = style.strokeStyle; }
                    return this;
                }
                /// <summary>
                /// Set notehead to a provided `stave`
                /// </summary>
                public override Stave Stave
                {
                    set
                    {
                        double line= this.Line;
                        this.stave = value;
                        this.Y = value.GetYForNote(line);
                        this.context = this.stave.context;
                    }
                }
                /// <summary>
                /// Pre-render formatting
                /// </summary>
                public new NoteHead PreFormat()
                {
                    if (this.preFormatted) return this;
                    Glyph4NoteHead glyph= this.Glyph as Glyph4NoteHead;
                    double width= glyph.headWidth + this.extraLeftPx + this.extraRightPx;
                    this.SetWidth(width);
                    this.PreFormatted = true;
                    return this;
                }
                /// <summary>
                /// Draw the notehead
                /// </summary>
                public void Draw()
                {
                    throw new NotImplementedException();
                }
                #endregion


                #region 隐含字段
                protected object index;//猜测是int或者int？
                protected double y;
                protected bool displaced;
                protected int stemDirection;
                protected double line;//可能是int。以后看到确实要改时再改。
                protected string glyphCode;
                protected NoteHeadStyle style;//复杂类型，目前还不清楚  `style` is an `object` with the following properties: `shadowColor`, `shadowBlur`, `fillStyle`, `strokeStyle`
                protected object slashed;//不清楚类型
                protected bool customGlyph;//看名字像bool
                #endregion
            }
        }
    }
}
