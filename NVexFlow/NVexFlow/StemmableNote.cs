////对应 stemmablenote.js
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
        /// <returns></returns>
        public StemmableNote BuildStem()
        {
            Stem stem = new Stem(null);
            this.Stem = stem;
            return this;
        }
        /// <summary>
        /// Get the full length of stem.Set the stem length to a specific. Will override the default length.
        /// </summary>
        public double StemLength
        {
            get
            {
                return Stem.HEIGHT + this.StemExtension;
            }

            set
            {
                //set在js中的位置在getStemExtension下面
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
        {
            get
            { return stemDirection.Value; }
            set
            {
                if(!value.HasValue)
                {
                    value = Stem.UP;
                }
                if(value != Stem.UP && value != Stem.Down)
                {
                    throw new Exception("BadArgument,Invalid stem direction: " + value);
                }
                this.stemDirection = value;
                if(this.stem != null)
                {
                    this.stem.Direction = value;
                    this.stem.Extension = this.StemExtension;//还未将Stem中的Direction、Extension修改成double。写到那部分再说。
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
        public object StemX
        {
            get
            {
                double xBegin = this.AbsoluteX + this.xShift;
                double xEnd = this.AbsoluteX + this.xShift + (this.glyph as Glyph4StemmableNote).headWidth;
                double stemX = this.stemDirection == Stem.Down ? xBegin : xEnd;
                stemX -= (Stem.WIDTH / 2) * this.stemDirection.Value;
                return stemX;
            }
        }
        /// <summary>
        /// Get the `x` coordinate for the center of the glyph. Used for `TabNote` stems and stemlets over rests
        /// </summary>
        public object CenterGlyphX
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
                    //===用不用object.ReferenceEquals(this.StemDirection, 1) 这样翻译？感觉没必要
                    return this.stemDirection == 1 ? glyph.stemUpExtension : glyph.stemDownExtension;
                }
                return 0;
            }
        }
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
                    if(this.stemDirection == Stem.Down)
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
        /// <param name="textLine"></param>
        /// <returns></returns>
        public virtual double GetYForTopText(double textLine)
        {
            StemExtents extents = this.StemExtents;
            if(this.HasStem())
            {
                return Math.Min(this.stave.GetYForTopText(textLine),extents.topY - (this.renderOptions.annotationSpacing * (textLine + 1)));
                //暂时猜测textLine是数字,但是看变量名不太像
            }
            else
            {
                return this.stave.GetYForTopText(textLine);
            }
        }
        public object YForBottomText(double textLine)
        {
            StemExtents extents = this.StemExtents;
            if(this.HasStem())
            {
                return Math.Max(this.stave.GetYForTopText(textLine),extents.baseY + (this.renderOptions.annotationSpacing * (textLine)));
                //暂时猜测textLine是数字,但是看变量名不太像
            }
            else
            {
                return this.stave.GetYForTopText(textLine);
            }
        }
        /// <summary>
        /// Post format the note
        /// </summary>
        /// <returns></returns>
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
        /// <param name="stemStruct"></param>
        public virtual void DrawStem(StemOpts stemStruct)
        {
            //        if (!this.context) throw new Vex.RERR("NoCanvasContext",
            //"Can't draw without a canvas context.");
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
