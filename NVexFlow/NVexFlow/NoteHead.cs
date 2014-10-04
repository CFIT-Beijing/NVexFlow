////对应 notehead.js
using System;
using NVexFlow.Model;
namespace NVexFlow
{
    // This file implements `NoteHeads`. `NoteHeads` are typically not manipulated
    // directly, but used internally in `StaveNote`.
    public class NoteHead:Note
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
        private void DrawSlashNoteHead(CanvasContext ctx,string duration,double x,double y,int stemDirection)
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
            this.x = headOptions.x ?? 0;
            this.y = headOptions.y ?? 0;
            this.note_type = headOptions.note_type;
            this.duration = headOptions.duration;
            this.displaced = headOptions.displaced ?? false;
            this.stem_direction = headOptions.stem_direction ?? StaveNote.STEM_UP;
            this.line = headOptions.line;

            // Get glyph code based on duration and note type. This could be regular notes, rests, or other custom codes.
            this.glyph = Flow.DurationToGlyph(this.duration,this.note_type) as Glyph4NoteHead;
            //其实Glyph4NoteHead可以写成partial的Glyph4Note，想表达的是Glyph4NoteHead比父类里使用的Glyph4Note多几个字段。你看看怎么弄吧
            //做成Glyph4NoteHead:Glyph4Note吧
            if(this.glyph == null)
            {
                throw new Exception("BadArguments,No glyph found for duration '" + this.duration + "' and type '" + this.note_type + "'");
            }
            this.glyph_code = (this.glyph as Glyph4NoteHead).code_head;
            this.x_shift = headOptions.x_shift;
            if(!string.IsNullOrEmpty(headOptions.custom_glyph_code))
            {
                this.custom_glyph = true;
                this.glyph_code = headOptions.custom_glyph_code;
            }
            this.context = null;
            this.style = headOptions.style;
            this.slashed = headOptions.slashed;
            //其实NoteHeadRenderOpts可以写成partial的NoteRenderOpts，想表达的是NoteHeadRenderOpts比父类里使用的RenderOpts多几个字段。你看看怎么弄吧
            //做成NoteHeadRenderOpts:NoteRenderOpts吧。必要时仿照CrescendoRenderOpts实现NoteHeadRenderOpts.Merge静态方法。
            this.render_options = new NoteHeadRenderOpts() {
                glyph_font_scale = 35,// font size for note heads
                stroke_px = 3// number of stroke px to the left and right of head
            };
            if(headOptions.glyph_font_scale.HasValue)
            {
                (this.render_options as NoteHeadRenderOpts).glyph_font_scale = headOptions.glyph_font_scale.Value;
            }
            this.SetWidth((this.glyph as Glyph4NoteHead).head_width);
        }
        /// <summary>
        /// Get the `ModifierContext` category
        /// </summary>
        public override string GetCategory()
        {
            return "notehead";
        }
        /// <summary>
        /// Set the Cavnas context for drawing
        /// </summary>
        public new NoteHead SetContext(CanvasContext context)
        {
            this.context = context;
            return this;
        }
        /// <summary>
        /// Get the width of the notehead
        /// </summary>
        public override double GetWidth()
        {
            return this.width;
        }
        /// <summary>
        /// Determine if the notehead is displaced
        /// </summary>
        public bool IsDisplaced()
        {
            return this.displaced;
        }
        /// <summary>
        /// Get/set the notehead's style 
        /// style` is an `object` with the following properties: `shadowColor`, `shadowBlur`, `fillStyle`, `strokeStyle`
        /// </summary>
        public NoteHeadStyle GetStyle()
        {
            return this.style;
        }
        public NoteHead SetStyle(NoteHeadStyle style)
        {
            this.style = style;
            return this;
        }
        /// <summary>
        /// Get the glyph data
        /// </summary>
        public override Glyph4Note GetGlyph()
        {
            return this.glyph;
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
        public double GetY()
        {
            return this.y;
        }
        public NoteHead SetY(double y)
        {
            this.y = y;
            return this;
        }
        /// <summary>
        /// Get the stave line the notehead is placed on 
        /// </summary>
        public double GetLine()
        {
            return this.line;
        }
        /// <summary>
        /// Get the canvas `x` coordinate position of the notehead.
        /// </summary>
        public override double GetAbsoluteX()
        {
            // If the note has not been preformatted, then get the static x value Otherwise, it's been formatted and we should use it's x value relative to its tick context
            double x = !this.preFormatted ? this.x : base.GetAbsoluteX();
            return x + (this.displaced ? this.width * this.stem_direction : 0);
        }
        /// <summary>
        /// Get the `BoundingBox` for the `NoteHead`
        /// </summary>
        public override BoundingBox GetBoundingBox()
        {
            if(!this.preFormatted)
            {
                throw new Exception("UnformattedNote,Can't call getBoundingBox on an unformatted note.");
            }
            double spacing = this.stave.GetSpacingBetweenLines();
            double halfSpacing = spacing / 2;
            double minY = this.y - halfSpacing;
            return new BoundingBox(this.GetAbsoluteX(),minY,this.width,spacing);
        }
        /// <summary>
        /// Apply current style to Canvas `context`
        /// </summary>
        public NoteHead ApplyStyle()
        {
            NoteHeadStyle style = this.GetStyle();
            if(style.shadow_color != null)
            { this.context.ShadowColor = style.shadow_color; }
            if(style.shadow_blur != null)
            { this.context.ShadowBlur = style.shadow_blur; }
            if(style.fill_style != null)
            { this.context.FillStyle = style.fill_style; }
            if(style.stroke_style != null)
            { this.context.StrokeStyle = style.stroke_style; }
            return this;
        }
        /// <summary>
        /// Set notehead to a provided `stave`
        /// </summary>
        public new NoteHead SetStave(Stave stave)
        {
            double line = this.GetLine();
            this.stave = stave;
            this.SetY(stave.GetYForNote(line));
            this.context = this.stave.context;
            return this;
        }
        /// <summary>
        /// Pre-render formatting
        /// </summary>
        public new NoteHead PreFormat()
        {
            if(this.preFormatted)
                return this;
            Glyph4NoteHead glyph = this.GetGlyph() as Glyph4NoteHead;
            double width = glyph.head_width + this.extra_left_px + this.extra_right_px;
            this.SetWidth(width);
            this.SetPreFormatted(true);
            return this;
        }
        /// <summary>
        /// Draw the notehead
        /// </summary>
        public override void Draw()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region 隐含字段
        public double y;
        public bool displaced;
        public int stem_direction;
        public double line;//可能是int。以后看到确实要改时再改。
        public string glyph_code;
        public NoteHeadStyle style;//复杂类型，目前还不清楚  `style` is an `object` with the following properties: `shadowColor`, `shadowBlur`, `fillStyle`, `strokeStyle`
        public object slashed;//不清楚类型
        public bool custom_glyph;//看名字像bool
        #endregion
    }
}
