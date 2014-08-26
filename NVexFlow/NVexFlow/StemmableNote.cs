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
    public class StemmableNote:Note
    {
        #region js直译部分
        public StemmableNote(NoteStruct noteStruct)
            : base(noteStruct)
        {
            Init(noteStruct);
        }
        private void Init(NoteStruct noteStruct)
        {
            this.stem = null;
            this.stemExtensionOverride = null;
            this.beam = null;
        }
        /// <summary>
        /// Get and set the note's `Stem`
        /// </summary>
        public Stem Stem
        {
            get
            { return this.stem; }
            set
            { this.stem = value; }
        }
        /// <summary>
        /// Builds and sets a new stem
        /// </summary>
        public StemmableNote BuildStem()
        {
            Stem stem = new Stem();
            this.Stem = stem;
            return this;
        }
        /// <summary>
        /// Get the full length of stem.
        /// Set the stem length to a specific. Will override the default length.
        /// </summary>
        public double StemLength
        {
            get
            {
                return Stem.HEIGHT + this.StemExtension;
            }
            set
            {
                //js中setStemLength在getStemExtension后面
                this.stemExtensionOverride = value - Stem.HEIGHT;
            }
        }
        /// <summary>
        /// Get the number of beams for this duration
        /// </summary>
        public object BeamCount
        {
            get
            {
                //暂时不知道glyph是什么类型，继承了Note，所以猜测是像Note里的glyph一样的结构。
                Glyph4StemmableNote glyph = this.Glyph as Glyph4StemmableNote;
                if(glyph != null)
                {
                    return glyph.beamCount;
                }
                else
                {
                    return 0;
                }
            }
        }
        /// <summary>
        /// Get the minimum length of stem
        /// </summary>
        public double StemMinumumLength
        {
            get
            {
                double length = this.duration == "w" || this.duration == "1" ? 0 : 20;
                // if note is flagged, cannot shorten beam
                //里程碑2时把这个做成两组字典查询，字典数据放到Flow类里
                switch(this.duration)
                {
                case "8":
                    if(this.beam == null)
                    { length = 35; }
                    break;
                case "16":
                    if(this.beam == null)
                    { length = 35; }
                    else
                    { length = 25; }
                    break;
                case "32":
                    if(this.beam == null)
                    { length = 45; }
                    else
                    { length = 35; }
                    break;
                case "64":
                    if(this.beam == null)
                    { length = 50; }
                    else
                    { length = 40; }
                    break;
                case "128":
                    if(this.beam == null)
                    { length = 55; }
                    else
                    { length = 45; }
                    break;
                }
                return length;
            }
        }
        /// <summary>
        /// Get/set the direction of the stem
        /// </summary>
        public int? StemDirection
        //应该用int类型，里程碑2应该改成枚举类型
        {
            get
            { return stemDirection.Value; }
            set
            {
                if(!value.HasValue)
                //这里的用法比较像set函数参数存在默认值
                {
                    value = Stem.UP;
                }
                if(value != Stem.UP && value != Stem.DOWN)
                {
                    throw new Exception("BadArgument,Invalid stem direction: " + value);
                }
                this.stemDirection = value;
                if(this.stem != null)
                {
                    this.stem.Direction = value.Value;
                    this.stem.Extension = this.StemExtension;
                }
                this.beam = null;
                if(this.preFormatted)
                {
                    this.PreFormat();
                }
            }
        }
        /// <summary>
        /// Get the `x` coordinate of the stem
        /// </summary>
        public double StemX
        {
            get
            {
                double xBegin = this.AbsoluteX + this.xShift;
                double xEnd = this.AbsoluteX + this.xShift + (this.glyph as Glyph4StemmableNote).headWidth;
                double stemX = this.stemDirection == Stem.DOWN ? xBegin : xEnd;
                stemX -= (Stem.WIDTH / 2) * this.stemDirection.Value;
                return stemX;
            }
        }
        /// <summary>
        /// Get the `x` coordinate for the center of the glyph. Used for `TabNote` stems and stemlets over rests
        /// </summary>
        public double CenterGlyphX
        {
            get
            {
                return this.AbsoluteX + this.xShift + (this.glyph as Glyph4StemmableNote).headWidth / 2;
            }
        }
        /// <summary>
        /// Get the stem extension for the current duration
        /// </summary>
        public double StemExtension
        {
            get
            {
                Glyph4StemmableNote glyph = this.Glyph as Glyph4StemmableNote;
                if(this.stemExtensionOverride.HasValue)
                {
                    return this.stemExtensionOverride.Value;
                }
                if(glyph != null)
                {
                    return this.stemDirection == 1 ? glyph.stemUpExtension : glyph.stemDownExtension;
                }
                return 0;
            }
        }
        // Set the stem length to a specific. Will override the default length.
        //在前面已经翻译过
        /// <summary>
        /// Get the top and bottom `y` values of the stem.
        /// </summary>
        public StemExtents StemExtents
        {
            get
            {
                if(this.ys == null || this.ys.Count() == 0)
                {
                    throw new Exception("NoYValues,Can't get top stem Y when note has no Y values.");
                }
                double topPixel = this.ys[0];
                double basePixel = this.ys[0];
                double stemHeight = Stem.HEIGHT + this.StemExtension;
                for(int i = 0;
                i < this.ys.Count();
                i++)
                {
                    double stemTop = this.ys[i] + (stemHeight * -this.stemDirection.Value);
                    //上面这句可看出stemDirection只能是1或-1，对应UP和DOWN
                    //里程碑2时考虑将stemDirection改成bool的isStemUp
                    if(this.stemDirection == Stem.DOWN)
                    {
                        topPixel = (topPixel > stemTop) ? topPixel : stemTop;
                        basePixel = (basePixel < this.ys[i]) ? basePixel : this.ys[i];
                    }
                    else
                    {
                        topPixel = (topPixel < stemTop) ? topPixel : stemTop;
                        basePixel = (basePixel > this.ys[i]) ? basePixel : this.ys[i];
                    }

                    if(this.noteType == "s" || this.noteType == "x")
                    //里程碑2时这部分的7做成常量放在Flow类里，noteType改成枚举类型或数值类型
                    {
                        topPixel -= this.stemDirection.Value * 7;
                        basePixel -= this.stemDirection.Value * 7;
                    }
                }
                return new StemExtents() { topY = topPixel,baseY = basePixel };
            }
        }
        /// <summary>
        /// Sets the current note's beam
        /// </summary>
        public Beam Beam
        {
            set
            { this.beam = value; }
        }
        /// <summary>
        /// Get the `y` value for the top/bottom modifiers at a specific `text_line`
        /// </summary>
        public virtual double GetYForTopText(double textLine)
        {
            StemExtents extents = this.StemExtents;
            if(this.HasStem())
            {
                return Math.Min(
                    this.stave.GetYForTopText(textLine),
                    extents.topY - (this.renderOptions.annotationSpacing * (textLine + 1))
                );
                //暂时猜测textLine是数字,但是看变量名不太像
            }
            else
            {
                return this.stave.GetYForTopText(textLine);
            }
        }
        public double GetYForBottomText(int textLine)
        {
            StemExtents extents = this.StemExtents;
            if(this.HasStem())
            {
                return Math.Max(
                    this.stave.GetYForTopText(textLine),
                    extents.baseY + (this.renderOptions.annotationSpacing * (textLine))
                );
                //暂时猜测textLine是数字,但是看变量名不太像
                //js专门给textLine加括号，很可能是将string解析成数值
                //里程碑2时需要看看GetYForBottomText的调用情况
                //此外，从乘法和Min函数的使用都可以肯定GetYForBottomText返回值是数，就看是double还是int了
            }
            else
            {
                return this.stave.GetYForBottomText(textLine);
            }
        }
        /// <summary>
        /// Post format the note
        /// </summary>
        public new StemmableNote PostFormat()
        {
            if(this.beam != null)
            {
                this.beam.PostFormat();
            }
            this.postFormatted = true;
            return this;
        }
        /// <summary>
        /// Render the stem onto the canvas
        /// </summary>
        public virtual void DrawStem(StemOpts stemStruct)
        {
            if(this.context == null)
            {
                throw new Exception("NoCanvasContext,Can't draw without a canvas context.");
            }
            this.Stem = new Stem(stemStruct);
            this.stem.Context = this.context;
            this.stem.Draw();
        }
        #endregion

        #region 隐含字段
        protected Stem stem;
        protected double? stemExtensionOverride;
        protected int? stemDirection;
        protected Beam beam;
        public override string Category
        {
            get
            { throw new System.NotImplementedException(); }
        }
        #endregion
    }
}
