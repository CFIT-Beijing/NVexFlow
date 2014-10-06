//对应 stemmablenote.js
using System;
using NVexFlow.Model;
using System.Linq;
namespace NVexFlow
{
    /// <summary>
    /// ## Description
    //
    // `StemmableNote` is an abstract interface for notes with optional stems. 
    // Examples of stemmable notes are `StaveNote` and `TabNote`
    /// </summary>
    public class StemmableNote : Note
    {
        #region js直译部分
        public StemmableNote(NoteStruct note_struct)
            : base(note_struct)
        {
            Init(note_struct);
        }
        private void Init(NoteStruct note_struct)
        {
            this.stem = null;
            this.stem_extension_override = null;
            this.beam = null;
        }
        /// <summary>
        /// Get and set the note's `Stem`
        /// </summary>
        public Stem GetStem()
        {
            return this.stem;
        }
        public StemmableNote SetStem(Stem stem)
        {
            this.stem = stem;
            return this;
        }
        /// <summary>
        /// Builds and sets a new stem
        /// </summary>
        public StemmableNote BuildStem()
        {
            Stem stem = new Stem();
            this.SetStem(stem);
            return this;
        }
        /// <summary>
        /// Get the full length of stem.
        /// Set the stem length to a specific. Will override the default length.
        /// </summary>
        public double GetStemLength()
        {
            return Stem.HEIGHT + this.GetStemExtension();
        }
        public StemmableNote SetStemLength(double height)
        {
            //js中setStemLength在getStemExtension后面
            this.stem_extension_override = height - Stem.HEIGHT;
            return this;
        }
        /// <summary>
        /// Get the number of beams for this duration
        /// </summary>
        public int GetBeamCount()
        { 
            //暂时不知道glyph是什么类型，继承了Note，所以猜测是像Note里的glyph一样的结构。
            Glyph4StemmableNote glyph = this.GetGlyph() as Glyph4StemmableNote;
            if (glyph != null)
            {
                return glyph.beam_count;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Get the minimum length of stem
        /// </summary>
        public double GetStemMinumumLength()
        {
            double length = this.duration == "w" || this.duration == "1" ? 0 : 20;
            // if note is flagged, cannot shorten beam
            //里程碑2时把这个做成两组字典查询，字典数据放到Flow类里
            switch (this.duration)
            {
                case "8":
                    if (this.beam == null)
                    { length = 35; }
                    break;
                case "16":
                    if (this.beam == null)
                    { length = 35; }
                    else
                    { length = 25; }
                    break;
                case "32":
                    if (this.beam == null)
                    { length = 45; }
                    else
                    { length = 35; }
                    break;
                case "64":
                    if (this.beam == null)
                    { length = 50; }
                    else
                    { length = 40; }
                    break;
                case "128":
                    if (this.beam == null)
                    { length = 55; }
                    else
                    { length = 45; }
                    break;
            }
            return length;
        }
        /// <summary>
        /// 还原Get、Set方法，属性未删
        /// </summary>
        /// <returns></returns>
        public int? GetStemDirection()
        { return stem_direction; }
        public StemmableNote SetStemDirection(int? direction)
        {
            if (!direction.HasValue)
            //这里的用法比较像set函数参数存在默认值
            {
                direction = Stem.UP;
            }
            if (direction != Stem.UP && direction != Stem.DOWN)
            {
                throw new Exception("BadArgument,Invalid stem direction: " + direction);
            }
            this.stem_direction = direction;
            if (this.stem != null)
            {
                this.stem.SetDirection(direction.Value);
                this.stem.SetExtension(this.GetStemExtension());
            }
            this.beam = null;
            if (this.preFormatted)
            {
                this.PreFormat();
            }
            return this;
        }
        /// <summary>
        /// Get/set the direction of the stem
        /// </summary>
        /// <summary>
        /// Get the `x` coordinate of the stem
        /// </summary>
        public virtual double GetStemX()
        {
            double x_begin = this.GetAbsoluteX() + this.x_shift;
            double x_end = this.GetAbsoluteX() + this.x_shift + (this.glyph as Glyph4StemmableNote).head_width;
            double stem_x = this.stem_direction == Stem.DOWN ? x_begin : x_end;
            stem_x -= (Stem.WIDTH / 2) * this.stem_direction.Value;
            return stem_x;
        }
        /// <summary>
        /// Get the `x` coordinate for the center of the glyph. Used for `TabNote` stems and stemlets over rests
        /// </summary>
        public double GetCenterGlyphX()
        {
            return this.GetAbsoluteX() + this.x_shift + (this.glyph as Glyph4StemmableNote).head_width / 2;
        }
        /// <summary>
        /// Get the stem extension for the current duration
        /// </summary>
        public virtual double GetStemExtension()
        {
            Glyph4StemmableNote glyph = this.GetGlyph() as Glyph4StemmableNote;
            if (this.stem_extension_override.HasValue)
            {
                return this.stem_extension_override.Value;
            }
            if (glyph != null)
            {
                return this.stem_direction == 1 ? glyph.stem_up_extension : glyph.stem_down_extension;
            }
            return 0;
        }
        // Set the stem length to a specific. Will override the default length.
        //在前面已经翻译过
        /// <summary>
        /// Get the top and bottom `y` values of the stem.
        /// </summary>
        public virtual StemExtents GetStemExtents()
        {
            if (this.ys == null || this.ys.Count() == 0)
            {
                throw new Exception("NoYValues,Can't get top stem Y when note has no Y values.");
            }
            double top_pixel = this.ys[0];
            double base_pixel = this.ys[0];
            double stem_height = Stem.HEIGHT + this.GetStemExtension();
            for (int i = 0;
            i < this.ys.Count();
            i++)
            {
                double stem_top = this.ys[i] + (stem_height * -this.stem_direction.Value);
                //上面这句可看出stemDirection只能是1或-1，对应UP和DOWN
                //里程碑2时考虑将stemDirection改成bool的isStemUp
                if (this.stem_direction == Stem.DOWN)
                {
                    top_pixel = (top_pixel > stem_top) ? top_pixel : stem_top;
                    base_pixel = (base_pixel < this.ys[i]) ? base_pixel : this.ys[i];
                }
                else
                {
                    top_pixel = (top_pixel < stem_top) ? top_pixel : stem_top;
                    base_pixel = (base_pixel > this.ys[i]) ? base_pixel : this.ys[i];
                }

                if (this.note_type == "s" || this.note_type == "x")
                //里程碑2时这部分的7做成常量放在Flow类里，noteType改成枚举类型或数值类型
                {
                    top_pixel -= this.stem_direction.Value * 7;
                    base_pixel -= this.stem_direction.Value * 7;
                }
            }
            return new StemExtents() { top_y = top_pixel, base_y = base_pixel };
        }
        /// <summary>
        /// Sets the current note's beam
        /// </summary>
        public StemmableNote SetBeam(Beam beam)
        {
            this.beam = beam;
            return this;
        }
        /// <summary>
        /// Get the `y` value for the top/bottom modifiers at a specific `text_line`
        /// </summary>
        public override double GetYForTopText(double text_line)
        {
            StemExtents extents = this.GetStemExtents();
            if (this.HasStem())
            {
                return Math.Min(
                    this.stave.GetYForTopText(text_line),
                    extents.top_y - (this.render_options.annotation_spacing * (text_line + 1))
                );
                //暂时猜测textLine是数字,但是看变量名不太像
            }
            else
            {
                return this.stave.GetYForTopText(text_line);
            }
        }
        public double GetYForBottomText(int text_line)
        {
            StemExtents extents = this.GetStemExtents();
            if (this.HasStem())
            {
                return Math.Max(
                    this.stave.GetYForTopText(text_line),
                    extents.base_y + (this.render_options.annotation_spacing * (text_line))
                );
                //暂时猜测textLine是数字,但是看变量名不太像
                //js专门给textLine加括号，很可能是将string解析成数值
                //里程碑2时需要看看GetYForBottomText的调用情况
                //此外，从乘法和Min函数的使用都可以肯定GetYForBottomText返回值是数，就看是double还是int了
            }
            else
            {
                return this.stave.GetYForBottomText(text_line);
            }
        }
        /// <summary>
        /// Post format the note
        /// </summary>
        public new StemmableNote PostFormat()
        {
            if (this.beam != null)
            {
                this.beam.PostFormat();
            }
            this.postFormatted = true;
            return this;
        }
        /// <summary>
        /// Render the stem onto the canvas
        /// </summary>
        public virtual void DrawStem(StemOpts stem_struct)
        {
            if (this.context == null)
            {
                throw new Exception("NoCanvasContext,Can't draw without a canvas context.");
            }
            this.SetStem(new Stem(stem_struct));
            this.stem.SetContext(this.context);
            this.stem.Draw();
        }
        #endregion

        #region 隐含字段
        public Stem stem;
        public double? stem_extension_override;
        public int? stem_direction;
        public Beam beam;
        public override string GetCategory()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
